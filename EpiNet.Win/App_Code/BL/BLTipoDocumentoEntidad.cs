using EpiNet.Win.App_Code.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiNet.Win.App_Code.BL
{
    class BLTipoDocumentoEntidad
    {
        public static object ListarTipoDocumentoEntidad(int Id, string descripcion)
        {
            return DAOTipoDocumentoEntidad.ListarTipoDocumentoEntidad(Id, descripcion);

        }
    }
}
