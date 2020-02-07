using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiNet.Win.App_Code.BE
{
    public class BEOpcion
    {
        public int EPI_INT_IDOPCION { get; set; }
        public string EPI_VCH_NOMBREOPCION { get; set; }
        public string EPI_VCH_IMAGEN16X16 { get; set; }
        public string EPI_VCH_IMAGEN32X32 { get; set; }

        public int EPI_INT_IMAGENINDEX16X16 { get; set; }
        public int EPI_INT_IMAGENINDEX32X32 { get; set; }

        public bool EPI_BIT_ESRIBBON { get; set; }

    }
}
