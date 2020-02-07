using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using EpiNet.Win.App_Code.BL;
using EpiNet.Win.App_Code;
using EpiNet.Win.App_Code.BE;

namespace EpiNet.Win.Seguridad.Modulo
{
    public partial class frmModulo : BaseModule
    {
        public int IdModulo = 0;
        public int IdModuloPadre = 0;
        public int IdModuloAbuelo = 0;
        public override string ModuleName { get { return "Modulo"; } }
        public frmModulo()
        {
            InitializeComponent();
           List<BEModulo> olModulos = new List<BEModulo>();
            olModulos = BLModulo.ListarModulos(0,0,"");

            gridControl1.DataSource = olModulos;
            //gridView1.ShowFindPanel();
        }
        //protected override void LookAndFeelStyleChanged()
        //{
        //    base.LookAndFeelStyleChanged();
        //    //ColorHelper.UpdateColor(ilColumns, gridControl1.LookAndFeel);
        //}

        protected override DevExpress.XtraGrid.GridControl Grid
        {
            get { return gridControl1; }
        }

        protected internal override void ButtonClick(string tag)
        {
            

            switch (tag)
            {
                case "SubModulo":
                    SubModulo();

                    break;

                case "Regresar":
                    RegresarModulo();

                    break;

                case "Nuevo":
                    CreaNuevoModulo();

                    break;

                case "Editar":
                    
                    if (gridView1.RowCount > 0)
                    {
                       //IdModulo = Convert.ToInt32(gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, gridView1.Columns["IDMODULO"]));
                       EditaModulo(CurrentIdModulo);

                        List<BEModulo> olModulos = new List<BEModulo>();
                        olModulos = BLModulo.ListarModulos(0, IdModuloPadre, "");

                        gridControl1.DataSource = olModulos;

                    }

                    break;
                default:
                    break;
            }
        }

        int CurrentIdModulo
        {
            get { return Convert.ToInt32(gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, gridView1.Columns["IDMODULO"])); }
        }


        private void RegresarModulo()
        {
            #region REGRESAR AL PADRE
            //int Pos;
            //Pos = dgvModulos.CurrentRow.Index;
            //dgvModulos.Rows[Pos].Cells["IDABUELO"].Value != null
            //Convert.ToInt32()
            

            if (gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, gridView1.Columns["IDABUELO"]) != "")
            {                
                
                IdModuloAbuelo = Convert.ToInt32(gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, gridView1.Columns["IDABUELO"]));
                IdModuloPadre = IdModuloAbuelo;
                List<BEModulo> olSubModulos = BLModulo.ListarModulos(0, IdModuloAbuelo, "");
                gridControl1.DataSource = olSubModulos;
            }
            else
            {
                
                XtraMessageBox.Show("Ha llegado al nivel máximo", "Alerta");

            }
            #endregion
        }

        void SubModulo()
        {

            #region VER SUBMODULOS

            //IdModuloPadre = Convert.ToInt32(gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, gridView1.Columns["IDMODULO"]));
            IdModuloPadre = CurrentIdModulo;
            
            List<BEModulo> olSubModulos = BLModulo.ListarModulos(0, CurrentIdModulo, "");

            if (olSubModulos.Count > 0)
            {
                gridControl1.DataSource = olSubModulos;
            }
            else
            {
                
                XtraMessageBox.Show("No Tiene Sub Modulos", "Alerta");
            }

            #endregion
        }

        void CreaNuevoModulo()
        {
            //Message message = new Message();
            //message.MailType = MailType.Draft;
            EditaModulo(0);
        }

        void EditaModulo(int idModulo)
        {
            Cursor.Current = Cursors.WaitCursor;
            frmModuloEditar form = new frmModuloEditar(idModulo);
            //form.Load += OnEditMailFormLoad;
            //form.FormClosed += OnEditMailFormClosed;
            //form.Location = new Point(OwnerForm.Left + (OwnerForm.Width - form.Width) / 2, OwnerForm.Top + (OwnerForm.Height - form.Height) / 2);
            form.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        internal override void ShowModule(bool firstShow)
        {
            base.ShowModule(firstShow);
            gridControl1.Focus();
            //UpdateActionButtons();
            if (firstShow)
            {
                gridControl1.ForceInitialize();
                //GridHelper.SetFindControlImages(gridControl1);
                //if (DataHelper.Contacts.Count == 0) UpdateCurrentContact();
            }
        }

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.RowHandle >= 0 && e.Clicks == 2)
                EditaModulo(CurrentIdModulo);
        }
    }
}
