using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiNet.Win.App_Code.BE
{
    public class BEImpuesto
    {
        public int IdImpuesto { get; set; }
        public string Descripcion { get; set; }
        public decimal? Porcentaje { get; set; }

    }
}
