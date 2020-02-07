using DevExpress.Utils.Menu;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.Utils.Design;
using DevExpress.XtraTabbedMdi;
using EpiNet.Win.Modules;

namespace EpiNet.Win
{
    class Controls
    {
    }
    public class ModulesNavigator
    {
        RibbonControl ribbon;
        PanelControl panel;
        XtraTabbedMdiManager tabbedMdiManager;
        public ModulesNavigator(RibbonControl ribbon, XtraTabbedMdiManager tabbedMdiManager)
        {
            this.ribbon = ribbon;
            //this.panel = panel;
            this.tabbedMdiManager = tabbedMdiManager;
        }
        //public void ChangeGroup(NavBarGroup group, object moduleData)
        public void ChangeNavBarGroup(NavBarGroupTagObject groupObject)
        {
            
            if (groupObject == null) return;
     
            bool firstShow = groupObject.Module == null;
            if (firstShow)
            {
                if (SplashScreenManager.Default == null)
                    SplashScreenManager.ShowForm(ribbon.FindForm(), typeof(EpiNet.Win.Forms.wfMain), false, true);


                if (SplashScreenManager.Default != null)
                {
                    //Form frm = moduleData as Form;
                    //if (frm != null)
                    //{
                    //    if (SplashScreenManager.FormInPendingState)
                    //        SplashScreenManager.CloseForm();
                    //    else
                    //        SplashScreenManager.CloseForm(false, 500, frm);
                    //}
                    //else
                        SplashScreenManager.CloseForm();
                }
            }

            ConstructorInfo constructorInfoObj = groupObject.ModuleType.GetConstructor(Type.EmptyTypes);
            if (constructorInfoObj != null)
            {
                groupObject.Module = constructorInfoObj.Invoke(null) as BaseModule;
                // groupObject.Module.InitModule(ribbon, null);
            }


            if (groupObject.Module != null)
            {

                //if (panel.Controls.Count > 0)
                //{
                //    BaseModule currentModule = panel.Controls[0] as BaseModule;
                //    if (currentModule != null)
                //        currentModule.HideModule();
                //}
                //panel.Controls.Clear();
                //panel.Controls.Add(groupObject.Module);
                //tabbedMdiManager.MdiParent = groupObject.Module;
                //XtraMdiTabPage page = tabbedMdiManager.SelectedPage;

                //tabbedMdiManager.SelectedPage = page;

                groupObject.Module.Dock = DockStyle.Fill;
                groupObject.Module.BaseModuleControl(ribbon);
                //groupObject.Module.ShowModule(false);
            }
        }
        
        public void ChangeNavBarItemGroup(NavBarGroupTagObject groupObject)
        {
            //bool allowSetVisiblePage = true;
            //NavBarGroupTagObject groupObject = group.Tag as NavBarGroupTagObject;
            if (groupObject == null) return;

            //List<RibbonPage> deferredPagesToShow = new List<RibbonPage>();

            //foreach (RibbonPage page in ribbon.Pages)
            //{
            //    if (!string.IsNullOrEmpty(string.Format("{0}", page.Tag)))
            //    {
            //        bool isPageVisible = groupObject.Name.Equals(page.Tag);
            //        if (isPageVisible != page.Visible && isPageVisible)
            //            deferredPagesToShow.Add(page);
            //        else
            //            page.Visible = isPageVisible;
            //    }
            //    if (page.Visible && allowSetVisiblePage)
            //    {
            //        //page.Text = "Home";
            //        ribbon.SelectedPage = page;
            //        allowSetVisiblePage = false;
            //    }
            //}

            //bool firstShow = groupObject.Module == null;
            //if (firstShow)
            //{
            //if (SplashScreenManager.Default == null)
            //    SplashScreenManager.ShowForm(ribbon.FindForm(), typeof(DevExpress.MailClient.Win.Forms.wfMain), false, true);

            //ConstructorInfo constructorInfoObj = groupObject.ModuleType.GetConstructor(Type.EmptyTypes);
            //if (constructorInfoObj != null)
            //{
            //    groupObject.Module = constructorInfoObj.Invoke(null) as BaseModule;
            //    groupObject.Module.InitModule(ribbon, moduleData);
            //}

            //if (SplashScreenManager.Default != null)
            //{
            //    Form frm = moduleData as Form;
            //    if (frm != null)
            //    {
            //        if (SplashScreenManager.FormInPendingState)
            //            SplashScreenManager.CloseForm();
            //        else
            //            SplashScreenManager.CloseForm(false, 500, frm);
            //    }
            //    else
            //        SplashScreenManager.CloseForm();
            //}
            //}

            //foreach (RibbonPage page in deferredPagesToShow)
            //{
            //    page.Visible = true;
            //}

            //foreach (RibbonPage page in ribbon.Pages)
            //{
            //    if (page.Visible)
            //    {
            //        ribbon.SelectedPage = page;
            //        break;
            //    }
            //}

            if (groupObject.Module != null)
            {
                if (panel.Controls.Count > 0)
                {
                    BaseModule currentModule = panel.Controls[0] as BaseModule;
                    if (currentModule != null)
                        currentModule.HideModule();
                }
                panel.Controls.Clear();
                panel.Controls.Add(groupObject.Module);
                groupObject.Module.Dock = DockStyle.Fill;
                groupObject.Module.ShowModule(false);
            }
        }

        //public BaseModule CurrentModule
        //{
        //    get
        //    {
        //        if (panel.Controls.Count == 0) return null;
        //        return panel.Controls[0] as BaseModule;
        //    }
        //}

        public BaseModule CurrentModule
        {
            get
            {
                if (tabbedMdiManager.Pages.Count == 0) return null;
                return tabbedMdiManager.SelectedPage.MdiChild as BaseModule;
            }
        }


    }

