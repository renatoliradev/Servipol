
namespace ServipolConfig
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.gBoxConexaoBD = new System.Windows.Forms.GroupBox();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.tBoxBDName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.tBoxBDPass = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.tBoxBDUser = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.tBoxBDPort = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.tBoxBDServer = new DevExpress.XtraEditors.TextEdit();
            this.btnValidateConnectionBD = new DevExpress.XtraEditors.SimpleButton();
            this.btnBackup = new DevExpress.XtraEditors.SimpleButton();
            this.btnRestore = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gBoxConexaoBD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBoxBDName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBoxBDPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBoxBDUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBoxBDPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBoxBDServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gBoxConexaoBD
            // 
            this.gBoxConexaoBD.Controls.Add(this.labelControl6);
            this.gBoxConexaoBD.Controls.Add(this.tBoxBDName);
            this.gBoxConexaoBD.Controls.Add(this.labelControl5);
            this.gBoxConexaoBD.Controls.Add(this.tBoxBDPass);
            this.gBoxConexaoBD.Controls.Add(this.labelControl4);
            this.gBoxConexaoBD.Controls.Add(this.tBoxBDUser);
            this.gBoxConexaoBD.Controls.Add(this.labelControl3);
            this.gBoxConexaoBD.Controls.Add(this.tBoxBDPort);
            this.gBoxConexaoBD.Controls.Add(this.labelControl2);
            this.gBoxConexaoBD.Controls.Add(this.tBoxBDServer);
            this.gBoxConexaoBD.Location = new System.Drawing.Point(12, 141);
            this.gBoxConexaoBD.Name = "gBoxConexaoBD";
            this.gBoxConexaoBD.Size = new System.Drawing.Size(577, 109);
            this.gBoxConexaoBD.TabIndex = 0;
            this.gBoxConexaoBD.TabStop = false;
            this.gBoxConexaoBD.Text = "Dados de conexão com o banco de dados PostgreSQL 9.5";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(6, 76);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(115, 13);
            this.labelControl6.TabIndex = 11;
            this.labelControl6.Text = "Denominação do banco:";
            // 
            // tBoxBDName
            // 
            this.tBoxBDName.EditValue = "servipol";
            this.tBoxBDName.Location = new System.Drawing.Point(138, 73);
            this.tBoxBDName.Name = "tBoxBDName";
            this.tBoxBDName.Size = new System.Drawing.Size(433, 20);
            this.tBoxBDName.TabIndex = 10;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(418, 50);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(34, 13);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "Senha:";
            // 
            // tBoxBDPass
            // 
            this.tBoxBDPass.EditValue = "cmo4lat1";
            this.tBoxBDPass.Location = new System.Drawing.Point(459, 47);
            this.tBoxBDPass.Name = "tBoxBDPass";
            this.tBoxBDPass.Properties.UseSystemPasswordChar = true;
            this.tBoxBDPass.Size = new System.Drawing.Size(112, 20);
            this.tBoxBDPass.TabIndex = 8;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(89, 50);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(40, 13);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "Usuário:";
            // 
            // tBoxBDUser
            // 
            this.tBoxBDUser.EditValue = "postgres";
            this.tBoxBDUser.Location = new System.Drawing.Point(138, 47);
            this.tBoxBDUser.Name = "tBoxBDUser";
            this.tBoxBDUser.Size = new System.Drawing.Size(252, 20);
            this.tBoxBDUser.TabIndex = 6;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(423, 24);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(30, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Porta:";
            // 
            // tBoxBDPort
            // 
            this.tBoxBDPort.EditValue = "5432";
            this.tBoxBDPort.Location = new System.Drawing.Point(459, 21);
            this.tBoxBDPort.Name = "tBoxBDPort";
            this.tBoxBDPort.Properties.Appearance.Options.UseTextOptions = true;
            this.tBoxBDPort.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tBoxBDPort.Size = new System.Drawing.Size(112, 20);
            this.tBoxBDPort.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(87, 24);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(44, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Servidor:";
            // 
            // tBoxBDServer
            // 
            this.tBoxBDServer.EditValue = "localhost";
            this.tBoxBDServer.Location = new System.Drawing.Point(138, 21);
            this.tBoxBDServer.Name = "tBoxBDServer";
            this.tBoxBDServer.Size = new System.Drawing.Size(252, 20);
            this.tBoxBDServer.TabIndex = 2;
            // 
            // btnValidateConnectionBD
            // 
            this.btnValidateConnectionBD.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnValidateConnectionBD.Appearance.Options.UseFont = true;
            this.btnValidateConnectionBD.Location = new System.Drawing.Point(595, 153);
            this.btnValidateConnectionBD.Name = "btnValidateConnectionBD";
            this.btnValidateConnectionBD.Size = new System.Drawing.Size(209, 26);
            this.btnValidateConnectionBD.TabIndex = 2;
            this.btnValidateConnectionBD.Text = "Salvar e Validar Conexão com BD";
            this.btnValidateConnectionBD.Click += new System.EventHandler(this.btnValidateConnectionBD_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnBackup.Appearance.Options.UseFont = true;
            this.btnBackup.Location = new System.Drawing.Point(595, 185);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(209, 26);
            this.btnBackup.TabIndex = 3;
            this.btnBackup.Text = "Realizar Backup";
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnRestore.Appearance.Options.UseFont = true;
            this.btnRestore.Location = new System.Drawing.Point(595, 217);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(209, 26);
            this.btnRestore.TabIndex = 4;
            this.btnRestore.Text = "Realizar Restore";
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnExit
            // 
            this.btnExit.Appearance.BorderColor = System.Drawing.Color.Black;
            this.btnExit.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnExit.Appearance.Options.UseBorderColor = true;
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.Location = new System.Drawing.Point(12, 274);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(792, 52);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Fechar Configurador";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(132, 123);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 44F, System.Drawing.FontStyle.Italic);
            this.label1.Location = new System.Drawing.Point(151, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(653, 71);
            this.label1.TabIndex = 7;
            this.label1.Text = "Servipol Configurador";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 339);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.btnValidateConnectionBD);
            this.Controls.Add(this.gBoxConexaoBD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrincipal";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Servipol Configurador";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.gBoxConexaoBD.ResumeLayout(false);
            this.gBoxConexaoBD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBoxBDName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBoxBDPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBoxBDUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBoxBDPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBoxBDServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gBoxConexaoBD;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit tBoxBDServer;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit tBoxBDPass;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit tBoxBDUser;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit tBoxBDPort;
        private DevExpress.XtraEditors.SimpleButton btnValidateConnectionBD;
        private DevExpress.XtraEditors.SimpleButton btnBackup;
        private DevExpress.XtraEditors.SimpleButton btnRestore;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit tBoxBDName;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}