using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiNet.Win.App_Code.DAO
{
    class DAOTipoExistencia
    {
        internal static object ListarTipoExistencia(int id, string descripcion)
        {
            try
            {
                object olTipoExistencia = new List<object>();

                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {

                    olTipoExistencia = (from exi in db.TBL_EPI_TIPOEXISTENCIA
                               where (exi.EPI_INT_IDTIPOEXISTENCIA == id || id == 0)
                               && (exi.EPI_VCH_DESCRIPCION.Contains(descripcion))
                               select new
                               {
                                   EPI_INT_IDTIPOEXISTENCIA = exi.EPI_INT_IDTIPOEXISTENCIA,
                                   EPI_VCH_DESCRIPCION = exi.EPI_VCH_DESCRIPCION

                               }
                                ).ToList();

                }

                return olTipoExistencia;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
