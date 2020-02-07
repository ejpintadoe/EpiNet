using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpiNet.Win.App_Code.BE;
using EpiNet.Win.App_Code.DAO;

namespace EpiNet.Win.App_Code.BL
{
    class BLOpcion
    {
        public List<TBL_EPI_OPCION> ListarOpcionModulo(int idPerfil, int idModulo)
        {
            return DAOOpcion.ListarOpcionModulo(idPerfil, idModulo);
        }

        public static List<BEOpcion> Listar(int IdOpcion, string Descripcion)
        {

            return DAOOpcion.Listar(IdOpcion, Descripcion);

        }

        public static eResultado Insertar(TBL_EPI_OPCION oOpcion)
        {
            return DAOOpcion.Insertar(oOpcion);
        }

        public static eResultado Actualizar(TBL_EPI_OPCION oOpcion)
        {
            return DAOOpcion.Actualizar(oOpcion);
        }


    }
}
