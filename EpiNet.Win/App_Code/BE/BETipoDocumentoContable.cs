using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiNet.Win.App_Code.BE
{
    public class BETipoDocumentoContable
    {
        public int EPI_INT_IDTIPODOCUMENTOCONTABLESERIES { get; set; }
        public int EPI_INT_IDTIPODOCUMENTOCONTABLE { get; set; }
        public string EPI_VCH_NOMBREDOCUMENTO { get; set; }
        public string EPI_VCH_SERIE { get; set; }
        public int EPI_INT_CORRELATIVO { get; set; }
    }
}
