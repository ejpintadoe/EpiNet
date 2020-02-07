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

namespace EpiNet.Win.Ventas.Producto
{
    public partial class frmProductoEditar : DevExpress.XtraEditors.XtraForm
    {
        public int IdProducto = 0;
        public frmProductoEditar()
        {
            InitializeComponent();
            InicializaControles();
        }
        public frmProductoEditar(int idProducto)
        {
            InitializeComponent();
            InicializaControles();

            this.IdProducto = idProducto;

            if (IdProducto > 0)
            {
                TBL_EPI_PRODUCTO oProd = BLProducto.obtieneProducto(IdProducto);

                chkInventariable.Checked = Convert.ToBoolean(oProd.EPI_BIT_INVENTARIABLE);

                txtCodigoProducto.Text = oProd.EPI_VCH_CODIGOPRODUCTO;
                chkInventariable.EditValue = oProd.EPI_BIT_INVENTARIABLE;

                txtDescripcion.Text = oProd.EPI_VCH_DESCRIPCION;
                txtDescripcionDetallada.Text = oProd.EPI_VCH_DESCRIPCIONDETALLADA;
                txtComentario.Text = oProd.EPI_VCH_COMENTARIO;

                lookUpCuentaContable.EditValue = oProd.EPI_INT_IDCUENTACONTABLE;
                searchLookUpImpuesto.EditValue = oProd.EPI_INT_IDIMPUESTO;
                txtPrecioVenta.EditValue = oProd.EPI_NUM_PRECIOVENTA;

                //Clasificacion
                searchLookUpTipoUso.EditValue = oProd.EPI_INT_IDTIPOUSO;
                searchLookUpMarca.EditValue = oProd.EPI_INT_IDMARCA;
                searchLookUpTipoExistencia.EditValue = oProd.EPI_INT_IDTIPOEXISTENCIA;



                txtCodigoBarraInterno.Text = oProd.EPI_VCH_CODIGOBARRAINTERNO;
                txtCodigoBarraProveedor.Text = oProd.EPI_VCH_CODIGOBARRAPROVEEDOR;
                searchLookUpUnidadMedida.EditValue = oProd.EPI_INT_IDUNIDADMEDIDA;
                searchLookUpProcedencia.EditValue = oProd.EPI_INT_IDPROCEDENCIA;

                txtStockMin.EditValue = oProd.EPI_NUM_STOCKMIN;
                txtStockMax.EditValue = oProd.EPI_NUM_STOCKMAX;

                searchLookUpMonedaCompra.EditValue = oProd.EPI_INT_IDMONEDACOMPRA;
                txtPrecioCompra.EditValue = oProd.EPI_NUM_PRECIOCOMPRA;

                
                txtSaldoStock.EditValue = oProd.EPI_NUM_SALDOSTOCK;
                txtSaldoDisponibleVenta.EditValue = oProd.EPI_NUM_SALDODISPONIBLEVENTA;

            }

        }

