using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EpiNet.Win.App_Code.DAO
{
    class DAOCategoria
    {
        internal static List<TBL_EPI_CATEGORIA> ListarCategoria(int id, string descripcion)
        {
            try
            {
                List<TBL_EPI_CATEGORIA> olCategoria = new List<TBL_EPI_CATEGORIA>();

                using (DataClassEpiNetDataContext db = new DataClassEpiNetDataContext())
                {
                    olCategoria = (from p in db.TBL_EPI_CATEGORIA
                              where (p.EPI_INT_IDCATEGORIA == id || id == 0)
                              && (p.EPI_VCH_DESCRIPCION.ToUpper().Contains(descripcion.ToUpper()))
                              select p).ToList();

                }

                return olCategoria;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString() + " (COMUNICAR A SISTEMAS)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<TBL_EPI_CATEGORIA>();
            }
        }
    }
}
