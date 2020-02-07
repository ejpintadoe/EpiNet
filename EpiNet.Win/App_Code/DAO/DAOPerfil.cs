using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using EpiNet.Win.App_Code.BE;

namespace EpiNet.Win.App_Code.DAO
{
    class DAOPerfil
    {
        internal static BindingList<BEPerfil> ListarPerfil(int IdPerfil, string Descripcion)
        {

            try
            {

                List<BEPerfil> olPerfil = new List<BEPerfil>();

                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {

                    olPerfil = (from p in db.TBL_EPI_PERFIL
                                where p.EPI_BIT_ACTIVO == true
                                && (p.EPI_INT_IDPERFIL == IdPerfil || IdPerfil == 0)
                                && (p.EPI_VCH_NOMBREPERFIL.Contains(Descripcion))
                                select new BEPerfil
                                {
                                    EPI_INT_IDPERFIL = p.EPI_INT_IDPERFIL,
                                    EPI_VCH_NOMBREPERFIL = p.EPI_VCH_NOMBREPERFIL,
                                    EPI_BIT_ACTIVO = p.EPI_BIT_ACTIVO ?? false

                                }).ToList();

                }
                return new BindingList<BEPerfil>(olPerfil);

            }
            catch (Exception ex)
            {
                return new BindingList<BEPerfil>();

                throw ex;
            }

        }

        internal static eResultado EliminarOpcionModuloPerfil(int idPerfil, int idOpcionModulo)
        {
            try
            {
                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {

                    TBL_EPI_OPCIONMODULOPERFIL oOpcionModuloPerfil = (from x in db.TBL_EPI_OPCIONMODULOPERFIL
                                                                      where x.EPI_BIT_ACTIVO == true && x.EPI_INT_IDPERFIL == idPerfil
                                                                      && x.EPI_INT_IDOPCIONMODULO == idOpcionModulo
                                                                      select x).Take(1).FirstOrDefault();

                    if (oOpcionModuloPerfil != null)
                    {
                        oOpcionModuloPerfil.EPI_BIT_ACTIVO = false;
                        db.SubmitChanges();
                    }
                }
                return eResultado.Correcto;
                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return eResultado.Error;
                throw ex;
            }

        }

        internal static eResultado AgregarOpcionModuloPerfil(int idPerfil, int idOpcionModulo)
        {
            try
            {
                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {

                    TBL_EPI_OPCIONMODULOPERFIL oOpcionModuloPerfil = (from x in db.TBL_EPI_OPCIONMODULOPERFIL
                                                                      where x.EPI_INT_IDPERFIL == idPerfil
                                                                    && x.EPI_INT_IDOPCIONMODULO == idOpcionModulo

                                                                      select x).Take(1).FirstOrDefault();

                    if (oOpcionModuloPerfil == null)
                    {

                        oOpcionModuloPerfil = new TBL_EPI_OPCIONMODULOPERFIL();
                        oOpcionModuloPerfil.EPI_BIT_ACTIVO = true;
                        oOpcionModuloPerfil.EPI_INT_IDPERFIL = idPerfil;
                        oOpcionModuloPerfil.EPI_INT_IDOPCIONMODULO = idOpcionModulo;
                        db.TBL_EPI_OPCIONMODULOPERFIL.InsertOnSubmit(oOpcionModuloPerfil);
                        db.SubmitChanges();
                    }
                    else
                    {
                        oOpcionModuloPerfil.EPI_BIT_ACTIVO = true;
                        db.SubmitChanges();
                    }

                    List<TBL_EPI_MODULO> olModulo = (from m in db.TBL_EPI_OPCIONMODULOPERFIL
                                                     where m.EPI_BIT_ACTIVO == true
                                                     && m.EPI_INT_IDPERFIL == idPerfil
                                                     && m.TBL_EPI_OPCIONMODULO.EPI_BIT_ACTIVO == true
                                                     && m.TBL_EPI_OPCIONMODULO.TBL_EPI_MODULO.EPI_BIT_ACTIVO == true
                                                     select m.TBL_EPI_OPCIONMODULO.TBL_EPI_MODULO).Distinct().ToList();

                    if (olModulo.Count > 0)
                    {

                        foreach (TBL_EPI_MODULO item in olModulo)
                        {

                            AgregarOpcionModuloPerfilPadre(item.EPI_INT_IDMODULO, idPerfil);

                        }

                    }


                }

                return eResultado.Correcto;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return eResultado.Error;
                throw ex;
            }
        }

