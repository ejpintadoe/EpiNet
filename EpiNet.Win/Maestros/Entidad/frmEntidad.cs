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
using EpiNet.Win.App_Code.BE;

namespace EpiNet.Win.Maestros.Entidad
{
    public partial class frmEntidad : BaseModule
    {
        public int IdEntidad = 0;
        public override string ModuleName { get { return "Entidad"; } }

        public frmEntidad()
        {
            InitializeComponent();
            InicializaControles();
            BuscarEntidad();

        }

        private void BuscarEntidad()
        {
            int idTipoEntidad = 0;
            string criterio = "";
            idTipoEntidad = Convert.ToInt32(lookUpTipoEntidad.EditValue);
            criterio = txtCriterio.Text;
            List<BEEntidad> lstEntidad = BLEntidad.listarEntidad(0, idTipoEntidad, criterio);
            gridControl1.DataSource = lstEntidad;
        }

        int CurrentIdEntidad
        {
            get { return Convert.ToInt32(gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, gridView1.Columns["EPI_INT_IDENTIDAD"])); }
        }

        protected internal override void ButtonClick(string tag)
        {

            switch (Enum.Parse(typeof(eOpciones), tag))
            {
                case eOpciones.Nuevo:
                    CreaNuevaEntidad();
                    break;

                case eOpciones.Editar:
                    if (gridView1.RowCount > 0)
                    {
                        EditaEntidad(CurrentIdEntidad);
                        
                    }

                    break;
                default:
                    break;
            }
            
            
        }

        private void EditaEntidad(int idEntidad)
        {
            Cursor.Current = Cursors.WaitCursor;
            frmEntidadEditar form = new frmEntidadEditar(idEntidad);
            
            form.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void CreaNuevaEntidad()
        {
            EditaEntidad(0);
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.RowHandle >= 0 && e.Clicks == 2)
                EditaEntidad(CurrentIdEntidad);
        }

        private void txtCriterio_Enter(object sender, EventArgs e)
        {
          
            BuscarEntidad();
        }
        

       
    }
}