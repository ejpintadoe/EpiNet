using DevExpress.XtraEditors;
using EpiNet.Win.App_Code.BE;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EpiNet.Win.App_Code.DAO
{
    class DAOProducto
    {
        internal static TBL_EPI_PRODUCTO obtieneProducto(int idProducto)
        {
            try
            {
                TBL_EPI_PRODUCTO oProducto = new TBL_EPI_PRODUCTO();
                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {

                    oProducto = (from pro in db.TBL_EPI_PRODUCTO
                                 where pro.EPI_INT_IDPRODUCTO == idProducto &&
                                 pro.EPI_BIT_ACTIVO == true

                                 select pro).FirstOrDefault();

                }

                return oProducto;

            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message.ToString() + " (COMUNICAR A SISTEMAS)", "ERROR");
                return null;
            }
        }

        internal static List<BEProducto> ListarProductos(int iD, string criterio)
        {

            try
            {
                List<BEProducto> olProd = new List<BEProducto>();

                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {
                    olProd = (from p in db.TBL_EPI_PRODUCTO
                              where (p.EPI_INT_IDPRODUCTO == iD || iD == 0)
                              && (p.EPI_VCH_CODIGOPRODUCTO.ToUpper().Contains(criterio.ToUpper())
                                 || p.EPI_VCH_DESCRIPCION.ToUpper().Contains(criterio.ToUpper()))
                              select new BEProducto
                              {
                                  EPI_INT_IDPRODUCTO = p.EPI_INT_IDPRODUCTO,
                                  EPI_VCH_CODIGOPRODUCTO = p.EPI_VCH_CODIGOPRODUCTO,
                                  EPI_VCH_DESCRIPCION = p.EPI_VCH_DESCRIPCION,
                                  EPI_VCH_DESCRIPCIONDETALLADA = p.EPI_VCH_DESCRIPCIONDETALLADA,
                                  EPI_VCH_COMENTARIO = p.EPI_VCH_COMENTARIO,
                                  EPI_NUM_PRECIOVENTA = p.EPI_NUM_PRECIOVENTA ?? 0,
                                  EPI_INT_IDUNIDADMEDIDA = p.EPI_INT_IDUNIDADMEDIDA ?? 0,
                                  EPI_VCH_UNIDADMEDIDA = (from m in db.TBL_EPI_UNIDADMEDIDA where m.EPI_INT_IDUNIDADMEDIDA == p.EPI_INT_IDUNIDADMEDIDA select m.EPI_VCH_SIMBOLO).FirstOrDefault() ?? "",
                                  EPI_INT_IDIMPUESTO = p.EPI_INT_IDIMPUESTO ?? 0
                                  
                                
                            }).ToList();

                }

                return olProd;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString() + " (COMUNICAR A SISTEMAS)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<BEProducto>();
            }
        }

        internal static eResultado Actualizar(TBL_EPI_PRODUCTO oProducto)
        {
            DbTransaction dbTrans = null;
            try
            {

                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {
                    db.Connection.Open();
                    dbTrans = db.Connection.BeginTransaction();
                    db.Transaction = dbTrans;

                    TBL_EPI_PRODUCTO oProductoActual = new TBL_EPI_PRODUCTO();

                    oProductoActual = (from pro in db.TBL_EPI_PRODUCTO
                                       where pro.EPI_INT_IDPRODUCTO == oProducto.EPI_INT_IDPRODUCTO
                                       select pro).FirstOrDefault();


                    oProductoActual.EPI_VCH_CODIGOPRODUCTO = oProducto.EPI_VCH_CODIGOPRODUCTO;
                    oProductoActual.EPI_BIT_INVENTARIABLE = oProducto.EPI_BIT_INVENTARIABLE;

                    oProductoActual.EPI_VCH_DESCRIPCION = oProducto.EPI_VCH_DESCRIPCION;
                    oProductoActual.EPI_VCH_DESCRIPCIONDETALLADA = oProducto.EPI_VCH_DESCRIPCIONDETALLADA;
                    oProductoActual.EPI_VCH_COMENTARIO = oProducto.EPI_VCH_COMENTARIO;

                    oProductoActual.EPI_INT_IDCUENTACONTABLE = oProducto.EPI_INT_IDCUENTACONTABLE;
                    oProductoActual.EPI_INT_IDIMPUESTO = oProducto.EPI_INT_IDIMPUESTO;
                    oProductoActual.EPI_NUM_PRECIOVENTA = oProducto.EPI_NUM_PRECIOVENTA;

                    oProductoActual.EPI_VCH_CODIGOBARRAINTERNO = oProducto.EPI_VCH_CODIGOBARRAINTERNO;
                    oProductoActual.EPI_VCH_CODIGOBARRAPROVEEDOR = oProducto.EPI_VCH_CODIGOBARRAPROVEEDOR;
                    oProductoActual.EPI_INT_IDUNIDADMEDIDA = oProducto.EPI_INT_IDUNIDADMEDIDA;
                    oProductoActual.EPI_INT_IDPROCEDENCIA = oProducto.EPI_INT_IDPROCEDENCIA;
                    oProductoActual.EPI_NUM_STOCKMIN = oProducto.EPI_NUM_STOCKMIN;
                    oProductoActual.EPI_NUM_STOCKMAX = oProducto.EPI_NUM_STOCKMAX;
                    oProductoActual.EPI_INT_IDMONEDACOMPRA = oProducto.EPI_INT_IDMONEDACOMPRA;
                    oProductoActual.EPI_NUM_PRECIOCOMPRA = oProducto.EPI_NUM_PRECIOCOMPRA;
                    oProductoActual.EPI_NUM_SALDOSTOCK = oProducto.EPI_NUM_SALDOSTOCK;
                    oProductoActual.EPI_NUM_SALDODISPONIBLEVENTA = oProducto.EPI_NUM_SALDODISPONIBLEVENTA;

                    oProductoActual.EPI_INT_IDTIPOUSO = oProducto.EPI_INT_IDTIPOUSO;
                    oProductoActual.EPI_INT_IDMARCA = oProducto.EPI_INT_IDMARCA;
                    oProductoActual.EPI_INT_IDTIPOEXISTENCIA = oProducto.EPI_INT_IDTIPOEXISTENCIA;
                    oProductoActual.EPI_INT_IDCATEGORIA = oProducto.EPI_INT_IDCATEGORIA;
                    //oProductoActual.EPI_DAT_FECHAMODIFICACION = DateTime.Now;
                    db.SubmitChanges();

                    dbTrans.Commit();
                }

                return eResultado.Correcto;

            }
            catch (Exception ex)
            {
                dbTrans.Rollback();
                XtraMessageBox.Show(ex.Message.ToString() + " (COMUNICAR A SISTEMAS)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return eResultado.Error;
            }
        }

        internal static eResultado Insertar(TBL_EPI_PRODUCTO oProducto)
        {
            DbTransaction dbTrans = null;
            try
            {
                using (DataClassEpiNetDataContext dc = new DataClassEpiNetDataContext())
                {
                    dc.Connection.Open();
                    dbTrans = dc.Connection.BeginTransaction();
                    dc.Transaction = dbTrans;

                    dc.TBL_EPI_PRODUCTO.InsertOnSubmit(oProducto);
                    dc.SubmitChanges();

                    dbTrans.Commit();
                }

                return eResultado.Correcto;
            }
            catch (Exception ex)
            {
                dbTrans.Rollback();
                XtraMessageBox.Show(ex.ToString() + " Comunicar a Sistemas", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return eResultado.Error;
            }
        }
    }
}
