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
using DevExpress.XtraGrid.Views.Grid;
using EpiNet.Win.App_Code.BE;
using EpiNet.Win.App_Code.BL;
using EpiNet.Win.App_Code;
using EpiNet.Win.Reportes;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Parameters;

namespace EpiNet.Win.Ventas.Facturacion
{
    public partial class frmFacturacionEditar : DevExpress.XtraEditors.XtraForm
    {
        public int IdFactura = 0;
        public frmFacturacionEditar()
        {
            InitializeComponent();
            InicializaControles();
            BaseForm.VariablesGlobales.Impuesto = BLImpuesto.GetListImpuesto(0, "");

            BindingSource bs = new BindingSource();
            bs.DataSource = new BindingList<BEFacturaDetalle>();
            gridControl2.DataSource = bs;

        }

        public frmFacturacionEditar(int id)
        {
            InitializeComponent();
            InicializaControles();
            BaseForm.VariablesGlobales.Impuesto = BLImpuesto.GetListImpuesto(0, "");

            BaseForm.CargarGridControl(gridControl2, new BindingList<BEFacturaDetalle>());
            
            IdFactura = id;
            
            if (IdFactura > 0)
            {
                InicializaEdicion(IdFactura);
            }

        }

        private void InicializaEdicion(int idFactura)
        {
            List<EPI_SP_LISTARFACTURAEDICIONResult> lstFactura = BLFacturacion.GetListaFacturaEdicion(idFactura);
            if (lstFactura.Count <= 0) return;

            searchLookUpTipoDocumento.EditValue = lstFactura[0].IDTIPODOCUMENTOCONTABLE;
            //txtSerie.Text = lstFactura[0].SERIEFACTURA;
            //txtCorrelativo.Text = lstFactura[0].NUMERODOCUMENTO.PadLeft(7, '0');
            searchLookUpMoneda.EditValue = Convert.ToInt32(lstFactura[0].IDMONEDA);
            searchLookUpTipoPago.EditValue = Convert.ToInt32(lstFactura[0].IDTIPOPAGO);
            deFechaEmision.EditValue = Convert.ToDateTime(lstFactura[0].FECHADESDE);
            deFechaVencimiento.EditValue = Convert.ToDateTime(lstFactura[0].FECHAHASTA);
            searchLookUpCliente.EditValue = lstFactura[0].PERSONAFACTURAIDENTIDAD;
            txtObservaciones.Text = lstFactura[0].OBSERVACIONES;
            txtReferencia1.Text = lstFactura[0].REFERENCIA1;
            txtReferencia2.Text = lstFactura[0].REFERENCIA2;

        
            List<BEFacturaDetalle> lstDetalleFactura = (from df in lstFactura
                                                        where df.EPI_NUM_IDFACTURADETALLE != null
                                                        select new BEFacturaDetalle {
                                                            EPI_NUM_IDFACTURADETALLE=   Convert.ToInt32(df.EPI_NUM_IDFACTURADETALLE ?? 0),
                                                            EPI_INT_ITEM=    df.EPI_INT_ITEM ?? 0,
                                                            EPI_INT_IDPRODUCTO = df.EPI_INT_IDPRODUCTO ?? 0,
                                                            EPI_NUM_CANTIDAD= df.EPI_NUM_CANTIDAD ?? 0,
                                                            EPI_VCH_DESCRIPCION=  df.EPI_VCH_DESCRIPCION,
                                                            EPI_INT_IDUNIDADMEDIDA = df.EPI_INT_IDUNIDADMEDIDA ?? 0,
                                                            EPI_VCH_UNIDADMEDIDA = df.EPI_VCH_UNIDADMEDIDA,
                                                            EPI_INT_IDIMPUESTO = df.EPI_INT_IDIMPUESTO ?? 0,
                                                            EPI_NUM_VALORUNITARIO = Math.Round(Convert.ToDecimal(df.EPI_NUM_VALORUNITARIO), 2, MidpointRounding.AwayFromZero) ,
                                                            EPI_NUM_SUBTOTAL = Math.Round(Convert.ToDecimal(df.EPI_NUM_SUBTOTAL), 2, MidpointRounding.AwayFromZero),
                                                            EPI_NUM_IGVVENTA = Math.Round(Convert.ToDecimal(df.EPI_NUM_IGVVENTA), 2, MidpointRounding.AwayFromZero),
                                                            EPI_NUM_IMPORTETOTAL = Math.Round(Convert.ToDecimal(df.EPI_NUM_IMPORTETOTAL), 2, MidpointRounding.AwayFromZero),
                                                            EPI_BIT_ACTIVO = df.EPI_BIT_ACTIVO ?? false
                                                        }).ToList();

            BaseForm.CargarGridControl(gridControl2, lstDetalleFactura);

        }

