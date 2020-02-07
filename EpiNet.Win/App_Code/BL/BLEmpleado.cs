using EpiNet.Win.App_Code.BE;
using EpiNet.Win.App_Code.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EpiNet.Win.App_Code.BL
{
    class BLEmpleado
    {
        public static List<BEEmpleado> ListarEmpleados(int IdEmpleado, string Descripcion)
        {
            return DAOEmpleado.ListarEmpleados(IdEmpleado, Descripcion);
        }
        public static TBL_EPI_EMPLEADO obtieneEmpleados(int idEmpleado)
        {
            return DAOEmpleado.obtieneEmpleados(idEmpleado);

        }

        internal static eResultado Insertar(TBL_EPI_EMPLEADO oEmpleado)
        {
            return DAOEmpleado.Insertar(oEmpleado);
        }

        internal static eResultado Actualizar(TBL_EPI_EMPLEADO oEmpleado)
        {
            return DAOEmpleado.Actualizar(oEmpleado);
        }
    }
}

