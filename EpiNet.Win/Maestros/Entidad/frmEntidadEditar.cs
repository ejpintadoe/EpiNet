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

namespace EpiNet.Win.Maestros.Entidad
{
    public partial class frmEntidadEditar : DevExpress.XtraEditors.XtraForm
    {
        public int IdEntidad = 0;

        public frmEntidadEditar()
        {
            InitializeComponent();
            InicializaControles();
        }
        public frmEntidadEditar(int idEntidad)
        {
            InitializeComponent();
            InicializaControles();
            this.IdEntidad = idEntidad;

            if (IdEntidad > 0)
            {
                TBL_EPI_ENTIDAD oEntidad = BLEntidad.obtenerEntidad(idEntidad);

                luTipoPersona.EditValue = oEntidad.EPI_INT_IDTIPOPERSONA;
                luTipoDocumento.EditValue = oEntidad.EPI_INT_IDTIPODOCUMENTO;
                txtCodigoLegal.Text = oEntidad.EPI_VCH_NUMERODOCUMENTO;
                txtRazonSocial.Text = oEntidad.EPI_VCH_RAZONSOCIAL;
                txtNombreComercial.Text = oEntidad.EPI_VCH_NOMBRECOMERCIAL;
                txtSitioWeb.Text = oEntidad.EPI_VCH_SITIOWEB;
                txtGiroNegocio.Text = oEntidad.EPI_VCH_GIRONEGOCIO;
                txtDireccion.Text = oEntidad.EPI_VCH_DIRECCION;

                List<TBL_EPI_ENTIDADTIPOENTIDAD> lstTipoEntidad = BLEntidad.listarTipoEntidad(idEntidad);

                foreach (var item in lstTipoEntidad)
                {
                    for (int i = 0; i < chkLstBoxTipoEntidad.ItemCount; i++)
                    {

                        if (Convert.ToInt32(item.EPI_INT_IDTIPOENTIDAD) == Convert.ToInt32(chkLstBoxTipoEntidad.Items[i].Value))
                            chkLstBoxTipoEntidad.Items[i].CheckState = CheckState.Checked;
                    } 
                }

            }



        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                if (chkLstBoxTipoEntidad.CheckedItems.Count == 0)
                {
                    XtraMessageBox.Show("Debe seleccionar tipo Entidad", "Sistemas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                    
                if (luTipoDocumento.EditValue == null) {
                    XtraMessageBox.Show("Debe seleccionar tipo Documento", "Sistemas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (luTipoPersona.EditValue == null) {
                    XtraMessageBox.Show("Debe seleccionar tipo Persona", "Sistemas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(txtCodigoLegal.Text)){
                    XtraMessageBox.Show("Debe ingresar codigo Legal", "Sistemas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(txtRazonSocial.Text))
                {
                    XtraMessageBox.Show("Debe ingresar razon social", "Sistemas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(txtDireccion.Text))
                {
                    XtraMessageBox.Show("Debe ingresar Direccion fiscal", "Sistemas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<TBL_EPI_ENTIDADTIPOENTIDAD> lstTipoEntidad = new List<TBL_EPI_ENTIDADTIPOENTIDAD>();
                TBL_EPI_ENTIDAD oEntidad = new TBL_EPI_ENTIDAD();

                oEntidad.EPI_VCH_NUMERODOCUMENTO = txtCodigoLegal.Text;
                oEntidad.EPI_VCH_RAZONSOCIAL = txtRazonSocial.Text;
                oEntidad.EPI_INT_IDTIPODOCUMENTO = Convert.ToInt32(luTipoDocumento.EditValue);
                oEntidad.EPI_INT_IDTIPOPERSONA = Convert.ToInt32(luTipoPersona.EditValue);
                oEntidad.EPI_VCH_NOMBRECOMERCIAL = txtNombreComercial.Text;
                oEntidad.EPI_VCH_DIRECCION = txtDireccion.Text;
                oEntidad.EPI_VCH_SITIOWEB = txtSitioWeb.Text;
                oEntidad.EPI_VCH_GIRONEGOCIO = txtGiroNegocio.Text;
                
                for (int i = 0; i < chkLstBoxTipoEntidad.CheckedItems.Count; i++)
                {
                    lstTipoEntidad.Add(new TBL_EPI_ENTIDADTIPOENTIDAD
                    {
                        EPI_INT_IDTIPOENTIDAD = Convert.ToInt32(chkLstBoxTipoEntidad.CheckedItems[i]),
                    });
                }

                eResultado Res;

                if (IdEntidad == 0)
                {
                    //oEntidad.EPI_BIT_ACTIVO = true;
                    oEntidad.EPI_DAT_FECHACREACION = DateTime.Now;
                    oEntidad.EPI_INT_USUARIOCREA = BaseForm.VariablesGlobales.IdUsuario;


                    Res = BLEntidad.Insertar(oEntidad, lstTipoEntidad);
                    
                    if (Res == eResultado.Correcto)
                    {
                        this.IdEntidad = oEntidad.EPI_INT_IDENTIDAD;

                        XtraMessageBox.Show("Entidad se insertó correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    oEntidad.EPI_INT_IDENTIDAD = this.IdEntidad;
                    oEntidad.EPI_INT_USUARIOMODIFICA = BaseForm.VariablesGlobales.IdUsuario;
                    oEntidad.EPI_DAT_FECHAMODIFICACION = DateTime.Now;

                    Res = BLEntidad.Actualizar(oEntidad, lstTipoEntidad);

                    if (Res == eResultado.Correcto)
                    {

                        XtraMessageBox.Show("Entidad se Actualizó correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

        }


    }
}