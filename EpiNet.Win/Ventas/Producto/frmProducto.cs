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

namespace EpiNet.Win.Ventas.Producto
{
    public partial class frmProducto : BaseModule
    {
        public frmProducto()
        {
            InitializeComponent();
        }
        int CurrentIdProducto
        {
            get { return Convert.ToInt32(gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, gridView1.Columns["EPI_INT_IDPRODUCTO"])); }
        }
        protected internal override void ButtonClick(string tag)
        {

            //XtraMessageBox.Show(Enum.Parse(typeof(eOpciones), tag).ToString());

            switch (Enum.Parse(typeof(eOpciones), tag))
            {
                case eOpciones.Nuevo:
                    EditaProducto(0);
                    break;
                case eOpciones.Editar:
                    if (gridView1.RowCount > 0)
                    {
                        EditaProducto(CurrentIdProducto);
                    }

                    break;
                default:
                    break;
            }
        }

        private void EditaProducto(int idProducto)
        {
            Cursor.Current = Cursors.WaitCursor;
            frmProductoEditar form = new frmProductoEditar(idProducto);
            //form.Load += OnEditMailFormLoad;
            //form.FormClosed += OnEditMailFormClosed;
            //form.Location = new Point(OwnerForm.Left + (OwnerForm.Width - form.Width) / 2, OwnerForm.Top + (OwnerForm.Height - form.Height) / 2);
            form.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            List<BEProducto> olProductos = new List<BEProducto>();
            olProductos = BLProducto.ListarProductos(0, txtCriterio.Text);

            gridControl1.DataSource = olProductos;
        }
    }
}