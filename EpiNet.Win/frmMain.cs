using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraNavBar;
using System.Reflection;
using DevExpress.XtraTreeList;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTreeList.Nodes;
using EpiNet.Win.App_Code;
using EpiNet.Win.App_Code.BE;
using System.Globalization;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraTabbedMdi;
using DevExpress.XtraBars.Helpers;
using EpiNet.Win.App_Code.BL;

namespace EpiNet.Win
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        BEUsuario oUsuario = new BEUsuario();
        NavBarGroup nbGroup;
        NavBarItem nbItem;

        ModulesNavigator modulesNavigator;

        Assembly asm = Assembly.GetEntryAssembly();

        public frmMain()
        {
            //TEST
            InitializeComponent();
            InitSkinGallery();
            oUsuario = BaseForm.VariablesGlobales.MiUsuario;
            BaseForm.VariablesGlobales.Impuesto = BLImpuesto.GetListImpuesto(0, "");

            if (!string.IsNullOrEmpty(oUsuario.Usuario.EPI_VCH_SKINGALLERY))
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(oUsuario.Usuario.EPI_VCH_SKINGALLERY);

            modulesNavigator = new ModulesNavigator(ribbonControlMain, xtraTabbedMdiManager1);


            TreeListNode tlAnnouncements = treeList1.AppendNode(new object[] { Properties.Resources.Announcements, MailType.Inbox, MailFolder.Announcements, 5 }, null);
            treeList1.AppendNode(new object[] { Properties.Resources.Inbox, MailType.Inbox, MailFolder.Announcements }, tlAnnouncements);
            treeList1.AppendNode(new object[] { Properties.Resources.SentItems, MailType.Sent, MailFolder.Announcements, 1 }, tlAnnouncements);


            this.GeneraMenu(oUsuario.Modulos.OrderBy(x => x.EPI_INT_ORDEN).ToList());
            
        }

        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(skinRibbonGalleryBarItem1, true);

            //SkinHelper.InitSkinGalleryDropDown(galleryDropDown1);

        }


        void GeneraMenu(List<TBL_EPI_MODULO> olModulos)
        {

            int codPadre = 0;
            Type formtype;
                        
            List<TBL_EPI_MODULO> olMenuPadre = (from p in olModulos where p.EPI_INT_MODULOPADRE == codPadre select p).ToList();

            bool nieto = false;

            foreach (var item in olMenuPadre)
            {
                nbGroup = new NavBarGroup();
                formtype = asm.GetType(string.Format("EpiNet.Win.{0}", item.EPI_VCH_WINDOWSFORM));
                nbGroup.Caption = item.EPI_VCH_NOMBREMODULO;

                if (item.EPI_INT_IMAGENINDEX32X32 != null && item.EPI_INT_IMAGENINDEX32X32 > -1)
                    nbGroup.LargeImage = imageCollection32x32.Images[Convert.ToInt32(item.EPI_INT_IMAGENINDEX32X32)];
                   
                //nbGroup.LargeImage = (Bitmap)(object)Properties.Resources.ResourceManager.GetObject(item.EPI_VCH_IMAGEN32x32 ?? "", CultureInfo.CurrentUICulture);
                nbGroup.Tag = new NavBarGroupTagObject(item.EPI_VCH_NOMBREMODULO,item.EPI_INT_IDMODULO, formtype);
                navBarControlMain.Groups.Add(nbGroup);

                nieto = tieneNieto(item.EPI_INT_IDMODULO, olModulos);

                if (nieto == true)
                {
                    TreeList tree = new TreeList();
                    nbGroup.GroupStyle = NavBarGroupStyle.ControlContainer;
                    nbGroup.GroupClientHeight = 100;
                    //nbGroup.Expanded = true;
                    tree = new TreeList();
                    //tree.ShownEditor += ChildClick;

                    //tree.StateImageList = navbarImageCollection;
                    construyeTreeList(tree, item.EPI_INT_IDMODULO, olModulos);
                    tree.LookAndFeel.ActiveLookAndFeel.UseDefaultLookAndFeel = true;
                    nbGroup.ControlContainer.Controls.Add(tree);
                }
                else
                {
                    nbItem = new NavBarItem();

                    navBarControlMain.BeginUpdate();
                    //SubMenu(nbItem, item.id, olMenu);
                    SubMenu(nbItem, item.EPI_INT_IDMODULO, olModulos);
                    navBarControlMain.EndUpdate();
                }
            }
        }

        public void GenerarOpciones(NavBarGroupTagObject groupObject)
        {
            bool existeRibbonPage = false;
            bool isRibbonPageVisible = false;

            foreach (RibbonPage page in ribbonControlMain.Pages)
            {
                if (!string.IsNullOrEmpty(string.Format("{0}", page.Tag)))
                {
                   
                    isRibbonPageVisible = groupObject.Name.Equals(page.Tag);

                    page.Visible = isRibbonPageVisible;

                    if (isRibbonPageVisible)
                    {
                        existeRibbonPage = isRibbonPageVisible;
                        ribbonControlMain.SelectedPage = page;
                    }
                }
            }

            ribbonPage1.Visible = true;
            ribbonPage2.Visible = true;



            if (!existeRibbonPage)
            {
                
                RibbonPage ribbonPage = new RibbonPage();
                RibbonPageGroup ribbonPageGroup = new RibbonPageGroup();
                

                ribbonPage.Text = groupObject.Name.ToUpper();
                ribbonPage.Tag = groupObject.Name;

                ribbonPageGroup.Text = "Opciones";
                ribbonPageGroup.ShowCaptionButton = false;

                List<TBL_EPI_OPCION> olOpcion = new BLOpcion().ListarOpcionModulo(Convert.ToInt32(oUsuario.Usuario.EPI_INT_IDPERFIL), groupObject.IdModulo);


                foreach (var item in olOpcion)
                {
                    BarButtonItem barButtonItem = new BarButtonItem();
                    barButtonItem.Caption = item.EPI_VCH_NOMBREOPCION;
                    //barButtonItem.ImageOptions.LargeImage = global::EpiNet.Win.Properties.Resources.NewMail_32x32;
                    barButtonItem.ImageOptions.LargeImage = imageCollection32x32.Images[Convert.ToInt32(item.EPI_INT_IMAGENINDEX32X32 ?? 0)];
                    InitBarButtonItem(barButtonItem, item.EPI_VCH_NOMBREOPCION, "Nuevo Modulo");
                    ribbonPageGroup.ItemLinks.Add(barButtonItem);
                }

               
                ribbonPage.Groups.Add(ribbonPageGroup);

                ribbonControlMain.Pages.Add(ribbonPage);
                ribbonControlMain.SelectedPage = ribbonPage;
            }

        }

        public void construyeTreeList(TreeList tree, int subMenu, List<TBL_EPI_MODULO> olModulos)
        {
            tree.Columns.AddField("link").Visible = true;
            tree.BorderStyle = BorderStyles.NoBorder;

            List<TBL_EPI_MODULO> olModulosHijos = olModulos.Where(x => x.EPI_INT_MODULOPADRE == subMenu).ToList();
            //TreeListNode nodoHijo = null;
            foreach (var item in olModulosHijos)
            {
                TreeListNode nodo = tree.AppendNode(null, null);
                nodo.SetValue("link", item.EPI_VCH_NOMBREMODULO);
                ////if (item.SLI_INT_IDIMGFORM != null)
                ////{
                ////    nodo.StateImageIndex = (int)item.SLI_INT_IDIMGFORM;
                ////}
                //nodoHijo = null;                
                construyeTreeListSubMenu(nodo, item.EPI_INT_IDMODULO, olModulos, tree);
            }

            tree.OptionsView.ShowColumns = false;
            tree.OptionsView.ShowIndicator = false;
            tree.OptionsView.ShowHorzLines = false;
            tree.OptionsView.ShowVertLines = false;
            //tree.Columns["link"].OptionsColumn.ReadOnly = true;
            //tree.Columns["link"].OptionsColumn.AllowEdit = true;
            //tree.Appearance.Empty.BackColor = Color.Transparent;
            //tree.Appearance.OddRow.BackColor = Color.Transparent;
            //tree.Columns["link"].AppearanceCell.BackColor = Color.Transparent;
            //tree.Columns["link"].AppearanceCell.BorderColor = Color.Transparent;
            tree.OptionsView.EnableAppearanceOddRow = true;
            tree.OptionsView.EnableAppearanceEvenRow = true;
            tree.Dock = DockStyle.Fill;
        }

        public void construyeTreeListSubMenu(TreeListNode nodoP, int subTree, List<TBL_EPI_MODULO> olModulos, TreeList tree)
        {
            List<TBL_EPI_MODULO> olModulosHijos = olModulos.Where(x => x.EPI_INT_MODULOPADRE == subTree).ToList();
            foreach (var item in olModulosHijos)
            {
                ////ToolStripMenuItem SSMenu = new ToolStripMenuItem(hijo.SLI_VCH_NOMBREMODULO.ToString(), null, new EventHandler(ChildClick));                
                nodoP = tree.AppendNode(null, nodoP);
                ////nodoP.HasChildren = true;
                //if (item.SLI_INT_IDIMGFORM != null)
                //{
                //    nodoP.StateImageIndex = (int)item.SLI_INT_IDIMGFORM;
                //}

                nodoP.SetValue("link", item.EPI_VCH_NOMBREMODULO);

                nodoP.ImageIndex = item.EPI_INT_IDMODULO;
                construyeTreeListSubMenu(nodoP, item.EPI_INT_IDMODULO, olModulos, tree);
            }
        }

        private bool tieneNieto(int subMenu, List<TBL_EPI_MODULO> olModulos)
        {
            try
            {
                bool tiene = false;
                List<TBL_EPI_MODULO> olModulosHijos = olModulos.Where(x => x.EPI_INT_MODULOPADRE == subMenu).ToList();
                foreach (var item in olModulosHijos)
                {
                    List<TBL_EPI_MODULO> olModulosNietos = olModulos.Where(x => x.EPI_INT_MODULOPADRE == item.EPI_INT_IDMODULO).ToList();
                    if (olModulosNietos.Count > 0)
                    {
                        tiene = true;
                        return tiene;
                    }
                }

                return tiene;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString() + " (COMUNICAR A SISTEMAS)", "ERROR");
                return false;
            }
        }

        public void SubMenu(NavBarItem mnu, int submenu, List<TBL_EPI_MODULO> olModulos)
        {
            List<TBL_EPI_MODULO> olModulosHijos = olModulos.Where(x => x.EPI_INT_MODULOPADRE == submenu).ToList();
            Type formtypeHijo;
            foreach (var hijo in olModulosHijos)
            {
                //ToolStripMenuItem SSMenu = new ToolStripMenuItem(hijo.SLI_VCH_NOMBREMODULO.ToString(), null, new EventHandler(ChildClick)); 
                formtypeHijo = asm.GetType(string.Format("EpiNet.Win.{0}", hijo.EPI_VCH_WINDOWSFORM));
                nbItem = new NavBarItem();
                nbItem.Caption = hijo.EPI_VCH_NOMBREMODULO;

                if(hijo.EPI_INT_IMAGENINDEX16X16 != null && hijo.EPI_INT_IMAGENINDEX16X16 > 0)
                    nbItem.ImageOptions.SmallImage = imageCollection16x16.Images[Convert.ToInt32(hijo.EPI_INT_IMAGENINDEX16X16)];
                    //nbItem.ImageOptions.SmallImage = (Bitmap)(object)Properties.Resources.ResourceManager.GetObject(hijo.EPI_VCH_IMAGEN16x16 ?? "", CultureInfo.CurrentUICulture);
                nbItem.Tag = new NavBarGroupTagObject(hijo.EPI_VCH_NOMBREMODULO,hijo.EPI_INT_IDMODULO, formtypeHijo);

                //if (hijo.SLI_INT_IDIMGFORM != null)
                //{
                //    nbItem.SmallImageIndex = (int)hijo.SLI_INT_IDIMGFORM;
                //}
                nbItem.LinkClicked += new NavBarLinkEventHandler(this.navBarItem_LinkClicked);
                SubMenu(nbItem, hijo.EPI_INT_IDMODULO, olModulos);
                nbGroup.ItemLinks.Add(nbItem);

                //mnu.DropDownItems.Add(SSMenu);
            }
        }
        
        private void navBarItem_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            //object data = GetModuleData((NavBarGroupTagObject)e.Link.Item.Tag);
            NavBarGroupTagObject groupObject = e.Link.Item.Tag as NavBarGroupTagObject;

            if (groupObject.ModuleType == null) return;

            modulesNavigator.ChangeNavBarGroup(groupObject);

            groupObject.Module.MdiParent = this;
            groupObject.Module.Text = groupObject.Name;
            groupObject.Module.Show();

            groupObject.Module.ShowModule(false);
            this.GenerarOpciones(groupObject);


        }

        private void navBarControl_ActiveGroupChanged(object sender, NavBarGroupEventArgs e)
        {
            //object data = GetModuleData((NavBarGroupTagObject)e.Group.Tag);
            NavBarGroupTagObject groupObject = e.Group.Tag as NavBarGroupTagObject;


            if (groupObject == null) return;
            if (groupObject.ModuleType == null) return;

            modulesNavigator.ChangeNavBarGroup(groupObject); 
        }
        internal void ShowInfo(int? count)
        {
            //if (count == null) bsiInfo.Caption = string.Empty;
            //else
            //    bsiInfo.Caption = string.Format(Properties.Resources.InfoText, count.Value);
            HtmlText = string.Format("{0}{1}", GetModuleName(), GetModulePartName());
        }

        string GetModuleName()
        {
            if (string.IsNullOrEmpty(modulesNavigator.CurrentModule.PartName)) return CurrentModuleName;
            return string.Format("<b>{0}</b>", CurrentModuleName);
        }
        string GetModulePartName()
        {
            if (string.IsNullOrEmpty(modulesNavigator.CurrentModule.PartName)) return null;
            return string.Format(" - {0}", modulesNavigator.CurrentModule.PartName);
        }

        public string CurrentModuleName { get { return modulesNavigator.CurrentModule.ModuleName; } }

        void InitBarButtonItem(DevExpress.XtraBars.BarButtonItem buttonItem, object tag, string description)
        {
            buttonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(bbi_ItemClick);
            buttonItem.Hint = description;
            buttonItem.Tag = tag;
        }

        private void bbi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            modulesNavigator.CurrentModule.ButtonClick(string.Format("{0}", e.Item.Tag));
        }

        private void xtraTabbedMdiManager1_SelectedPageChanged(object sender, EventArgs e)
        {
            MdiTabPageEventArgs pa = (MdiTabPageEventArgs)e;
            bool isRibbonPageVisible = false;
            foreach (RibbonPage page in ribbonControlMain.Pages)
            {
                if (!string.IsNullOrEmpty(string.Format("{0}", page.Tag)))
                {


                    if(!string.IsNullOrEmpty(string.Format("{0}", pa.Page)))
                       isRibbonPageVisible = pa.Page.Text.Equals(page.Tag);

                    page.Visible = isRibbonPageVisible;

                    if (isRibbonPageVisible)
                    {
                         ribbonControlMain.SelectedPage = page;
                    }
                }
            }

            ribbonPage1.Visible = true;
            ribbonPage2.Visible = true;



        }

        private void skinRibbonGalleryBarItem1_GalleryItemClick(object sender, GalleryItemClickEventArgs e)
        {
            //string ss = e.Item.Caption;
            new BLUsuario().updateSkinGallery(e.Item.Caption, oUsuario.Usuario.EPI_INT_IDUSUARIO);

        }
    }
}