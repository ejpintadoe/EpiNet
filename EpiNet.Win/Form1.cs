using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EpiNet.Win.Forms;
using EpiNet.Win.Modules;
using DevExpress.XtraTabbedMdi;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace EpiNet.Win
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
            InitData();

            ribbonPage1.Visible = false;
            ribbonPage2.Visible = false;

       
        }
        private void InitData()
        {
            TreeListNode tlAnnouncements = treeList1.AppendNode(new object[] { Properties.Resources.Announcements, MailType.Inbox, MailFolder.Announcements, 5 }, null);
            tlAnnouncements.Tag = "prueba";
            treeList1.AppendNode(new object[] { Properties.Resources.Inbox, MailType.Inbox, MailFolder.Announcements }, tlAnnouncements);
            treeList1.AppendNode(new object[] { Properties.Resources.SentItems, MailType.Sent, MailFolder.Announcements, 1 }, tlAnnouncements);


            treeList1.ExpandAll();
            //if (!DesignTimeTools.IsDesignMode)
            //    CreateMessagesList(treeList1.Nodes);
            //allowDataSourceChanged = true;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmLogin childForm1 = new frmLogin();
            childForm1.MdiParent = this;
            //childForm1.FormClosing +=  OnMdiChildFormClosing();
            childForm1.Show();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //frmMain modulo = new frmMain();
            //modulo.MdiParent = this;
            //modulo.Show();

            frmMailEdit sfrom = new frmMailEdit();
            sfrom.MdiParent = this;
            sfrom.Show();
            //XtraMessageBox("");

        }

        private void xtraTabbedMdiManager1_SelectedPageChanged(object sender, System.EventArgs e)
        {
            string ee = "es";
            DevExpress.XtraTabbedMdi.MdiTabPageEventArgs pa = (DevExpress.XtraTabbedMdi.MdiTabPageEventArgs)e;
            if (pa.Page == null)
                ee = "null";
            else
                ee = pa.Page.Text;

            switch (ee)
            {
                case "frmMailEdit":
                    ribbonPage2.Visible = true;
                    
                    ribbonPage1.Visible = false;

                    break;

                case "frmLogin":

                    ribbonPage2.Visible = false;
                    ribbonPage1.Visible = true;
                    break;

                case "null":
                    ribbonPage2.Visible = false;
                    ribbonPage1.Visible = false;
                    break;
             
                default:
                    break;
            }

        }

        void OnMdiChildFormClosing(object sender, FormClosingEventArgs e)
        {
            XtraMdiTabPage page = xtraTabbedMdiManager1.Pages[sender as Form];
            int index = xtraTabbedMdiManager1.Pages.IndexOf(page);
            index--;
            if (index >= 0)
                xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[index];
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmLogin childForm1 = new frmLogin();
            childForm1.MdiParent = this;
            //childForm1.FormClosing +=  OnMdiChildFormClosing();
            childForm1.Show();
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmMailEdit sfrom = new frmMailEdit();
            sfrom.MdiParent = this;
            sfrom.Show();
        }

        private void treeList1_ShownEditor(object sender, EventArgs e)
        {
            TreeList treeList = (TreeList)sender;
            string aa = "";
            for (int i = 0; i < treeList.Nodes.Count; i++)
            {
                aa = (string)treeList.Nodes[i].Tag;
            }


          

            
        }

        private void treeList1_ColumnButtonClick(object sender, EventArgs e)
        {
            string aa = "";
        }

        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            string aa = (string)e.Node.Tag;
        }
    }
}
