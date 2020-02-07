using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiNet.Win.App_Code.BE
{
    public class BEFacturaDetalle
    {
        
        public int EPI_NUM_IDFACTURADETALLE { get; set; }
        public int EPI_NUM_IDFACTURA { get; set; }
        public int EPI_INT_ITEM { get; set; }
        public int EPI_INT_IDPRODUCTO { get; set; }
        public string EPI_VCH_DESCRIPCION { get; set; }
        public int EPI_INT_IDUNIDADMEDIDA { get; set; }
        public string EPI_VCH_UNIDADMEDIDA { get; set; }
        public decimal EPI_NUM_CANTIDAD { get; set; }
        public int EPI_INT_IDIMPUESTO { get; set; }
        public decimal EPI_NUM_VALORUNITARIO { get; set; }
        public decimal EPI_NUM_SUBTOTAL { get; set; }
        public decimal EPI_NUM_IGVVENTA { get; set; }
        public decimal EPI_NUM_IMPORTETOTAL { get; set; }
        public bool EPI_BIT_ACTIVO { get; set; }

        public string EPI_VCH_CLIENTEENTIDAD { get; set; }
        public string EPI_VCH_RUC { get; set; }
        public string EPI_VCH_DIRECCIONENTIDAD { get; set; }
        public DateTime EPI_DAT_FECHAEMISION { get; set; }
        public string EPI_VCH_NUMEROENLETRAS { get; set; }
    }
}
