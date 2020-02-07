using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using EpiNet.Win.Forms;

namespace EpiNet.Win.Modules
{
    public partial class user1 : BaseModule
    {
        public user1()
        {
            InitializeComponent();
            partName = "User1";
        }

        protected internal override void ButtonClick(string tag)
        {
            switch (tag)
            {
                case "NewUser1":
                    XtraForm1 form = new XtraForm1();
                    form.ShowDialog();
                    break;

            }
        }
    }
}
