
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
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnConfirmar = new DevExpress.XtraEditors.SimpleButton();
            this.tabControlFuncionario = new System.Windows.Forms.TabControl();
            this.tabPrincipal = new System.Windows.Forms.TabPage();
            this.gbAplicacao = new System.Windows.Forms.GroupBox();
            this.chkBoxPostoCombustivel = new System.Windows.Forms.CheckBox();
            this.gbSituacao = new System.Windows.Forms.GroupBox();
            this.chkBoxRegistroAtivo = new System.Windows.Forms.CheckBox();
            this.gbDescricao = new System.Windows.Forms.GroupBox();
            this.tBoxDescricao = new System.Windows.Forms.TextBox();
            this.tabDadosRegistro = new System.Windows.Forms.TabPage();
            this.groupBox35 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tBoxDataAlteracao = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tBoxUsuarioAlteracao = new System.Windows.Forms.TextBox();
            this.groupBox37 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tBoxDataCadastro = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tBoxUsuarioCadastro = new System.Windows.Forms.TextBox();
            this.groupBox38 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tBoxDataDesativacao = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tBoxUsuarioDesativacao = new System.Windows.Forms.TextBox();
            this.tabControlFuncionario.SuspendLayout();
            this.tabPrincipal.SuspendLayout();
            this.gbAplicacao.SuspendLayout();
            this.gbSituacao.SuspendLayout();
            this.gbDescricao.SuspendLayout();
            this.tabDadosRegistro.SuspendLayout();
            this.groupBox35.SuspendLayout();
            this.groupBox37.SuspendLayout();
            this.groupBox38.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Appearance.Options.UseFont = true;
            this.btnCancelar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnCancelar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCancelar.ImageOptions.SvgImage")));
            this.btnCancelar.Location = new System.Drawing.Point(5, 274);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(144, 44);
            this.btnCancelar.TabIndex = 241;
            this.btnCancelar.TabStop = false;
            this.btnCancelar.Text = "[Esc] - Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.Appearance.Options.UseFont = true;
            this.btnConfirmar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnConfirmar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnConfirmar.ImageOptions.SvgImage")));
            this.btnConfirmar.Location = new System.Drawing.Point(346, 274);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(143, 44);
            this.btnConfirmar.TabIndex = 240;
            this.btnConfirmar.Text = "[F12] - Confirmar";
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // tabControlFuncionario
            // 
            this.tabControlFuncionario.Controls.Add(this.tabPrincipal);
            this.tabControlFuncionario.Controls.Add(this.tabDadosRegistro);
            this.tabControlFuncionario.Location = new System.Drawing.Point(1, 8);
            this.tabControlFuncionario.Name = "tabControlFuncionario";
            this.tabControlFuncionario.SelectedIndex = 0;
            this.tabControlFuncionario.Size = new System.Drawing.Size(492, 260);
            this.tabControlFuncionario.TabIndex = 239;
            this.tabControlFuncionario.TabStop = false;
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Controls.Add(this.gbAplicacao);
            this.tabPrincipal.Controls.Add(this.gbSituacao);
            this.tabPrincipal.Controls.Add(this.gbDescricao);
            this.tabPrincipal.Location = new System.Drawing.Point(4, 22);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrincipal.Size = new System.Drawing.Size(484, 234);
            this.tabPrincipal.TabIndex = 0;
            this.tabPrincipal.Text = "Principal";
            this.tabPrincipal.UseVisualStyleBackColor = true;
            // 
            // gbAplicacao
            // 
            this.gbAplicacao.Controls.Add(this.chkBoxPostoCombustivel);
            this.gbAplicacao.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAplicacao.Location = new System.Drawing.Point(6, 72);
            this.gbAplicacao.Name = "gbAplicacao";
            this.gbAplicacao.Size = new System.Drawing.Size(149, 58);
            this.gbAplicacao.TabIndex = 9;
            this.gbAplicacao.TabStop = false;
            // 
            // chkBoxPostoCombustivel
            // 
            this.chkBoxPostoCombustivel.AutoSize = true;
            this.chkBoxPostoCombustivel.Font = new System.Drawing.Font("Calibri", 9F);
            this.chkBoxPostoCombustivel.Location = new System.Drawing.Point(6, 22);
            this.chkBoxPostoCombustivel.Name = "chkBoxPostoCombustivel";
            this.chkBoxPostoCombustivel.Size = new System.Drawing.Size(141, 18);
            this.chkBoxPostoCombustivel.TabIndex = 1;
            this.chkBoxPostoCombustivel.Text = "Posto de combustível";
            this.chkBoxPostoCombustivel.UseVisualStyleBackColor = true;
            // 
            // gbSituacao
            // 
            this.gbSituacao.Controls.Add(this.chkBoxRegistroAtivo);
            this.gbSituacao.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSituacao.Location = new System.Drawing.Point(5, 136);
            this.gbSituacao.Name = "gbSituacao";
            this.gbSituacao.Size = new System.Drawing.Size(150, 48);
            this.gbSituacao.TabIndex = 8;
            this.gbSituacao.TabStop = false;
            this.gbSituacao.Text = "Situação";
            // 
            // chkBoxRegistroAtivo
            // 
            this.chkBoxRegistroAtivo.AutoSize = true;
            this.chkBoxRegistroAtivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkBoxRegistroAtivo.Font = new System.Drawing.Font("Calibri", 9F);
            this.chkBoxRegistroAtivo.Location = new System.Drawing.Point(6, 22);
            this.chkBoxRegistroAtivo.Name = "chkBoxRegistroAtivo";
            this.chkBoxRegistroAtivo.Size = new System.Drawing.Size(100, 18);
            this.chkBoxRegistroAtivo.TabIndex = 1;
            this.chkBoxRegistroAtivo.Text = "Registro Ativo";
            this.chkBoxRegistroAtivo.UseVisualStyleBackColor = true;
            // 
            // gbDescricao
            // 
            this.gbDescricao.Controls.Add(this.tBoxDescricao);
            this.gbDescricao.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDescricao.Location = new System.Drawing.Point(6, 6);
            this.gbDescricao.Name = "gbDescricao";
            this.gbDescricao.Size = new System.Drawing.Size(472, 60);
            this.gbDescricao.TabIndex = 2;
            this.gbDescricao.TabStop = false;
            this.gbDescricao.Text = "Denominação*";
            // 
            // tBoxDescricao
            // 
            this.tBoxDescricao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tBoxDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tBoxDescricao.Font = new System.Drawing.Font("Calibri", 9F);
            this.tBoxDescricao.Location = new System.Drawing.Point(6, 22);
            this.tBoxDescricao.Name = "tBoxDescricao";
            this.tBoxDescricao.Size = new System.Drawing.Size(460, 22);
            this.tBoxDescricao.TabIndex = 1;
            // 
            // tabDadosRegistro
            // 
            this.tabDadosRegistro.Controls.Add(this.groupBox35);
            this.tabDadosRegistro.Controls.Add(this.groupBox37);
            this.tabDadosRegistro.Controls.Add(this.groupBox38);
            this.tabDadosRegistro.Location = new System.Drawing.Point(4, 22);
            this.tabDadosRegistro.Name = "tabDadosRegistro";
            this.tabDadosRegistro.Padding = new System.Windows.Forms.Padding(3);
            this.tabDadosRegistro.Size = new System.Drawing.Size(484, 234);
            this.tabDadosRegistro.TabIndex = 4;
            this.tabDadosRegistro.Text = "Dados do Registro";
            this.tabDadosRegistro.UseVisualStyleBackColor = true;
            // 
            // groupBox35
            // 
            this.groupBox35.Controls.Add(this.label13);
            this.groupBox35.Controls.Add(this.tBoxDataAlteracao);
            this.groupBox35.Controls.Add(this.label14);
            this.groupBox35.Controls.Add(this.tBoxUsuarioAlteracao);
            this.groupBox35.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox35.Location = new System.Drawing.Point(3, 156);
            this.groupBox35.Name = "groupBox35";
            this.groupBox35.Size = new System.Drawing.Size(478, 69);
            this.groupBox35.TabIndex = 999;
            this.groupBox35.TabStop = false;
            this.groupBox35.Text = "Dados da Última Alteração do Cadastro";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 9F);
            this.label13.Location = new System.Drawing.Point(6, 45);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 14);
            this.label13.TabIndex = 15;
            this.label13.Text = "Data:";
            // 
            // tBoxDataAlteracao
            // 
            this.tBoxDataAlteracao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tBoxDataAlteracao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tBoxDataAlteracao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tBoxDataAlteracao.Font = new System.Drawing.Font("Calibri", 9F);
            this.tBoxDataAlteracao.Location = new System.Drawing.Point(65, 45);
            this.tBoxDataAlteracao.Name = "tBoxDataAlteracao";
            this.tBoxDataAlteracao.ReadOnly = true;
            this.tBoxDataAlteracao.Size = new System.Drawing.Size(408, 15);
            this.tBoxDataAlteracao.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 9F);
            this.label14.Location = new System.Drawing.Point(6, 25);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 14);
            this.label14.TabIndex = 13;
            this.label14.Text = "Usuário:";
            // 
            // tBoxUsuarioAlteracao
            // 
            this.tBoxUsuarioAlteracao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tBoxUsuarioAlteracao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tBoxUsuarioAlteracao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tBoxUsuarioAlteracao.Font = new System.Drawing.Font("Calibri", 9F);
            this.tBoxUsuarioAlteracao.Location = new System.Drawing.Point(65, 25);
            this.tBoxUsuarioAlteracao.Name = "tBoxUsuarioAlteracao";
            this.tBoxUsuarioAlteracao.ReadOnly = true;
            this.tBoxUsuarioAlteracao.Size = new System.Drawing.Size(407, 15);
            this.tBoxUsuarioAlteracao.TabIndex = 12;
            // 
            // groupBox37
            // 
            this.groupBox37.Controls.Add(this.label9);
            this.groupBox37.Controls.Add(this.tBoxDataCadastro);
            this.groupBox37.Controls.Add(this.label10);
            this.groupBox37.Controls.Add(this.tBoxUsuarioCadastro);
            this.groupBox37.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox37.Location = new System.Drawing.Point(3, 6);
            this.groupBox37.Name = "groupBox37";
            this.groupBox37.Size = new System.Drawing.Size(478, 71);
            this.groupBox37.TabIndex = 800;
            this.groupBox37.TabStop = false;
            this.groupBox37.Text = "Dados de Inclusão do Cadastro";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9F);
            this.label9.Location = new System.Drawing.Point(6, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 14);
            this.label9.TabIndex = 15;
            this.label9.Text = "Data:";
            // 
            // tBoxDataCadastro
            // 
            this.tBoxDataCadastro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tBoxDataCadastro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tBoxDataCadastro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tBoxDataCadastro.Font = new System.Drawing.Font("Calibri", 9F);
            this.tBoxDataCadastro.Location = new System.Drawing.Point(65, 45);
            this.tBoxDataCadastro.Name = "tBoxDataCadastro";
            this.tBoxDataCadastro.ReadOnly = true;
            this.tBoxDataCadastro.Size = new System.Drawing.Size(406, 15);
            this.tBoxDataCadastro.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 9F);
            this.label10.Location = new System.Drawing.Point(6, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 14);
            this.label10.TabIndex = 13;
            this.label10.Text = "Usuário:";
            // 
            // tBoxUsuarioCadastro
            // 
            this.tBoxUsuarioCadastro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tBoxUsuarioCadastro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tBoxUsuarioCadastro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tBoxUsuarioCadastro.Font = new System.Drawing.Font("Calibri", 9F);
            this.tBoxUsuarioCadastro.Location = new System.Drawing.Point(65, 25);
            this.tBoxUsuarioCadastro.Name = "tBoxUsuarioCadastro";
            this.tBoxUsuarioCadastro.ReadOnly = true;
            this.tBoxUsuarioCadastro.Size = new System.Drawing.Size(407, 15);
            this.tBoxUsuarioCadastro.TabIndex = 12;
            // 
            // groupBox38
            // 
            this.groupBox38.Controls.Add(this.label11);
            this.groupBox38.Controls.Add(this.tBoxDataDesativacao);
            this.groupBox38.Controls.Add(this.label12);
            this.groupBox38.Controls.Add(this.tBoxUsuarioDesativacao);
            this.groupBox38.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox38.Location = new System.Drawing.Point(3, 80);
            this.groupBox38.Name = "groupBox38";
            this.groupBox38.Size = new System.Drawing.Size(478, 70);
            this.groupBox38.TabIndex = 900;
            this.groupBox38.TabStop = false;
            this.groupBox38.Text = "Dados da Última Desativação do Cadastro";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 9F);
            this.label11.Location = new System.Drawing.Point(6, 45);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 14);
            this.label11.TabIndex = 15;
            this.label11.Text = "Data:";
            // 
            // tBoxDataDesativacao
            // 
            this.tBoxDataDesativacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tBoxDataDesativacao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tBoxDataDesativacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tBoxDataDesativacao.Font = new System.Drawing.Font("Calibri", 9F);
            this.tBoxDataDesativacao.Location = new System.Drawing.Point(65, 45);
            this.tBoxDataDesativacao.Name = "tBoxDataDesativacao";
            this.tBoxDataDesativacao.ReadOnly = true;
            this.tBoxDataDesativacao.Size = new System.Drawing.Size(407, 15);
            this.tBoxDataDesativacao.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 9F);
            this.label12.Location = new System.Drawing.Point(6, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 14);
            this.label12.TabIndex = 13;
            this.label12.Text = "Usuário:";
            // 
            // tBoxUsuarioDesativacao
            // 
            this.tBoxUsuarioDesativacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tBoxUsuarioDesativacao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tBoxUsuarioDesativacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tBoxUsuarioDesativacao.Font = new System.Drawing.Font("Calibri", 9F);
            this.tBoxUsuarioDesativacao.Location = new System.Drawing.Point(65, 25);
            this.tBoxUsuarioDesativacao.Name = "tBoxUsuarioDesativacao";
            this.tBoxUsuarioDesativacao.ReadOnly = true;
            this.tBoxUsuarioDesativacao.Size = new System.Drawing.Size(407, 15);
            this.tBoxUsuarioDesativacao.TabIndex = 12;
            // 
            // frmLocalManutencaoCadastrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 326);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.tabControlFuncionario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLocalManutencaoCadastrar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar Local de Manutenção";
            this.Load += new System.EventHandler(this.frmLocalManutencaoCadastrar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLocalManutencaoCadastrar_KeyDown);
            this.tabControlFuncionario.ResumeLayout(false);
            this.tabPrincipal.ResumeLayout(false);
            this.gbAplicacao.ResumeLayout(false);
            this.gbAplicacao.PerformLayout();
            this.gbSituacao.ResumeLayout(false);
            this.gbSituacao.PerformLayout();
            this.gbDescricao.ResumeLayout(false);
            this.gbDescricao.PerformLayout();
            this.tabDadosRegistro.ResumeLayout(false);
            this.groupBox35.ResumeLayout(false);
            this.groupBox35.PerformLayout();
            this.groupBox37.ResumeLayout(false);
            this.groupBox37.PerformLayout();
            this.groupBox38.ResumeLayout(false);
            this.groupBox38.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnConfirmar;
        private System.Windows.Forms.TabControl tabControlFuncionario;
        private System.Windows.Forms.TabPage tabPrincipal;
        private System.Windows.Forms.GroupBox gbAplicacao;
        private System.Windows.Forms.CheckBox chkBoxPostoCombustivel;
        private System.Windows.Forms.GroupBox gbSituacao;
        private System.Windows.Forms.CheckBox chkBoxRegistroAtivo;
        private System.Windows.Forms.GroupBox gbDescricao;
        private System.Windows.Forms.TextBox tBoxDescricao;
        private System.Windows.Forms.TabPage tabDadosRegistro;
        private System.Windows.Forms.GroupBox groupBox35;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tBoxDataAlteracao;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tBoxUsuarioAlteracao;
        private System.Windows.Forms.GroupBox groupBox37;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tBoxDataCadastro;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tBoxUsuarioCadastro;
        private System.Windows.Forms.GroupBox groupBox38;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tBoxDataDesativacao;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tBoxUsuarioDesativacao;
    }
}