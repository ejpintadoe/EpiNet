using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using EpiNet.Win.App_Code.DAO;

namespace EpiNet.Win.App_Code.BL
{
    class BLFacturacion
    {
        public static string InsertaFactura(TBL_EPI_FACTURA oFac, List<TBL_EPI_FACTURADETALLE> olFacDetalle)
        {
            return DAOFacturacion.InsertaFactura(oFac, olFacDetalle);
        }
        internal static string ActualizaFactura(TBL_EPI_FACTURA oFac, List<TBL_EPI_FACTURADETALLE> olFacDetalle)
        {
            return DAOFacturacion.ActualizaFactura(oFac, olFacDetalle);
        }

        public static List<EPI_SP_LISTARFACTURAEDICIONResult> GetListaFacturaEdicion(int idFactura)
        {
            return DAOFacturacion.GetListaFacturaEdicionidFactura(idFactura);
        }

        public static List<EPI_SP_LISTAFACTURAResult> GetListaFactura(int tipoDoc, int idCliente, string serie, string criterio, DateTime fechaDesde, DateTime fechaHasta)
        {
            return DAOFacturacion.GetListaFactura(tipoDoc, idCliente, serie, criterio, fechaDesde, fechaHasta);
        }

        internal static TBL_EPI_FACTURA GetFactura(int idFactura)
        {
            return DAOFacturacion.GetFactura(idFactura);
        }

        internal static string AnulaFactura(int idFactura)
        {
            return DAOFacturacion.AnulaFactura(idFactura);
        }

        internal static void MarcaImpresa(int idFactura, bool impresa)
        {
            DAOFacturacion.MarcaImpresa(idFactura, impresa);
        }
    }
}
