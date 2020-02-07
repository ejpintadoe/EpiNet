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

namespace EpiNet.Win.RecursosHumanos.Empleado
{
    public partial class frmEmpleadoEditar : DevExpress.XtraEditors.XtraForm
    {
        public int idEmpleado = 0;
        public frmEmpleadoEditar()
        {
            InitializeComponent();
        }
        public frmEmpleadoEditar(int idEmpleado)
        {
            InitializeComponent();
            lookUpTipoDocumento.Properties.DataSource = BLTipoDocumentoEntidad.ListarTipoDocumentoEntidad(0, "");

            this.idEmpleado = idEmpleado;

            if (idEmpleado > 0)
            {
                TBL_EPI_EMPLEADO oEmpleado = BLEmpleado.obtieneEmpleados(idEmpleado);

                lookUpTipoDocumento.EditValue = oEmpleado.EPI_INT_IDTIPODOCUMENTOIDENTIDAD;
                txtNumeroDocumento.Text= oEmpleado.EPI_VCH_NUMERODOCUMENTOIDENTIDAD;
                imgCboGenero.EditValue = oEmpleado.EPI_INT_IDSEXO;
                txtNombres.Text = oEmpleado.EPI_VCH_NOMBRE;
                txtApellidoPaterno.Text = oEmpleado.EPI_VCH_APELLIDOPATERNO;
                txtApellidoMaterno.Text = oEmpleado.EPI_VCH_APELLIDOMATERNO;
                txtTelefono.Text = oEmpleado.EPI_VCH_TELEFONODOMICILIO ;
                txtTelefonoMovil.Text = oEmpleado.EPI_VCH_TELEFONOMOVIL;
                txtCorreoPersonal.Text = oEmpleado.EPI_VCH_CORREOPERSONAL;
                txtDireccion.Text = oEmpleado.EPI_VCH_DIRECCIONDOMICILIO;

            }
            
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                TBL_EPI_EMPLEADO oEmpleado = new TBL_EPI_EMPLEADO();

                if (lookUpTipoDocumento.EditValue == null)
                {
                    XtraMessageBox.Show("Debe Seleccionar Tipo Documento", "ERROR"); return;
                }


                if (string.IsNullOrEmpty(txtNumeroDocumento.Text))
                {
                    XtraMessageBox.Show("Debe Ingresar Numero Documento", "ERROR"); return;
                }
                    

                if (imgCboGenero.SelectedIndex == -1 || imgCboGenero.SelectedItem == null)
                {
                    XtraMessageBox.Show("Debe Seleccionar Genero", "ERROR"); return;
                }
                

                oEmpleado.EPI_INT_IDTIPODOCUMENTOIDENTIDAD = Convert.ToInt32(lookUpTipoDocumento.EditValue);
                oEmpleado.EPI_VCH_NUMERODOCUMENTOIDENTIDAD = txtNumeroDocumento.Text;
                oEmpleado.EPI_INT_IDSEXO = Convert.ToInt32(imgCboGenero.EditValue);
                oEmpleado.EPI_VCH_NOMBRE = txtNombres.Text;
                oEmpleado.EPI_VCH_APELLIDOPATERNO = txtApellidoPaterno.Text;
                oEmpleado.EPI_VCH_APELLIDOMATERNO = txtApellidoMaterno.Text;
                oEmpleado.EPI_VCH_TELEFONODOMICILIO = txtTelefono.Text;
                oEmpleado.EPI_VCH_TELEFONOMOVIL = txtTelefonoMovil.Text;
                oEmpleado.EPI_VCH_CORREOPERSONAL = txtCorreoPersonal.Text;
                oEmpleado.EPI_VCH_DIRECCIONDOMICILIO = txtDireccion.Text;

                eResultado Res;

                if (idEmpleado == 0)
                {
                    oEmpleado.EPI_BIT_ACTIVO = true;
                    //oEmpleado.EPI_DAT_FECHACREACION = DateTime.Now;
                    Res = BLEmpleado.Insertar(oEmpleado);

                    this.idEmpleado = oEmpleado.EPI_INT_IDEMPLEADO;

                    if (Res == eResultado.Correcto)
                    {
                        XtraMessageBox.Show("Empleado se ingresó correctamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // MessageBox.Show("Empleado se insertó correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    oEmpleado.EPI_INT_IDEMPLEADO = this.idEmpleado;
                    //oEmpleado.EPI_DAT_FECHAMODIFICA = DateTime.Now;
                    Res = BLEmpleado.Actualizar(oEmpleado);

                    if (Res == eResultado.Correcto)
                    {
                        XtraMessageBox.Show("Módulo se Actualizó correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString() + " Comunicar a Sistemas", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}