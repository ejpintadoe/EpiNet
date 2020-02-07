using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EpiNet.Win.App_Code.BE;
using System.Data.Common;

namespace EpiNet.Win.App_Code.DAO
{
    class DAOEntidad
    {

        internal static List<BEEntidad> listarEntidad(int idEntidad, int idTipoEntidad, string criterio)
        {
            try
            {
                List<BEEntidad> lstEntidad = new List<BEEntidad>();

                using (DataClassEpiNetDataContext dc = new DataClassEpiNetDataContext())
                {

                    lstEntidad = (from e in dc.TBL_EPI_ENTIDADTIPOENTIDAD
                                  where e.EPI_BIT_ESTADO == true
                                    && (e.EPI_INT_IDTIPOENTIDAD == idTipoEntidad || idTipoEntidad == 0)
                                    && (e.TBL_EPI_ENTIDAD.EPI_VCH_NUMERODOCUMENTO.Contains(criterio)
                                    || e.TBL_EPI_ENTIDAD.EPI_VCH_RAZONSOCIAL.Contains(criterio)
                                    || e.TBL_EPI_ENTIDAD.EPI_VCH_NOMBRECOMERCIAL.Contains(criterio))
                                    && (e.TBL_EPI_ENTIDAD.EPI_INT_IDENTIDAD == idEntidad || idEntidad == 0)
                                  orderby e.TBL_EPI_ENTIDAD.EPI_VCH_RAZONSOCIAL
                                  select new BEEntidad
                                  {
                                      EPI_INT_IDENTIDAD = e.TBL_EPI_ENTIDAD.EPI_INT_IDENTIDAD,
                                      EPI_VCH_NUMERODOCUMENTO = e.TBL_EPI_ENTIDAD.EPI_VCH_NUMERODOCUMENTO,
                                      EPI_VCH_RAZONSOCIAL = e.TBL_EPI_ENTIDAD.EPI_VCH_RAZONSOCIAL,
                                      EPI_VCH_NOMBRECOMERCIAL = e.TBL_EPI_ENTIDAD.EPI_VCH_NOMBRECOMERCIAL,
                                      EPI_VCH_DIRECCION = e.TBL_EPI_ENTIDAD.EPI_VCH_DIRECCION
                                  }).Distinct().ToList();

                }

                return lstEntidad;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString() + " (COMUNICAR A SISTEMAS)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<BEEntidad>();


            }

        }

        internal static List<object> GetListEntidadPorTipo(int idEntidad, int idTipoEntidad1, int idTipoEntidad2, int idTipoEntidad3)
        {
            try
            {
                List<object> olEntidad = new List<object>();

                using (DataClassEpiNetDataContext dc = new DataClassEpiNetDataContext())
                {
                    olEntidad = (from e in dc.EPI_SP_LISTAENTIDADPORTIPO(idEntidad, idTipoEntidad1, idTipoEntidad2, idTipoEntidad3)
                                 select e).Cast<object>().ToList();

                }

                return olEntidad;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString() + " (COMUNICAR A SISTEMAS)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<object>();
            }
        }

