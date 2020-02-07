using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiNet.Win.App_Code.DAO
{
    class DAOFacturacion
    {
        internal static string InsertaFactura(TBL_EPI_FACTURA oFac, List<TBL_EPI_FACTURADETALLE> olFacDetalle)
        {
            DbTransaction dbTrans = null;
            string mensaje = "";
            
            try
            {
                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {
                    db.Connection.Open();
                    dbTrans = db.Connection.BeginTransaction();
                    db.Transaction = dbTrans;

                    db.TBL_EPI_FACTURA.InsertOnSubmit(oFac);
                    db.SubmitChanges();
                    //DAOAuditoria.InsertaAuditoria(eTablaEPI.TBL_EPI_FACTURA, onFac, eTipoAccionBD.CREACION, BaseForm.VariablesGlobales.Miusuario.Usuario.EPI_INT_USUARIO, null, "", "");

                    foreach (TBL_EPI_FACTURADETALLE item in olFacDetalle)
                    {
                        item.EPI_NUM_IDFACTURA = oFac.EPI_NUM_IDFACTURA;
                        db.TBL_EPI_FACTURADETALLE.InsertOnSubmit(item);
                        db.SubmitChanges();
                        //DAOAuditoria.InsertaAuditoria(eTablaEPI.TBL_EPI_FACTURADETALLE, item, eTipoAccionBD.CREACION, BaseForm.VariablesGlobales.Miusuario.Usuario.EPI_INT_USUARIO, null, "", "");
                                                
                    }


                    TBL_EPI_TIPODOCUMENTOCONTABLESERIES objSerieDoc = new TBL_EPI_TIPODOCUMENTOCONTABLESERIES();
                    objSerieDoc = (from t in db.TBL_EPI_TIPODOCUMENTOCONTABLESERIES where t.EPI_INT_IDTIPODOCUMENTOCONTABLE == oFac.EPI_INT_IDTIPODOCUMENTOCONTABLE && t.EPI_VCH_SERIE == oFac.EPI_VCH_SERIEFACTURA && t.EPI_BIT_ACTIVO == true select t).FirstOrDefault();

                    if (objSerieDoc != null)
                    {
                        if (objSerieDoc.EPI_INT_CORRELATIVO == Convert.ToInt32(oFac.EPI_VCH_NUMERODOCUMENTO) - 1)
                        {
                            objSerieDoc.EPI_INT_CORRELATIVO = Convert.ToInt32(oFac.EPI_VCH_NUMERODOCUMENTO);
                            db.SubmitChanges();
                        }
                    }


                    dbTrans.Commit();
                    mensaje = "Se registro el documento: " + oFac.TBL_EPI_TIPODOCUMENTOCONTABLE.EPI_VCH_NOMBREDOCUMENTO + "(" + oFac.EPI_VCH_SERIEFACTURA + " - " + oFac.EPI_VCH_NUMERODOCUMENTO + ")";
                }
                return mensaje;
            }
            catch (Exception ex)
            {
                mensaje = "Ocurrio un problema : " + Environment.NewLine + ex.Message.ToString() + Environment.NewLine + " (COMUNICAR A SISTEMAS)";
                dbTrans.Rollback();
                return mensaje;
            }
        }

        internal static void MarcaImpresa(int idFactura, bool impresa)
        {
            DbTransaction dbTrans = null;
            try
            {
                TBL_EPI_FACTURA objFactura = new TBL_EPI_FACTURA();
                using (DataClassEpiNetDataContext dc = new DataClassEpiNetDataContext())
                {
                    dc.Connection.Open();
                    dbTrans = dc.Connection.BeginTransaction();
                    dc.Transaction = dbTrans;

                    objFactura = (from b in dc.TBL_EPI_FACTURA
                                  where b.EPI_BIT_ACTIVO == true && b.EPI_NUM_IDFACTURA == idFactura
                                  select b).SingleOrDefault();
                    if (objFactura != null)
                    {
                        objFactura.EPI_BIT_IMPRESA = impresa;
                        dc.SubmitChanges();
                        //DAOAuditoria.InsertaAuditoria(eTablaSLI.TBL_SLI_FACTURA, objFactura, eTipoAccionBD.MODIFICACION, BaseForm.VariablesGlobales.Miusuario.Usuario.SLI_INT_USUARIO, null, "", "");
                    }

                    dbTrans.Commit();
                }
            }
            catch (Exception ex)
            {
                dbTrans.Rollback();
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message.ToString() + " (COMUNICAR A SISTEMAS)", "ERROR");
            }
        }

        internal static string AnulaFactura(int idFactura)
        {
            string resultado = "";
            DbTransaction dbTrans = null;

            try
            {
                TBL_EPI_FACTURA objFactura = new TBL_EPI_FACTURA();
                List<TBL_EPI_FACTURADETALLE> olDetFac = new List<TBL_EPI_FACTURADETALLE>();
                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {
                    db.Connection.Open();
                    dbTrans = db.Connection.BeginTransaction();
                    db.Transaction = dbTrans;

                    olDetFac = (from r in db.TBL_EPI_FACTURADETALLE
                                    where r.EPI_NUM_IDFACTURA == idFactura && r.EPI_BIT_ACTIVO == true
                                    select r).ToList();
                    foreach (var item in olDetFac)
                    {
                        item.EPI_BIT_ACTIVO = false;
                        db.SubmitChanges();
                        //DAOAuditoria.InsertaAuditoria(eTablaSLI.TBL_SLI_FACTURADETALLE, item, eTipoAccionBD.ELIMINACION, BaseForm.VariablesGlobales.Miusuario.Usuario.SLI_INT_USUARIO, null, "", "");
                    }

                    objFactura = (from b in db.TBL_EPI_FACTURA
                                  where b.EPI_BIT_ACTIVO == true && b.EPI_NUM_IDFACTURA == idFactura
                                  select b).SingleOrDefault();
                    if (objFactura != null)
                    {
                        objFactura.EPI_BIT_ANULADA = true;
                        //objFactura.SLI_NUM_TOTAL = 0;
                        //objFactura.SLI_NUM_IMPUESTO = 0;
                        //objFactura.SLI_NUM_BASEEXPONERADO = 0;
                        //objFactura.SLI_NUM_BASEIPONIBLE = 0;
                        db.SubmitChanges();
                        //DAOAuditoria.InsertaAuditoria(eTablaSLI.TBL_SLI_FACTURA, objFactura, eTipoAccionBD.ANULAR, BaseForm.VariablesGlobales.Miusuario.Usuario.SLI_INT_USUARIO, null, "", "");
                    }

                    dbTrans.Commit();

                    resultado = "OK.. Se Anulo el documento " + objFactura.EPI_VCH_SERIEFACTURA + '-' + objFactura.EPI_VCH_NUMERODOCUMENTO;
                    return resultado;

                }
            }
            catch (Exception ex)
            {

                dbTrans.Rollback();
                //DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message.ToString() + " (COMUNICAR A SISTEMAS)", "ERROR");
                return "Ocurrio un problema, verificar con Sitemas " + Environment.NewLine + ex.Message.ToString();
            }
        }

        internal static TBL_EPI_FACTURA GetFactura(int idFactura)
        {
            try
            {
                TBL_EPI_FACTURA oFac = new TBL_EPI_FACTURA();
                using (DataClassEpiNetDataContext dc = new DataClassEpiNetDataContext())
                {
                    oFac = (from t in dc.TBL_EPI_FACTURA
                            where t.EPI_BIT_ACTIVO == true && t.EPI_NUM_IDFACTURA == Convert.ToDecimal(idFactura)
                            select t).FirstOrDefault();
                }
                return oFac;
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message.ToString() + " (COMUNICAR A SISTEMAS)", "ERROR");
                return null;
            }
        }

        internal static string ActualizaFactura(TBL_EPI_FACTURA oFac, List<TBL_EPI_FACTURADETALLE> olFacDetalle)
        {
            DbTransaction dbTrans = null;
            string mensaje = "";
            try
            {
                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {
                    db.Connection.Open();
                    dbTrans = db.Connection.BeginTransaction();
                    db.Transaction = dbTrans;

                    TBL_EPI_FACTURA objFact = (from t in db.TBL_EPI_FACTURA where t.EPI_NUM_IDFACTURA == oFac.EPI_NUM_IDFACTURA select t).FirstOrDefault();

                    if (objFact != null)
                    {
                        objFact.EPI_INT_IDMONEDA = oFac.EPI_INT_IDMONEDA;
                        objFact.EPI_DAT_FECHADESDE = oFac.EPI_DAT_FECHADESDE;
                        objFact.EPI_DAT_FECHAHASTA = oFac.EPI_DAT_FECHAHASTA;
                        objFact.EPI_INT_PERSONAFACTURAIDENTIDAD = oFac.EPI_INT_PERSONAFACTURAIDENTIDAD;
                        objFact.EPI_VCH_OBSERVACIONES = oFac.EPI_VCH_OBSERVACIONES;
                        objFact.EPI_VCH_REFERENCIA1 = oFac.EPI_VCH_REFERENCIA1;
                        objFact.EPI_VCH_REFERENCIA2 = oFac.EPI_VCH_REFERENCIA2;

                        objFact.EPI_NUM_BASEEXPONERADO = oFac.EPI_NUM_BASEEXPONERADO;
                        objFact.EPI_NUM_BASEIPONIBLE = oFac.EPI_NUM_BASEIPONIBLE;
                        objFact.EPI_NUM_IMPUESTO = oFac.EPI_NUM_IMPUESTO;
                        objFact.EPI_NUM_IMPORTETOTAL = oFac.EPI_NUM_IMPORTETOTAL;
                        objFact.EPI_NUM_TIPOVENTA = oFac.EPI_NUM_TIPOVENTA;
                        objFact.EPI_VCH_TOTALENLETRAS = oFac.EPI_VCH_TOTALENLETRAS;


                        db.SubmitChanges();
                        //DAOAuditoria.InsertaAuditoria(eTablaEPI.TBL_EPI_FACTURA, onFac, eTipoAccionBD.MODIFICACION, BaseForm.VariablesGlobales.Miusuario.Usuario.EPI_INT_USUARIO, null, "", "");
                        TBL_EPI_FACTURADETALLE oDet = new TBL_EPI_FACTURADETALLE();
                        List<TBL_EPI_FACTURADETALLE> lstDet = (from t in db.TBL_EPI_FACTURADETALLE where t.EPI_BIT_ACTIVO == true && t.EPI_NUM_IDFACTURA == oFac.EPI_NUM_IDFACTURA select t).ToList();

                        foreach (var item in lstDet)
                        {
                            item.EPI_BIT_ACTIVO = false;
                            db.SubmitChanges();
                            //DAOAuditoria.InsertaAuditoria(eTablaEPI.TBL_EPI_FACTURADETALLE, item, eTipoAccionBD.ELIMINACION, BaseForm.VariablesGlobales.Miusuario.Usuario.EPI_INT_USUARIO, null, "", "");
                        }

                        foreach (TBL_EPI_FACTURADETALLE item in olFacDetalle)
                        {
                            oDet = (from or in db.TBL_EPI_FACTURADETALLE
                                    where or.EPI_NUM_IDFACTURADETALLE == item.EPI_NUM_IDFACTURADETALLE
                                    select or).FirstOrDefault();

                            if (oDet != null)
                            {
                                oDet.EPI_INT_ITEM = item.EPI_INT_ITEM;
                                oDet.EPI_INT_IDPRODUCTO = item.EPI_INT_IDPRODUCTO;
                                oDet.EPI_NUM_CANTIDAD = item.EPI_NUM_CANTIDAD;
                                oDet.EPI_VCH_DESCRIPCION = item.EPI_VCH_DESCRIPCION;
                                oDet.EPI_INT_IDIMPUESTO = item.EPI_INT_IDIMPUESTO;
                                oDet.EPI_NUM_VALORUNITARIO = item.EPI_NUM_VALORUNITARIO;
                                oDet.EPI_NUM_SUBTOTAL = item.EPI_NUM_SUBTOTAL;
                                oDet.EPI_NUM_IGVVENTA = item.EPI_NUM_IGVVENTA;
                                oDet.EPI_NUM_IMPORTETOTAL = item.EPI_NUM_IMPORTETOTAL;
                                oDet.EPI_BIT_ACTIVO = true;
                                db.SubmitChanges();
                                //new DAOAuditoria().InsertarAuditoria(eBaseDatos.AmericaMovil_Hellmann, eTablaSLI.TBL_SLI_ORDENCOMPRADETALLE, oOrdenDetalle, eTipoAccionBD.MODIFICACION, (int)objOrdenCompra.SLI_INT_USUARIOMODIFICA);
                            }
                            else
                            {
                                item.EPI_NUM_IDFACTURA = oFac.EPI_NUM_IDFACTURA;
                                item.EPI_BIT_ACTIVO = true;
                                db.TBL_EPI_FACTURADETALLE.InsertOnSubmit(item);
                                db.SubmitChanges();
                                //DAOAuditoria.InsertaAuditoria(eTablaEPI.TBL_EPI_FACTURADETALLE, onFac, eTipoAccionBD.CREACION, BaseForm.VariablesGlobales.Miusuario.Usuario.EPI_INT_USUARIO, null, "", "");
                            }
                        }


                        dbTrans.Commit();
                        mensaje = "Se modificó el documento: " + objFact.TBL_EPI_TIPODOCUMENTOCONTABLE.EPI_VCH_NOMBREDOCUMENTO + "(" + objFact.EPI_VCH_SERIEFACTURA + " - " + objFact.EPI_VCH_NUMERODOCUMENTO + ")";
                    }
                }
                return mensaje;
            }
            catch (Exception ex)
            {
                mensaje = "Ocurrio un problema : " + Environment.NewLine + ex.Message.ToString() + Environment.NewLine + " (COMUNICAR A SISTEMAS)";
                dbTrans.Rollback();
                return mensaje;
            }
        }
        
        internal static List<EPI_SP_LISTARFACTURAEDICIONResult> GetListaFacturaEdicionidFactura(int idFactura)
        {
            try
            {
                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {
                    return db.EPI_SP_LISTARFACTURAEDICION(idFactura).ToList<EPI_SP_LISTARFACTURAEDICIONResult>();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString() + " (COMUNICAR A SISTEMAS)", "ERROR");
                return null;
            }
        }


        internal static List<EPI_SP_LISTAFACTURAResult> GetListaFactura(int tipoDoc, int idCliente, string serie, string criterio, DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {
                    return db.EPI_SP_LISTAFACTURA(tipoDoc, idCliente, serie, criterio, fechaDesde, fechaHasta).ToList<EPI_SP_LISTAFACTURAResult>();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString() + " (COMUNICAR A SISTEMAS)", "ERROR");
                return null;
            }
        }
    }
}
