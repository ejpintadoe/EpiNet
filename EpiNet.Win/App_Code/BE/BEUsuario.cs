using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiNet.Win.App_Code.BE
{
    public class BEUsuario
    {
        public TBL_EPI_USUARIO Usuario { set; get; }
        public TBL_EPI_EMPLEADO Empleado { set; get; }
        public List<TBL_EPI_MODULO> Modulos { set; get; }
       
    }
}