        private void InicializaControles()
        {
            BaseForm.IniciaFecDesdeHasta(deFechaEmision, deFechaVencimiento, 0);

            List<BESearchLookUpEdit> lstSLUEMoneda = new List<BESearchLookUpEdit>();

            lstSLUEMoneda.AddRange(new BESearchLookUpEdit[]
            {
                new BESearchLookUpEdit { fieldName = "EPI_INT_IDMONEDA", caption = "Id" },
                new BESearchLookUpEdit { fieldName = "EPI_VCH_NOMBRE", caption = "Descripcion"},
                new BESearchLookUpEdit { fieldName = "EPI_VCH_SIMBOLO", caption = "Simbolo"}
            });

            BaseForm.CargarSearchLookUpEdit(searchLookUpMoneda, BLMoneda.ListarMoneda(0, ""), lstSLUEMoneda);


            List<BESearchLookUpEdit> lstSLUETipoPago = new List<BESearchLookUpEdit>();
            lstSLUETipoPago.AddRange(new BESearchLookUpEdit[] {
                new BESearchLookUpEdit { fieldName = "EPI_INT_IDGENERICA", caption = "Id" },
                new BESearchLookUpEdit { fieldName = "EPI_VCH_CAMPO2", caption = "Descripcion" }
            });
            BaseForm.CargarSearchLookUpEdit(searchLookUpTipoPago, BLGenerica.ListarGenerica(eTblGen.TIPOPAGO.ToString()), lstSLUETipoPago);

            List<BESearchLookUpEdit> lstSLUEImpuesto = new List<BESearchLookUpEdit>();
            lstSLUEImpuesto.AddRange(new BESearchLookUpEdit[] {
                new BESearchLookUpEdit { fieldName = "EPI_INT_IDIMPUESTO", caption = "Id" },
                new BESearchLookUpEdit { fieldName = "EPI_VCH_NOMBRE", caption = "Descripcion" }
            });
            BaseForm.CargarRepositoryItemSearchLookUpEdit(repositoryItemSearchLookUpEdit1, BLImpuesto.ListarImpuesto(0, ""), lstSLUEImpuesto);

            List<BESearchLookUpEdit> lstSLUECliente = new List<BESearchLookUpEdit>();
            lstSLUECliente.AddRange(new BESearchLookUpEdit[] {
                new BESearchLookUpEdit { fieldName = "EPI_INT_IDENTIDAD", caption = "Id" },
                new BESearchLookUpEdit { fieldName = "EPI_VCH_RAZONSOCIAL2", caption = "Descripcion" },
                new BESearchLookUpEdit { fieldName = "EPI_VCH_RAZONSOCIAL1", caption = "Descripcion2" },
                new BESearchLookUpEdit { fieldName = "EPI_VCH_DIRECCION", caption = "Descripcion2" }
            });
            BaseForm.CargarSearchLookUpEdit(searchLookUpCliente, BLEntidad.GetListEntidadPorTipo(0,Convert.ToInt32(eTipoEntidad.Cliente),0,0), lstSLUECliente);

            List<BESearchLookUpEdit> lstSLUETipoDocumentoContable = new List<BESearchLookUpEdit>();
            lstSLUETipoDocumentoContable.AddRange(new BESearchLookUpEdit[] {
                new BESearchLookUpEdit { fieldName = "EPI_INT_IDTIPODOCUMENTOCONTABLE", caption = "Id" },
                new BESearchLookUpEdit { fieldName = "EPI_VCH_NOMBREDOCUMENTO", caption = "Descripcion" },
                new BESearchLookUpEdit { fieldName = "EPI_INT_IDTIPODOCUMENTOCONTABLESERIES", caption = "Descripcion" }

            });
            BaseForm.CargarSearchLookUpEdit(searchLookUpTipoDocumento, BLTipoDocumentoContable.GetTipoDocumentoContablePreferida(),lstSLUETipoDocumentoContable);

        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gridViewDetalle.AddNewRow();

            gridViewDetalle.SetRowCellValue(gridViewDetalle.FocusedRowHandle, "value4", "3");
            gridViewDetalle.SetRowCellValue(gridViewDetalle.FocusedRowHandle, "value5", "Despcition");
            gridViewDetalle.SetRowCellValue(gridViewDetalle.FocusedRowHandle, "value6", "35");
        }

