using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EpiNet.Win.App_Code.BE;

namespace EpiNet.Win.App_Code.DAO
{
    class DAOOpcion
    {
        internal static List<TBL_EPI_OPCION> ListarOpcionModulo(int idPerfil, int idModulo)
        {
            try
            {
                List<TBL_EPI_OPCION> olOpcion = new List<TBL_EPI_OPCION>();
                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {


                    if (idPerfil == Convert.ToInt32(ePerfil.Admin))
                    {
                        olOpcion = (from opm in db.TBL_EPI_OPCIONMODULO
                                    where opm.EPI_INT_IDMODULO == idModulo
                                    && opm.EPI_BIT_ACTIVO == true
                                    && opm.TBL_EPI_OPCION.EPI_BIT_ESRIBBON == true
                                    select opm.TBL_EPI_OPCION).ToList();
                    }
                    else
                    {
                        olOpcion = (from opmp in db.TBL_EPI_OPCIONMODULOPERFIL
                                    where opmp.EPI_BIT_ACTIVO == true 
                                    && opmp.EPI_INT_IDPERFIL == idPerfil
                                    && opmp.TBL_EPI_OPCIONMODULO.EPI_INT_IDMODULO == idModulo
                                    && opmp.TBL_EPI_OPCIONMODULO.TBL_EPI_OPCION.EPI_BIT_ESRIBBON == true
                                    select opmp.TBL_EPI_OPCIONMODULO.TBL_EPI_OPCION).ToList();

                    }

                }
                return olOpcion;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        internal static eResultado Actualizar(TBL_EPI_OPCION oOpcion)
        {
            DbTransaction dbTrans = null;

            try
            {
                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {

                    db.Connection.Open();
                    dbTrans = db.Connection.BeginTransaction();
                    db.Transaction = dbTrans;

                    TBL_EPI_OPCION oOpcionAct = new TBL_EPI_OPCION();


                    oOpcionAct = (from p in db.TBL_EPI_OPCION where p.EPI_INT_IDOPCION == oOpcion.EPI_INT_IDOPCION select p).FirstOrDefault();

                    oOpcionAct.EPI_VCH_NOMBREOPCION = oOpcion.EPI_VCH_NOMBREOPCION;
                    oOpcionAct.EPI_VCH_IMAGEN16X16 = oOpcion.EPI_VCH_IMAGEN16X16;
                    oOpcionAct.EPI_VCH_IMAGEN32X32 = oOpcion.EPI_VCH_IMAGEN32X32;
                    oOpcionAct.EPI_INT_IMAGENINDEX16X16 = oOpcion.EPI_INT_IMAGENINDEX16X16;
                    oOpcionAct.EPI_INT_IMAGENINDEX32X32 = oOpcion.EPI_INT_IMAGENINDEX32X32;
                    oOpcionAct.EPI_DAT_FECHAMODIFICACION = DateTime.Now;
                    


                    db.SubmitChanges();
                    dbTrans.Commit();

                }
                return eResultado.Correcto;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + " Comunicar a Sistemas", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dbTrans.Rollback();
                return eResultado.Error;
                throw ex;

            }

        }

        internal static eResultado Insertar(TBL_EPI_OPCION oOpcion)
        {


            DbTransaction dbTrans = null;

            try
            {
                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {
                    db.Connection.Open();
                    dbTrans = db.Connection.BeginTransaction();
                    db.Transaction = dbTrans;

                    oOpcion.EPI_DAT_FECHACREACION = DateTime.Now;

                    db.TBL_EPI_OPCION.InsertOnSubmit(oOpcion);

                    db.SubmitChanges();
                    dbTrans.Commit();

                }
                return eResultado.Correcto;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + " Comunicar a Sistemas", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dbTrans.Rollback();
                return eResultado.Error;
                throw ex;
            }
        }

        internal static List<BEOpcion> Listar(int IdOpcion, string Descripcion)
        {
            try
            {
                List<BEOpcion> olOpciones = new List<BEOpcion>();

                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {

                    olOpciones = (from op in db.TBL_EPI_OPCION
                                  where op.EPI_BIT_ACTIVO == true
                                  && (op.EPI_INT_IDOPCION == IdOpcion || IdOpcion == 0)
                                  && (op.EPI_VCH_NOMBREOPCION == Descripcion || Descripcion == "")
                                  select new BEOpcion
                                  {
                                     EPI_INT_IDOPCION =   op.EPI_INT_IDOPCION,
                                     EPI_VCH_NOMBREOPCION = op.EPI_VCH_NOMBREOPCION,
                                     EPI_BIT_ESRIBBON = Convert.ToBoolean(op.EPI_BIT_ESRIBBON ?? false),
                                     EPI_VCH_IMAGEN16X16 = op.EPI_VCH_IMAGEN16X16,
                                     EPI_VCH_IMAGEN32X32 = op.EPI_VCH_IMAGEN32X32,
                                     EPI_INT_IMAGENINDEX16X16 = Convert.ToInt32(op.EPI_INT_IMAGENINDEX16X16 ?? 0),
                                     EPI_INT_IMAGENINDEX32X32 =Convert.ToInt32(op.EPI_INT_IMAGENINDEX32X32 ?? 0)


                                  } ).ToList();
                }
                return olOpciones;
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }
    }
}
