using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpiNet.Win.App_Code.DAO;

namespace EpiNet.Win.App_Code.BL
{
    class BLCategoria
    {
        public static List<TBL_EPI_CATEGORIA> ListarCategoria(int id, string descripcion)
        {
            return DAOCategoria.ListarCategoria(id, descripcion);
        }

    }
}
