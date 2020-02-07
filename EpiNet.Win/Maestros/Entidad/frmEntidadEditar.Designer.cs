using EpiNet.Win.App_Code;
using EpiNet.Win.App_Code.BE;
using EpiNet.Win.App_Code.BL;
using System.Collections.Generic;
using System.ComponentModel;

namespace EpiNet.Win.Maestros.Entidad
{
    partial class frmEntidadEditar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEntidadEditar));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.tabPane1 = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabNavigationPage1 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.layoutControl3 = new DevExpress.XtraLayout.LayoutControl();
            this.txtDireccion = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.tabNavigationPage2 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.tabNavigationPage3 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.luTipoDocumento = new DevExpress.XtraEditors.LookUpEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnGuardar = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancelar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.luTipoPersona = new DevExpress.XtraEditors.LookUpEdit();
            this.txtSitioWeb = new DevExpress.XtraEditors.TextEdit();
            this.chkLstBoxTipoEntidad = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.txtNombreComercial = new DevExpress.XtraEditors.TextEdit();
            this.txtRazonSocial = new DevExpress.XtraEditors.TextEdit();
            this.txtCodigoLegal = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtGiroNegocio = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPane1)).BeginInit();
            this.tabPane1.SuspendLayout();
            this.tabNavigationPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl3)).BeginInit();
            this.layoutControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDireccion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luTipoDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luTipoPersona.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSitioWeb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLstBoxTipoEntidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreComercial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRazonSocial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoLegal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGiroNegocio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.tabPane1);
            this.layoutControl1.Controls.Add(this.groupControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 24);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Padding = new System.Windows.Forms.Padding(5);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1025, 444);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // tabPane1
            // 
            this.tabPane1.Controls.Add(this.tabNavigationPage1);
            this.tabPane1.Controls.Add(this.tabNavigationPage2);
            this.tabPane1.Controls.Add(this.tabNavigationPage3);
            this.tabPane1.Location = new System.Drawing.Point(12, 237);
            this.tabPane1.Name = "tabPane1";
            this.tabPane1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabNavigationPage1,
            this.tabNavigationPage2,
            this.tabNavigationPage3});
            this.tabPane1.RegularSize = new System.Drawing.Size(1001, 195);
            this.tabPane1.SelectedPage = this.tabNavigationPage2;
            this.tabPane1.Size = new System.Drawing.Size(1001, 195);
            this.tabPane1.TabIndex = 5;
            this.tabPane1.Text = "tabPane1";
            // 
            // tabNavigationPage1
            // 
            this.tabNavigationPage1.Caption = "Local";
            this.tabNavigationPage1.Controls.Add(this.layoutControl3);
            this.tabNavigationPage1.Name = "tabNavigationPage1";
            this.tabNavigationPage1.Size = new System.Drawing.Size(983, 150);
            // 
            // layoutControl3
            // 
            this.layoutControl3.Controls.Add(this.txtDireccion);
            this.layoutControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl3.Location = new System.Drawing.Point(0, 0);
            this.layoutControl3.Name = "layoutControl3";
            this.layoutControl3.Root = this.layoutControlGroup3;
            this.layoutControl3.Size = new System.Drawing.Size(983, 150);
            this.layoutControl3.TabIndex = 0;
            this.layoutControl3.Text = "layoutControl3";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(58, 12);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(913, 20);
            this.txtDireccion.StyleController = this.layoutControl3;
            this.txtDireccion.TabIndex = 4;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup3.GroupBordersVisible = false;
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem7,
            this.emptySpaceItem1});
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(983, 150);
            this.layoutControlGroup3.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtDireccion;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(963, 24);
            this.layoutControlItem7.Text = "Dirección";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(43, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 24);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(963, 106);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // tabNavigationPage2
            // 
            this.tabNavigationPage2.Caption = "Ventas";
            this.tabNavigationPage2.Name = "tabNavigationPage2";
            this.tabNavigationPage2.Size = new System.Drawing.Size(983, 150);
            // 
            // tabNavigationPage3
            // 
            this.tabNavigationPage3.Caption = "Contactos";
            this.tabNavigationPage3.Name = "tabNavigationPage3";
            this.tabNavigationPage3.Size = new System.Drawing.Size(983, 161);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl2);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1001, 221);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Información";
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.txtGiroNegocio);
            this.layoutControl2.Controls.Add(this.luTipoDocumento);
            this.layoutControl2.Controls.Add(this.luTipoPersona);
            this.layoutControl2.Controls.Add(this.txtSitioWeb);
            this.layoutControl2.Controls.Add(this.chkLstBoxTipoEntidad);
            this.layoutControl2.Controls.Add(this.checkEdit1);
            this.layoutControl2.Controls.Add(this.txtNombreComercial);
            this.layoutControl2.Controls.Add(this.txtRazonSocial);
            this.layoutControl2.Controls.Add(this.txtCodigoLegal);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 20);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(997, 199);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // luTipoDocumento
            // 
            this.luTipoDocumento.Location = new System.Drawing.Point(102, 36);
            this.luTipoDocumento.MenuManager = this.barManager1;
            this.luTipoDocumento.Name = "luTipoDocumento";
            this.luTipoDocumento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luTipoDocumento.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.luTipoDocumento.Size = new System.Drawing.Size(239, 20);
            this.luTipoDocumento.StyleController = this.layoutControl2;
            this.luTipoDocumento.TabIndex = 15;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem2,
            this.btnGuardar,
            this.btnCancelar});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 4;
            // 
            // bar2
            // 
            this.bar2.BarName = "Menú principal";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGuardar),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCancelar)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Menú principal";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Caption = "Guardar";
            this.btnGuardar.Id = 2;
            this.btnGuardar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.ImageOptions.Image")));
            this.btnGuardar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnGuardar.ImageOptions.LargeImage")));
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnGuardar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGuardar_ItemClick);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Caption = "Cancelar";
            this.btnCancelar.Id = 3;
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.LargeImage")));
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1025, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 468);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1025, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 444);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1025, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 444);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Guardar";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.MergeType = DevExpress.XtraBars.BarMenuMerge.Replace;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Cancelar";
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
            this.barButtonItem2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.LargeImage")));
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // luTipoPersona
            // 
            this.luTipoPersona.Location = new System.Drawing.Point(102, 12);
            this.luTipoPersona.MenuManager = this.barManager1;
            this.luTipoPersona.Name = "luTipoPersona";
            this.luTipoPersona.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luTipoPersona.Size = new System.Drawing.Size(239, 20);
            this.luTipoPersona.StyleController = this.layoutControl2;
            this.luTipoPersona.TabIndex = 14;
            // 
            // txtSitioWeb
            // 
            this.txtSitioWeb.Location = new System.Drawing.Point(102, 108);
            this.txtSitioWeb.Name = "txtSitioWeb";
            this.txtSitioWeb.Properties.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("textEdit5.Properties.ContextImageOptions.Image")));
            this.txtSitioWeb.Size = new System.Drawing.Size(561, 20);
            this.txtSitioWeb.StyleController = this.layoutControl2;
            this.txtSitioWeb.TabIndex = 13;
            // 
            // chkLstBoxTipoEntidad
            // 
            this.chkLstBoxTipoEntidad.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("6", "Cliente"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("7", "Proveedor")});
            this.chkLstBoxTipoEntidad.Location = new System.Drawing.Point(667, 28);
            this.chkLstBoxTipoEntidad.Name = "chkLstBoxTipoEntidad";
            this.chkLstBoxTipoEntidad.Size = new System.Drawing.Size(318, 100);
            this.chkLstBoxTipoEntidad.StyleController = this.layoutControl2;
            this.chkLstBoxTipoEntidad.TabIndex = 12;
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(530, 12);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "Ficha Activa";
            this.checkEdit1.Size = new System.Drawing.Size(133, 19);
            this.checkEdit1.StyleController = this.layoutControl2;
            this.checkEdit1.TabIndex = 11;
            // 
            // txtNombreComercial
            // 
            this.txtNombreComercial.Location = new System.Drawing.Point(102, 84);
            this.txtNombreComercial.Name = "txtNombreComercial";
            this.txtNombreComercial.Size = new System.Drawing.Size(233, 20);
            this.txtNombreComercial.StyleController = this.layoutControl2;
            this.txtNombreComercial.TabIndex = 8;
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Location = new System.Drawing.Point(102, 60);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(561, 20);
            this.txtRazonSocial.StyleController = this.layoutControl2;
            this.txtRazonSocial.TabIndex = 7;
            // 
            // txtCodigoLegal
            // 
            this.txtCodigoLegal.Location = new System.Drawing.Point(435, 36);
            this.txtCodigoLegal.Name = "txtCodigoLegal";
            this.txtCodigoLegal.Size = new System.Drawing.Size(228, 20);
            this.txtCodigoLegal.StyleController = this.layoutControl2;
            this.txtCodigoLegal.TabIndex = 6;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem9,
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.emptySpaceItem4,
            this.layoutControlItem8,
            this.layoutControlItem12,
            this.layoutControlItem2,
            this.layoutControlItem11,
            this.layoutControlItem3});
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(997, 199);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtCodigoLegal;
            this.layoutControlItem4.Location = new System.Drawing.Point(333, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(322, 24);
            this.layoutControlItem4.Text = "Codigo Legal";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(87, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtRazonSocial;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(655, 24);
            this.layoutControlItem5.Text = "Razon Social";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(87, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtNombreComercial;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(327, 24);
            this.layoutControlItem6.Text = "Nombre Comercial";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(87, 13);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.checkEdit1;
            this.layoutControlItem9.Location = new System.Drawing.Point(518, 0);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(137, 24);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(333, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(185, 24);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 120);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(655, 59);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(655, 120);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(322, 59);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.AppearanceItemCaption.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.layoutControlItem8.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem8.Control = this.chkLstBoxTipoEntidad;
            this.layoutControlItem8.Location = new System.Drawing.Point(655, 0);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(322, 120);
            this.layoutControlItem8.Text = "Tipo Entidad";
            this.layoutControlItem8.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(87, 13);
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.txtSitioWeb;
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(655, 24);
            this.layoutControlItem11.Text = "Sitio Web";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(87, 13);
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.luTipoPersona;
            this.layoutControlItem12.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(333, 24);
            this.layoutControlItem12.Text = "Tipo Persona";
            this.layoutControlItem12.TextSize = new System.Drawing.Size(87, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.luTipoDocumento;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(333, 24);
            this.layoutControlItem2.Text = "Tipo Identificación";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(87, 13);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem10});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1025, 444);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.groupControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1005, 225);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.AppearanceItemCaption.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.layoutControlItem10.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem10.AppearanceItemCaption.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.layoutControlItem10.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem10.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem10.Control = this.tabPane1;
            this.layoutControlItem10.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.False;
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 225);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(1005, 199);
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            // 
            // txtGiroNegocio
            // 
            this.txtGiroNegocio.Location = new System.Drawing.Point(429, 84);
            this.txtGiroNegocio.MenuManager = this.barManager1;
            this.txtGiroNegocio.Name = "txtGiroNegocio";
            this.txtGiroNegocio.Size = new System.Drawing.Size(234, 20);
            this.txtGiroNegocio.StyleController = this.layoutControl2;
            this.txtGiroNegocio.TabIndex = 16;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtGiroNegocio;
            this.layoutControlItem3.Location = new System.Drawing.Point(327, 72);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(328, 24);
            this.layoutControlItem3.Text = "Giro Negocio";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(87, 13);
            // 
            // frmEntidadEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 468);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmEntidadEditar";
            this.Text = "frmEntidadEditar";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPane1)).EndInit();
            this.tabPane1.ResumeLayout(false);
            this.tabNavigationPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl3)).EndInit();
            this.layoutControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDireccion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.luTipoDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luTipoPersona.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSitioWeb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLstBoxTipoEntidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreComercial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRazonSocial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoLegal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGiroNegocio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void InicializaControles()
        {
            List<BELookUpEdit> lstLUE = new List<BELookUpEdit>();
            
            lstLUE.AddRange(new BELookUpEdit[] {
                new BELookUpEdit { fieldName = "EPI_INT_IDTIPODOCUMENTOIDENTIDAD", caption = "Id" },
                new BELookUpEdit { fieldName = "EPI_VCH_DESCRIPCIONCORTA", caption = "Corta" }
            });


                
            BaseForm.CargarLookUpEdit(luTipoDocumento, BLTipoDocumentoEntidad.ListarTipoDocumentoEntidad(0, ""), lstLUE);

            List<BELookUpEdit> lstLUE2 = new List<BELookUpEdit>();

            lstLUE2.AddRange(new BELookUpEdit[] {
                new BELookUpEdit { fieldName = "EPI_INT_IDGENERICA", caption = "Id" },
                new BELookUpEdit { fieldName = "EPI_VCH_CAMPO2", caption = "Corta" }
            });



            BaseForm.CargarLookUpEdit(luTipoPersona, BLGenerica.ListarGenerica(eTblGen.TIPOPERSONA.ToString()) , lstLUE2);


        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraBars.Navigation.TabPane tabPane1;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage1;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage2;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraEditors.CheckedListBoxControl chkLstBoxTipoEntidad;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.TextEdit txtNombreComercial;
        private DevExpress.XtraEditors.TextEdit txtRazonSocial;
        private DevExpress.XtraEditors.TextEdit txtCodigoLegal;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControl layoutControl3;
        private DevExpress.XtraEditors.TextEdit txtDireccion;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage3;
        private DevExpress.XtraEditors.TextEdit txtSitioWeb;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnGuardar;
        private DevExpress.XtraBars.BarButtonItem btnCancelar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraEditors.LookUpEdit luTipoDocumento;
        private DevExpress.XtraEditors.LookUpEdit luTipoPersona;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.TextEdit txtGiroNegocio;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}