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
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace EpiNet.Win
{
    public partial class userLogin : DevExpress.XtraEditors.XtraUserControl
    {
        public userLogin()
        {
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            TreeListNode tlAnnouncements = treeList1.AppendNode(new object[] { Properties.Resources.Announcements, MailType.Inbox, MailFolder.Announcements, 5 }, null);
            treeList1.AppendNode(new object[] { Properties.Resources.Inbox, MailType.Inbox, MailFolder.Announcements }, tlAnnouncements);
            treeList1.AppendNode(new object[] { Properties.Resources.SentItems, MailType.Sent, MailFolder.Announcements, 1 }, tlAnnouncements);

            treeList1.ExpandAll();
            //if (!DesignTimeTools.IsDesignMode)
            //    CreateMessagesList(treeList1.Nodes);
            //allowDataSourceChanged = true;
        }
    }

    public class MyTreeList : TreeList
    {
        public DevExpress.XtraTreeList.Handler.StateData StateData
        {
            get
            {
                return this.Handler.StateData;
            }
        }
        protected internal TreeListNode DropTaget
        {
            get
            {
                if (StateData != null && StateData.DragInfo != null && StateData.DragInfo.RowInfo != null) return StateData.DragInfo.RowInfo.Node;
                return null;
            }
        }
    }
}
