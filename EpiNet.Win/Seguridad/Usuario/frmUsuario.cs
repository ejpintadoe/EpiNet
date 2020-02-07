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
using EpiNet.Win.App_Code.BL;

namespace EpiNet.Win.Seguridad.Usuario
{
    public partial class frmUsuario : BaseModule
    {
        public frmUsuario()
        {
            InitializeComponent();

            gridControl1.DataSource = BLUsuario.ListarUsuarioEmpleado(0, "");
        }
        int CurrentIdEmpleado
        {
            get { return Convert.ToInt32(gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, gridView1.Columns["EPI_INT_IDEMPLEADO"])); }
        }

        protected internal override void ButtonClick(string tag)
        {

            //XtraMessageBox.Show(Enum.Parse(typeof(eOpciones), tag).ToString());

            switch (Enum.Parse(typeof(eOpciones), tag))
            {
                case eOpciones.Editar:
                    if (gridView1.RowCount > 0)
                    {
                        EditaUsuario(CurrentIdEmpleado);
                    }

                    break;
                default:
                    break;
            }
        }

        void EditaUsuario(int IdEmpleado)
        {
            Cursor.Current = Cursors.WaitCursor;
            frmUsuarioEditar form = new frmUsuarioEditar(IdEmpleado);
            //form.Load += OnEditMailFormLoad;
            //form.FormClosed += OnEditMailFormClosed;
            //form.Location = new Point(OwnerForm.Left + (OwnerForm.Width - form.Width) / 2, OwnerForm.Top + (OwnerForm.Height - form.Height) / 2);
            form.ShowDialog();
            Cursor.Current = Cursors.Default;
        }
    }
}