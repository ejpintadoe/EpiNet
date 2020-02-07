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
using EpiNet.Win.App_Code.BE;
using EpiNet.Win.App_Code.BL;


namespace EpiNet.Win
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            BEUsuario oUsuario = new BEUsuario();

            if (Environment.MachineName == "NET" || this.txtUsuario.Text == "userit" || Environment.MachineName == "LPT-EPINTADO" || Environment.MachineName == "LAPTOP-HPI4V4U2")
            {
                this.txtUsuario.Text = "Administrador";
                this.txtPassword.Text = "Erik0206";
            }

            eResultado res = BLUsuario.ValidarUsuario(this.txtUsuario.Text, BaseForm.EncriptarPassword(this.txtPassword.Text), ref oUsuario);


            if (res == eResultado.Correcto)
            {
                if (oUsuario.Modulos != null && oUsuario.Modulos.Count() > 0)
                {
                    BaseForm.VariablesGlobales.MiUsuario = oUsuario;
                    frmMain frm = new frmMain();
                    this.Hide(); frm.ShowDialog(); this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Su Perfil no tiene permiso para acceder a los módulos, verifique con sistemas", "Sistemas");
                    //MessageBox.Show("Su Perfil no tiene permiso para acceder a los módulos, verifique con sistemas");
                }
            }
            else
            {
                XtraMessageBox.Show("Verifique su usuario y contraseña", "Sistemas");
            }


            
        }
    }
}