using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiNet.Win.App_Code.DAO
{
    class DAOMarca
    {
        internal static object ListarMarca(int idMarca, string descripcion)
        {
            try
            {
                object olMarca = new List<object>();

                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {

                    olMarca = (from m in db.TBL_EPI_MARCA
                                 where (m.EPI_INT_IDMARCA == idMarca || idMarca == 0)
                                 && (m.EPI_VCH_DESCRIPCION.Contains(descripcion))
                                 select new
                                 {
                                     EPI_INT_IDMARCA = m.EPI_INT_IDMARCA,
                                     EPI_VCH_DESCRIPCION = m.EPI_VCH_DESCRIPCION
                                  
                                 }
                                ).ToList();

                }

                return olMarca;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
