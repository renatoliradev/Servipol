
namespace Servipol.Forms.Manutenção_de_Veículos.Cadastros
{
    partial class frmVeiculosCadastrar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVeiculosCadastrar));
            this.cBoxFazRevisao = new System.Windows.Forms.ComboBox();
            this.cBoxCombustivel = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rBtnPlacaAntiga = new System.Windows.Forms.RadioButton();
            this.rBtnPlacaMercosul = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.auxCodVeiculo = new System.Windows.Forms.Label();
            this.auxTipoVeiculo = new System.Windows.Forms.Label();
            this.gbPlaca = new System.Windows.Forms.GroupBox();
            this.tBoxPlacaVeiculo = new System.Windows.Forms.MaskedTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cBoxCodigoVeiculo = new System.Windows.Forms.ComboBox();
            this.tBoxDescricaoVeiculo = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cBoxTipoVeiculo = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.cBoxRegistraKmDiario = new System.Windows.Forms.ComboBox();
            this.btnConfirmar = new DevExpress.XtraEditors.SimpleButton();
            this.gbSituacao = new System.Windows.Forms.GroupBox();
            this.chkBoxRegistroAtivo = new System.Windows.Forms.CheckBox();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.gbPlaca.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.gbSituacao.SuspendLayout();
            this.SuspendLayout();
            // 
            // cBoxFazRevisao
            // 
            this.cBoxFazRevisao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxFazRevisao.Font = new System.Drawing.Font("Calibri", 9F);
            this.cBoxFazRevisao.FormattingEnabled = true;
            this.cBoxFazRevisao.Items.AddRange(new object[] {
            "Sim",
            "Não"});
            this.cBoxFazRevisao.Location = new System.Drawing.Point(6, 22);
            this.cBoxFazRevisao.Name = "cBoxFazRevisao";
            this.cBoxFazRevisao.Size = new System.Drawing.Size(199, 22);
            this.cBoxFazRevisao.TabIndex = 2;
            // 
            // cBoxCombustivel
            // 
            this.cBoxCombustivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxCombustivel.Font = new System.Drawing.Font("Calibri", 9F);
            this.cBoxCombustivel.FormattingEnabled = true;
            this.cBoxCombustivel.Items.AddRange(new object[] {
            "Gasolina",
            "Etanol",
            "Diesel"});
            this.cBoxCombustivel.Location = new System.Drawing.Point(6, 22);
            this.cBoxCombustivel.Name = "cBoxCombustivel";
            this.cBoxCombustivel.Size = new System.Drawing.Size(163, 22);
            this.cBoxCombustivel.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cBoxCombustivel);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(252, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(175, 68);
            this.groupBox1.TabIndex = 228;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Combustível preferencial*";
            // 
            // rBtnPlacaAntiga
            // 
            this.rBtnPlacaAntiga.AutoSize = true;
            this.rBtnPlacaAntiga.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBtnPlacaAntiga.Location = new System.Drawing.Point(6, 43);
            this.rBtnPlacaAntiga.Name = "rBtnPlacaAntiga";
            this.rBtnPlacaAntiga.Size = new System.Drawing.Size(104, 18);
            this.rBtnPlacaAntiga.TabIndex = 1;
            this.rBtnPlacaAntiga.Text = "Modelo Antigo";
            this.rBtnPlacaAntiga.UseVisualStyleBackColor = true;
            this.rBtnPlacaAntiga.CheckedChanged += new System.EventHandler(this.rBtnPlacaAntiga_CheckedChanged);
            // 
            // rBtnPlacaMercosul
            // 
            this.rBtnPlacaMercosul.AutoSize = true;
            this.rBtnPlacaMercosul.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBtnPlacaMercosul.Location = new System.Drawing.Point(6, 22);
            this.rBtnPlacaMercosul.Name = "rBtnPlacaMercosul";
            this.rBtnPlacaMercosul.Size = new System.Drawing.Size(116, 18);
            this.rBtnPlacaMercosul.TabIndex = 0;
            this.rBtnPlacaMercosul.Text = "Padrão Mercosul";
            this.rBtnPlacaMercosul.UseVisualStyleBackColor = true;
            this.rBtnPlacaMercosul.CheckedChanged += new System.EventHandler(this.rBtnPlacaMercosul_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cBoxFazRevisao);
            this.groupBox5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(12, 152);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(211, 57);
            this.groupBox5.TabIndex = 229;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Fazendo revisão na concessionária*";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rBtnPlacaAntiga);
            this.groupBox6.Controls.Add(this.rBtnPlacaMercosul);
            this.groupBox6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(12, 78);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(145, 68);
            this.groupBox6.TabIndex = 221;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Modelo de Placa";
            // 
            // auxCodVeiculo
            // 
            this.auxCodVeiculo.AutoSize = true;
            this.auxCodVeiculo.Location = new System.Drawing.Point(854, 262);
            this.auxCodVeiculo.Name = "auxCodVeiculo";
            this.auxCodVeiculo.Size = new System.Drawing.Size(83, 13);
            this.auxCodVeiculo.TabIndex = 227;
            this.auxCodVeiculo.Text = "auxCodVeiculo";
            // 
            // auxTipoVeiculo
            // 
            this.auxTipoVeiculo.AutoSize = true;
            this.auxTipoVeiculo.Location = new System.Drawing.Point(854, 235);
            this.auxTipoVeiculo.Name = "auxTipoVeiculo";
            this.auxTipoVeiculo.Size = new System.Drawing.Size(85, 13);
            this.auxTipoVeiculo.TabIndex = 226;
            this.auxTipoVeiculo.Text = "auxTipoVeiculo";
            // 
            // gbPlaca
            // 
            this.gbPlaca.Controls.Add(this.tBoxPlacaVeiculo);
            this.gbPlaca.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPlaca.Location = new System.Drawing.Point(163, 78);
            this.gbPlaca.Name = "gbPlaca";
            this.gbPlaca.Size = new System.Drawing.Size(83, 68);
            this.gbPlaca.TabIndex = 222;
            this.gbPlaca.TabStop = false;
            this.gbPlaca.Text = "Placa*";
            // 
            // tBoxPlacaVeiculo
            // 
            this.tBoxPlacaVeiculo.Font = new System.Drawing.Font("Calibri", 9F);
            this.tBoxPlacaVeiculo.Location = new System.Drawing.Point(6, 22);
            this.tBoxPlacaVeiculo.Mask = "LLL0L00";
            this.tBoxPlacaVeiculo.Name = "tBoxPlacaVeiculo";
            this.tBoxPlacaVeiculo.Size = new System.Drawing.Size(70, 22);
            this.tBoxPlacaVeiculo.TabIndex = 4;
            this.tBoxPlacaVeiculo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBoxPlacaVeiculo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBoxPlacaVeiculo_KeyPress);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cBoxCodigoVeiculo);
            this.groupBox4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(142, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(64, 60);
            this.groupBox4.TabIndex = 219;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Código*";
            // 
            // cBoxCodigoVeiculo
            // 
            this.cBoxCodigoVeiculo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxCodigoVeiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxCodigoVeiculo.Font = new System.Drawing.Font("Calibri", 9F);
            this.cBoxCodigoVeiculo.FormattingEnabled = true;
            this.cBoxCodigoVeiculo.Location = new System.Drawing.Point(6, 22);
            this.cBoxCodigoVeiculo.Name = "cBoxCodigoVeiculo";
            this.cBoxCodigoVeiculo.Size = new System.Drawing.Size(52, 22);
            this.cBoxCodigoVeiculo.TabIndex = 2;
            // 
            // tBoxDescricaoVeiculo
            // 
            this.tBoxDescricaoVeiculo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tBoxDescricaoVeiculo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tBoxDescricaoVeiculo.Font = new System.Drawing.Font("Calibri", 9F);
            this.tBoxDescricaoVeiculo.Location = new System.Drawing.Point(6, 22);
            this.tBoxDescricaoVeiculo.Name = "tBoxDescricaoVeiculo";
            this.tBoxDescricaoVeiculo.Size = new System.Drawing.Size(203, 22);
            this.tBoxDescricaoVeiculo.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tBoxDescricaoVeiculo);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(212, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(215, 60);
            this.groupBox2.TabIndex = 220;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Descrição*";
            // 
            // cBoxTipoVeiculo
            // 
            this.cBoxTipoVeiculo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxTipoVeiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxTipoVeiculo.Font = new System.Drawing.Font("Calibri", 9F);
            this.cBoxTipoVeiculo.FormattingEnabled = true;
            this.cBoxTipoVeiculo.Location = new System.Drawing.Point(6, 22);
            this.cBoxTipoVeiculo.Name = "cBoxTipoVeiculo";
            this.cBoxTipoVeiculo.Size = new System.Drawing.Size(112, 22);
            this.cBoxTipoVeiculo.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cBoxTipoVeiculo);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(124, 60);
            this.groupBox3.TabIndex = 218;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tipo*";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.cBoxRegistraKmDiario);
            this.groupBox7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(229, 152);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(198, 57);
            this.groupBox7.TabIndex = 230;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Obrigatório registrar Km Diário*";
            // 
            // cBoxRegistraKmDiario
            // 
            this.cBoxRegistraKmDiario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxRegistraKmDiario.Font = new System.Drawing.Font("Calibri", 9F);
            this.cBoxRegistraKmDiario.FormattingEnabled = true;
            this.cBoxRegistraKmDiario.Items.AddRange(new object[] {
            "Sim",
            "Não"});
            this.cBoxRegistraKmDiario.Location = new System.Drawing.Point(6, 22);
            this.cBoxRegistraKmDiario.Name = "cBoxRegistraKmDiario";
            this.cBoxRegistraKmDiario.Size = new System.Drawing.Size(186, 22);
            this.cBoxRegistraKmDiario.TabIndex = 2;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.Appearance.Options.UseFont = true;
            this.btnConfirmar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnConfirmar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnConfirmar.ImageOptions.SvgImage")));
            this.btnConfirmar.Location = new System.Drawing.Point(284, 281);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(143, 44);
            this.btnConfirmar.TabIndex = 232;
            this.btnConfirmar.Text = "[F12] - Confirmar";
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // gbSituacao
            // 
            this.gbSituacao.Controls.Add(this.chkBoxRegistroAtivo);
            this.gbSituacao.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSituacao.Location = new System.Drawing.Point(12, 215);
            this.gbSituacao.Name = "gbSituacao";
            this.gbSituacao.Size = new System.Drawing.Size(128, 48);
            this.gbSituacao.TabIndex = 233;
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
            // btnCancelar
            // 
            this.btnCancelar.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Appearance.Options.UseFont = true;
            this.btnCancelar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnCancelar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCancelar.ImageOptions.SvgImage")));
            this.btnCancelar.Location = new System.Drawing.Point(12, 281);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(144, 44);
            this.btnCancelar.TabIndex = 234;
            this.btnCancelar.TabStop = false;
            this.btnCancelar.Text = "[Esc] - Cancelar";
            // 
            // frmVeiculosCadastrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 335);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.gbSituacao);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.auxCodVeiculo);
            this.Controls.Add(this.auxTipoVeiculo);
            this.Controls.Add(this.gbPlaca);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVeiculosCadastrar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Incluir Veículo";
            this.Load += new System.EventHandler(this.frmVeiculosCadastrar_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.gbPlaca.ResumeLayout(false);
            this.gbPlaca.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.gbSituacao.ResumeLayout(false);
            this.gbSituacao.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cBoxFazRevisao;
        private System.Windows.Forms.ComboBox cBoxCombustivel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rBtnPlacaAntiga;
        private System.Windows.Forms.RadioButton rBtnPlacaMercosul;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label auxCodVeiculo;
        private System.Windows.Forms.Label auxTipoVeiculo;
        private System.Windows.Forms.GroupBox gbPlaca;
        private System.Windows.Forms.MaskedTextBox tBoxPlacaVeiculo;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tBoxDescricaoVeiculo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cBoxTipoVeiculo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ComboBox cBoxRegistraKmDiario;
        private System.Windows.Forms.ComboBox cBoxCodigoVeiculo;
        private DevExpress.XtraEditors.SimpleButton btnConfirmar;
        private System.Windows.Forms.GroupBox gbSituacao;
        private System.Windows.Forms.CheckBox chkBoxRegistroAtivo;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
    }
}