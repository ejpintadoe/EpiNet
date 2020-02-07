using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpiNet.Win.App_Code.DAO;
using EpiNet.Win.App_Code.BE;

namespace EpiNet.Win.App_Code.BL
{
    class BLTipoDocumentoContable
    {
        public static List<object> GetTipoDocumentoContablePreferida()
        {
            return DAOTipoDocumentoContable.GetTipoDocumentoContablePreferida();
        }

        public static BETipoDocumentoContable GetTipoDocumentoContableSerie(int idTipoDocumentoContableSerie)
        {
            return DAOTipoDocumentoContable.GetTipoDocumentoContableSerie(idTipoDocumentoContableSerie);
        }
    }
}
