using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EpiNet.Win.App_Code.BE;

namespace EpiNet.Win.App_Code.DAO
{
    class DAOUsuario
    {

        internal static object ListarUsuarioEmpleado(int IdUduario, string filtro)
        {
            try
            {
                object oUsuEmp = new object();

                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {
                    oUsuEmp = (from e in db.TBL_EPI_EMPLEADO
                               //from u in db.TBL_EPI_USUARIO
                               where e.EPI_BIT_ACTIVO == true
                               select new
                               {
                                   EPI_INT_IDUSUARIO = e.EPI_INT_IDUSUARIO,
                                   EPI_INT_IDEMPLEADO = e.EPI_INT_IDEMPLEADO,
                                   EPI_VCH_NOMBRE = e.EPI_VCH_NOMBRE,
                                   EPI_VCH_APELLIDOS = e.EPI_VCH_APELLIDOPATERNO

                               }
                               ).ToList();


                }
                return oUsuEmp;
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        internal static TBL_EPI_USUARIO obtieneUsuario(int idUsuario)
        {
            try
            {
                TBL_EPI_USUARIO oUsu = new TBL_EPI_USUARIO();
                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {
                     oUsu = (from t in db.TBL_EPI_USUARIO
                                            where t.EPI_BIT_ACTIVO == true
                                            && t.EPI_INT_IDUSUARIO == idUsuario
                                            select t).SingleOrDefault();


                }

                return oUsu;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        internal void updateSkinGallery(string caption, int idUsuario)
        {
            try
            {
                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {
                    TBL_EPI_USUARIO oUS = (from p in db.TBL_EPI_USUARIO
                                           where p.EPI_INT_IDUSUARIO == idUsuario
                                           select p).SingleOrDefault();

                    oUS.EPI_VCH_SKINGALLERY = caption;
                    db.SubmitChanges();
                    
                }
                
            }
            catch (Exception ex)
            {
                //new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = ConfigurationManager.AppSettings["TITULOMENAJEALERTA"].ToString(), Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                
            }
        }

        public static eResultado ValidarUsuario(string usuario, string pass, ref BEUsuario oUsuario)
        {
            try
            {
                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {
                    TBL_EPI_USUARIO oUsu = (from t in db.TBL_EPI_USUARIO
                                            where t.EPI_BIT_ACTIVO == true
                                            && t.EPI_VCH_USUARIO == usuario
                                            && t.EPI_VCH_CLAVE == pass
                                            select t).SingleOrDefault();
                    if (oUsu == null)
                    {
                        return eResultado.IncorrectoLogin;
                    }
                    else
                    {
                        oUsuario = new BEUsuario();
                        oUsuario.Usuario = oUsu;

                        TBL_EPI_EMPLEADO oEmpl = (from r in db.TBL_EPI_EMPLEADO
                                                  where r.EPI_BIT_ACTIVO == true
                                                  && r.EPI_INT_IDUSUARIO == oUsu.EPI_INT_IDUSUARIO
                                                  select r).SingleOrDefault();

                        oUsuario.Empleado = oEmpl;


                        if (oUsu.EPI_INT_IDPERFIL == Convert.ToInt32(ePerfil.Admin))
                        {
                            oUsuario.Modulos = (from f in db.TBL_EPI_MODULO
                                                where f.EPI_BIT_ACTIVO == true && f.EPI_BIT_WINDOWS == true
                                                //&& (f.EPI_VCH_WINDOWSFORM.Equals("") || f.EPI_VCH_WINDOWSFORM.StartsWith("frm"))
                                                orderby f.EPI_INT_ORDEN ascending
                                                select f).ToList();
                        }
                        else
                        {
                            oUsuario.Modulos = (from f in db.TBL_EPI_OPCIONMODULOPERFIL
                                                where f.EPI_BIT_ACTIVO == true
                                                && f.EPI_INT_IDPERFIL == oUsu.EPI_INT_IDPERFIL
                                                && f.TBL_EPI_OPCIONMODULO.TBL_EPI_MODULO.EPI_BIT_WINDOWS == true
                                                //&& (f.TBL_EPI_OPCIONMODULO.TBL_EPI_MODULO.EPI_VCH_WINDOWSFORM.Equals("")|| f.TBL_EPI_OPCIONMODULO.TBL_EPI_MODULO.EPI_VCH_WINDOWSFORM.StartsWith("frm"))
                                                orderby f.TBL_EPI_OPCIONMODULO.TBL_EPI_MODULO.EPI_INT_ORDEN ascending
                                                select f.TBL_EPI_OPCIONMODULO.TBL_EPI_MODULO).Distinct().ToList();

                            //oUsuario.Modulos = (from mp in db.TBL_SGC_OPCIONMODULOPERFILs
                            //                    where mp.SGC_BIT_ACTIVO == true
                            //                    && mp.SGC_INT_IDPERFIL == oUsu.SGC_INT_IDPERFIL
                            //                    && mp.TBL_SGC_OPCIONMODULO.TBL_SGC_MODULO.SGC_BIT_WINDOWS == true
                            //                    orderby mp.TBL_SGC_OPCIONMODULO.TBL_SGC_MODULO.SGC_INT_ORDEN ascending
                            //                    select mp.TBL_SGC_OPCIONMODULO.TBL_SGC_MODULO).Distinct().ToList();
                        }

                        return eResultado.Correcto;
                    }
                }
            }
            catch (Exception ex)
            {
                return eResultado.Error;
            }

        }

        internal static eResultado ActualizarEmpleadoUsuario(TBL_EPI_USUARIO oUsuario, int idEmpleado)
        {
            try
            {
                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {
                    TBL_EPI_USUARIO oUS = (from p in db.TBL_EPI_USUARIO
                                           where p.EPI_INT_IDUSUARIO == oUsuario.EPI_INT_IDUSUARIO
                                           select p).SingleOrDefault();

                    oUS.EPI_VCH_USUARIO = oUsuario.EPI_VCH_USUARIO;
                    if (oUsuario.EPI_VCH_CLAVE != null)
                        oUS.EPI_VCH_CLAVE = oUsuario.EPI_VCH_CLAVE;
                    oUS.EPI_INT_IDPERFIL = oUsuario.EPI_INT_IDPERFIL;
                    oUS.EPI_BIT_HABILITADO = oUsuario.EPI_BIT_HABILITADO;

                    db.SubmitChanges();
                    //new DAOAuditoria().Insertar(eTablaCIS.TBL_CIS_USUARIO, oUS, eTipoAccionBD.MODIFICACION, Usuario);

                    TBL_EPI_EMPLEADO oEmp = (from p in db.TBL_EPI_EMPLEADO
                                            where p.EPI_INT_IDEMPLEADO == idEmpleado
                                             select p).SingleOrDefault();

                    oEmp.EPI_INT_IDUSUARIO = oUsuario.EPI_INT_IDUSUARIO;

                    db.SubmitChanges();

                    //new DAOEmpleado().ActualizaEmpleadoUsuario(oEmpleado, oUsuario.CIS_INT_USUARIO, Usuario);
                }
                return eResultado.Correcto;
            }
            catch (Exception ex)
            {
                //new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = ConfigurationManager.AppSettings["TITULOMENAJEALERTA"].ToString(), Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return eResultado.Error;
            }
        }
        internal static eResultado InsertarEmpleadoUsuario(TBL_EPI_USUARIO oUsuario, int idEmpleado)
        {
            try
            {
                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {
                    db.TBL_EPI_USUARIO.InsertOnSubmit(oUsuario);
                    db.SubmitChanges();
                    //new DAOAuditoria().Insertar(eTablaCIS.TBL_CIS_USUARIO, oUS, eTipoAccionBD.MODIFICACION, Usuario);

                    TBL_EPI_EMPLEADO oEmp = (from p in db.TBL_EPI_EMPLEADO
                                             where p.EPI_INT_IDEMPLEADO == idEmpleado
                                             select p).SingleOrDefault();

                    oEmp.EPI_INT_IDUSUARIO = oUsuario.EPI_INT_IDUSUARIO;

                    db.SubmitChanges();

                    //new DAOEmpleado().ActualizaEmpleadoUsuario(oEmpleado, oUsuario.CIS_INT_USUARIO, Usuario);
                }
                return eResultado.Correcto;
            }
            catch (Exception ex)
            {
                //new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = ConfigurationManager.AppSettings["TITULOMENAJEALERTA"].ToString(), Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return eResultado.Error;
            }

        }

        internal static bool ValidarNombreUsuario(string NombreUsuario)
        {
            try
            {
                int CantidadNombreUsuario = 0;
                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {
                    CantidadNombreUsuario = (from p in db.TBL_EPI_USUARIO
                                             where p.EPI_VCH_USUARIO.ToUpper() == NombreUsuario
                                             //&& p.CIS_BIT_ACTIVO == true
                                             select p).Count();
                }
                if (CantidadNombreUsuario > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                //new Ext.Net.MessageBox().Show(new Ext.Net.MessageBoxConfig() { Title = ConfigurationManager.AppSettings["TITULOMENAJEALERTA"].ToString(), Message = ex.Message, Buttons = Ext.Net.MessageBox.Button.OK });
                return false;
            }
        }


    }
}