        internal static eResultado Actualizar(TBL_EPI_ENTIDAD oEntidad, List<TBL_EPI_ENTIDADTIPOENTIDAD> lstTipoEntidad)
        {
            DbTransaction dbTrans = null;
            try
            {

                using (DataClassEpiNetDataContext db= new DataClassEpiNetDataContext())
                {
                    db.Connection.Open();
                    dbTrans = db.Connection.BeginTransaction();
                    db.Transaction = dbTrans;

                    TBL_EPI_ENTIDAD oEntidadActual = new TBL_EPI_ENTIDAD();

                    oEntidadActual = (from e in db.TBL_EPI_ENTIDAD where e.EPI_INT_IDENTIDAD == oEntidad.EPI_INT_IDENTIDAD select e).FirstOrDefault();

                    oEntidadActual.EPI_INT_IDTIPOPERSONA = oEntidad.EPI_INT_IDTIPOPERSONA;
                    oEntidadActual.EPI_INT_IDTIPODOCUMENTO = oEntidad.EPI_INT_IDTIPODOCUMENTO;
                    oEntidadActual.EPI_VCH_NUMERODOCUMENTO = oEntidad.EPI_VCH_NUMERODOCUMENTO;
                    oEntidadActual.EPI_VCH_RAZONSOCIAL = oEntidad.EPI_VCH_RAZONSOCIAL;
                    oEntidadActual.EPI_VCH_NOMBRECOMERCIAL = oEntidad.EPI_VCH_NOMBRECOMERCIAL;
                    oEntidadActual.EPI_VCH_DIRECCION = oEntidad.EPI_VCH_DIRECCION;
                    oEntidadActual.EPI_VCH_SITIOWEB = oEntidad.EPI_VCH_SITIOWEB;
                    oEntidadActual.EPI_VCH_GIRONEGOCIO = oEntidad.EPI_VCH_GIRONEGOCIO;
                    oEntidadActual.EPI_INT_USUARIOMODIFICA = oEntidad.EPI_INT_USUARIOMODIFICA;
                    oEntidadActual.EPI_DAT_FECHAMODIFICACION = DateTime.Now;
                    db.SubmitChanges();

                    List<TBL_EPI_ENTIDADTIPOENTIDAD> lstTipoEntidadAct = (from te in db.TBL_EPI_ENTIDADTIPOENTIDAD
                                                                          where te.EPI_BIT_ESTADO == true
                                                                          && te.EPI_INT_IDENTIDAD == oEntidad.EPI_INT_IDENTIDAD select te).ToList();

                    foreach (var item in lstTipoEntidadAct)
                    {
                        item.EPI_BIT_ESTADO = false;
                        db.SubmitChanges();
                    }

                    foreach (var item in lstTipoEntidad)
                    {
                        TBL_EPI_ENTIDADTIPOENTIDAD oTipoEntidad = (from te in db.TBL_EPI_ENTIDADTIPOENTIDAD
                                                                   where te.EPI_INT_IDENTIDAD == oEntidad.EPI_INT_IDENTIDAD
                                                                   && te.EPI_INT_IDTIPOENTIDAD == item.EPI_INT_IDTIPOENTIDAD
                                                                   select te).FirstOrDefault();
                        if (oTipoEntidad != null)
                        {
                            oTipoEntidad.EPI_BIT_ESTADO = true;
                            oTipoEntidad.EPI_INT_USUARIOMODIFICA = oEntidad.EPI_INT_USUARIOMODIFICA;
                            oTipoEntidad.EPI_DAT_FECHAMODIFICACION = DateTime.Now;
                            db.SubmitChanges();

                        }
                        else {
                            item.EPI_BIT_ESTADO = true;
                            item.EPI_INT_IDENTIDAD = oEntidad.EPI_INT_IDENTIDAD;
                            item.EPI_INT_USUARIOCREA = oEntidad.EPI_INT_USUARIOMODIFICA;
                            item.EPI_DAT_FECHACREACION = DateTime.Now;
                            db.TBL_EPI_ENTIDADTIPOENTIDAD.InsertOnSubmit(item);
                            db.SubmitChanges();
                        }

                    }

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

        internal static eResultado Insertar(TBL_EPI_ENTIDAD oEntidad, List<TBL_EPI_ENTIDADTIPOENTIDAD> lstTipoEntidad)
        {
            DbTransaction dbTrans = null;
            try
            {               
                using (DataClassEpiNetDataContext dc = new DataClassEpiNetDataContext())
                {
                    dc.Connection.Open();
                    dbTrans = dc.Connection.BeginTransaction();
                    dc.Transaction = dbTrans;

                    dc.TBL_EPI_ENTIDAD.InsertOnSubmit(oEntidad);
                    dc.SubmitChanges();

                    foreach (var item in lstTipoEntidad)
                    {
                        item.EPI_BIT_ESTADO = true;
                        item.EPI_INT_USUARIOCREA = oEntidad.EPI_INT_USUARIOCREA;
                        item.EPI_DAT_FECHACREACION = DateTime.Now;
                        item.EPI_INT_IDENTIDAD = oEntidad.EPI_INT_IDENTIDAD;
                        dc.TBL_EPI_ENTIDADTIPOENTIDAD.InsertOnSubmit(item);
                        dc.SubmitChanges();
                    }

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

        internal static TBL_EPI_ENTIDAD obtenerEntidad(int idEntidad)
        {
            try
            {
                TBL_EPI_ENTIDAD oEntidad = new TBL_EPI_ENTIDAD();

                using (DataClassEpiNetDataContext dc = new DataClassEpiNetDataContext())
                {
                    oEntidad = (from e in dc.TBL_EPI_ENTIDAD where e.EPI_INT_IDENTIDAD == idEntidad select e).FirstOrDefault();

                }

                return oEntidad;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString() + " (COMUNICAR A SISTEMAS)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new TBL_EPI_ENTIDAD();
            }
        }

        internal static List<TBL_EPI_ENTIDADTIPOENTIDAD> listarTipoEntidad(int idEntidad)
        {
            try
            {
                List<TBL_EPI_ENTIDADTIPOENTIDAD> lstTipoEntidad = new List<TBL_EPI_ENTIDADTIPOENTIDAD>();

                using (DataClassEpiNetDataContext dc = new DataClassEpiNetDataContext())
                {
                    lstTipoEntidad = (from te in dc.TBL_EPI_ENTIDADTIPOENTIDAD where te.EPI_INT_IDENTIDAD == idEntidad
                                      && te.EPI_BIT_ESTADO == true select te).ToList();
                
                }
                return lstTipoEntidad;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString() + " (COMUNICAR A SISTEMAS)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<TBL_EPI_ENTIDADTIPOENTIDAD>();
            }
        }
    }
}
