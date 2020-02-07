using EpiNet.Win.App_Code.BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiNet.Win.App_Code.DAO
{
    class DAOMoneda
    {
        internal static List<object> ListarMoneda(int id, string descripcion)
        {
            try
            {
                List<object> olMoneda = new List<object>();

                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {

                    olMoneda = (from mo in db.TBL_EPI_MONEDA
                                        where (mo.EPI_INT_IDMONEDA == id || id == 0)
                                        && (mo.EPI_VCH_NOMBRE.Contains(descripcion))
                                        select new
                                        {
                                            EPI_INT_IDMONEDA = mo.EPI_INT_IDMONEDA,
                                            EPI_VCH_NOMBRE = mo.EPI_VCH_NOMBRE,
                                            EPI_VCH_SIMBOLO = mo.EPI_VCH_SIMBOLO
                                        }
                                ).Cast<object>().ToList();

                }

                return olMoneda;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
