
namespace Servipol.Forms.Configuração.Controle_de_Acesso
{
    partial class frmUsuarioAlterarSenha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuarioAlterarSenha));
            this.btnConfirmar = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.gbNovaSenha = new System.Windows.Forms.GroupBox();
            this.tBoxSenha = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tBoxUsuario = new System.Windows.Forms.TextBox();
            this.gbRepeticaoSenha = new System.Windows.Forms.GroupBox();
            this.tBoxRepeticaoSenha = new System.Windows.Forms.TextBox();
            this.gbNovaSenha.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbRepeticaoSenha.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnConfirmar.Appearance.Options.UseFont = true;
            this.btnConfirmar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnConfirmar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnConfirmar.ImageOptions.SvgImage")));
            this.btnConfirmar.Location = new System.Drawing.Point(163, 219);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(167, 42);
            this.btnConfirmar.TabIndex = 22;
            this.btnConfirmar.Text = "[F12] - Confirmar";
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnCancelar.Appearance.Options.UseFont = true;
            this.btnCancelar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnCancelar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCancelar.ImageOptions.SvgImage")));
            this.btnCancelar.Location = new System.Drawing.Point(6, 219);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(151, 42);
            this.btnCancelar.TabIndex = 21;
            this.btnCancelar.Text = "[Esc] - Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // gbNovaSenha
            // 
            this.gbNovaSenha.Controls.Add(this.tBoxSenha);
            this.gbNovaSenha.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbNovaSenha.Location = new System.Drawing.Point(6, 81);
            this.gbNovaSenha.Name = "gbNovaSenha";
            this.gbNovaSenha.Size = new System.Drawing.Size(324, 63);
            this.gbNovaSenha.TabIndex = 18;
            this.gbNovaSenha.TabStop = false;
            this.gbNovaSenha.Text = "Nova Senha";
            // 
            // tBoxSenha
            // 
            this.tBoxSenha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tBoxSenha.Font = new System.Drawing.Font("Calibri", 9F);
            this.tBoxSenha.Location = new System.Drawing.Point(6, 26);
            this.tBoxSenha.Name = "tBoxSenha";
            this.tBoxSenha.Size = new System.Drawing.Size(312, 22);
            this.tBoxSenha.TabIndex = 2;
            this.tBoxSenha.UseSystemPasswordChar = true;
            this.tBoxSenha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBoxSenha_KeyDown);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tBoxUsuario);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(6, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(324, 63);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Usuário";
            // 
            // tBoxUsuario
            // 
            this.tBoxUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tBoxUsuario.Font = new System.Drawing.Font("Calibri", 9F);
            this.tBoxUsuario.Location = new System.Drawing.Point(6, 26);
            this.tBoxUsuario.Name = "tBoxUsuario";
            this.tBoxUsuario.ReadOnly = true;
            this.tBoxUsuario.Size = new System.Drawing.Size(312, 22);
            this.tBoxUsuario.TabIndex = 3;
            this.tBoxUsuario.TabStop = false;
            // 
            // gbRepeticaoSenha
            // 
            this.gbRepeticaoSenha.Controls.Add(this.tBoxRepeticaoSenha);
            this.gbRepeticaoSenha.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRepeticaoSenha.Location = new System.Drawing.Point(6, 150);
            this.gbRepeticaoSenha.Name = "gbRepeticaoSenha";
            this.gbRepeticaoSenha.Size = new System.Drawing.Size(324, 63);
            this.gbRepeticaoSenha.TabIndex = 19;
            this.gbRepeticaoSenha.TabStop = false;
            this.gbRepeticaoSenha.Text = "Repita a Nova Senha";
            // 
            // tBoxRepeticaoSenha
            // 
            this.tBoxRepeticaoSenha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tBoxRepeticaoSenha.Font = new System.Drawing.Font("Calibri", 9F);
            this.tBoxRepeticaoSenha.Location = new System.Drawing.Point(6, 26);
            this.tBoxRepeticaoSenha.Name = "tBoxRepeticaoSenha";
            this.tBoxRepeticaoSenha.Size = new System.Drawing.Size(312, 22);
            this.tBoxRepeticaoSenha.TabIndex = 2;
            this.tBoxRepeticaoSenha.UseSystemPasswordChar = true;
            this.tBoxRepeticaoSenha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBoxRepeticaoSenha_KeyDown);
            // 
            // frmUsuarioAlterarSenha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 270);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.gbNovaSenha);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gbRepeticaoSenha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUsuarioAlterarSenha";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alterar Senha de Usuário";
            this.Load += new System.EventHandler(this.frmUsuarioAlterarSenha_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmUsuarioAlterarSenha_KeyDown);
            this.gbNovaSenha.ResumeLayout(false);
            this.gbNovaSenha.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbRepeticaoSenha.ResumeLayout(false);
            this.gbRepeticaoSenha.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnConfirmar;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private System.Windows.Forms.GroupBox gbNovaSenha;
        private System.Windows.Forms.TextBox tBoxSenha;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tBoxUsuario;
        private System.Windows.Forms.GroupBox gbRepeticaoSenha;
        private System.Windows.Forms.TextBox tBoxRepeticaoSenha;
    }
}