        private void gridControl2_ProcessGridKey(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:

                    gridViewDetalle.DeleteRow(gridViewDetalle.FocusedRowHandle);
                    break;
                default:
                    break;
            }
        }

        private void gridView2_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "EPI_VCH_DESCRIPCION") return;
            GridView gv = sender as GridView;
            decimal subTotal = 0;
            decimal igv = 0;
            decimal cant = Convert.ToDecimal(gv.GetRowCellValue(e.RowHandle, gv.Columns["EPI_NUM_CANTIDAD"]));
            decimal Precio = Convert.ToDecimal(gv.GetRowCellValue(e.RowHandle, gv.Columns["EPI_NUM_VALORUNITARIO"]));
            
            subTotal = cant * Precio;

            igv = subTotal * (BaseForm.VariablesGlobales.GetImpuesto(Convert.ToInt32(gv.GetRowCellValue(e.RowHandle, gv.Columns["EPI_INT_IDIMPUESTO"]))));

            gv.SetRowCellValue(e.RowHandle, "EPI_NUM_SUBTOTAL", Math.Round(Convert.ToDecimal(subTotal), 2, MidpointRounding.AwayFromZero));
            gv.SetRowCellValue(e.RowHandle, "EPI_NUM_IGVVENTA", Math.Round(Convert.ToDecimal(igv), 2, MidpointRounding.AwayFromZero));
            gv.SetRowCellValue(e.RowHandle, "EPI_NUM_IMPORTETOTAL", Math.Round(Convert.ToDecimal(subTotal + igv), 2, MidpointRounding.AwayFromZero));

            gv.UpdateCurrentRow();

            CalcularTotales();

        }

        private void CalcularTotales()
        {
            decimal subTotal = 0;
            decimal igv = 0;
            decimal total = 0;

            for (int i = 0; i < gridViewDetalle.RowCount; i++)
            {
                subTotal += Convert.ToDecimal(gridViewDetalle.GetRowCellValue(i, "EPI_NUM_SUBTOTAL"));
                igv += Convert.ToDecimal(gridViewDetalle.GetRowCellValue(i, "EPI_NUM_IGVVENTA"));
                total += Convert.ToDecimal(gridViewDetalle.GetRowCellValue(i, "EPI_NUM_IMPORTETOTAL"));
            }

            //igv = subTotal * (decimal)0.18;
            lblBaseImponible.Text = subTotal.ToString();
            lblIgv.Text = Convert.ToString(igv);
            lblImporteTotal.Text = Convert.ToString(total);
        }

        private void textEdit2_KeyUp(object sender, KeyEventArgs e)
        {
            List<BEProducto> olProductos = new List<BEProducto>();
            olProductos = BLProducto.ListarProductos(0, textEdit2.Text);
            BaseForm.CargarGridControl(gridControl1, olProductos);
            
        }

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.RowHandle >= 0 && e.Clicks == 2)
            {
                bool existe = false;
                decimal cant = 0;
                decimal Precio = 0;
                decimal subTotal = 0;
                decimal igv = 0;
                for (int i = 0; i < gridViewDetalle.RowCount; i++)
                {
                    cant = 0;
                    Precio = 0;
                    if (Convert.ToInt32(gridViewDetalle.GetRowCellValue(i, "EPI_INT_IDPRODUCTO")) == Convert.ToInt32(gridViewProducto.GetRowCellValue(e.RowHandle, "EPI_INT_IDPRODUCTO")))
                    {

                        cant = Convert.ToInt32(gridViewDetalle.GetRowCellValue(i, "EPI_NUM_CANTIDAD")) + 1;
                        Precio = Convert.ToDecimal(gridViewDetalle.GetRowCellValue(i, "EPI_NUM_VALORUNITARIO"));
                        subTotal = Precio * cant;
                        igv = subTotal * 0.18M;
                        
                        gridViewDetalle.SetRowCellValue(i, "EPI_NUM_CANTIDAD", cant);
                        gridViewDetalle.SetRowCellValue(i, "EPI_NUM_SUBTOTAL", Math.Round(Convert.ToDecimal(subTotal), 2, MidpointRounding.AwayFromZero));
                        gridViewDetalle.SetRowCellValue(i, "EPI_NUM_IGVVENTA", Math.Round(Convert.ToDecimal(igv), 2, MidpointRounding.AwayFromZero));
                        gridViewDetalle.SetRowCellValue(i, "EPI_NUM_IMPORTETOTAL", Math.Round(Convert.ToDecimal(subTotal + igv), 2, MidpointRounding.AwayFromZero));


                        gridViewDetalle.UpdateCurrentRow();
                        CalcularTotales();
                        existe = true;
                    }
                       
                }

                if (!existe)
                {
                    gridViewDetalle.AddNewRow();
                    gridViewDetalle.SetRowCellValue(gridViewDetalle.FocusedRowHandle, "EPI_NUM_IDFACTURADETALLE", "0");
                    gridViewDetalle.SetRowCellValue(gridViewDetalle.FocusedRowHandle, "EPI_INT_IDPRODUCTO", gridViewProducto.GetRowCellValue(e.RowHandle, "EPI_INT_IDPRODUCTO"));
                    gridViewDetalle.SetRowCellValue(gridViewDetalle.FocusedRowHandle, "EPI_NUM_CANTIDAD", "1");
                    gridViewDetalle.SetRowCellValue(gridViewDetalle.FocusedRowHandle, "EPI_VCH_DESCRIPCION", gridViewProducto.GetRowCellValue(e.RowHandle, "EPI_VCH_DESCRIPCION"));
                    gridViewDetalle.SetRowCellValue(gridViewDetalle.FocusedRowHandle, "EPI_NUM_VALORUNITARIO", gridViewProducto.GetRowCellValue(e.RowHandle, "EPI_NUM_PRECIOVENTA"));
                    gridViewDetalle.SetRowCellValue(gridViewDetalle.FocusedRowHandle, "EPI_INT_IDUNIDADMEDIDA", gridViewProducto.GetRowCellValue(e.RowHandle, "EPI_INT_IDUNIDADMEDIDA"));
                    gridViewDetalle.SetRowCellValue(gridViewDetalle.FocusedRowHandle, "EPI_VCH_UNIDADMEDIDA", gridViewProducto.GetRowCellValue(e.RowHandle, "EPI_VCH_UNIDADMEDIDA"));
                    gridViewDetalle.SetRowCellValue(gridViewDetalle.FocusedRowHandle, "EPI_INT_IDIMPUESTO", gridViewProducto.GetRowCellValue(e.RowHandle, "EPI_INT_IDIMPUESTO"));
                }
            }
        }

        private void searchLookUpCliente_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit currentEditor = (sender as SearchLookUpEdit);
            int iCurrentIndex = searchLookUpCliente.Properties.GetIndexByKeyValue(searchLookUpCliente.EditValue);
            EPI_SP_LISTAENTIDADPORTIPOResult findedRecord = (currentEditor.Properties.DataSource as BindingSource).List[iCurrentIndex] as EPI_SP_LISTAENTIDADPORTIPOResult;

            txtDatosEntidad.Text = findedRecord.EPI_VCH_NUMERODOCUMENTO + Environment.NewLine+ findedRecord.EPI_VCH_RAZONSOCIAL1 + Environment.NewLine + findedRecord.EPI_VCH_DIRECCION;


        }

        private void searchLookUpTipoDocumento_EditValueChanged(object sender, EventArgs e)
        {
            
            SearchLookUpEdit currentEditor = (sender as SearchLookUpEdit);
            int iCurrentIndex = currentEditor.Properties.GetIndexByKeyValue(currentEditor.EditValue);
            BETipoDocumentoContable findedRecord = (currentEditor.Properties.DataSource as BindingSource).List[iCurrentIndex] as BETipoDocumentoContable;

            int idTipoDocSerie = Convert.ToInt32(findedRecord.EPI_INT_IDTIPODOCUMENTOCONTABLESERIES);
            BETipoDocumentoContable oSerie = BLTipoDocumentoContable.GetTipoDocumentoContableSerie(idTipoDocSerie);

            if (oSerie != null)
            {
                txtSerie.Text = oSerie.EPI_VCH_SERIE;
                txtCorrelativo.Text = oSerie.EPI_INT_CORRELATIVO.ToString().PadLeft(7,'0');
            }
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            try
            {
                StringBuilder sb = ValidaDatosFactura();
                if (!sb.ToString().Equals(""))
                {
                    XtraMessageBox.Show(sb.ToString(), "ERRORES A CORREGIR");
                    return;
                }



                TBL_EPI_FACTURA oFac = new TBL_EPI_FACTURA();

                oFac.EPI_INT_IDTIPODOCUMENTOCONTABLE = Convert.ToInt32(searchLookUpTipoDocumento.EditValue);
                oFac.EPI_VCH_SERIEFACTURA = this.txtSerie.Text;
                oFac.EPI_VCH_NUMERODOCUMENTO = this.txtCorrelativo.Text;

                oFac.EPI_INT_IDMONEDA = Convert.ToInt32(searchLookUpMoneda.EditValue);
                oFac.EPI_INT_IDTIPOPAGO = Convert.ToInt32(searchLookUpTipoPago.EditValue);

                oFac.EPI_DAT_FECHACREA = Convert.ToDateTime(deFechaEmision.EditValue);
                oFac.EPI_DAT_FECHADESDE = Convert.ToDateTime(deFechaEmision.EditValue);
                oFac.EPI_DAT_FECHAHASTA = Convert.ToDateTime(deFechaVencimiento.EditValue);
                oFac.EPI_INT_PERSONAFACTURAIDENTIDAD = Convert.ToInt32(searchLookUpCliente.EditValue);
                oFac.EPI_VCH_OBSERVACIONES = txtObservaciones.Text;
                oFac.EPI_VCH_REFERENCIA1 = txtReferencia1.Text;
                oFac.EPI_VCH_REFERENCIA2 = txtReferencia2.Text;
                oFac.EPI_NUM_BASEIPONIBLE = Convert.ToDecimal(lblBaseImponible.Text == "" ? "0" : lblBaseImponible.Text);
                //oFac.EPI_NUM_BASEEXPONERADO = 
                oFac.EPI_NUM_IMPUESTO = Convert.ToDecimal(lblIgv.Text == "" ? "0" : lblIgv.Text);
                oFac.EPI_NUM_IMPORTETOTAL = Convert.ToDecimal(lblImporteTotal.Text == "" ? "0" : lblImporteTotal.Text);
                oFac.EPI_VCH_TOTALENLETRAS = new BaseForm().DevuelveNumeroEnLetras(oFac.EPI_NUM_IMPORTETOTAL.ToString(), "PEN");
                //oFac.EPI_NUM_TIPOVENTA
                oFac.EPI_BIT_ACTIVO = true;
                oFac.EPI_BIT_ANULADA = false;
                oFac.EPI_BIT_IMPRESA = false;

                List<TBL_EPI_FACTURADETALLE> olFacDetalle = new List<TBL_EPI_FACTURADETALLE>();
                TBL_EPI_FACTURADETALLE oFacDetalle = new TBL_EPI_FACTURADETALLE();

                for (int i = 0; i < gridViewDetalle.RowCount; i++)
                {
                    oFacDetalle = new TBL_EPI_FACTURADETALLE();
                    //oFacDetalle.EPI_INT_ITEM
                    oFacDetalle.EPI_NUM_CANTIDAD = Convert.ToDecimal(gridViewDetalle.GetRowCellValue(i, "EPI_NUM_CANTIDAD"));

                    oFacDetalle.EPI_INT_IDPRODUCTO = Convert.ToInt32(gridViewDetalle.GetRowCellValue(i, "EPI_INT_IDPRODUCTO"));
                    oFacDetalle.EPI_VCH_DESCRIPCION = gridViewDetalle.GetRowCellValue(i, "EPI_VCH_DESCRIPCION").ToString();
                    oFacDetalle.EPI_INT_IDIMPUESTO = Convert.ToInt32(gridViewDetalle.GetRowCellValue(i, "EPI_INT_IDIMPUESTO").ToString());
                    oFacDetalle.EPI_NUM_VALORUNITARIO = Math.Round(Convert.ToDecimal(gridViewDetalle.GetRowCellValue(i, "EPI_NUM_VALORUNITARIO")), 2, MidpointRounding.AwayFromZero);
                    oFacDetalle.EPI_NUM_IGVVENTA = Math.Round(Convert.ToDecimal(gridViewDetalle.GetRowCellValue(i, "EPI_NUM_IGVVENTA")), 2, MidpointRounding.AwayFromZero);
                    oFacDetalle.EPI_NUM_SUBTOTAL = Math.Round(Convert.ToDecimal(gridViewDetalle.GetRowCellValue(i, "EPI_NUM_SUBTOTAL")), 2, MidpointRounding.AwayFromZero);
                    oFacDetalle.EPI_NUM_IMPORTETOTAL = Math.Round(Convert.ToDecimal(gridViewDetalle.GetRowCellValue(i, "EPI_NUM_IMPORTETOTAL")), 2, MidpointRounding.AwayFromZero);
                    oFacDetalle.EPI_BIT_ACTIVO = true;
                    olFacDetalle.Add(oFacDetalle);

                }

                if (IdFactura == 0)
                {
                    oFac.EPI_DAT_FECHACREA = DateTime.Now;
                    oFac.EPI_INT_IDUSUARIOCREA = BaseForm.VariablesGlobales.IdUsuario;
                    XtraMessageBox.Show(BLFacturacion.InsertaFactura(oFac, olFacDetalle), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();

                }
                else
                {
                    oFac.EPI_DAT_FECHAMODIFICA = DateTime.Now;
                    oFac.EPI_INT_IDUSUARIOMODIFICA = BaseForm.VariablesGlobales.IdUsuario;
                    oFac.EPI_NUM_IDFACTURA = IdFactura;

                    XtraMessageBox.Show(BLFacturacion.ActualizaFactura(oFac, olFacDetalle), "SISTEMAS");
                    this.Close();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        private StringBuilder ValidaDatosFactura()
        {
            StringBuilder sb = new StringBuilder();

            if (searchLookUpTipoDocumento.Properties.DataSource == null || Convert.ToInt32(searchLookUpTipoDocumento.EditValue) == 0) { sb.AppendLine("Debe agregar Tipo de Documento"); }
            if (this.txtSerie.EditValue == null || this.txtSerie.Text.Equals("")) { sb.AppendLine("Debe agregar la serie del documento"); }
            if ((this.txtCorrelativo.EditValue == null || this.txtCorrelativo.Text.Equals(""))) { sb.AppendLine("Debe agregar el numero de documento"); }
            if (searchLookUpMoneda.Properties.DataSource == null || Convert.ToInt32(searchLookUpMoneda.EditValue) == 0) { sb.AppendLine("Debe agregar Tipo de Moneda"); }
            if (searchLookUpTipoPago.Properties.DataSource == null || Convert.ToInt32(searchLookUpTipoPago.EditValue) == 0) { sb.AppendLine("Debe agregar Tipo de Pago"); }
            if (this.deFechaEmision.EditValue == null) { sb.AppendLine("Debe agregar una fecha de emision válida"); }
            //if (this.deFechaVencimiento.EditValue == null) { sb.AppendLine("Debe agregar una fecha de vencimiento válida"); }
            if (searchLookUpCliente.Properties.DataSource == null || Convert.ToInt32(searchLookUpCliente.EditValue) == 0) { sb.AppendLine("Debe agregar la persona a facturar"); }
            //if (Convert.ToInt32(slueCentroCosto.EditValue) == 0) { sb.AppendLine("Debe agregar el centro de costo"); }

            if (gridViewDetalle.RowCount == 0) { sb.AppendLine("Debe agregar el detalle a facturar"); }
            return sb;
        }

        private void btnGuardarImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraReport1 XReport = new XtraReport1();
            foreach (Parameter p in XReport.Parameters)
            {
                p.Visible = false;
            }


            List<EPI_SP_LISTARFACTURAEDICIONResult> lstFactura = BLFacturacion.GetListaFacturaEdicion(IdFactura);

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
                                                            EPI_BIT_ACTIVO = df.EPI_BIT_ACTIVO ?? false
                                                        }).ToList();

            XReport.InitData(lstDetalleFactura);

            ReportPrintTool tool = new ReportPrintTool(XReport);
            //tool.Print();
            tool.ShowPreview();

        }
    }
}