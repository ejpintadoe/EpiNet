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
using EpiNet.Win.Reportes;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Parameters;
using EpiNet.Win.Reportes.Ventas;

namespace EpiNet.Win.Ventas.Facturacion
{
    public partial class frmFacturacion : BaseModule
    {
        public frmFacturacion()
        {
            InitializeComponent();
            InicializaControles();
        }

        private void InicializaControles()
        {
            BaseForm.IniciaFecDesdeHasta(deFechaDesde, deFechaHasta, 30);
            List<BESearchLookUpEdit> lstSLUETipoDocumentoContable = new List<BESearchLookUpEdit>();
            lstSLUETipoDocumentoContable.AddRange(new BESearchLookUpEdit[] {
                new BESearchLookUpEdit { fieldName = "EPI_INT_IDTIPODOCUMENTOCONTABLE", caption = "Id" },
                new BESearchLookUpEdit { fieldName = "EPI_VCH_NOMBREDOCUMENTO", caption = "Descripcion" },
                new BESearchLookUpEdit { fieldName = "EPI_INT_IDTIPODOCUMENTOCONTABLESERIES", caption = "Descripcion" }

            });
            BaseForm.CargarSearchLookUpEdit(searchLookUpTipoDocumento, BLTipoDocumentoContable.GetTipoDocumentoContablePreferida(), lstSLUETipoDocumentoContable);

            List<BESearchLookUpEdit> lstSLUECliente = new List<BESearchLookUpEdit>();
            lstSLUECliente.AddRange(new BESearchLookUpEdit[] {
                new BESearchLookUpEdit { fieldName = "EPI_INT_IDENTIDAD", caption = "Id" },
                new BESearchLookUpEdit { fieldName = "EPI_VCH_RAZONSOCIAL2", caption = "Descripcion" },
                new BESearchLookUpEdit { fieldName = "EPI_VCH_RAZONSOCIAL1", caption = "Descripcion2" },
                new BESearchLookUpEdit { fieldName = "EPI_VCH_DIRECCION", caption = "Descripcion2" }
            });
            BaseForm.CargarSearchLookUpEdit(searchLookUpCliente, BLEntidad.GetListEntidadPorTipo(0, Convert.ToInt32(eTipoEntidad.Cliente), 0, 0), lstSLUECliente);


        }

        int CurrentIdFactura
        {
            get { return Convert.ToInt32(gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, gridView1.Columns["EPI_NUM_IDFACTURA"])); }
        }

        protected internal override void ButtonClick(string tag)
        {

            //XtraMessageBox.Show(Enum.Parse(typeof(eOpciones), tag).ToString());

            switch (Enum.Parse(typeof(eOpciones), tag))
            {
                case eOpciones.Nuevo:
                    EditaFactura(0);
                    break;
                case eOpciones.Editar:
                    if (gridView1.RowCount > 0)
                    {
                        EditaFactura(CurrentIdFactura);
                    }

                    break;

                case eOpciones.Imprimir:
                    if (gridView1.RowCount > 0)
                    {
                        ImprimirFactura(CurrentIdFactura);
                    }

                    break;

                case eOpciones.Anular:

                    if (gridView1.RowCount > 0)
                    {
                        AnularFactura(CurrentIdFactura);
                    }
                    break;

                case eOpciones.Buscar:

                    BuscarFactura();

                    break;
                default:
                    break;
            }
        }

        private void BuscarFactura()
        {
            int idTipoDoc = Convert.ToInt32(searchLookUpTipoDocumento.EditValue);
            int idCliente = Convert.ToInt32(searchLookUpCliente.EditValue);

            List<EPI_SP_LISTAFACTURAResult> lstFactura = BLFacturacion.GetListaFactura(idTipoDoc, idCliente, txtSerie.Text, txtCriterio.Text, Convert.ToDateTime(deFechaDesde.EditValue), Convert.ToDateTime(deFechaHasta.EditValue));
            BaseForm.CargarGridControl(gridControl1, lstFactura);
        }

        private void AnularFactura(int currentIdFactura)
        {
            TBL_EPI_FACTURA objFac = BLFacturacion.GetFactura(currentIdFactura);

            if (objFac.EPI_BIT_ANULADA == true)
            {
                XtraMessageBox.Show("El documento está anulado, no puede volver anular", "SISTEMAS");
                return;
            }

            if (objFac.EPI_BIT_IMPRESA == false)
            {
                XtraMessageBox.Show("El documento no está impreso, no puede anular", "SISTEMAS");
                return;
            }

            if (objFac.EPI_BIT_ANULADA == false)
            {
                DialogResult result = XtraMessageBox.Show("Seguro de anular el documento " + objFac.EPI_VCH_SERIEFACTURA + '-' + objFac.EPI_VCH_NUMERODOCUMENTO + " ?", "Confirmar", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    XtraMessageBox.Show(BLFacturacion.AnulaFactura(Convert.ToInt32(currentIdFactura)));
                }
            }
        }

