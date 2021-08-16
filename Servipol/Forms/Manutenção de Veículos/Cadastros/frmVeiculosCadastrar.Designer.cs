
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
            this.tabControlFuncionario = new System.Windows.Forms.TabControl();
            this.tabPrincipal = new System.Windows.Forms.TabPage();
            this.tabDadosRegistro = new System.Windows.Forms.TabPage();
            this.groupBox35 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tBoxDataAlteracao = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tBoxUsuarioAlteracao = new System.Windows.Forms.TextBox();
            this.groupBox36 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tBoxDataReativacao = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tBoxUsuarioReativacao = new System.Windows.Forms.TextBox();
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
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.gbPlaca.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.gbSituacao.SuspendLayout();
            this.tabControlFuncionario.SuspendLayout();
            this.tabPrincipal.SuspendLayout();
            this.tabDadosRegistro.SuspendLayout();
            this.groupBox35.SuspendLayout();
            this.groupBox36.SuspendLayout();
            this.groupBox37.SuspendLayout();
            this.groupBox38.SuspendLayout();
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
            this.groupBox1.Location = new System.Drawing.Point(246, 72);
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
            this.groupBox5.Location = new System.Drawing.Point(6, 146);
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
            this.groupBox6.Location = new System.Drawing.Point(6, 72);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(145, 68);
            this.groupBox6.TabIndex = 221;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Modelo de Placa";
            // 
            // auxCodVeiculo
            // 
            this.auxCodVeiculo.AutoSize = true;
            this.auxCodVeiculo.Location = new System.Drawing.Point(1126, 443);
            this.auxCodVeiculo.Name = "auxCodVeiculo";
            this.auxCodVeiculo.Size = new System.Drawing.Size(83, 13);
            this.auxCodVeiculo.TabIndex = 227;
            this.auxCodVeiculo.Text = "auxCodVeiculo";
            // 
            // auxTipoVeiculo
            // 
            this.auxTipoVeiculo.AutoSize = true;
            this.auxTipoVeiculo.Location = new System.Drawing.Point(1126, 416);
            this.auxTipoVeiculo.Name = "auxTipoVeiculo";
            this.auxTipoVeiculo.Size = new System.Drawing.Size(85, 13);
            this.auxTipoVeiculo.TabIndex = 226;
            this.auxTipoVeiculo.Text = "auxTipoVeiculo";
            // 
            // gbPlaca
            // 
            this.gbPlaca.Controls.Add(this.tBoxPlacaVeiculo);
            this.gbPlaca.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPlaca.Location = new System.Drawing.Point(157, 72);
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
            this.groupBox4.Location = new System.Drawing.Point(136, 6);
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
            this.groupBox2.Location = new System.Drawing.Point(206, 6);
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
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
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
            this.groupBox7.Location = new System.Drawing.Point(223, 146);
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
            this.btnConfirmar.Location = new System.Drawing.Point(285, 351);
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
            this.gbSituacao.Location = new System.Drawing.Point(6, 209);
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
            this.btnCancelar.Location = new System.Drawing.Point(7, 351);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(144, 44);
            this.btnCancelar.TabIndex = 234;
            this.btnCancelar.TabStop = false;
            this.btnCancelar.Text = "[Esc] - Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // tabControlFuncionario
            // 
            this.tabControlFuncionario.Controls.Add(this.tabPrincipal);
            this.tabControlFuncionario.Controls.Add(this.tabDadosRegistro);
            this.tabControlFuncionario.Location = new System.Drawing.Point(3, 12);
            this.tabControlFuncionario.Name = "tabControlFuncionario";
            this.tabControlFuncionario.SelectedIndex = 0;
            this.tabControlFuncionario.Size = new System.Drawing.Size(435, 333);
            this.tabControlFuncionario.TabIndex = 235;
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Controls.Add(this.groupBox3);
            this.tabPrincipal.Controls.Add(this.groupBox4);
            this.tabPrincipal.Controls.Add(this.gbSituacao);
            this.tabPrincipal.Controls.Add(this.groupBox2);
            this.tabPrincipal.Controls.Add(this.groupBox6);
            this.tabPrincipal.Controls.Add(this.groupBox7);
            this.tabPrincipal.Controls.Add(this.gbPlaca);
            this.tabPrincipal.Controls.Add(this.groupBox1);
            this.tabPrincipal.Controls.Add(this.groupBox5);
            this.tabPrincipal.Location = new System.Drawing.Point(4, 22);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrincipal.Size = new System.Drawing.Size(427, 307);
            this.tabPrincipal.TabIndex = 0;
            this.tabPrincipal.Text = "Principal";
            this.tabPrincipal.UseVisualStyleBackColor = true;
            // 
            // tabDadosRegistro
            // 
            this.tabDadosRegistro.Controls.Add(this.groupBox35);
            this.tabDadosRegistro.Controls.Add(this.groupBox36);
            this.tabDadosRegistro.Controls.Add(this.groupBox37);
            this.tabDadosRegistro.Controls.Add(this.groupBox38);
            this.tabDadosRegistro.Location = new System.Drawing.Point(4, 22);
            this.tabDadosRegistro.Name = "tabDadosRegistro";
            this.tabDadosRegistro.Padding = new System.Windows.Forms.Padding(3);
            this.tabDadosRegistro.Size = new System.Drawing.Size(427, 307);
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
            this.groupBox35.Location = new System.Drawing.Point(3, 231);
            this.groupBox35.Name = "groupBox35";
            this.groupBox35.Size = new System.Drawing.Size(421, 69);
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
            this.tBoxDataAlteracao.Size = new System.Drawing.Size(351, 15);
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
            this.tBoxUsuarioAlteracao.Size = new System.Drawing.Size(350, 15);
            this.tBoxUsuarioAlteracao.TabIndex = 12;
            // 
            // groupBox36
            // 
            this.groupBox36.Controls.Add(this.label5);
            this.groupBox36.Controls.Add(this.tBoxDataReativacao);
            this.groupBox36.Controls.Add(this.label6);
            this.groupBox36.Controls.Add(this.tBoxUsuarioReativacao);
            this.groupBox36.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox36.Location = new System.Drawing.Point(3, 156);
            this.groupBox36.Name = "groupBox36";
            this.groupBox36.Size = new System.Drawing.Size(421, 69);
            this.groupBox36.TabIndex = 950;
            this.groupBox36.TabStop = false;
            this.groupBox36.Text = "Dados da Última Reativação do Cadastro";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F);
            this.label5.Location = new System.Drawing.Point(6, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 14);
            this.label5.TabIndex = 15;
            this.label5.Text = "Data:";
            // 
            // tBoxDataReativacao
            // 
            this.tBoxDataReativacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tBoxDataReativacao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tBoxDataReativacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tBoxDataReativacao.Font = new System.Drawing.Font("Calibri", 9F);
            this.tBoxDataReativacao.Location = new System.Drawing.Point(65, 45);
            this.tBoxDataReativacao.Name = "tBoxDataReativacao";
            this.tBoxDataReativacao.ReadOnly = true;
            this.tBoxDataReativacao.Size = new System.Drawing.Size(351, 15);
            this.tBoxDataReativacao.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F);
            this.label6.Location = new System.Drawing.Point(6, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 14);
            this.label6.TabIndex = 13;
            this.label6.Text = "Usuário:";
            // 
            // tBoxUsuarioReativacao
            // 
            this.tBoxUsuarioReativacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tBoxUsuarioReativacao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tBoxUsuarioReativacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tBoxUsuarioReativacao.Font = new System.Drawing.Font("Calibri", 9F);
            this.tBoxUsuarioReativacao.Location = new System.Drawing.Point(65, 25);
            this.tBoxUsuarioReativacao.Name = "tBoxUsuarioReativacao";
            this.tBoxUsuarioReativacao.ReadOnly = true;
            this.tBoxUsuarioReativacao.Size = new System.Drawing.Size(350, 15);
            this.tBoxUsuarioReativacao.TabIndex = 12;
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
            this.groupBox37.Size = new System.Drawing.Size(421, 71);
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
            this.tBoxDataCadastro.Size = new System.Drawing.Size(349, 15);
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
            this.tBoxUsuarioCadastro.Size = new System.Drawing.Size(350, 15);
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
            this.groupBox38.Size = new System.Drawing.Size(421, 70);
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
            this.tBoxDataDesativacao.Size = new System.Drawing.Size(350, 15);
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
            this.tBoxUsuarioDesativacao.Size = new System.Drawing.Size(350, 15);
            this.tBoxUsuarioDesativacao.TabIndex = 12;
            // 
            // frmVeiculosCadastrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 405);
            this.Controls.Add(this.tabControlFuncionario);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.auxCodVeiculo);
            this.Controls.Add(this.auxTipoVeiculo);
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
            this.tabControlFuncionario.ResumeLayout(false);
            this.tabPrincipal.ResumeLayout(false);
            this.tabDadosRegistro.ResumeLayout(false);
            this.groupBox35.ResumeLayout(false);
            this.groupBox35.PerformLayout();
            this.groupBox36.ResumeLayout(false);
            this.groupBox36.PerformLayout();
            this.groupBox37.ResumeLayout(false);
            this.groupBox37.PerformLayout();
            this.groupBox38.ResumeLayout(false);
            this.groupBox38.PerformLayout();
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
        private System.Windows.Forms.TabControl tabControlFuncionario;
        private System.Windows.Forms.TabPage tabPrincipal;
        private System.Windows.Forms.TabPage tabDadosRegistro;
        private System.Windows.Forms.GroupBox groupBox35;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tBoxDataAlteracao;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tBoxUsuarioAlteracao;
        private System.Windows.Forms.GroupBox groupBox36;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tBoxDataReativacao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tBoxUsuarioReativacao;
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