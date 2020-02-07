using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiNet.Win.App_Code.BE
{
    public class BEEmpleado
    {
        public int EPI_INT_IDEMPLEADO { get; set; }
        public string EPI_VCH_NOMBRE { get; set; }
        public string EPI_VCH_APELLIDOPATERNO { get; set; }
        public string EPI_VCH_APELLIDOMATERNO { get; set; }
        public int EPI_INT_IDSEXO { get; set; }
        public int EPI_INT_IDTIPODOCUMENTOIDENTIDAD { get; set; }
        public string EPI_VCH_NUMERODOCUMENTOIDENTIDAD { get; set; }
        public string EPI_VCH_DIRECCIONDOMICILIO { get; set; }
        public string EPI_VCH_TELEFONODOMICILIO { get; set; }
        public string EPI_VCH_TELEFONOMOVIL { get; set; }

    }
}
