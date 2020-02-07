using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using EpiNet.Win.App_Code.BE;

namespace EpiNet.Win.App_Code.DAO
{
    class DAOModulo
    {
        internal static List<TBL_EPI_MODULO> ListarModulo(int IdModulo, string Descripcion)
        {
            try
            {
                List<TBL_EPI_MODULO> olModulos = new List<TBL_EPI_MODULO>();
                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {

                    olModulos = (from m in db.TBL_EPI_MODULO
                                 where m.EPI_BIT_ACTIVO == true
                                 && (m.EPI_INT_IDMODULO == IdModulo || IdModulo == 0)
                                 && (m.EPI_VCH_NOMBREMODULO.Contains(Descripcion))
                                 select m).ToList();
                }
                return olModulos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal static List<BEModulo> ListarModulos(int IdModulo, int IdPadre, string Descripcion)
        {

            try
            {
                List<BEModulo> olModulos = new List<BEModulo>();

                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {
                    olModulos = (from m in db.TBL_EPI_MODULO
                                 where m.EPI_BIT_ACTIVO == true
                                 && (m.EPI_INT_IDMODULO == IdModulo || IdModulo == 0)
                                 && m.EPI_INT_MODULOPADRE == IdPadre
                                 && m.EPI_VCH_NOMBREMODULO.ToUpper().Contains(Descripcion.ToUpper())
                                 orderby m.EPI_INT_ORDEN ascending
                                 select new BEModulo
                                 {

                                     IDMODULO = m.EPI_INT_IDMODULO.ToString(),
                                     IDPADRE = m.EPI_INT_MODULOPADRE == null ? "" : m.EPI_INT_MODULOPADRE.ToString(),
                                     IDABUELO = (from ma in db.TBL_EPI_MODULO where ma.EPI_INT_IDMODULO == m.EPI_INT_MODULOPADRE select ma.EPI_INT_MODULOPADRE.ToString()).SingleOrDefault(),
                                     ORDEN = m.EPI_INT_ORDEN == null ? "" : m.EPI_INT_ORDEN.ToString(),
                                     MODULO = m.EPI_VCH_NOMBREMODULO == null ? "" : m.EPI_VCH_NOMBREMODULO,
                                     NOMWINDOWSFORM = m.EPI_VCH_WINDOWSFORM == null ? "" : m.EPI_VCH_WINDOWSFORM,
                                     NOMPAGINA = m.EPI_VCH_PAGINA == null ? "" : m.EPI_VCH_PAGINA,
                                     NOMAPPMOVIL = m.EPI_VCH_APPMOVIL == null ? "" : m.EPI_VCH_APPMOVIL,
                                     NOMIMAGEN16x16 = m.EPI_VCH_IMAGEN16x16,
                                     NOMIMAGEN32x32 = m.EPI_VCH_IMAGEN32x32,
                                     WINDOWS = Convert.ToBoolean(m.EPI_BIT_WINDOWS),
                                     WEB = Convert.ToBoolean(m.EPI_BIT_WEB),
                                     APPMOVIL = Convert.ToBoolean(m.EPI_BIT_MOVIL),
                                    
                                 }

                                 ).ToList();

                    return olModulos;

                }



            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
        internal static TBL_EPI_MODULO obtieneModulos(int IdModulo)
        {
            try
            {
                TBL_EPI_MODULO olModulos = new TBL_EPI_MODULO();
                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {

                    olModulos = (from m in db.TBL_EPI_MODULO
                                 where m.EPI_INT_IDMODULO == IdModulo &&
                                 m.EPI_BIT_ACTIVO == true

                                 select m).FirstOrDefault();

                }

                return olModulos;

            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message.ToString() + " (COMUNICAR A SISTEMAS)", "ERROR");
                return null;
            }
        }
        internal static List<BEOpcion> ListarOpcionesModulo(int IdModulo)
        {
            try
            {

                List<BEOpcion> olOpcionesModulo = new List<BEOpcion>();

                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {
                    olOpcionesModulo = (from om in db.TBL_EPI_OPCIONMODULO
                                        join o in db.TBL_EPI_OPCION on om.EPI_INT_IDOPCION equals o.EPI_INT_IDOPCION
                                        where om.EPI_BIT_ACTIVO == true
                                        && (om.EPI_INT_IDMODULO == IdModulo)
                                        select new BEOpcion
                                        {
                                            EPI_INT_IDOPCION = o.EPI_INT_IDOPCION,
                                            EPI_VCH_NOMBREOPCION = o.EPI_VCH_NOMBREOPCION,
                                            EPI_BIT_ESRIBBON = Convert.ToBoolean(o.EPI_BIT_ESRIBBON ?? false)
                                        }).ToList();

                }
                return olOpcionesModulo;

            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message.ToString() + " (COMUNICAR A SISTEMAS)", "ERROR");
                return null;

            }

        }
        internal static eResultado AgregarOpcionModulo(int IdModulo, int IdOpcion)
        {
            try
            {
                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {

                    TBL_EPI_OPCIONMODULO oOpcionModulo = (from x in db.TBL_EPI_OPCIONMODULO
                                                          where x.EPI_INT_IDMODULO == IdModulo
                                                              && x.EPI_INT_IDOPCION == IdOpcion
                                                              && x.EPI_INT_IDOPCION != null
                                                          select x).Take(1).FirstOrDefault();

                    if (oOpcionModulo == null)
                    {

                        oOpcionModulo = new TBL_EPI_OPCIONMODULO();
                        oOpcionModulo.EPI_BIT_ACTIVO = true;
                        oOpcionModulo.EPI_INT_IDMODULO = IdModulo;
                        oOpcionModulo.EPI_INT_IDOPCION = IdOpcion;
                        db.TBL_EPI_OPCIONMODULO.InsertOnSubmit(oOpcionModulo);
                        db.SubmitChanges();
                    }
                    else
                    {
                        oOpcionModulo.EPI_BIT_ACTIVO = true;
                        db.SubmitChanges();
                    }
                }

                return eResultado.Correcto;
            }
            catch (Exception ex)
            {
                return eResultado.Error;
                throw ex;
            }
        }
        internal static eResultado EliminarOpcionModulo(int IdModulo, int IdOpcion)
        {
            try
            {
                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {

                    TBL_EPI_OPCIONMODULO oOpcionModulo = (from x in db.TBL_EPI_OPCIONMODULO
                                                          where x.EPI_INT_IDMODULO == IdModulo
                                                              && x.EPI_BIT_ACTIVO == true
                                                              && x.EPI_INT_IDOPCION == IdOpcion
                                                              && x.EPI_INT_IDOPCION != null
                                                          select x).Take(1).FirstOrDefault();

                    if (oOpcionModulo != null)
                    {
                        oOpcionModulo.EPI_BIT_ACTIVO = false;
                        db.SubmitChanges();
                    }

                }

                return eResultado.Correcto;
            }
            catch (Exception ex)
            {
                return eResultado.Error;
                throw ex;
            }


        }
        internal static eResultado Insertar(TBL_EPI_MODULO oModulo)
        {
            DbTransaction dbTrans = null;

            try
            {
                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {
                    db.Connection.Open();
                    dbTrans = db.Connection.BeginTransaction();
                    db.Transaction = dbTrans;

                    oModulo.EPI_INT_ORDEN = Convert.ToByte((from p in db.TBL_EPI_MODULO where p.EPI_INT_MODULOPADRE == oModulo.EPI_INT_MODULOPADRE select p.EPI_INT_ORDEN).Max() + 1);
                    db.TBL_EPI_MODULO.InsertOnSubmit(oModulo);
                    db.SubmitChanges();

                    TBL_EPI_OPCIONMODULO oOpcionModulo = new TBL_EPI_OPCIONMODULO();

                    oOpcionModulo.EPI_BIT_ACTIVO = true;
                    oOpcionModulo.EPI_INT_IDMODULO = oModulo.EPI_INT_IDMODULO;

                    db.TBL_EPI_OPCIONMODULO.InsertOnSubmit(oOpcionModulo);
                    db.SubmitChanges();

                    dbTrans.Commit();


                }

                return eResultado.Correcto;


            }
            catch (Exception ex)
            {
                dbTrans.Rollback();
                XtraMessageBox.Show(ex.ToString() + " Comunicar a Sistemas", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return eResultado.Error;
               
            }


        }
        internal static eResultado Actualizar(TBL_EPI_MODULO oModulo)
        {
            DbTransaction dbTrans = null;

            try
            {
                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {
                    db.Connection.Open();
                    dbTrans = db.Connection.BeginTransaction();
                    db.Transaction = dbTrans;

                    TBL_EPI_MODULO oModuloActualiza = new TBL_EPI_MODULO();

                    oModuloActualiza = (from m in db.TBL_EPI_MODULO where m.EPI_INT_IDMODULO == oModulo.EPI_INT_IDMODULO select m).FirstOrDefault();


                    oModuloActualiza.EPI_VCH_NOMBREMODULO = oModulo.EPI_VCH_NOMBREMODULO;
                    oModuloActualiza.EPI_VCH_WINDOWSFORM = oModulo.EPI_VCH_WINDOWSFORM;
                    oModuloActualiza.EPI_VCH_PAGINA = oModulo.EPI_VCH_PAGINA;
                    oModuloActualiza.EPI_VCH_APPMOVIL = oModulo.EPI_VCH_APPMOVIL;
                    oModuloActualiza.EPI_BIT_WINDOWS = oModulo.EPI_BIT_WINDOWS;
                    oModuloActualiza.EPI_BIT_WEB = oModulo.EPI_BIT_WEB;
                    oModuloActualiza.EPI_BIT_MOVIL = oModulo.EPI_BIT_MOVIL;
                    oModuloActualiza.EPI_INT_MODULOPADRE = oModulo.EPI_INT_MODULOPADRE;
                    oModuloActualiza.EPI_DAT_FECHAMODIFICA = oModulo.EPI_DAT_FECHAMODIFICA;
                    oModuloActualiza.EPI_VCH_IMAGEN16x16 = oModulo.EPI_VCH_IMAGEN16x16;
                    oModuloActualiza.EPI_VCH_IMAGEN32x32 = oModulo.EPI_VCH_IMAGEN32x32;
                    oModuloActualiza.EPI_INT_IMAGENINDEX16X16 = oModulo.EPI_INT_IMAGENINDEX16X16;
                    oModuloActualiza.EPI_INT_IMAGENINDEX32X32 = oModulo.EPI_INT_IMAGENINDEX32X32;


                    db.SubmitChanges();

                    TBL_EPI_OPCIONMODULO oOpcionModulo = (from x in db.TBL_EPI_OPCIONMODULO
                                                          where x.EPI_INT_IDMODULO == oModulo.EPI_INT_IDMODULO
                                                              && x.EPI_INT_IDOPCION == null
                                                          select x).FirstOrDefault();

                    if (oOpcionModulo == null)
                    {

                        oOpcionModulo = new TBL_EPI_OPCIONMODULO();
                        oOpcionModulo.EPI_BIT_ACTIVO = true;
                        oOpcionModulo.EPI_INT_IDMODULO = oModulo.EPI_INT_IDMODULO;

                        db.TBL_EPI_OPCIONMODULO.InsertOnSubmit(oOpcionModulo);
                        db.SubmitChanges();
                    }
                    dbTrans.Commit();


                }

                return eResultado.Correcto;


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString() + " Comunicar a Sistemas", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dbTrans.Rollback();
                return eResultado.Error;
                throw ex;

            }




        }
        internal static object ListarModulos()
        {
            object olModulos = new object();
            using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
            {

                olModulos = (from m in db.TBL_EPI_MODULO
                             where m.EPI_INT_MODULOPADRE == 0
                             select new
                             {
                                 EPI_INT_IDMODULO = m.EPI_INT_IDMODULO,
                                 EPI_VCH_NOMBREMODULO = m.EPI_VCH_NOMBREMODULO,
                                 EPI_VCH_PAGINA = m.EPI_VCH_PAGINA,
                                 EPI_VCH_WINDOWSFORM = m.EPI_VCH_WINDOWSFORM,
                                 EPI_VCH_APPMOVIL = m.EPI_VCH_APPMOVIL

                             }).ToList();

            }

            return olModulos;
        }
        internal static List<BEOpcionModuloPerfil> ListarOpcionesModuloPerfil(int IdModulo)
        {
            try
            {
                List<BEOpcionModuloPerfil> olModulo = new List<BEOpcionModuloPerfil>();
                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {
                    olModulo = (from p in db.TBL_EPI_OPCIONMODULO
                                where p.EPI_BIT_ACTIVO == true
                                && p.TBL_EPI_OPCION.EPI_BIT_ACTIVO == true
                                && p.TBL_EPI_MODULO.EPI_BIT_ACTIVO == true
                                //&& p.SGC_INT_IDOPCION != null
                                && p.EPI_INT_IDMODULO == IdModulo
                                select new BEOpcionModuloPerfil
                                {
                                    EPI_INT_IDOPCION = Convert.ToInt32(p.EPI_INT_IDOPCION),
                                    EPI_INT_IDOPCIONMODULO = Convert.ToInt32(p.EPI_INT_IDOPCIONMODULO),
                                    EPI_VCH_NOMBREOPCIONMODULO = p.TBL_EPI_MODULO.EPI_VCH_NOMBREMODULO + " » " + p.TBL_EPI_OPCION.EPI_VCH_NOMBREOPCION,
                                    

                                }).ToList();

                }

                return olModulo;

            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.ToString() + " Comunicar a Sistemas", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<BEOpcionModuloPerfil>();

                throw ex;


            }

        }
        internal static List<EPI_SP_MODULOResult> ListarModulos2()
        {
            List<EPI_SP_MODULOResult> olModulos = new List<EPI_SP_MODULOResult>();
            using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
            {


                olModulos = db.EPI_SP_MODULO().ToList<EPI_SP_MODULOResult>();
            }
            return olModulos;
        }
    }
}
