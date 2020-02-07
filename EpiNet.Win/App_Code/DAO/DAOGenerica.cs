using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiNet.Win.App_Code.DAO
{
    class DAOGenerica
    {
        internal static List<TBL_EPI_GENERICA> ListarGenerica(string tbl)
        {

            try
            {
                List<TBL_EPI_GENERICA> obj = new List<TBL_EPI_GENERICA>();

                using (DataClassEpiNetDataContext dc = new DataClassEpiNetDataContext())
                {

                    obj = (from g in dc.TBL_EPI_GENERICA where g.EPI_VCH_NOMTABLA == tbl
                           && g.EPI_BIT_ESTADO == true
                           select g).ToList();

                }

                return obj;

            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}
