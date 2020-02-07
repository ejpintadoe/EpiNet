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

namespace EpiNet.Win.RecursosHumanos.Empleado
{
    public partial class frmEmpleado : BaseModule
    {
        public frmEmpleado()
        {
            InitializeComponent();

            List<BEEmpleado> olEmpleado = new List<BEEmpleado>();
            olEmpleado = BLEmpleado.ListarEmpleados(0, "");
            gridControl1.DataSource = olEmpleado;

        }
        int CurrentIdEmpleado
        {
            get { return Convert.ToInt32(gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, gridView1.Columns["EPI_INT_IDEMPLEADO"])); }
        }


        protected internal override void ButtonClick(string tag)
        {
            switch (tag)
            {


                case "Nuevo":
                    CreaNuevoEmpleado();

                    break;

                case "Editar":

                    if (gridView1.RowCount > 0)
                    {
                        //IdModulo = Convert.ToInt32(gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, gridView1.Columns["IDMODULO"]));
                        EditaEmpleado(CurrentIdEmpleado);

                    }

                    break;
                default:
                    break;
            }

        }

        void CreaNuevoEmpleado()
        {
            //Message message = new Message();
            //message.MailType = MailType.Draft;
            EditaEmpleado(0);
        }

        void EditaEmpleado(int idEmpleado)
        {

            frmEmpleadoEditar form = new frmEmpleadoEditar(idEmpleado);
            //form.Load += OnEditMailFormLoad;
            //form.FormClosed += OnEditMailFormClosed;
            //form.Location = new Point(OwnerForm.Left + (OwnerForm.Width - form.Width) / 2, OwnerForm.Top + (OwnerForm.Height - form.Height) / 2);
            form.ShowDialog();
            Cursor.Current = Cursors.Default;
        }
    }
}