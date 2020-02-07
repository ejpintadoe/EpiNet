using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiNet.Win.App_Code.DAO
{
    class DAOTipoDocumentoEntidad
    {
        internal static object ListarTipoDocumentoEntidad(int id, string descripcion)
        {
            try
            {
               object olTipoDoc = new List<object>();

                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {

                    olTipoDoc = (from t in db.TBL_EPI_TIPODOCUMENTOIDENTIDAD
                                where (t.EPI_INT_IDTIPODOCUMENTOIDENTIDAD == id || id == 0)
                                && (t.EPI_VCH_DESCRIPCIONCORTA.Contains(descripcion))
                                select new
                                {
                                    EPI_INT_IDTIPODOCUMENTOIDENTIDAD = t.EPI_INT_IDTIPODOCUMENTOIDENTIDAD,
                                    EPI_VCH_DESCRIPCIONCORTA = t.EPI_VCH_DESCRIPCIONCORTA,
                                    EPI_VCH_DESCRIPCIONLARGA = t.EPI_VCH_DESCRIPCIONLARGA
                                }
                                ).ToList();

                }

                return olTipoDoc;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
