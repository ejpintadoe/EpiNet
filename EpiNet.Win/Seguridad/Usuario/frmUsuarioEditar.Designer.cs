namespace EpiNet.Win.Seguridad.Usuario
{
    partial class frmUsuarioEditar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuarioEditar));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancelar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.txtConfirmaClave = new DevExpress.XtraEditors.TextEdit();
            this.txtClave = new DevExpress.XtraEditors.TextEdit();
            this.txtUsuario = new DevExpress.XtraEditors.TextEdit();
            this.txtEmpleado = new DevExpress.XtraEditors.TextEdit();
            this.searchLookUpEdit1 = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmaClave.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClave.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpleado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.checkEdit1);
            this.layoutControl1.Controls.Add(this.txtConfirmaClave);
            this.layoutControl1.Controls.Add(this.txtClave);
            this.layoutControl1.Controls.Add(this.txtUsuario);
            this.layoutControl1.Controls.Add(this.txtEmpleado);
            this.layoutControl1.Controls.Add(this.searchLookUpEdit1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 24);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(452, 177);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(322, 60);
            this.checkEdit1.MenuManager = this.barManager1;
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "Habilitado";
            this.checkEdit1.Size = new System.Drawing.Size(118, 19);
            this.checkEdit1.StyleController = this.layoutControl1;
            this.checkEdit1.TabIndex = 9;
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
            this.btnCancelar});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 2;
            // 
            // bar2
            // 
            this.bar2.BarName = "Menú principal";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCancelar)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Menú principal";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Guardar";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Caption = "Cancelar";
            this.btnCancelar.Id = 1;
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.LargeImage")));
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(452, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 201);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(452, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 177);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(452, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 177);
            // 
            // txtConfirmaClave
            // 
            this.txtConfirmaClave.Location = new System.Drawing.Point(117, 108);
            this.txtConfirmaClave.MenuManager = this.barManager1;
            this.txtConfirmaClave.Name = "txtConfirmaClave";
            this.txtConfirmaClave.Properties.UseSystemPasswordChar = true;
            this.txtConfirmaClave.Size = new System.Drawing.Size(201, 20);
            this.txtConfirmaClave.StyleController = this.layoutControl1;
            this.txtConfirmaClave.TabIndex = 8;
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(117, 84);
            this.txtClave.MenuManager = this.barManager1;
            this.txtClave.Name = "txtClave";
            this.txtClave.Properties.UseSystemPasswordChar = true;
            this.txtClave.Size = new System.Drawing.Size(201, 20);
            this.txtClave.StyleController = this.layoutControl1;
            this.txtClave.TabIndex = 7;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(117, 60);
            this.txtUsuario.MenuManager = this.barManager1;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(201, 20);
            this.txtUsuario.StyleController = this.layoutControl1;
            this.txtUsuario.TabIndex = 6;
            // 
            // txtEmpleado
            // 
            this.txtEmpleado.Location = new System.Drawing.Point(117, 12);
            this.txtEmpleado.MenuManager = this.barManager1;
            this.txtEmpleado.Name = "txtEmpleado";
            this.txtEmpleado.Properties.ReadOnly = true;
            this.txtEmpleado.Size = new System.Drawing.Size(323, 20);
            this.txtEmpleado.StyleController = this.layoutControl1;
            this.txtEmpleado.TabIndex = 5;
            // 
            // searchLookUpEdit1
            // 
            this.searchLookUpEdit1.Location = new System.Drawing.Point(117, 36);
            this.searchLookUpEdit1.MenuManager = this.barManager1;
            this.searchLookUpEdit1.Name = "searchLookUpEdit1";
            this.searchLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpEdit1.Properties.PopupView = this.searchLookUpEdit1View;
            this.searchLookUpEdit1.Size = new System.Drawing.Size(323, 20);
            this.searchLookUpEdit1.StyleController = this.layoutControl1;
            this.searchLookUpEdit1.TabIndex = 4;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem2,
            this.emptySpaceItem2,
            this.layoutControlItem6,
            this.layoutControlItem5,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(452, 177);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.searchLookUpEdit1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(432, 24);
            this.layoutControlItem1.Text = "Perfil";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(102, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(310, 72);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(122, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtUsuario;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(310, 24);
            this.layoutControlItem3.Text = "User Name";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(102, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtClave;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(310, 24);
            this.layoutControlItem4.Text = "Contraseña";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(102, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtEmpleado;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(432, 24);
            this.layoutControlItem2.Text = "Empleado";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(102, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(310, 96);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(122, 61);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtConfirmaClave;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(310, 61);
            this.layoutControlItem5.Text = "Confirma Contraseña";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(102, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.checkEdit1;
            this.layoutControlItem6.Location = new System.Drawing.Point(310, 48);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(122, 24);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // frmUsuarioEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 201);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmUsuarioEditar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmUsuarioEditar";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmaClave.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClave.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpleado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtEmpleado;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btnCancelar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.TextEdit txtConfirmaClave;
        private DevExpress.XtraEditors.TextEdit txtClave;
        private DevExpress.XtraEditors.TextEdit txtUsuario;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}