    //public class BaseControl : XtraUserControl
    //{
    //    public BaseControl()
    //    {
    //        if (!DesignTimeTools.IsDesignMode)
    //            LookAndFeel.ActiveLookAndFeel.StyleChanged += new EventHandler(ActiveLookAndFeel_StyleChanged);
    //    }
    //    protected override void OnLoad(EventArgs e)
    //    {
    //        base.OnLoad(e);
    //        if (!DesignTimeTools.IsDesignMode)
    //            LookAndFeelStyleChanged();
    //    }
    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing && !DesignTimeTools.IsDesignMode)
    //            LookAndFeel.ActiveLookAndFeel.StyleChanged -= new EventHandler(ActiveLookAndFeel_StyleChanged);
    //        base.Dispose(disposing);
    //    }
    //    void ActiveLookAndFeel_StyleChanged(object sender, EventArgs e)
    //    {
    //        LookAndFeelStyleChanged();
    //    }
    //    protected virtual void LookAndFeelStyleChanged() { }
    //}
       
    public class BaseModule : XtraForm
    {
        RibbonControl ribbon;

        internal virtual void BaseModuleControl(RibbonControl ribbon)
        {
            this.ribbon = ribbon;
        }

        protected string partName = string.Empty;
        internal frmMain OwnerForm {
            get {

                
                return ribbon.FindForm() as frmMain;
                //return (Type)("EpiNet.Win.frmMain");
            }
        }
   
        internal virtual void ShowModule(bool firstShow)
        {
            frmMain owner = OwnerForm;
            if (owner == null) return;
            //owner.SaveAsMenuItem.Enabled = SaveAsEnable;
            //owner.SaveAttachmentMenuItem.Enabled = SaveAttachmentEnable;
            //owner.SaveCalendar.Visible = SaveCalendarVisible;
            //owner.EnableLayoutButtons(true);
            //ShowReminder();
            ShowInfo();
            //owner.ZoomManager.ZoomFactor = (int)(ZoomFactor * 100);
            SetZoomCaption();
            //owner.EnableZoomControl(AllowZoomControl);
        }
        internal virtual void FocusObject(object obj) { }

        //protected virtual void ShowReminder()
        //{
        //    if (OwnerForm != null)
        //        OwnerForm.ShowReminder(null);
        //}

        internal void ShowInfo()
        {
            //if (OwnerForm == null) return;
            //if (Grid == null)
            //{
            //    OwnerForm.ShowInfo(null);
            //    return;
            //}
            //ICollection list = Grid.DataSource as ICollection;
            //if (list == null)
            //    OwnerForm.ShowInfo(null);
            //else OwnerForm.ShowInfo(list.Count);

            OwnerForm.ShowInfo(null);
        }
               
        internal virtual void HideModule() { }

        //internal virtual void InitModule(IDXMenuManager manager, object data)
        //{
        //    SetMenuManager(this.Controls, manager);
        //    if (Grid != null && Grid.MainView is ColumnView)
        //    {
        //        ((ColumnView)Grid.MainView).ColumnFilterChanged += new EventHandler(BaseModule_ColumnFilterChanged);
        //    }
        //}

        //internal void ShowInfo(ColumnView view)
        //{
        //    if (OwnerForm == null) return;
        //    ShowReminder();
        //    OwnerForm.ShowInfo(view.DataRowCount);
        //}
        void BaseModule_ColumnFilterChanged(object sender, EventArgs e)
        {
            //ShowInfo(sender as ColumnView);
        }
        //void SetMenuManager(ControlCollection controlCollection, IDXMenuManager manager)
        //{
        //    foreach (Control ctrl in controlCollection)
        //    {
        //        GridControl grid = ctrl as GridControl;
        //        if (grid != null)
        //        {
        //            grid.MenuManager = manager;
        //            break;
        //        }
        //        BaseEdit edit = ctrl as BaseEdit;
        //        if (edit != null)
        //        {
        //            edit.MenuManager = manager;
        //            break;
        //        }
        //        SetMenuManager(ctrl.Controls, manager);
        //    }
        //}
        protected virtual bool AllowZoomControl { get { return false; } }
        protected virtual void SetZoomCaption() { }
        public virtual float ZoomFactor
        {
            get { return 1; }
            set { }
        }
        //public virtual IPrintable PrintableComponent { get { return Grid; } }
        //public virtual IPrintable ExportComponent { get { return Grid; } }
        protected virtual GridControl Grid { get { return null; } }
        protected virtual bool SaveAsEnable { get { return false; } }
        protected virtual bool SaveAttachmentEnable { get { return false; } }
        protected virtual bool SaveCalendarVisible { get { return false; } }
        protected internal virtual void ButtonClick(string tag) { }

        //protected internal virtual void MessagesDataChanged(DataSourceChangedEventArgs args) { }
        protected internal virtual void SendKeyDown(KeyEventArgs e) { }
        //protected internal virtual RichEditControl CurrentRichEdit { get { return null; } }
        public virtual string ModuleName { get { return this.GetType().Name; } }
        public string PartName { get { return partName; } }
    }

    public class NavBarGroupTagObject
    {
        string name;
        int idModulo;
        Type moduleType;
        BaseModule module;
        public NavBarGroupTagObject(string name,int idModulo, Type moduleType)
        {
            this.name = name;
            this.idModulo = idModulo;
            this.moduleType = moduleType;
            module = null;
        }
        public string Name
        {
            get { return name; }
        }
        public int IdModulo
        {
            get { return idModulo; }
        }
        public Type ModuleType { get { return moduleType; } }
        public BaseModule Module
        {
            get { return module; }
            set { module = value; }
        }
    }

}
