using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using EpiNet.Win.App_Code.BE;
using System.Collections.Generic;

namespace EpiNet.Win.Reportes.Ventas
{
    public partial class XR_FacturaVenta : DevExpress.XtraReports.UI.XtraReport
    {
        public XR_FacturaVenta()
        {
            InitializeComponent();
        }
        public void InitData(List<BEFacturaDetalle> olDetalle)
        {

            objectDataSource1.DataSource = olDetalle;
        }

    }
}
