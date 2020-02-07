using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiNet.Win.App_Code.DAO
{
    class DAOUnidadMedida
    {
        internal static object ListarUnidadMedida(int id, string descripcion)
        {
            try
            {
                object olUM = new List<object>();

                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {

                    olUM = (from um in db.TBL_EPI_UNIDADMEDIDA
                                        where (um.EPI_INT_IDUNIDADMEDIDA == id || id == 0)
                                        && (um.EPI_VCH_DESCRIPCION.Contains(descripcion))
                                        select new
                                        {
                                            EPI_INT_IDUNIDADMEDIDA = um.EPI_INT_IDUNIDADMEDIDA,
                                            EPI_VCH_DESCRIPCION = (um.EPI_VCH_SIMBOLO ?? " ") + "-" + um.EPI_VCH_DESCRIPCION
                                            
                                        }
                                ).ToList();

                }

                return olUM;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