        private void EditaFactura(int idFactura)
        {
            Cursor.Current = Cursors.WaitCursor;
            frmFacturacionEditar form = new frmFacturacionEditar(idFactura);
            //form.Load += OnEditMailFormLoad;
            //form.FormClosed += OnEditMailFormClosed;
            //form.Location = new Point(OwnerForm.Left + (OwnerForm.Width - form.Width) / 2, OwnerForm.Top + (OwnerForm.Height - form.Height) / 2);
            form.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void ImprimirFactura(int idFactura)
        {
            List<EPI_SP_LISTARFACTURAEDICIONResult> lstFactura = BLFacturacion.GetListaFacturaEdicion(idFactura);

            //if (lstFactura.Count < 1) return;

            string mensaje = "";
            if (lstFactura[0].BIT_ANULADA == true) { mensaje = "El documento está anulado, no puede imprimir"; }
            if (lstFactura[0].BIT_IMPRESA == true) { mensaje = "El documento ya se encuentra impreso, no puede imprimir, solo visualizar B01 y B03"; }
            

            XR_FacturaVenta XR_Factura = new XR_FacturaVenta();
            foreach (Parameter p in XR_Factura.Parameters)
            {
                p.Visible = false;
            }
          

            List<BEFacturaDetalle> lstDetalleFactura = (from df in lstFactura
                                                        where df.EPI_NUM_IDFACTURADETALLE != null
                                                        select new BEFacturaDetalle
                                                        {
                                                            EPI_NUM_IDFACTURADETALLE = Convert.ToInt32(df.EPI_NUM_IDFACTURADETALLE ?? 0),
                                                            EPI_INT_ITEM = df.EPI_INT_ITEM ?? 0,
                                                            EPI_INT_IDPRODUCTO = df.EPI_INT_IDPRODUCTO ?? 0,
                                                            EPI_NUM_CANTIDAD = df.EPI_NUM_CANTIDAD ?? 0,
                                                            EPI_VCH_DESCRIPCION = df.EPI_VCH_DESCRIPCION,
                                                            EPI_INT_IDUNIDADMEDIDA = df.EPI_INT_IDUNIDADMEDIDA ?? 0,
                                                            EPI_VCH_UNIDADMEDIDA = df.EPI_VCH_UNIDADMEDIDA,
                                                            EPI_INT_IDIMPUESTO = df.EPI_INT_IDIMPUESTO ?? 0,
                                                            EPI_NUM_VALORUNITARIO = Math.Round(Convert.ToDecimal(df.EPI_NUM_VALORUNITARIO), 2, MidpointRounding.AwayFromZero),
                                                            EPI_NUM_SUBTOTAL = Math.Round(Convert.ToDecimal(df.EPI_NUM_SUBTOTAL), 2, MidpointRounding.AwayFromZero),
                                                            EPI_NUM_IGVVENTA = Math.Round(Convert.ToDecimal(df.EPI_NUM_IGVVENTA), 2, MidpointRounding.AwayFromZero),
                                                            EPI_NUM_IMPORTETOTAL = Math.Round(Convert.ToDecimal(df.EPI_NUM_IMPORTETOTAL), 2, MidpointRounding.AwayFromZero),
                                                            EPI_BIT_ACTIVO = df.EPI_BIT_ACTIVO ?? false,
                                                            EPI_VCH_CLIENTEENTIDAD = lstFactura[0].PERSONAFACTURARAZONSOCIAL,
                                                            EPI_VCH_DIRECCIONENTIDAD = lstFactura[0].PERSONAFACTURADIRECCION,
                                                            EPI_VCH_RUC = lstFactura[0].PERSONAFACTURANUMERODOCUMENTO,
                                                            EPI_VCH_NUMEROENLETRAS = lstFactura[0].TOTALENLETRAS,
                                                            EPI_DAT_FECHAEMISION = Convert.ToDateTime(lstFactura[0].FECHADESDE.ToString()),

                                                        }).ToList();

            XR_Factura.InitData(lstDetalleFactura);

            ReportPrintTool tool = new ReportPrintTool(XR_Factura);
            //tool.Print();
            tool.ShowPreview();


            BLFacturacion.MarcaImpresa(idFactura, true);

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarFactura();

        }
    }
}