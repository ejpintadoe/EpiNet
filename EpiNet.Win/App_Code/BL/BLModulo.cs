using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpiNet.Win.App_Code.BE;
using EpiNet.Win.App_Code.DAO;

namespace EpiNet.Win.App_Code.BL
{
    class BLModulo
    {
        public static List<TBL_EPI_MODULO> ListarModulo(int IdModulo, string Descripcion)
        {
            return DAOModulo.ListarModulo(IdModulo, Descripcion);
        }
        public static List<BEModulo> ListarModulos(int IdModulo, int IdPadre, string Descripcion)
        {
            return DAOModulo.ListarModulos(IdModulo, IdPadre, Descripcion);
        }
        public static object ListarModulos()
        {
            return DAOModulo.ListarModulos();
        }
        public static TBL_EPI_MODULO obtieneModulos(int idModulo)
        {
            return DAOModulo.obtieneModulos(idModulo);
        }
        public static List<BEOpcion> ListarOpcionesModulo(int IdModulo)
        {
            return DAOModulo.ListarOpcionesModulo(IdModulo);
        }
        public static eResultado AgregarOpcionModulo(int IdModulo, int IdOpcion)
        {
            return DAOModulo.AgregarOpcionModulo(IdModulo, IdOpcion);
        }
        public static eResultado EliminarOpcionModulo(int IdModulo, int IdOpcion)
        {
            return DAOModulo.EliminarOpcionModulo(IdModulo, IdOpcion);
        }
        public static eResultado Insertar(TBL_EPI_MODULO oModulo)
        {
            return DAOModulo.Insertar(oModulo);
        }
        public static eResultado Actualizar(TBL_EPI_MODULO oModulo)
        {
            return DAOModulo.Actualizar(oModulo);
        }      
        public static List<BEOpcionModuloPerfil> ListarOpcionesModuloPerfil(int IdModulo)
        {
            return DAOModulo.ListarOpcionesModuloPerfil(IdModulo);
        }
        public static List<EPI_SP_MODULOResult> ListarModulos2()
        {
            return DAOModulo.ListarModulos2();
        }

    }
}
