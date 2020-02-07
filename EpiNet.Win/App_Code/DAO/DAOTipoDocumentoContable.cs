using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpiNet.Win.App_Code.BL;
using EpiNet.Win.App_Code.BE;

namespace EpiNet.Win.App_Code.DAO
{
    class DAOTipoDocumentoContable
    {
        internal static List<object> GetTipoDocumentoContablePreferida()
        {
            try
            {

                List<object> olTipoDoc = new List<object>();

                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {
                    olTipoDoc = (from om in db.TBL_EPI_TIPODOCUMENTOCONTABLESERIES
                                 join o in db.TBL_EPI_TIPODOCUMENTOCONTABLE on om.EPI_INT_IDTIPODOCUMENTOCONTABLE equals o.EPI_INT_IDTIPODOCUMENTOCONTABLE
                                 where om.EPI_BIT_PREFERIDA == true
                                        
                                        select new BETipoDocumentoContable
                                        {
                                            EPI_INT_IDTIPODOCUMENTOCONTABLESERIES = om.EPI_INT_IDTIPODOCUMENTOCONTABLESERIES,
                                            EPI_INT_IDTIPODOCUMENTOCONTABLE = om.EPI_INT_IDTIPODOCUMENTOCONTABLE ?? 0,
                                            EPI_VCH_NOMBREDOCUMENTO = om.EPI_VCH_SERIE + "-" + o.EPI_VCH_NOMBREDOCUMENTO,
                                            EPI_VCH_SERIE = om.EPI_VCH_SERIE,
                                            EPI_INT_CORRELATIVO = om.EPI_INT_CORRELATIVO ?? 0
                                        }).Cast<object>().ToList();

                }
                return olTipoDoc;

            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message.ToString() + " (COMUNICAR A SISTEMAS)", "ERROR");
                return null;

            }
        }

        internal static BETipoDocumentoContable GetTipoDocumentoContableSerie(int idTipoDocumentoContableSerie)
        {
            try
            {

                BETipoDocumentoContable oTipoDoc = new BETipoDocumentoContable();

                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {
                    oTipoDoc = (from om in db.TBL_EPI_TIPODOCUMENTOCONTABLESERIES
                                 
                                 where om.EPI_BIT_ACTIVO == true && om.EPI_INT_IDTIPODOCUMENTOCONTABLESERIES == idTipoDocumentoContableSerie

                                 select new BETipoDocumentoContable
                                 {
                                     EPI_INT_IDTIPODOCUMENTOCONTABLESERIES = om.EPI_INT_IDTIPODOCUMENTOCONTABLESERIES,
                                     EPI_INT_IDTIPODOCUMENTOCONTABLE = om.EPI_INT_IDTIPODOCUMENTOCONTABLE ?? 0,
                                     EPI_VCH_SERIE = om.EPI_VCH_SERIE,
                                     EPI_INT_CORRELATIVO = (om.EPI_INT_CORRELATIVO ?? 0) + 1
                                 }).FirstOrDefault();

                }
                return oTipoDoc;

            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message.ToString() + " (COMUNICAR A SISTEMAS)", "ERROR");
                return null;

            }
        }
    }
}
