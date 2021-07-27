
namespace Servipol
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbUsuario = new DevExpress.XtraEditors.GroupControl();
            this.cBoxUsuario = new System.Windows.Forms.ComboBox();
            this.gbSenha = new DevExpress.XtraEditors.GroupControl();
            this.tBoxSenha = new System.Windows.Forms.TextBox();
            this.btnSair = new DevExpress.XtraEditors.SimpleButton();
            this.btnEntrar = new DevExpress.XtraEditors.SimpleButton();
            this.auxSenhaSistema = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbUsuario)).BeginInit();
            this.gbUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbSenha)).BeginInit();
            this.gbSenha.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(169, 163);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 114;
            this.pictureBox1.TabStop = false;
            // 
            // gbUsuario
            // 
            this.gbUsuario.Controls.Add(this.cBoxUsuario);
            this.gbUsuario.Location = new System.Drawing.Point(187, 12);
            this.gbUsuario.Name = "gbUsuario";
            this.gbUsuario.Size = new System.Drawing.Size(306, 52);
            this.gbUsuario.TabIndex = 110;
            this.gbUsuario.Text = "Usuário";
            // 
            // cBoxUsuario
            // 
            this.cBoxUsuario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cBoxUsuario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cBoxUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cBoxUsuario.FormattingEnabled = true;
            this.cBoxUsuario.Location = new System.Drawing.Point(5, 25);
            this.cBoxUsuario.Name = "cBoxUsuario";
            this.cBoxUsuario.Size = new System.Drawing.Size(296, 21);
            this.cBoxUsuario.TabIndex = 0;
            this.cBoxUsuario.SelectedIndexChanged += new System.EventHandler(this.cBoxUsuario_SelectedIndexChanged);
            // 
            // gbSenha
            // 
            this.gbSenha.Controls.Add(this.tBoxSenha);
            this.gbSenha.Location = new System.Drawing.Point(187, 70);
            this.gbSenha.Name = "gbSenha";
            this.gbSenha.Size = new System.Drawing.Size(306, 52);
            this.gbSenha.TabIndex = 111;
            this.gbSenha.Text = "Senha";
            // 
            // tBoxSenha
            // 
            this.tBoxSenha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tBoxSenha.Location = new System.Drawing.Point(5, 25);
            this.tBoxSenha.Name = "tBoxSenha";
            this.tBoxSenha.Size = new System.Drawing.Size(296, 22);
            this.tBoxSenha.TabIndex = 5;
            this.tBoxSenha.UseSystemPasswordChar = true;
            this.tBoxSenha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBoxSenha_KeyDown);
            // 
            // btnSair
            // 
            this.btnSair.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Appearance.Options.UseFont = true;
            this.btnSair.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSair.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSair.ImageOptions.SvgImage")));
            this.btnSair.Location = new System.Drawing.Point(397, 128);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(96, 47);
            this.btnSair.TabIndex = 113;
            this.btnSair.Text = "Sair";
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnEntrar
            // 
            this.btnEntrar.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntrar.Appearance.Options.UseFont = true;
            this.btnEntrar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnEntrar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEntrar.ImageOptions.SvgImage")));
            this.btnEntrar.Location = new System.Drawing.Point(187, 128);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(204, 47);
            this.btnEntrar.TabIndex = 112;
            this.btnEntrar.Text = "Entrar";
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // auxSenhaSistema
            // 
            this.auxSenhaSistema.AutoSize = true;
            this.auxSenhaSistema.Location = new System.Drawing.Point(791, 70);
            this.auxSenhaSistema.Name = "auxSenhaSistema";
            this.auxSenhaSistema.Size = new System.Drawing.Size(96, 13);
            this.auxSenhaSistema.TabIndex = 115;
            this.auxSenhaSistema.Text = "auxSenhaSistema";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 187);
            this.ControlBox = false;
            this.Controls.Add(this.auxSenhaSistema);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.gbUsuario);
            this.Controls.Add(this.gbSenha);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnEntrar);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmLogin";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbUsuario)).EndInit();
            this.gbUsuario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbSenha)).EndInit();
            this.gbSenha.ResumeLayout(false);
            this.gbSenha.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.GroupControl gbUsuario;
        private System.Windows.Forms.ComboBox cBoxUsuario;
        private DevExpress.XtraEditors.GroupControl gbSenha;
        private System.Windows.Forms.TextBox tBoxSenha;
        private DevExpress.XtraEditors.SimpleButton btnSair;
        private DevExpress.XtraEditors.SimpleButton btnEntrar;
        private System.Windows.Forms.Label auxSenhaSistema;
    }
}