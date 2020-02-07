using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpiNet.Win.App_Code.DAO;

namespace EpiNet.Win.App_Code.BL
{
    class BLTipoExistencia
    {
        internal static object ListarTipoExistencia(int Id, string descripcion)
        {
            return DAOTipoExistencia.ListarTipoExistencia(Id, descripcion);
        }
    }
}
