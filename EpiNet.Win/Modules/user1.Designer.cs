namespace EpiNet.Win.Modules
{
    partial class user1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.repositoryItemImageComboBox3 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.repositoryItemImageComboBox4 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gcPriority = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcIcon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAttachment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSubject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFrom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRead = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(3, 3);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1,
            this.repositoryItemImageComboBox2,
            this.repositoryItemImageComboBox3,
            this.repositoryItemImageComboBox4});
            this.gridControl1.Size = new System.Drawing.Size(632, 508);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Low", 0, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Medium", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("High", 2, 1)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // repositoryItemImageComboBox2
            // 
            this.repositoryItemImageComboBox2.AutoHeight = false;
            this.repositoryItemImageComboBox2.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox2.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Unread", 0, 3),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Read", 1, 2)});
            this.repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
            // 
            // repositoryItemImageComboBox3
            // 
            this.repositoryItemImageComboBox3.AutoHeight = false;
            this.repositoryItemImageComboBox3.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox3.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Attachment", 1, 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Empty", 0, -1)});
            this.repositoryItemImageComboBox3.Name = "repositoryItemImageComboBox3";
            // 
            // repositoryItemImageComboBox4
            // 
            this.repositoryItemImageComboBox4.AutoHeight = false;
            this.repositoryItemImageComboBox4.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox4.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Read", 1, 6),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Unread", 0, 5)});
            this.repositoryItemImageComboBox4.Name = "repositoryItemImageComboBox4";
            // 
            // gcPriority
            // 
            this.gcPriority.Caption = "Priority";
            this.gcPriority.ColumnEdit = this.repositoryItemImageComboBox1;
            this.gcPriority.FieldName = "Priority";
            this.gcPriority.ImageOptions.ImageIndex = 0;
            this.gcPriority.Name = "gcPriority";
            this.gcPriority.OptionsColumn.AllowFocus = false;
            this.gcPriority.OptionsColumn.AllowSize = false;
            this.gcPriority.OptionsColumn.FixedWidth = true;
            this.gcPriority.OptionsColumn.ShowCaption = false;
            this.gcPriority.ToolTip = "Importance";
            this.gcPriority.Visible = true;
            this.gcPriority.VisibleIndex = 0;
            this.gcPriority.Width = 27;
            // 
            // gcIcon
            // 
            this.gcIcon.Caption = "Read";
            this.gcIcon.ColumnEdit = this.repositoryItemImageComboBox2;
            this.gcIcon.FieldName = "Read";
            this.gcIcon.ImageOptions.ImageIndex = 1;
            this.gcIcon.Name = "gcIcon";
            this.gcIcon.OptionsColumn.AllowEdit = false;
            this.gcIcon.OptionsColumn.AllowFocus = false;
            this.gcIcon.OptionsColumn.AllowSize = false;
            this.gcIcon.OptionsColumn.FixedWidth = true;
            this.gcIcon.OptionsColumn.ShowCaption = false;
            this.gcIcon.ToolTip = "Icon";
            this.gcIcon.Visible = true;
            this.gcIcon.VisibleIndex = 1;
            this.gcIcon.Width = 27;
            // 
            // gcAttachment
            // 
            this.gcAttachment.Caption = "Attachment";
            this.gcAttachment.ColumnEdit = this.repositoryItemImageComboBox3;
            this.gcAttachment.FieldName = "Attachment";
            this.gcAttachment.ImageOptions.ImageIndex = 2;
            this.gcAttachment.Name = "gcAttachment";
            this.gcAttachment.OptionsColumn.AllowEdit = false;
            this.gcAttachment.OptionsColumn.AllowFocus = false;
            this.gcAttachment.OptionsColumn.AllowSize = false;
            this.gcAttachment.OptionsColumn.FixedWidth = true;
            this.gcAttachment.OptionsColumn.ShowCaption = false;
            this.gcAttachment.ToolTip = "Attachment";
            this.gcAttachment.Visible = true;
            this.gcAttachment.VisibleIndex = 2;
            this.gcAttachment.Width = 27;
            // 
            // gcSubject
            // 
            this.gcSubject.Caption = "Subject";
            this.gcSubject.FieldName = "Subject";
            this.gcSubject.Name = "gcSubject";
            this.gcSubject.OptionsColumn.AllowFocus = false;
            this.gcSubject.Visible = true;
            this.gcSubject.VisibleIndex = 5;
            this.gcSubject.Width = 320;
            // 
            // gcFrom
            // 
            this.gcFrom.Caption = "From";
            this.gcFrom.FieldName = "From";
            this.gcFrom.Name = "gcFrom";
            this.gcFrom.OptionsColumn.AllowFocus = false;
            this.gcFrom.Visible = true;
            this.gcFrom.VisibleIndex = 4;
            this.gcFrom.Width = 110;
            // 
            // gcDate
            // 
            this.gcDate.Caption = "Received";
            this.gcDate.FieldName = "Date";
            this.gcDate.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.DateRange;
            this.gcDate.Name = "gcDate";
            this.gcDate.OptionsColumn.AllowFocus = false;
            this.gcDate.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateAlt;
            this.gcDate.Visible = true;
            this.gcDate.VisibleIndex = 6;
            this.gcDate.Width = 95;
            // 
            // gcRead
            // 
            this.gcRead.ColumnEdit = this.repositoryItemImageComboBox4;
            this.gcRead.FieldName = "Read";
            this.gcRead.ImageOptions.Alignment = System.Drawing.StringAlignment.Center;
            this.gcRead.ImageOptions.ImageIndex = 3;
            this.gcRead.Name = "gcRead";
            this.gcRead.OptionsColumn.AllowEdit = false;
            this.gcRead.OptionsColumn.AllowFocus = false;
            this.gcRead.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gcRead.OptionsColumn.AllowShowHide = false;
            this.gcRead.OptionsColumn.AllowSize = false;
            this.gcRead.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gcRead.OptionsColumn.FixedWidth = true;
            this.gcRead.OptionsColumn.ShowCaption = false;
            this.gcRead.OptionsFilter.AllowAutoFilter = false;
            this.gcRead.OptionsFilter.AllowFilter = false;
            this.gcRead.Visible = true;
            this.gcRead.VisibleIndex = 3;
            this.gcRead.Width = 25;
            // 
            // user1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "user1";
            this.Size = new System.Drawing.Size(768, 514);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox3;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox4;
        private DevExpress.XtraGrid.Columns.GridColumn gcPriority;
        private DevExpress.XtraGrid.Columns.GridColumn gcIcon;
        private DevExpress.XtraGrid.Columns.GridColumn gcAttachment;
        private DevExpress.XtraGrid.Columns.GridColumn gcSubject;
        private DevExpress.XtraGrid.Columns.GridColumn gcFrom;
        private DevExpress.XtraGrid.Columns.GridColumn gcDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcRead;
    }
}
