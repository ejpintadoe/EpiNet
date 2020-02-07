using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpiNet.Win.App_Code.BE;
using EpiNet.Win.App_Code.DAO;

namespace EpiNet.Win.App_Code.BL
{
    class BLEntidad
    {
        public static List<BEEntidad> listarEntidad(int idEntidad, int idTipoEntidad, string criterio)
        {
            return DAOEntidad.listarEntidad(idEntidad, idTipoEntidad, criterio);
        }
        public static TBL_EPI_ENTIDAD obtenerEntidad(int idEntidad)
        {
            return DAOEntidad.obtenerEntidad(idEntidad);
        }

        public static List<TBL_EPI_ENTIDADTIPOENTIDAD> listarTipoEntidad(int idEntidad)
        {
            return DAOEntidad.listarTipoEntidad(idEntidad);
        }

        internal static eResultado Insertar(TBL_EPI_ENTIDAD oEntidad, List<TBL_EPI_ENTIDADTIPOENTIDAD> lstTipoEntidad)
        {
            return DAOEntidad.Insertar(oEntidad, lstTipoEntidad);
        }

        internal static eResultado Actualizar(TBL_EPI_ENTIDAD oEntidad, List<TBL_EPI_ENTIDADTIPOENTIDAD> lstTipoEntidad)
        {
            return DAOEntidad.Actualizar(oEntidad, lstTipoEntidad);
        }

        internal static List<object> GetListEntidadPorTipo(int idEntidad, int idTipoEntidad1, int idTipoEntidad2, int idTipoEntidad3)
        {
            return DAOEntidad.GetListEntidadPorTipo(idEntidad, idTipoEntidad1, idTipoEntidad2, idTipoEntidad3);
        }
    }
}
