
namespace Servipol.Forms.Manutenção_de_Veículos.Cadastros
{
    partial class frmLocalManutencaoCadastrar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLocalManutencaoCadastrar));
            this.btnCancelarCadastro = new DevExpress.XtraEditors.SimpleButton();
            this.btnConfirmaInclusao = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.chkBoxPostoCombustivel = new System.Windows.Forms.CheckBox();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tBoxDenominacao = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelarCadastro
            // 
            this.btnCancelarCadastro.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarCadastro.Appearance.Options.UseFont = true;
            this.btnCancelarCadastro.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnCancelarCadastro.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCancelarCadastro.ImageOptions.SvgImage")));
            this.btnCancelarCadastro.Location = new System.Drawing.Point(12, 146);
            this.btnCancelarCadastro.Name = "btnCancelarCadastro";
            this.btnCancelarCadastro.Size = new System.Drawing.Size(214, 44);
            this.btnCancelarCadastro.TabIndex = 182;
            this.btnCancelarCadastro.Text = "[Esc] - Cancelar inclusão";
            this.btnCancelarCadastro.Click += new System.EventHandler(this.btnCancelarCadastro_Click);
            // 
            // btnConfirmaInclusao
            // 
            this.btnConfirmaInclusao.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmaInclusao.Appearance.Options.UseFont = true;
            this.btnConfirmaInclusao.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnConfirmaInclusao.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnConfirmaInclusao.ImageOptions.SvgImage")));
            this.btnConfirmaInclusao.Location = new System.Drawing.Point(330, 146);
            this.btnConfirmaInclusao.Name = "btnConfirmaInclusao";
            this.btnConfirmaInclusao.Size = new System.Drawing.Size(233, 44);
            this.btnConfirmaInclusao.TabIndex = 181;
            this.btnConfirmaInclusao.Text = "[F12] - Confirmar inclusão";
            this.btnConfirmaInclusao.Click += new System.EventHandler(this.btnConfirmaInclusao_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.chkBoxPostoCombustivel);
            this.groupControl2.Enabled = false;
            this.groupControl2.Location = new System.Drawing.Point(12, 72);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(152, 49);
            this.groupControl2.TabIndex = 180;
            // 
            // chkBoxPostoCombustivel
            // 
            this.chkBoxPostoCombustivel.AutoSize = true;
            this.chkBoxPostoCombustivel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBoxPostoCombustivel.Location = new System.Drawing.Point(5, 25);
            this.chkBoxPostoCombustivel.Name = "chkBoxPostoCombustivel";
            this.chkBoxPostoCombustivel.Size = new System.Drawing.Size(142, 18);
            this.chkBoxPostoCombustivel.TabIndex = 172;
            this.chkBoxPostoCombustivel.Text = "Posto de Combustível";
            this.chkBoxPostoCombustivel.UseVisualStyleBackColor = true;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.tBoxDenominacao);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(551, 54);
            this.groupControl1.TabIndex = 179;
            this.groupControl1.Text = "Denominação*";
            // 
            // tBoxDenominacao
            // 
            this.tBoxDenominacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tBoxDenominacao.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBoxDenominacao.Location = new System.Drawing.Point(5, 25);
            this.tBoxDenominacao.Name = "tBoxDenominacao";
            this.tBoxDenominacao.Size = new System.Drawing.Size(541, 22);
            this.tBoxDenominacao.TabIndex = 1;
            // 
            // frmLocalManutencaoCadastrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 203);
            this.Controls.Add(this.btnCancelarCadastro);
            this.Controls.Add(this.btnConfirmaInclusao);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLocalManutencaoCadastrar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Incluir Local de Manutenção";
            this.Load += new System.EventHandler(this.frmLocalManutencaoCadastrar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancelarCadastro;
        private DevExpress.XtraEditors.SimpleButton btnConfirmaInclusao;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.CheckBox chkBoxPostoCombustivel;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.TextBox tBoxDenominacao;
    }
}