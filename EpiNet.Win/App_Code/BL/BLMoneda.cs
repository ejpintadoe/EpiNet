using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpiNet.Win.App_Code.DAO;
using EpiNet.Win.App_Code.BE;

namespace EpiNet.Win.App_Code.BL
{
    class BLMoneda
    {
        internal static List<object>  ListarMoneda(int id, string descripcion)
        {
            return DAOMoneda.ListarMoneda(id, descripcion);
        }
    }
}
