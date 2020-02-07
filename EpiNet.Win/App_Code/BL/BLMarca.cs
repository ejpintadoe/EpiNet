using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpiNet.Win.App_Code.DAO;

namespace EpiNet.Win.App_Code.BL
{
    class BLMarca
    {
        internal static object ListarMarca(int idMarca, string descripcion)
        {
            return DAOMarca.ListarMarca(idMarca, descripcion);
        }
    }
}
