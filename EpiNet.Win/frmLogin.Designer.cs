namespace EpiNet.Win
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.btnIniciarSesion = new DevExpress.XtraEditors.SimpleButton();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtUsuario = new DevExpress.XtraEditors.TextEdit();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIniciarSesion
            // 
            this.btnIniciarSesion.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(142)))), ((int)(((byte)(214)))));
            this.btnIniciarSesion.Appearance.ForeColor = System.Drawing.Color.Lavender;
            this.btnIniciarSesion.Appearance.Options.UseBackColor = true;
            this.btnIniciarSesion.Appearance.Options.UseForeColor = true;
            this.btnIniciarSesion.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(142)))), ((int)(((byte)(214)))));
            this.btnIniciarSesion.AppearanceHovered.Options.UseBackColor = true;
            this.btnIniciarSesion.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnIniciarSesion.Location = new System.Drawing.Point(274, 242);
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Size = new System.Drawing.Size(154, 31);
            this.btnIniciarSesion.TabIndex = 14;
            this.btnIniciarSesion.Text = "Iniciar Sesión";
            this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(274, 198);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtPassword.Properties.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("txtPassword.Properties.ContextImageOptions.Image")));
            this.txtPassword.Properties.UseSystemPasswordChar = true;
            this.txtPassword.Size = new System.Drawing.Size(145, 20);
            this.txtPassword.TabIndex = 12;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(274, 127);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Properties.AccessibleDescription = "dsdsds";
            this.txtUsuario.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtUsuario.Properties.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("txtUsuario.Properties.ContextImageOptions.Image")));
            this.txtUsuario.Size = new System.Drawing.Size(145, 20);
            this.txtUsuario.TabIndex = 11;
            this.txtUsuario.ToolTipTitle = "xcxc";
            // 
            // pictureEdit1
            // 
            //this.pictureEdit1.EditValue = global::EpiNet.Win.Properties.Resources.;
            this.pictureEdit1.Location = new System.Drawing.Point(289, 12);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Size = new System.Drawing.Size(81, 70);
            this.pictureEdit1.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(163)))), ((int)(((byte)(159)))));
            this.label2.Location = new System.Drawing.Point(270, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Contraseña";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(163)))), ((int)(((byte)(159)))));
            this.label1.Location = new System.Drawing.Point(270, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Usuario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(163)))), ((int)(((byte)(159)))));
            this.label3.Location = new System.Drawing.Point(286, 306);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "© 2019 EpiNet";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
            this.panelControl1.Appearance.BackColor2 = System.Drawing.Color.OliveDrab;
            this.panelControl1.Appearance.BorderColor = System.Drawing.Color.Yellow;
            this.panelControl1.Appearance.FontStyleDelta = System.Drawing.FontStyle.Italic;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Appearance.Options.UseFont = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.CausesValidation = false;
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(200, 384);
            this.panelControl1.TabIndex = 15;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 384);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.btnIniciarSesion);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "frmLogin";
            this.Text = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtUsuario;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btnIniciarSesion;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}