        public static void AgregarOpcionModuloPerfilPadre(int IdModuloHijo, int IdPerfil)
        {

            try
            {
                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {


                    TBL_EPI_MODULO oModulo = (from m in db.TBL_EPI_MODULO
                                              where m.EPI_INT_IDMODULO == IdModuloHijo
                                              && m.EPI_BIT_ACTIVO == true
                                              select m).SingleOrDefault();


                    if (oModulo != null)
                    {

                        TBL_EPI_OPCIONMODULO oOpcionModulo = (from om in db.TBL_EPI_OPCIONMODULO
                                                              where om.EPI_INT_IDMODULO == oModulo.EPI_INT_MODULOPADRE
                                                              && om.EPI_INT_IDOPCION == null
                                                              && om.EPI_BIT_ACTIVO == true
                                                              select om).Take(1).SingleOrDefault();
                        if (oOpcionModulo != null)
                        {

                            TBL_EPI_OPCIONMODULOPERFIL oOpcionModuloPerfil = (from omp in db.TBL_EPI_OPCIONMODULOPERFIL
                                                                              where omp.EPI_INT_IDOPCIONMODULO == oOpcionModulo.EPI_INT_IDOPCIONMODULO
                                                                              && omp.EPI_INT_IDPERFIL == IdPerfil
                                                                              select omp).Take(1).SingleOrDefault();


                            if (oOpcionModuloPerfil == null)
                            {
                                oOpcionModuloPerfil = new TBL_EPI_OPCIONMODULOPERFIL();

                                oOpcionModuloPerfil.EPI_BIT_ACTIVO = true;
                                oOpcionModuloPerfil.EPI_INT_IDOPCIONMODULO = oOpcionModulo.EPI_INT_IDOPCIONMODULO;
                                oOpcionModuloPerfil.EPI_INT_IDPERFIL = IdPerfil;

                                db.TBL_EPI_OPCIONMODULOPERFIL.InsertOnSubmit(oOpcionModuloPerfil);
                                db.SubmitChanges();

                            }
                            else
                            {

                                oOpcionModuloPerfil.EPI_BIT_ACTIVO = true;
                                db.SubmitChanges();

                            }


                        }

                        if (oModulo.EPI_INT_MODULOPADRE != 0)
                        {

                          AgregarOpcionModuloPerfilPadre(Convert.ToInt32(oModulo.EPI_INT_MODULOPADRE), IdPerfil);


                        }

                    }

                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString(), "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }

        }

        internal static List<BEOpcionModuloPerfil> ListarOpcionesModuloPerfil(int IdPerfil)
        {
            try
            {
                List<BEOpcionModuloPerfil> olOpcionModuloPerfil = new List<BEOpcionModuloPerfil>();
                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {
                    olOpcionModuloPerfil = (from p in db.TBL_EPI_OPCIONMODULOPERFIL
                                            where p.EPI_BIT_ACTIVO == true
                                            && p.TBL_EPI_OPCIONMODULO.EPI_BIT_ACTIVO == true
                                            && p.TBL_EPI_PERFIL.EPI_BIT_ACTIVO == true
                                            && p.TBL_EPI_OPCIONMODULO.EPI_INT_IDOPCION != null
                                            && p.EPI_INT_IDPERFIL == IdPerfil
                                            select new BEOpcionModuloPerfil
                                            {
                                              EPI_INT_IDOPCION = Convert.ToInt32(p.TBL_EPI_OPCIONMODULO.EPI_INT_IDOPCION),
                                              EPI_INT_IDOPCIONMODULOPERFIL   = Convert.ToInt32(p.EPI_INT_IDOPCIONMODULOPERFIL),
                                              EPI_INT_IDOPCIONMODULO  = Convert.ToInt32(p.EPI_INT_IDOPCIONMODULO),
                                              EPI_VCH_NOMBREOPCIONMODULO   = p.TBL_EPI_OPCIONMODULO.TBL_EPI_MODULO.EPI_VCH_NOMBREMODULO + " » " + p.TBL_EPI_OPCIONMODULO.TBL_EPI_OPCION.EPI_VCH_NOMBREOPCION,
                                            }).ToList();

                }
                return olOpcionModuloPerfil;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString(), "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<BEOpcionModuloPerfil>();

                throw ex;


            }

        }

        internal static eResultado Insertar(TBL_EPI_PERFIL oPerfil)
        {
            DbTransaction dbTrans = null;

            try
            {
                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {
                    db.Connection.Open();
                    dbTrans = db.Connection.BeginTransaction();
                    db.Transaction = dbTrans;
                                       
                    db.TBL_EPI_PERFIL.InsertOnSubmit(oPerfil);

                    db.SubmitChanges();
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

        internal static eResultado Actualizar(TBL_EPI_PERFIL oPerfil)
        {
            DbTransaction dbTrans = null;

            try
            {
                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {
                    db.Connection.Open();
                    dbTrans = db.Connection.BeginTransaction();
                    db.Transaction = dbTrans;

                    TBL_EPI_PERFIL oPerfilActualiza = new TBL_EPI_PERFIL();
                    
                    oPerfilActualiza = (from p in db.TBL_EPI_PERFIL where p.EPI_INT_IDPERFIL == oPerfil.EPI_INT_IDPERFIL select p).FirstOrDefault();

                    oPerfilActualiza.EPI_VCH_NOMBREPERFIL = oPerfil.EPI_VCH_NOMBREPERFIL;
                    oPerfilActualiza.EPI_BIT_ACTIVO = oPerfil.EPI_BIT_ACTIVO;
                    
                    db.SubmitChanges();
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

    }
}
