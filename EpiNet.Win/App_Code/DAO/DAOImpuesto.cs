using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpiNet.Win.App_Code.BE;

namespace EpiNet.Win.App_Code.DAO
{
    class DAOImpuesto
    {
        internal static object ListarImpuesto(int id, string nombre)
        {
            try
            {
                object olImp = new List<object>();

                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {

                    olImp = (from im in db.TBL_EPI_IMPUESTO
                             where (im.EPI_INT_IDIMPUESTO == id || id == 0)
                             && (im.EPI_VCH_NOMBRE.Contains(nombre))
                             select new
                             {
                                 EPI_INT_IDIMPUESTO = im.EPI_INT_IDIMPUESTO,
                                 EPI_VCH_NOMBRE = im.EPI_VCH_NOMBRE + " - (" + im.EPI_NUM_PORCENTAJE.ToString() + "%)"
                             }).ToList();

                }

                return olImp;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        internal static List<BEImpuesto> GetListImpuesto(int id, string nombre)
        {
            try
            {
               List<BEImpuesto> olImp = new List<BEImpuesto>();

                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {

                    olImp = (from im in db.TBL_EPI_IMPUESTO
                             where (im.EPI_INT_IDIMPUESTO == id || id == 0)
                             && im.EPI_VCH_NOMBRE.Contains(nombre)
                             select new BEImpuesto
                             {
                                 IdImpuesto = im.EPI_INT_IDIMPUESTO,
                                 Descripcion = im.EPI_VCH_NOMBRE ?? "",
                                 Porcentaje = Convert.ToDecimal(im.EPI_NUM_PORCENTAJE ?? 0)
                             }).ToList();


                }

                return olImp;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
