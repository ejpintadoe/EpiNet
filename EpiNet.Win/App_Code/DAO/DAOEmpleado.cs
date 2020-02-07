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
    class DAOEmpleado
    {
        internal static List<BEEmpleado> ListarEmpleados(int idEmpleado, string Descripcion)
        {
            try
            {
                List<BEEmpleado> olEmpleado = new List<BEEmpleado>();

                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {
                    olEmpleado = (from em in db.TBL_EPI_EMPLEADO
                                 where em.EPI_BIT_ACTIVO == true
                                 && (em.EPI_INT_IDEMPLEADO == idEmpleado || idEmpleado == 0)
                                 && em.EPI_VCH_NUMERODOCUMENTOIDENTIDAD.ToUpper().Contains(Descripcion.ToUpper())
                                 //orderby em.EPI_INT_ORDEN ascending
                                 select new BEEmpleado
                                 {

                                     EPI_INT_IDEMPLEADO = em.EPI_INT_IDEMPLEADO,
                                     EPI_VCH_NUMERODOCUMENTOIDENTIDAD = em.EPI_VCH_NUMERODOCUMENTOIDENTIDAD,
                                     EPI_VCH_NOMBRE = em.EPI_VCH_NOMBRE,
                                     EPI_VCH_APELLIDOPATERNO = em.EPI_VCH_APELLIDOPATERNO,
                                     EPI_VCH_APELLIDOMATERNO = em.EPI_VCH_APELLIDOMATERNO,
                                     EPI_INT_IDSEXO = Convert.ToInt32(em.EPI_INT_IDSEXO ?? 0),
                                     EPI_INT_IDTIPODOCUMENTOIDENTIDAD = Convert.ToInt32(em.EPI_INT_IDTIPODOCUMENTOIDENTIDAD ?? 0),
                                     EPI_VCH_DIRECCIONDOMICILIO = em.EPI_VCH_DIRECCIONDOMICILIO,
                                     EPI_VCH_TELEFONODOMICILIO  =em.EPI_VCH_TELEFONODOMICILIO,
                                     EPI_VCH_TELEFONOMOVIL = em.EPI_VCH_TELEFONOMOVIL

                                 }

                                 ).ToList();

                    return olEmpleado;

                }

            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        internal static eResultado Insertar(TBL_EPI_EMPLEADO oEmpleado)
        {
            DbTransaction dbTrans = null;

            try
            {
                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {
                    db.Connection.Open();
                    dbTrans = db.Connection.BeginTransaction();
                    db.Transaction = dbTrans;

                   
                    db.TBL_EPI_EMPLEADO.InsertOnSubmit(oEmpleado);
                    db.SubmitChanges();


                    dbTrans.Commit();


                }

                return eResultado.Correcto;


            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.ToString() + " Comunicar a Sistemas", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dbTrans.Rollback();
                return eResultado.Error;
                throw ex;


            }


        }
        internal static eResultado Actualizar(TBL_EPI_EMPLEADO oEmpleado)
        {
            DbTransaction dbTrans = null;

            try
            {
                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {
                    db.Connection.Open();
                    dbTrans = db.Connection.BeginTransaction();
                    db.Transaction = dbTrans;

                    TBL_EPI_EMPLEADO oEmpleadoAct = new TBL_EPI_EMPLEADO();

                    oEmpleadoAct = (from em in db.TBL_EPI_EMPLEADO where em.EPI_INT_IDEMPLEADO == oEmpleado.EPI_INT_IDEMPLEADO select em).FirstOrDefault();
                                       
                    oEmpleadoAct.EPI_INT_IDTIPODOCUMENTOIDENTIDAD = oEmpleado.EPI_INT_IDTIPODOCUMENTOIDENTIDAD;
                    oEmpleadoAct.EPI_VCH_NUMERODOCUMENTOIDENTIDAD = oEmpleado.EPI_VCH_NUMERODOCUMENTOIDENTIDAD;
                    oEmpleadoAct.EPI_INT_IDSEXO = oEmpleado.EPI_INT_IDSEXO;
                    oEmpleadoAct.EPI_VCH_NOMBRE = oEmpleado.EPI_VCH_NOMBRE;
                    oEmpleadoAct.EPI_VCH_APELLIDOPATERNO = oEmpleado.EPI_VCH_APELLIDOPATERNO;
                    oEmpleadoAct.EPI_VCH_APELLIDOMATERNO = oEmpleado.EPI_VCH_APELLIDOMATERNO;
                    oEmpleadoAct.EPI_VCH_TELEFONODOMICILIO = oEmpleado.EPI_VCH_TELEFONODOMICILIO;
                    oEmpleadoAct.EPI_VCH_TELEFONOMOVIL = oEmpleado.EPI_VCH_TELEFONOMOVIL;
                    oEmpleadoAct.EPI_VCH_CORREOPERSONAL = oEmpleado.EPI_VCH_CORREOPERSONAL;
                    oEmpleadoAct.EPI_VCH_DIRECCIONDOMICILIO = oEmpleado.EPI_VCH_DIRECCIONDOMICILIO;

                    db.SubmitChanges();

                    dbTrans.Commit();


                }

                return eResultado.Correcto;


            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.ToString() + " Comunicar a Sistemas", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dbTrans.Rollback();
                return eResultado.Error;
                throw ex;

            }




        }

        internal static TBL_EPI_EMPLEADO obtieneEmpleados(int idEmpleado)
        {
            try
            {
                TBL_EPI_EMPLEADO olEmpleado = new TBL_EPI_EMPLEADO();
                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {

                    olEmpleado = (from em in db.TBL_EPI_EMPLEADO
                                 where em.EPI_INT_IDEMPLEADO == idEmpleado &&
                                 em.EPI_BIT_ACTIVO == true

                                 select em).FirstOrDefault();

                }

                return olEmpleado;

            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message.ToString() + " (COMUNICAR A SISTEMAS)", "ERROR");
                return null;
            }
        }
    }
}
