using EpiNet.Win.App_Code.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiNet.Win.App_Code.BL
{
    class BLGenerica
    {
        public static List<TBL_EPI_GENERICA> ListarGenerica(string tbl)
        {
            return DAOGenerica.ListarGenerica(tbl);
        }

    }
}
