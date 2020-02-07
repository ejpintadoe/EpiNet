using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports;
using DevExpress.XtraReports.UI;
using EpiNet.Win.App_Code.BE;
using System.Collections.Generic;
using DevExpress.XtraReports.Parameters;

namespace EpiNet.Win.Reportes
{
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport1()
        {
            InitializeComponent();
        }

        public void InitData(List<BEFacturaDetalle> olDetalle)
        {

            objectDataSource1.DataSource = olDetalle;
        }

    }
}
