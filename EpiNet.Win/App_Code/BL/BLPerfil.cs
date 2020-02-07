using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpiNet.Win.App_Code.BE;
using EpiNet.Win.App_Code.DAO;

namespace EpiNet.Win.App_Code.BL
{
    class BLPerfil
    {
        public static BindingList<BEPerfil> ListarPerfil(int IdPerfil, string Descripcion)

        {
            return DAOPerfil.ListarPerfil(IdPerfil, Descripcion);
        }

        public static List<BEOpcionModuloPerfil> ListarOpcionesModuloPerfil(int IdPerfil)
        {
            return DAOPerfil.ListarOpcionesModuloPerfil(IdPerfil);
        }

        internal static eResultado Insertar(TBL_EPI_PERFIL oPerfil)
        {
            return DAOPerfil.Insertar(oPerfil);
        }

        internal static eResultado Actualizar(TBL_EPI_PERFIL oPerfil)
        {
            return DAOPerfil.Actualizar(oPerfil);
        }

        internal static eResultado AgregarOpcionModuloPerfil(int IdPerfil, int IdOpcionModulo)
        {
            return DAOPerfil.AgregarOpcionModuloPerfil(IdPerfil, IdOpcionModulo);
        }

        internal static eResultado EliminarOpcionModuloPerfil(int idPerfil, int IdOpcionModulo)
        {
            return DAOPerfil.EliminarOpcionModuloPerfil(idPerfil, IdOpcionModulo);
        }
    }
}
