using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpiNet.Win.App_Code.BE;
using EpiNet.Win.App_Code.DAO;
namespace EpiNet.Win.App_Code.BL
{
    class BLProducto
    {
        internal static TBL_EPI_PRODUCTO obtieneProducto(int idProducto)
        {
            return DAOProducto.obtieneProducto(idProducto);
        }

        internal static eResultado Insertar(TBL_EPI_PRODUCTO oProducto)
        {
            return DAOProducto.Insertar(oProducto);
        }

        internal static eResultado Actualizar(TBL_EPI_PRODUCTO oProducto)
        {
            return DAOProducto.Actualizar(oProducto);
        }

        internal static List<BEProducto> ListarProductos(int ID, string criterio)
        {
            return DAOProducto.ListarProductos(ID, criterio);
        }
    }
}
