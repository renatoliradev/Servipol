
namespace Servipol.Forms.Manutenção_de_Veículos.Cadastros
{
    partial class frmTipoManutencaoCadastrar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTipoManutencaoCadastrar));
            this.btnCancelarCadastro = new DevExpress.XtraEditors.SimpleButton();
            this.btnConfirmaInclusao = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.chkBoxCarro = new System.Windows.Forms.CheckBox();
            this.chkBoxMoto = new System.Windows.Forms.CheckBox();
            this.gbDenominacao = new DevExpress.XtraEditors.GroupControl();
            this.tBoxDenominacao = new System.Windows.Forms.TextBox();
            this.auxChkBoxMoto = new System.Windows.Forms.Label();
            this.auxChkBoxCarro = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbDenominacao)).BeginInit();
            this.gbDenominacao.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelarCadastro
            // 
            this.btnCancelarCadastro.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarCadastro.Appearance.Options.UseFont = true;
            this.btnCancelarCadastro.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnCancelarCadastro.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCancelarCadastro.ImageOptions.SvgImage")));
            this.btnCancelarCadastro.Location = new System.Drawing.Point(12, 165);
            this.btnCancelarCadastro.Name = "btnCancelarCadastro";
            this.btnCancelarCadastro.Size = new System.Drawing.Size(214, 44);
            this.btnCancelarCadastro.TabIndex = 179;
            this.btnCancelarCadastro.Text = "[Esc] - Cancelar inclusão";
            this.btnCancelarCadastro.Click += new System.EventHandler(this.btnCancelarCadastro_Click);
            // 
            // btnConfirmaInclusao
            // 
            this.btnConfirmaInclusao.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmaInclusao.Appearance.Options.UseFont = true;
            this.btnConfirmaInclusao.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnConfirmaInclusao.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnConfirmaInclusao.ImageOptions.SvgImage")));
            this.btnConfirmaInclusao.Location = new System.Drawing.Point(346, 165);
            this.btnConfirmaInclusao.Name = "btnConfirmaInclusao";
            this.btnConfirmaInclusao.Size = new System.Drawing.Size(233, 44);
            this.btnConfirmaInclusao.TabIndex = 178;
            this.btnConfirmaInclusao.Text = "[F12] - Confirmar inclusão";
            this.btnConfirmaInclusao.Click += new System.EventHandler(this.btnConfirmaInclusao_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.chkBoxCarro);
            this.groupControl1.Controls.Add(this.chkBoxMoto);
            this.groupControl1.Location = new System.Drawing.Point(12, 71);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(214, 88);
            this.groupControl1.TabIndex = 177;
            this.groupControl1.Text = "Veículos que o serviço se aplica";
            // 
            // chkBoxCarro
            // 
            this.chkBoxCarro.AutoSize = true;
            this.chkBoxCarro.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBoxCarro.Location = new System.Drawing.Point(5, 34);
            this.chkBoxCarro.Name = "chkBoxCarro";
            this.chkBoxCarro.Size = new System.Drawing.Size(54, 18);
            this.chkBoxCarro.TabIndex = 2;
            this.chkBoxCarro.Text = "Carro";
            this.chkBoxCarro.UseVisualStyleBackColor = true;
            // 
            // chkBoxMoto
            // 
            this.chkBoxMoto.AutoSize = true;
            this.chkBoxMoto.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBoxMoto.Location = new System.Drawing.Point(5, 58);
            this.chkBoxMoto.Name = "chkBoxMoto";
            this.chkBoxMoto.Size = new System.Drawing.Size(54, 18);
            this.chkBoxMoto.TabIndex = 3;
            this.chkBoxMoto.Text = "Moto";
            this.chkBoxMoto.UseVisualStyleBackColor = true;
            // 
            // gbDenominacao
            // 
            this.gbDenominacao.Controls.Add(this.tBoxDenominacao);
            this.gbDenominacao.Location = new System.Drawing.Point(12, 12);
            this.gbDenominacao.Name = "gbDenominacao";
            this.gbDenominacao.Size = new System.Drawing.Size(567, 53);
            this.gbDenominacao.TabIndex = 176;
            this.gbDenominacao.Text = "Descrição do Serviço*";
            // 
            // tBoxDenominacao
            // 
            this.tBoxDenominacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tBoxDenominacao.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBoxDenominacao.Location = new System.Drawing.Point(5, 25);
            this.tBoxDenominacao.Name = "tBoxDenominacao";
            this.tBoxDenominacao.Size = new System.Drawing.Size(557, 22);
            this.tBoxDenominacao.TabIndex = 1;
            // 
            // auxChkBoxMoto
            // 
            this.auxChkBoxMoto.AutoSize = true;
            this.auxChkBoxMoto.Location = new System.Drawing.Point(778, 326);
            this.auxChkBoxMoto.Name = "auxChkBoxMoto";
            this.auxChkBoxMoto.Size = new System.Drawing.Size(91, 13);
            this.auxChkBoxMoto.TabIndex = 181;
            this.auxChkBoxMoto.Text = "auxChkBoxMoto";
            // 
            // auxChkBoxCarro
            // 
            this.auxChkBoxCarro.AutoSize = true;
            this.auxChkBoxCarro.Location = new System.Drawing.Point(777, 300);
            this.auxChkBoxCarro.Name = "auxChkBoxCarro";
            this.auxChkBoxCarro.Size = new System.Drawing.Size(91, 13);
            this.auxChkBoxCarro.TabIndex = 180;
            this.auxChkBoxCarro.Text = "auxChkBoxCarro";
            // 
            // frmTipoManutencaoCadastrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 220);
            this.Controls.Add(this.auxChkBoxMoto);
            this.Controls.Add(this.auxChkBoxCarro);
            this.Controls.Add(this.btnCancelarCadastro);
            this.Controls.Add(this.btnConfirmaInclusao);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.gbDenominacao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTipoManutencaoCadastrar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Incluir Tipo de Manutenção";
            this.Load += new System.EventHandler(this.frmTipoManutencaoCadastrar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbDenominacao)).EndInit();
            this.gbDenominacao.ResumeLayout(false);
            this.gbDenominacao.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancelarCadastro;
        private DevExpress.XtraEditors.SimpleButton btnConfirmaInclusao;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.CheckBox chkBoxCarro;
        private System.Windows.Forms.CheckBox chkBoxMoto;
        private DevExpress.XtraEditors.GroupControl gbDenominacao;
        private System.Windows.Forms.TextBox tBoxDenominacao;
        private System.Windows.Forms.Label auxChkBoxMoto;
        private System.Windows.Forms.Label auxChkBoxCarro;
    }
}