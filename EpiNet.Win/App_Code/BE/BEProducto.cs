using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiNet.Win.App_Code.BE
{
    public class BEProducto
    {
        public int EPI_INT_IDPRODUCTO { get; set; }
        public string EPI_VCH_CODIGOPRODUCTO { get; set; }
        public string EPI_VCH_DESCRIPCION { get; set; }
        public string EPI_VCH_DESCRIPCIONDETALLADA { get; set; }
        public string EPI_VCH_COMENTARIO { get; set; }

        public decimal EPI_NUM_PRECIOVENTA { get; set; }

        public int EPI_INT_IDUNIDADMEDIDA { get; set; }
        public string EPI_VCH_UNIDADMEDIDA { get; set; }

        public int EPI_INT_IDIMPUESTO { get; set; }
    }
}
