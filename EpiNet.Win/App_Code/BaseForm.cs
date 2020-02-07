using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using EpiNet.Win.App_Code.BE;
using EpiNet.Win.App_Code.BL;
using System.Collections;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace EpiNet.Win.App_Code
{
    public class BaseForm
    {
        public class VariablesGlobales
        {
            public static BEUsuario MiUsuario;
            public static int idModulo;
            public static decimal tcVenta;
            public static decimal tcCompra;
            public static List<BEImpuesto> Impuesto;

            public static int IdUsuario {
                get {
                    return MiUsuario.Usuario.EPI_INT_IDUSUARIO;
                }
            }

            public static BEImpuesto GetObjectImpuesto(int id)
            {
                return Impuesto.Where(x => x.IdImpuesto == id).FirstOrDefault();
            }

            public static decimal GetImpuesto(int id)
            {
                BEImpuesto oImpuesto = Impuesto.Where(x => x.IdImpuesto == id).FirstOrDefault();
                decimal porcentaje = oImpuesto == null ? 0.0M : (oImpuesto.Porcentaje ?? 0) / 100M;

                return porcentaje;
            }
            //public static int idEmpresa;
            //public static DateTime FechaTrabajo;
            //public static decimal impCuarta;
            //public static string basededaots;
            //public static SqlConnection conn;
        }

        public static string EncriptarPassword(string txtPassword)
        {
            //arreglo de bytes donde guardaremos la llave
            string key = "WonderCrisKeySeguridad";
            byte[] keyArray;
            //arreglo de bytes donde guardaremos el texto
            //que vamos a encriptar
            byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(txtPassword);

            //se utilizan las clases de encriptación
            //provistas por el Framework
            //Algoritmo MD5
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            //se guarda la llave para que se le realice
            //hashing
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

            hashmd5.Clear();

            //Algoritmo 3DAS
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            //se empieza con la transformación de la cadena
            ICryptoTransform cTransform = tdes.CreateEncryptor();

            //arreglo de bytes donde se guarda la
            //cadena cifrada
            byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);

            tdes.Clear();

            //se regresa el resultado en forma de una cadena
            return Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);
        }

        public static string DesencriptarPassword(string txtPasswordEncriptado)
        {
            string key = "WonderCrisKeySeguridad";
            byte[] keyArray;
            //convierte el texto en una secuencia de bytes
            byte[] Array_a_Descifrar = Convert.FromBase64String(txtPasswordEncriptado);

            //se llama a las clases que tienen los algoritmos
            //de encriptación se le aplica hashing
            //algoritmo MD5
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;



            ICryptoTransform cTransform = tdes.CreateDecryptor();

            byte[] resultArray = cTransform.TransformFinalBlock(Array_a_Descifrar, 0, Array_a_Descifrar.Length);

            tdes.Clear();
            //se regresa en forma de cadena

            return UTF8Encoding.UTF8.GetString(resultArray);

        }

        public static void CargaSLU(SearchLookUpEdit slu, List<BELlenaSLUE> obj, string ValueMember, string DisplayMember)
        {

            //BELlenaSLUE itemTodos = new BELlenaSLUE { ValueMember = 0, DisplayMember= "[TODOS]" };

           

            List<BELlenaSLUE> itemTodos =  new List<BELlenaSLUE>();
            itemTodos.Add(new BELlenaSLUE { ValueMember = 0, DisplayMember = "[TODOS]" });
            itemTodos.AddRange(obj);

            var bindingList = new BindingList<BELlenaSLUE>(itemTodos);

            //BindingList<BELlenaSLUE> olObj = new BindingList<BELlenaSLUE>();
            //olObj.Add(itemTodos);
            //olObj.(obj.or);

            slu.Properties.ValueMember = ValueMember;
            slu.Properties.DisplayMember = DisplayMember;
            slu.Properties.DataSource = null;
            slu.Properties.DataSource = bindingList;
                        
            slu.Properties.PopulateViewColumns();

            //DevExpress.XtraGrid.Columns.GridColumn newGridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            //newGridColumn.Caption = "Name";
            //newGridColumn.FieldName = DisplayMember;

            //slu.Properties.View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            //newGridColumn});

            for (int i = 0; i < slu.Properties.View.Columns.Count; i++)
            {
                slu.Properties.View.Columns[i].Visible = false;
            }
            slu.Properties.View.Columns[DisplayMember].Visible = true;
            slu.Properties.View.Columns[DisplayMember].Caption = "Name";
            slu.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            slu.EditValue = 0;
        }
        
        public static void CargarLookUpEdit(LookUpEdit lue, object dataSource, List<BELookUpEdit> lstLUE)
        {

            lue.Properties.ValueMember = lstLUE[0].fieldName;
            lue.Properties.DisplayMember = lstLUE[1].fieldName;

            foreach (var item in lstLUE)
            {
                lue.Properties.Columns.Add(new LookUpColumnInfo(item.fieldName, item.caption));
            }
            lue.Properties.Columns[0].Visible = false;
            lue.Properties.DataSource = dataSource;
            //lue.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            //lue.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;

        }
        public static void CargarSearchLookUpEdit(SearchLookUpEdit slue, object dataSource, List<BESearchLookUpEdit> lstSLUE)
        {

            //var bindingList = new BindingList<object>(dataSource);
            BindingSource bs = new BindingSource();
            bs.DataSource = dataSource;

            slue.Properties.DataSource = null;
                      
            slue.Properties.ValueMember = lstSLUE[0].fieldName;
            slue.Properties.DisplayMember = lstSLUE[1].fieldName;
            slue.Properties.PopulateViewColumns();

            foreach (var item in lstSLUE)
            {
                slue.Properties.View.Columns.Add(new GridColumn { Caption = item.caption, FieldName = item.fieldName, Visible = false });
            }
            slue.Properties.View.Columns[1].Visible = true;

            slue.Properties.DataSource = bs;
            //slue..Columns[0].Visible = false;
            //slue.Properties.DataSource = dataSource;
            //lue.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            //lue.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;

        }

        public static void CargarRepositoryItemSearchLookUpEdit(RepositoryItemSearchLookUpEdit slue, object dataSource, List<BESearchLookUpEdit> lstSLUE)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataSource;

            slue.DataSource = null;
            

            slue.ValueMember = lstSLUE[0].fieldName;
            slue.DisplayMember = lstSLUE[1].fieldName;
            slue.PopulateViewColumns();

            foreach (var item in lstSLUE)
            {
                slue.View.Columns.Add(new GridColumn { Caption = item.caption, FieldName = item.fieldName, Visible = false });
            }
            slue.View.Columns[1].Visible = true;

            slue.DataSource = bs;
            //slue..Columns[0].Visible = false;
            //slue.Properties.DataSource = dataSource;
            //lue.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            //lue.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;

        }

        public static void CargarGridControl(GridControl gridControl, object dataSource)
        {
            BindingSource bs = new BindingSource();
            gridControl.DataSource = null;
            bs.DataSource = dataSource;
            gridControl.DataSource = bs;
        }

        internal static void CalculaColumnaItem(GridView gridView, string columna)
        {
            for (int i = 0; i <= gridView.RowCount - 1; i++)
            {
                gridView.SetRowCellValue(i, gridView.Columns[columna], i + 1);
            }
        }

        public static void IniciaFecDesdeHasta(DateEdit desde, DateEdit hasta, int dias)
        {                      
            desde.Text = DateTime.Now.ToShortDateString().ToString();
            hasta.Text = DateTime.Now.AddDays(dias).ToShortDateString().ToString();
        }

        #region NUMERO EN LETRAS

        #endregion

        public string DevuelveNumeroEnLetras(string num, string _currency)
        {
            string Resultado = "";
            string auxNumber = string.Empty;
            string Number = string.Empty;
            string decimalPart = string.Empty;
            string integerPart = string.Empty;


            auxNumber = num.Replace("$", "").Replace(",", "").Replace("+", "").Trim();
            for (int i = 0; i < auxNumber.Length; i++)
            {
                if (auxNumber.Substring(i, 1).Equals("0"))
                {
                    Number = auxNumber.Substring(i + 1);
                }
                else
                {
                    break;
                }
            }

            //-------Separa la parte entera de la decimal 
            if (string.IsNullOrEmpty(Number)) { Number = auxNumber; }
            string[] arrayNumber = splitString(Number, '.');

            integerPart = arrayNumber[0];

            if (arrayNumber[1].Length > 2)
            {
                decimalPart = arrayNumber[1].Substring(0, 2);
            }
            else if (arrayNumber[1].Length == 2)
            {
                decimalPart = arrayNumber[1];
            }
            else if (arrayNumber[1].Length == 1)
            {
                decimalPart = arrayNumber[1] + "0";
            }



            int Tama_Cadena = integerPart.Length;
            if (Tama_Cadena < 4)//3
                Resultado = Trio(Tama_Cadena, integerPart);
            else if (Tama_Cadena < 7)//6
            {
                int millares = Tama_Cadena - 3;
                if (integerPart.Substring(0, 1) == "1" && Tama_Cadena == 4)
                    Resultado = "mil " + Trio(3, integerPart.Substring(millares, 3));
                else
                    Resultado = Trio(millares, integerPart.Substring(0, millares)) + " mil " + Trio(3, integerPart.Substring(millares, 3));
            }
            else if (Tama_Cadena < 10)//9
            {
                int millares = Tama_Cadena - 3;
                int millon = Tama_Cadena - 6;
                if (integerPart.Substring(0, 1) == "1" && Tama_Cadena == 7)
                {
                    if (Trio(3, integerPart.Substring(millon, 3)) == "")
                        Resultado = "un millon " + Trio(3, integerPart.Substring(millares, 3));
                    else
                        Resultado = "millon " + Trio(3, integerPart.Substring(millon, 3)) + " mil " + Trio(3, integerPart.Substring(millares, 3));
                }
                else
                    Resultado = Trio(millon, integerPart.Substring(0, millon)) + " milllones " + Trio(3, integerPart.Substring(millon, 3)) + " mil " + Trio(3, integerPart.Substring(millares, 3));
            }
            else if (Tama_Cadena < 13)
                Resultado = Trio(3, integerPart.Substring(0, 3)) + " mil " + Trio(3, integerPart.Substring(4, 3)) + " milllones " + Trio(3, integerPart.Substring(7, 3)) + " mil " + Trio(3, integerPart.Substring(10, 3));
            else if (Tama_Cadena < 16)
                Resultado = Trio(3, integerPart.Substring(0, 3)) + " billones " + Trio(3, integerPart.Substring(4, 3)) + " mil " + Trio(3, integerPart.Substring(7, 3)) + " milllones " + Trio(3, integerPart.Substring(10, 3)) + " mil " + Trio(3, integerPart.Substring(13, 3));
            else if (Tama_Cadena < 19)
                Resultado = Trio(3, integerPart.Substring(0, 3)) + " mil " + Trio(3, integerPart.Substring(4, 3)) + " billones " + Trio(3, integerPart.Substring(7, 3)) + " mil " + Trio(3, integerPart.Substring(10, 3)) + " milllones " + Trio(3, integerPart.Substring(13, 3)) + " mil " + Trio(3, integerPart.Substring(13, 3));
            else if (Tama_Cadena < 21)
                Resultado = "";
            else if (Tama_Cadena < 24)
                Resultado = "";

            //-------Une la parte entera con la decimal y asigna la moneda

            if (_currency.Equals("PEN"))
            {
                //Words = Words + " PESOS " + decimalPart + "/100 M.N.";
                Resultado = (Resultado + " CON " + decimalPart + "/100 SOLES").ToUpper();
            }
            else
            {
                Resultado = (Resultado + " CON " + decimalPart + "/100 DOLARES").ToUpper();
            }

            return Resultado;
        }

        string Unidades(string numx)
        {
            return NumeroBase[Convert.ToInt32(numx)];
        }
        
        string Decenas(string numx)
        {
            string Pre = "";
            int Num = Convert.ToInt32(numx);
            if (Num < 30)
            {
                Pre = NumeroBase[Num];
            }
            else
            {
                //if (numx.Substring(0, 1) == "3")
                //    Pre = NumeroBase2[2] + Unidades(numx.Substring(1, 1));
                //else
                //{
                //    if (numx.Substring(1, 1) == "0")
                //        Pre = NumeroBase2[Convert.ToInt32(numx.Substring(0, 1))];
                //    else
                //        Pre = NumeroBase2[Convert.ToInt32(numx.Substring(0, 1))] + " y " + Unidades(numx.Substring(1, 1));
                //}


                if (numx.Substring(1, 1) == "0")
                    Pre = NumeroBase2[Convert.ToInt32(numx.Substring(0, 1))];
                else
                    Pre = NumeroBase2[Convert.ToInt32(numx.Substring(0, 1))] + " y " + Unidades(numx.Substring(1, 1));

            }
            return Pre;
        }
        
        string Centenas(string numx)
        {
            string Pre = "";
            if (numx.Substring(0, 1) == "1")
            {
                if (numx.Substring(1, 1) == "0" && numx.Substring(2, 1) == "0")
                    Pre = "cien ";
                else
                    Pre = "ciento " + Decenas(numx.Substring(1, 2));
            }
            else if (numx.Substring(0, 1) == "0")
            {
                Pre = "" + Decenas(numx.Substring(1, 2));
            }
            else if (numx.Substring(0, 1) == "5")
            {
                Pre = "quinientos " + Decenas(numx.Substring(1, 2));
            }
            else if (numx.Substring(0, 1) == "7")
            {
                Pre = "setecientos " + Decenas(numx.Substring(1, 2));
            }
            else if (numx.Substring(0, 1) == "9")
            {
                Pre = "novecientos " + Decenas(numx.Substring(1, 2));
            }
            else
            {
                Pre = NumeroBase[Convert.ToInt32(numx.Substring(0, 1))] + "cientos " + Decenas(numx.Substring(1, 2));
            }
            return Pre;
        }
        
        string Trio(int cant, string Val)
        {
            string CadenaFinal = "";
            switch (cant)
            {
                case 1:
                    CadenaFinal = Unidades(Val);
                    break;
                case 2:
                    CadenaFinal = Decenas(Val);
                    break;
                case 3:
                    CadenaFinal = Centenas(Val);
                    break;
            }
            return CadenaFinal;
        }

        public string[] splitString(string _textString, char _character)
        {
            string[] split = null;

            if (!string.IsNullOrEmpty(_textString))
            {
                if (_textString.Contains(_character.ToString()))
                {
                    split = _textString.Split(new char[] { _character });

                    if (string.IsNullOrEmpty(split[0])) { split[0] = "0"; }

                }
                else
                {
                    split = new string[2];
                    split[0] = _textString;
                    split[1] = "00";
                }
            }

            return split;
        }
        
        string[] NumeroBase ={
                                 "",
                                 "uno",
                                 "dos",
                                 "tres",
                                 "cuatro",
                                 "cinco",
                                 "seis",
                                 "siete",
                                 "ocho",
                                 "nueve",
                                 "diez",
                                 "once",
                                 "doce",
                                 "trece",
                                 "catorce",
                                 "quince",
                                 "dieciseis",
                                 "diecisiete",
                                 "dieciocho",
                                 "diecinueve",
                                 "veinte",
                                 "veintiuno",
                                 "veintidos",
                                 "veintitres",
                                 "veinticuatro",
                                 "veniticinco",
                                 "veintiseis",
                                 "veintisiete",
                                 "veintiocho",
                                 "veintinueve",

                            };
        string[] NumeroBase2 = {
                                   "",
                                   "",
                                   "",
                                   "treinta",
                                   "cuarenta",
                                   "cincuenta",
                                   "sesenta",
                                   "setenta",
                                   "ochenta",
                                   "noventa"
                               };

    }


    public class ResponseBase<TEntity> : ICloneable where TEntity : class, new()
    {
        public int? Code { get; set; }
        public string Message { get; set; }
        public string MessageEN { get; set; }
        public bool IsResultList { get; set; } = false;
        public IEnumerable<TEntity> listado { get; set; }
        public BindingList<TEntity> bindingList { get; set; }
        public TEntity objeto { get; set; }
        public Exception TechnicalErrors { get; set; }
        public List<string> FunctionalErrors { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return string.Format("Response[Code: {0}, Message: {1},  listado: {2} , objeto {3}, bindingList {4}]", Code, Message, listado, objeto, bindingList);
        }

    }
}
