using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpiNet.Win.App_Code.BE;
using EpiNet.Win.App_Code.DAO;

namespace EpiNet.Win.App_Code.BL
{
    class BLUsuario
    {
        public static object ListarUsuarioEmpleado(int IdUduario, string filtro)
        {
            return DAOUsuario.ListarUsuarioEmpleado(IdUduario, filtro);
        }
        public static eResultado ActualizarEmpleadoUsuario(TBL_EPI_USUARIO oUsuario, int idEmpleado)
        {
            return DAOUsuario.ActualizarEmpleadoUsuario(oUsuario, idEmpleado);
        }
        public static eResultado InsertarEmpleadoUsuario(TBL_EPI_USUARIO oUsuario, int idEmpleado)
        {
            return DAOUsuario.InsertarEmpleadoUsuario(oUsuario, idEmpleado);
        }

        public static eResultado ValidarUsuario(string usuario, string pass, ref BEUsuario oUsuario)
        {
            return DAOUsuario.ValidarUsuario(usuario, pass, ref oUsuario);
        }

        public static TBL_EPI_USUARIO obtieneUsuario(int idUsuario)
        {
            return DAOUsuario.obtieneUsuario(idUsuario);
        }
        public static bool ValidarNombreUsuario(string nombreUser)
        {
            return DAOUsuario.ValidarNombreUsuario(nombreUser);
        }

        internal void updateSkinGallery(string caption, int idUsuario)
        {
            new DAOUsuario().updateSkinGallery(caption, idUsuario);
        }
    }
}
