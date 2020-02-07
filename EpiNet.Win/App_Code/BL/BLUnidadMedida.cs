using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpiNet.Win.App_Code.DAO;

namespace EpiNet.Win.App_Code.BL
{
    class BLUnidadMedida
    {
        internal static object ListarUnidadMedida(int id, string descripcion)
        {
            return DAOUnidadMedida.ListarUnidadMedida(id, descripcion);
        }
    }
}
