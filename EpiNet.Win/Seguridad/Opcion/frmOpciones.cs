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
using EpiNet.Win.App_Code.BE;
using EpiNet.Win.App_Code.BL;
using EpiNet.Win.App_Code;

namespace EpiNet.Win.Seguridad.Opcion
{
    public partial class frmOpciones : BaseModule
    {
        public int IdOpcion = 0;
        public frmOpciones()
        {
            InitializeComponent();
            List<BEOpcion> olOpcion = new List<BEOpcion>();
            olOpcion = BLOpcion.Listar(0, "");

            gridControl1.DataSource = olOpcion;
        }
        public override string ModuleName { get { return "Seguridad >> Opcion"; } }

        protected internal override void ButtonClick(string tag)
        {

            switch (tag)
            {

                case "Nuevo":
                    CreaNuevoOpcion();

                    break;

                case "Editar":

                    if (gridView1.RowCount > 0)
                    {
                        this.IdOpcion = CurrentIdOpcion;
                        EditaOpcion(CurrentIdOpcion);

                    }

                    break;
                default:
                    break;
            }
        }

        int CurrentIdOpcion
        {
            get { return Convert.ToInt32(gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, gridView1.Columns["EPI_INT_IDOPCION"])); }
        }

        void CreaNuevoOpcion()
        {
            this.IdOpcion = 0;

        }


        void EditaOpcion(int IdOpcion)
        {

            BEOpcion oOpcion = BLOpcion.Listar(IdOpcion, "").SingleOrDefault();
            this.txtNombreOpcion.Text = oOpcion.EPI_VCH_NOMBREOPCION.ToString();
            this.txtImagen16x16.Text = oOpcion.EPI_VCH_IMAGEN16X16;
            this.txtImagen32x32.Text = oOpcion.EPI_VCH_IMAGEN32X32;
            this.txtImagenIndex16x16.Text = oOpcion.EPI_INT_IMAGENINDEX16X16.ToString();
            this.txtImagenIndex32x32.Text = oOpcion.EPI_INT_IMAGENINDEX32X32.ToString();

            

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

               TBL_EPI_OPCION  oOpcion = new TBL_EPI_OPCION();

                if (txtNombreOpcion.Text == string.Empty)
                {
                    MessageBox.Show("Debe Ingresar Nombre Perfil ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                oOpcion.EPI_VCH_NOMBREOPCION = txtNombreOpcion.Text;
                oOpcion.EPI_VCH_IMAGEN16X16 = txtImagen16x16.Text;
                oOpcion.EPI_VCH_IMAGEN32X32 = txtImagen32x32.Text;
                oOpcion.EPI_INT_IMAGENINDEX16X16 = Convert.ToInt32(txtImagenIndex16x16.Text);
                oOpcion.EPI_INT_IMAGENINDEX32X32 = Convert.ToInt32(txtImagenIndex32x32.Text);

                eResultado Res;

                switch (this.IdOpcion)
                {
                    case 0:


                        oOpcion.EPI_BIT_ACTIVO = true;
                        oOpcion.EPI_INT_USUARIOCREA = BaseForm.VariablesGlobales.IdUsuario;
                        
                        Res = BLOpcion.Insertar(oOpcion);

                        this.IdOpcion = oOpcion.EPI_INT_IDOPCION;


                        if (Res == eResultado.Correcto)
                        {

                            MessageBox.Show("Perfil se insertó correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //pnOpciones.Visible = true;

                        }
                                               
                        break;



                    default:


                        oOpcion.EPI_INT_IDOPCION = this.IdOpcion;
                        oOpcion.EPI_INT_USUARIOMODIFICA = BaseForm.VariablesGlobales.IdUsuario;

                        Res = BLOpcion.Actualizar(oOpcion);


                        if (Res == eResultado.Correcto)
                        {

                            MessageBox.Show("Perfil Actualizado Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        }

                        break;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }




        }
    }
}