        private void InicializaControles()
        {

            List<BESearchLookUpEdit> lstSLUEUnidadMedida = new List<BESearchLookUpEdit>();
            lstSLUEUnidadMedida.AddRange(new BESearchLookUpEdit[] {
                new BESearchLookUpEdit { fieldName = "EPI_INT_IDUNIDADMEDIDA", caption = "Id" },
                new BESearchLookUpEdit { fieldName = "EPI_VCH_DESCRIPCION", caption = "Descripcion" }
            });
            BaseForm.CargarSearchLookUpEdit(searchLookUpUnidadMedida, BLUnidadMedida.ListarUnidadMedida(0,""), lstSLUEUnidadMedida);

            List<BESearchLookUpEdit> lstSLUEImpuesto = new List<BESearchLookUpEdit>();
            lstSLUEImpuesto.AddRange(new BESearchLookUpEdit[] {
                new BESearchLookUpEdit { fieldName = "EPI_INT_IDIMPUESTO", caption = "Id" },
                new BESearchLookUpEdit { fieldName = "EPI_VCH_NOMBRE", caption = "Descripcion" }
            });
            BaseForm.CargarSearchLookUpEdit(searchLookUpImpuesto, BLImpuesto.ListarImpuesto(0,"") , lstSLUEImpuesto);


            List<BESearchLookUpEdit> lstSLUEMoneda = new List<BESearchLookUpEdit>();

            lstSLUEMoneda.AddRange(new BESearchLookUpEdit[]
            {
                new BESearchLookUpEdit { fieldName = "EPI_INT_IDMONEDA", caption = "Id" },
                new BESearchLookUpEdit { fieldName = "EPI_VCH_NOMBRE", caption = "Descripcion"},
                new BESearchLookUpEdit { fieldName = "EPI_VCH_SIMBOLO", caption = "Simbolo"}
            });

            BaseForm.CargarSearchLookUpEdit(searchLookUpMonedaCompra, BLMoneda.ListarMoneda(0, ""), lstSLUEMoneda);

            List<BESearchLookUpEdit> lstSLUEProcedencia = new List<BESearchLookUpEdit>();
            lstSLUEProcedencia.AddRange(new BESearchLookUpEdit[] {
                new BESearchLookUpEdit { fieldName = "EPI_INT_IDGENERICA", caption = "Id" },
                new BESearchLookUpEdit { fieldName = "EPI_VCH_CAMPO2", caption = "Descripcion" }
            });
            BaseForm.CargarSearchLookUpEdit(searchLookUpProcedencia, BLGenerica.ListarGenerica(eTblGen.PROCEDENCIA.ToString()), lstSLUEProcedencia);


            List<BESearchLookUpEdit> lstSLUEMarca = new List<BESearchLookUpEdit>();
            lstSLUEMarca.AddRange(new BESearchLookUpEdit[] {
                new BESearchLookUpEdit { fieldName = "EPI_INT_IDMARCA", caption = "Id" },
                new BESearchLookUpEdit { fieldName = "EPI_VCH_DESCRIPCION", caption = "Descripcion" }
            });
            BaseForm.CargarSearchLookUpEdit(searchLookUpMarca, BLMarca.ListarMarca(0, ""), lstSLUEMarca);


            List<BESearchLookUpEdit> lstSLUETipoExistencia = new List<BESearchLookUpEdit>();
            lstSLUETipoExistencia.AddRange(new BESearchLookUpEdit[] {
                new BESearchLookUpEdit { fieldName = "EPI_INT_IDTIPOEXISTENCIA", caption = "Id" },
                new BESearchLookUpEdit { fieldName = "EPI_VCH_DESCRIPCION", caption = "Descripcion" }
            });
            BaseForm.CargarSearchLookUpEdit(searchLookUpTipoExistencia, BLTipoExistencia.ListarTipoExistencia(0, ""), lstSLUETipoExistencia);

            List<BESearchLookUpEdit> lstSLUETipoUso = new List<BESearchLookUpEdit>();
            lstSLUETipoUso.AddRange(new BESearchLookUpEdit[] {
                new BESearchLookUpEdit { fieldName = "EPI_INT_IDGENERICA", caption = "Id" },
                new BESearchLookUpEdit { fieldName = "EPI_VCH_CAMPO2", caption = "Descripcion" }
            });
            BaseForm.CargarSearchLookUpEdit(searchLookUpTipoUso, BLGenerica.ListarGenerica(eTblGen.TIPOUSO.ToString()), lstSLUETipoUso);


            List<BESearchLookUpEdit> lstSLUECategoria = new List<BESearchLookUpEdit>();
            lstSLUECategoria.AddRange(new BESearchLookUpEdit[] {
                new BESearchLookUpEdit { fieldName = "EPI_INT_IDCATEGORIA", caption = "Id" },
                new BESearchLookUpEdit { fieldName = "EPI_VCH_DESCRIPCION", caption = "Descripcion" }
            });
            BaseForm.CargarSearchLookUpEdit(searchLookUpCategoria, BLCategoria.ListarCategoria(0, ""),lstSLUECategoria);


        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                TBL_EPI_PRODUCTO oProducto = new TBL_EPI_PRODUCTO();
                oProducto.EPI_BIT_INVENTARIABLE = chkInventariable.Checked;
                oProducto.EPI_VCH_CODIGOPRODUCTO = txtCodigoProducto.Text;
                oProducto.EPI_VCH_DESCRIPCION = txtDescripcion.Text;
                oProducto.EPI_VCH_DESCRIPCIONDETALLADA = txtDescripcionDetallada.Text;
                oProducto.EPI_VCH_COMENTARIO = txtComentario.Text;

                if (lookUpCuentaContable.EditValue != null)
                    oProducto.EPI_INT_IDCUENTACONTABLE = Convert.ToInt32(lookUpCuentaContable.EditValue);

                if (searchLookUpImpuesto.EditValue != null)
                    oProducto.EPI_INT_IDIMPUESTO = Convert.ToInt32(searchLookUpImpuesto.EditValue);

                oProducto.EPI_NUM_PRECIOVENTA = Convert.ToDecimal(txtPrecioVenta.EditValue);

                //Inventario
                oProducto.EPI_VCH_CODIGOBARRAINTERNO = txtCodigoBarraInterno.Text;
                oProducto.EPI_VCH_CODIGOBARRAPROVEEDOR = txtCodigoBarraProveedor.Text;
                
                if (searchLookUpUnidadMedida.EditValue != null)
                    oProducto.EPI_INT_IDUNIDADMEDIDA = Convert.ToInt32(searchLookUpUnidadMedida.EditValue);

                if (searchLookUpProcedencia.EditValue != null)
                    oProducto.EPI_INT_IDPROCEDENCIA = Convert.ToInt32(searchLookUpProcedencia.EditValue);

                
                oProducto.EPI_NUM_STOCKMIN = Convert.ToInt32(txtStockMin.EditValue);
                oProducto.EPI_NUM_STOCKMAX = Convert.ToInt32(txtStockMax.EditValue);

                if (searchLookUpMonedaCompra.EditValue != null)
                    oProducto.EPI_INT_IDMONEDACOMPRA = Convert.ToInt32(searchLookUpMonedaCompra.EditValue);

                oProducto.EPI_NUM_PRECIOCOMPRA = Convert.ToDecimal(txtPrecioCompra.EditValue);

                oProducto.EPI_NUM_SALDOSTOCK = Convert.ToDecimal(txtSaldoStock.EditValue);
                oProducto.EPI_NUM_SALDODISPONIBLEVENTA = Convert.ToDecimal(txtSaldoDisponibleVenta.EditValue);

                if (searchLookUpTipoUso.EditValue != null)
                    oProducto.EPI_INT_IDTIPOUSO = Convert.ToInt32(searchLookUpTipoUso.EditValue);

                if (searchLookUpMarca.EditValue != null)
                    oProducto.EPI_INT_IDMARCA = Convert.ToInt32(searchLookUpMarca.EditValue);

                if (searchLookUpTipoExistencia.EditValue != null)
                    oProducto.EPI_INT_IDTIPOEXISTENCIA = Convert.ToInt32(searchLookUpTipoExistencia.EditValue);

                if (searchLookUpCategoria.EditValue != null)
                    oProducto.EPI_INT_IDCATEGORIA = Convert.ToInt32(searchLookUpCategoria.EditValue);

                eResultado Res;

                if (IdProducto == 0)
                {
                    oProducto.EPI_BIT_ACTIVO = true;
                    //oProducto.EPI_DAT_FECHACREACION = DateTime.Now;
                    //oProducto.EPI_INT_USUARIOCREA = BaseForm.VariablesGlobales.IdUsuario;


                    Res = BLProducto.Insertar(oProducto);

                    if (Res == eResultado.Correcto)
                    {
                        this.IdProducto = oProducto.EPI_INT_IDPRODUCTO;

                        XtraMessageBox.Show("Producto se insertó correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    oProducto.EPI_INT_IDPRODUCTO = this.IdProducto;
                    //oProducto.EPI_INT_USUARIOMODIFICA = BaseForm.VariablesGlobales.IdUsuario;
                    //oProducto.EPI_DAT_FECHAMODIFICACION = DateTime.Now;

                    Res = BLProducto.Actualizar(oProducto);

                    if (Res == eResultado.Correcto)
                    {

                        XtraMessageBox.Show("Producto se Actualizó correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void panelContainer4_Click(object sender, EventArgs e)
        {

        }
    }
}