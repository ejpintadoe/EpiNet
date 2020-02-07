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
using EpiNet.Win.App_Code.BE;
using DevExpress.XtraGrid.Views.Base;

namespace EpiNet.Win.Seguridad.Perfil
{
    public partial class frmPerfil : BaseModule
    {
        public int idPerfil = 0;
        public frmPerfil()
        {
            InitializeComponent();
            BindingList<BEPerfil> olPerfil = new BindingList<BEPerfil>();
            olPerfil = BLPerfil.ListarPerfil(0, "");

            gridControl1.DataSource = olPerfil;
        }
        public override string ModuleName { get { return "Seguridad - Perfil"; } }

        protected internal override void ButtonClick(string tag)
        {
            
            switch (tag)
            {
                
                case "Nuevo":
                    CreaNuevoPerfil(0);

                    break;

                case "Editar":

                    if (gridView1.RowCount > 0)
                    {
                        
                        EditaPerfil(CurrentIdPerfil);

                    }

                    break;
                default:
                    break;
            }
        }

        int CurrentIdPerfil
        {
            get { return Convert.ToInt32(gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, gridView1.Columns["EPI_INT_IDPERFIL"])); }
        }

        void CreaNuevoPerfil(int idPerfil)
        {
            this.idPerfil = idPerfil;

            this.txtNombrePerfil.Text = string.Empty;

            List<BELlenaSLUE> omod = BLModulo.ListarModulo(0, "").Select(x => new BELlenaSLUE { ValueMember = Convert.ToInt32(x.EPI_INT_IDMODULO), DisplayMember = x.EPI_VCH_NOMBREMODULO }).ToList();
            BaseForm.CargaSLU(searchLookUpEdit1, omod, "ValueMember", "DisplayMember");


        }

        void EditaPerfil(int idPerfil)
        {
            this.idPerfil = idPerfil;

            BEPerfil olPerfil = BLPerfil.ListarPerfil(idPerfil, "").SingleOrDefault();
            this.txtNombrePerfil.Text = olPerfil.EPI_VCH_NOMBREPERFIL.ToString();

            List<BELlenaSLUE> omod = BLModulo.ListarModulo(0, "").Select(x => new BELlenaSLUE {  ValueMember = Convert.ToInt32(x.EPI_INT_IDMODULO),  DisplayMember = x.EPI_VCH_NOMBREMODULO }).ToList();                    
            BaseForm.CargaSLU(searchLookUpEdit1, omod, "ValueMember", "DisplayMember");

            CargarOpcionModuloPerfil();

        }

        void CargarOpcionModuloPerfil()
        {

            List<BEOpcionModuloPerfil> olOpcionesModulo = BLModulo.ListarOpcionesModuloPerfil(Convert.ToInt32(searchLookUpEdit1.EditValue));
            List<BEOpcionModuloPerfil> olOpcionesModuloPerfil = BLPerfil.ListarOpcionesModuloPerfil(this.idPerfil);

            gridControl3.DataSource = olOpcionesModuloPerfil;
            gridControl2.DataSource = olOpcionesModulo.Where(x => !olOpcionesModuloPerfil.Any(y => y.EPI_INT_IDOPCIONMODULO == x.EPI_INT_IDOPCIONMODULO)).ToList();

        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            CargarOpcionModuloPerfil();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {

                TBL_EPI_PERFIL oPerfil = new TBL_EPI_PERFIL();

                if (txtNombrePerfil.Text == string.Empty)
                {
                    XtraMessageBox.Show("Debe Ingresar Nombre Perfil ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                oPerfil.EPI_VCH_NOMBREPERFIL = txtNombrePerfil.Text;



                eResultado Res;

                switch (this.idPerfil)
                {
                    case 0:


                        oPerfil.EPI_BIT_ACTIVO = true;


                        Res = BLPerfil.Insertar(oPerfil);

                        this.idPerfil = oPerfil.EPI_INT_IDPERFIL;


                        if (Res == eResultado.Correcto)
                        {

                            XtraMessageBox.Show("Perfil se insertó correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //pnOpciones.Visible = true;

                        }

                        break;



                    default:


                        oPerfil.EPI_INT_IDPERFIL = Convert.ToInt32(this.idPerfil);
                        oPerfil.EPI_BIT_ACTIVO = true;

                        Res = BLPerfil.Actualizar(oPerfil);


                        if (Res == eResultado.Correcto)
                        {
                            XtraMessageBox.Show("Perfil Actualizado Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void btnDerecha_Click(object sender, EventArgs e)
        {

            ColumnView view = gridControl2.MainView as ColumnView;

            foreach (var item in gridView2.GetSelectedRows())
            {
                BEOpcionModuloPerfil oOpMod = new BEOpcionModuloPerfil();
                oOpMod = view.GetRow(item) as BEOpcionModuloPerfil;
                //eResultado res = BLModulo.AgregarOpcionModulo(idModulo, oOp.EPI_INT_IDOPCION);
                eResultado res = BLPerfil.AgregarOpcionModuloPerfil(this.idPerfil, oOpMod.EPI_INT_IDOPCIONMODULO);

            }

            CargarOpcionModuloPerfil();

        }

        private void btnIzquierda_Click(object sender, EventArgs e)
        {
            ColumnView view = gridControl3.MainView as ColumnView;

            foreach (var item in gridView3.GetSelectedRows())
            {
                BEOpcionModuloPerfil oOpMod = new BEOpcionModuloPerfil();
                oOpMod = view.GetRow(item) as BEOpcionModuloPerfil;

                //eResultado res = BLModulo.EliminarOpcionModulo(idModulo, oOp.EPI_INT_IDOPCION);
                eResultado res = BLPerfil.EliminarOpcionModuloPerfil(this.idPerfil, oOpMod.EPI_INT_IDOPCIONMODULO);

            }
            CargarOpcionModuloPerfil();

        }
    }
}