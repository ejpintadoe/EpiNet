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

namespace EpiNet.Win.Seguridad.Usuario
{
    public partial class frmUsuarioEditar : DevExpress.XtraEditors.XtraForm
    {
        public int idUsuario = 0;
        public int idEmpleado = 0;
        public frmUsuarioEditar()
        {
            InitializeComponent();
        }
        public frmUsuarioEditar(int idEmpleado)
        {
            InitializeComponent();
            this.idEmpleado = idEmpleado;

            TBL_EPI_EMPLEADO oEmpleado = BLEmpleado.obtieneEmpleados(idEmpleado);

            if (oEmpleado.EPI_INT_IDUSUARIO != null)
                this.idUsuario = Convert.ToInt32(oEmpleado.EPI_INT_IDUSUARIO);


            List<BELlenaSLUE> olPerfil = BLPerfil.ListarPerfil(0, "").Select(x => new BELlenaSLUE { ValueMember = Convert.ToInt32(x.EPI_INT_IDPERFIL), DisplayMember = x.EPI_VCH_NOMBREPERFIL }).ToList();
            BaseForm.CargaSLU(searchLookUpEdit1, olPerfil, "ValueMember", "DisplayMember");
            txtEmpleado.Text = oEmpleado.EPI_VCH_NOMBRE + " " + oEmpleado.EPI_VCH_APELLIDOPATERNO;

            if (idUsuario > 0)
            {
                TBL_EPI_USUARIO oUsuario = BLUsuario.obtieneUsuario(idUsuario);


                searchLookUpEdit1.EditValue = oUsuario.EPI_INT_IDPERFIL ?? 0;
                txtUsuario.Text = oUsuario.EPI_VCH_USUARIO;
                checkEdit1.Checked = oUsuario.EPI_BIT_HABILITADO ?? false;


            }


        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                               

                TBL_EPI_USUARIO oUser = new TBL_EPI_USUARIO();

                oUser.EPI_BIT_HABILITADO = this.checkEdit1.Checked;
                oUser.EPI_INT_IDPERFIL = Convert.ToInt32(this.searchLookUpEdit1.EditValue);


                eResultado Res;

                if (idUsuario == 0)
                {
                    if (BLUsuario.ValidarNombreUsuario(txtUsuario.Text))
                    {
                        XtraMessageBox.Show("Nombre de Usuario ya existe ingrese otro", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (txtUsuario.Text == string.Empty)
                    {
                        XtraMessageBox.Show("Debe Ingresar el Nombre de Usuario", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (txtClave.Text == string.Empty)
                    {
                        XtraMessageBox.Show("Debe Ingresar el Clave", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    if (txtClave.Text != txtConfirmaClave.Text)
                    {

                        XtraMessageBox.Show("Claves no coinciden", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;

                    }


                    oUser.EPI_VCH_USUARIO = txtUsuario.Text;
                    oUser.EPI_VCH_CLAVE = BaseForm.EncriptarPassword(txtClave.Text);
                    oUser.EPI_BIT_ACTIVO = true;

                    Res = BLUsuario.InsertarEmpleadoUsuario(oUser, idEmpleado);

                    this.idUsuario = oUser.EPI_INT_IDUSUARIO;

                    if (Res == eResultado.Correcto)
                    {

                        XtraMessageBox.Show("Usuario se insertó correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtClave.Text = string.Empty;
                        txtConfirmaClave.Text = string.Empty;

                    }


                }
                else
                {
                    if (txtClave.Text != string.Empty)
                    {

                        if (txtClave.Text != txtConfirmaClave.Text)
                        {
                            XtraMessageBox.Show("Claves no coinciden", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

                        oUser.EPI_VCH_CLAVE = BaseForm.EncriptarPassword(txtClave.Text);

                    }

                    oUser.EPI_INT_IDUSUARIO = this.idUsuario;
                    oUser.EPI_VCH_USUARIO = txtUsuario.Text;

                    Res = BLUsuario.ActualizarEmpleadoUsuario(oUser, this.idEmpleado);


                    if (Res == eResultado.Correcto)
                    {

                        XtraMessageBox.Show("Usuario Actualizado Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtClave.Text = string.Empty;
                        txtConfirmaClave.Text = string.Empty;

                    }

                }


            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}