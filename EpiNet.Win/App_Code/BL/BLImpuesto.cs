using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpiNet.Win.App_Code.BE;
using EpiNet.Win.App_Code.DAO;

namespace EpiNet.Win.App_Code.BL
{
    class BLImpuesto
    {
        internal static object ListarImpuesto(int id, string nombre)
        {
            return DAOImpuesto.ListarImpuesto(id, nombre);
        }
        internal static List<BEImpuesto> GetListImpuesto(int id, string nombre)
        {
            return DAOImpuesto.GetListImpuesto(id, nombre);
        }
    }
}
