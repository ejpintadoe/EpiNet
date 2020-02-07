using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using EpiNet.Win.App_Code;
using EpiNet.Win.App_Code.BL;
using EpiNet.Win.App_Code.BE;
using DevExpress.XtraGrid.Views;
using DevExpress.XtraGrid.Views.Grid;

using DevExpress.XtraGrid.Views.Base;
using System.Collections;

namespace EpiNet.Win.Seguridad.Modulo
{
    public partial class frmModuloEditar : DevExpress.XtraEditors.XtraForm
    {
        public int idModulo = 0;
        public frmModuloEditar()
        {
            InitializeComponent();
        }
        public frmModuloEditar(int idModulo)
        {
            InitializeComponent();
            this.idModulo = idModulo;
            
            List<BELlenaSLUE> omod = BLModulo.ListarModulo(0, "").Select(x => new BELlenaSLUE {  ValueMember = Convert.ToInt32(x.EPI_INT_IDMODULO),  DisplayMember = x.EPI_VCH_NOMBREMODULO }).ToList();
            BaseForm.CargaSLU(searchLookUpEdit2, omod, "ValueMember", "DisplayMember");
                       

            if (idModulo > 0)
            { 
                TBL_EPI_MODULO oModulo = BLModulo.obtieneModulos(idModulo);

                chkWindowsForm.Checked = Convert.ToBoolean(oModulo.EPI_BIT_WINDOWS ?? false);
                chkPaginaWeb.Checked = Convert.ToBoolean(oModulo.EPI_BIT_WEB ?? false);
                chkAppMovil.Checked = Convert.ToBoolean(oModulo.EPI_BIT_MOVIL ?? false);
                txtModulo.Text = oModulo.EPI_VCH_NOMBREMODULO ?? "";

                //txtWindowsForm.ReadOnly = chkWindowsForm.Checked;
                txtWindowsForm.Text = oModulo.EPI_VCH_WINDOWSFORM ?? "";

                //txtPaginaWeb.ReadOnly = chkPaginaWeb.Checked;
                txtPaginaWeb.Text = oModulo.EPI_VCH_PAGINA ?? "";

                //txtAppMovil.ReadOnly = chkAppMovil.Checked;
                txtAppMovil.Text = oModulo.EPI_VCH_APPMOVIL ?? "";


                txtImagen16x16.Text = oModulo.EPI_VCH_IMAGEN16x16 ?? "";
                txtImagen32x32.Text = oModulo.EPI_VCH_IMAGEN32x32 ?? "";

                txtImagenIndex16x16.EditValue = Convert.ToInt32(oModulo.EPI_INT_IMAGENINDEX16X16 ?? 0);
                txtImagenIndex32x32.EditValue = Convert.ToInt32(oModulo.EPI_INT_IMAGENINDEX32X32 ?? 0);

                searchLookUpEdit2.EditValue = oModulo.EPI_INT_MODULOPADRE;

            }

            ListarOpciones();


        }

        void ListarOpciones()
        {
            List<BEOpcion> olOpcionesModulo = BLModulo.ListarOpcionesModulo(idModulo);
            List<BEOpcion> olOpciones = BLOpcion.Listar(0, "");

            gridControl2.DataSource = olOpcionesModulo;
            gridControl1.DataSource = olOpciones.Where(x => !olOpcionesModulo.Any(y => y.EPI_INT_IDOPCION == x.EPI_INT_IDOPCION)).ToList();

        }

        private void btnDerecha_Click(object sender, EventArgs e)
        {
            ColumnView view = gridControl1.MainView as ColumnView;
                       
            foreach (var item in gridView1.GetSelectedRows())
            {
                BEOpcion oOp = new BEOpcion();
                oOp = view.GetRow(item) as BEOpcion;
                eResultado res = BLModulo.AgregarOpcionModulo(idModulo, oOp.EPI_INT_IDOPCION);
            }

            ListarOpciones();
        }
        private void btnIzquierda_Click(object sender, EventArgs e)
        {
            ColumnView view = gridControl2.MainView as ColumnView;

            foreach (var item in gridView2.GetSelectedRows())
            {
                BEOpcion oOp = new BEOpcion();
                oOp = view.GetRow(item) as BEOpcion;

                eResultado res = BLModulo.EliminarOpcionModulo(idModulo, oOp.EPI_INT_IDOPCION);

            }

            ListarOpciones();

        }

        private void btnGuargar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                TBL_EPI_MODULO oModulo = new TBL_EPI_MODULO();

                oModulo.EPI_VCH_NOMBREMODULO = txtModulo.Text;
                oModulo.EPI_VCH_WINDOWSFORM = txtWindowsForm.Text;
                oModulo.EPI_BIT_WINDOWS = chkWindowsForm.Checked;
                oModulo.EPI_VCH_PAGINA = txtPaginaWeb.Text;
                oModulo.EPI_BIT_WEB = chkPaginaWeb.Checked;
                oModulo.EPI_VCH_APPMOVIL = txtAppMovil.Text;
                oModulo.EPI_BIT_MOVIL = chkAppMovil.Checked;
                oModulo.EPI_VCH_IMAGEN16x16 = txtImagen16x16.Text;
                oModulo.EPI_VCH_IMAGEN32x32 = txtImagen32x32.Text;
                oModulo.EPI_INT_IMAGENINDEX16X16 = Convert.ToInt32(txtImagenIndex16x16.EditValue);
                oModulo.EPI_INT_IMAGENINDEX32X32 = Convert.ToInt32(txtImagenIndex32x32.EditValue);


                if (searchLookUpEdit2.EditValue == null) oModulo.EPI_INT_MODULOPADRE = 0;
                else oModulo.EPI_INT_MODULOPADRE = int.Parse(searchLookUpEdit2.EditValue.ToString());

                eResultado Res;

                if (idModulo == 0)
                {
                    oModulo.EPI_BIT_ACTIVO = true;
                    oModulo.EPI_DAT_FECHACREACION = DateTime.Now;


                    Res = BLModulo.Insertar(oModulo);

                    this.idModulo = oModulo.EPI_INT_IDMODULO;


                    if (Res == eResultado.Correcto)
                    {
                        XtraMessageBox.Show("Módulo se insertó correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    oModulo.EPI_INT_IDMODULO = this.idModulo;
                    //oModulo.EPI_INT_MODULOPADRE = Convert.ToInt32(this.lbIDPadre.Text);
                    oModulo.EPI_DAT_FECHAMODIFICA = DateTime.Now;

                    Res = BLModulo.Actualizar(oModulo);

                    if (Res == eResultado.Correcto)
                    {

                        XtraMessageBox.Show("Módulo se Actualizó correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnSubir_Click(object sender, EventArgs e)
        {

        }

        private void btnBajar_Click(object sender, EventArgs e)
        {

        }

        //BEOpcion CurrentContact
        //{
        //    get { return ((ColumnView)gridControl1.MainView).GetFocusedRow() as BEOpcion; }
        //}


    }
}