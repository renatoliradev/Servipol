
namespace Servipol.Forms.Manutenção_de_Veículos.Manutenção
{
    partial class frmManutencaoConsultar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManutencaoConsultar));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gBoxUsuario = new System.Windows.Forms.GroupBox();
            this.cBoxUsuario = new System.Windows.Forms.ComboBox();
            this.gBoxLocalManutencao = new System.Windows.Forms.GroupBox();
            this.cBoxLocalManutencao = new System.Windows.Forms.ComboBox();
            this.gBoxDataManutencao = new System.Windows.Forms.GroupBox();
            this.tBoxDataFinal = new System.Windows.Forms.DateTimePicker();
            this.tBoxDataInicial = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cBoxSituacao = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnImprimirConsulta = new DevExpress.XtraEditors.SimpleButton();
            this.btnVisualizar = new DevExpress.XtraEditors.SimpleButton();
            this.btnExcluir = new DevExpress.XtraEditors.SimpleButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tBoxQtdRegistros = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tBoxValorTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cBoxTipoBusca = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dGridManutencoes = new System.Windows.Forms.DataGridView();
            this.cBoxVeiculo = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gBoxVeiculo = new System.Windows.Forms.GroupBox();
            this.gBoxTipoManutencao = new System.Windows.Forms.GroupBox();
            this.cBoxTipoManutencao = new System.Windows.Forms.ComboBox();
            this.gBoxFuncionario = new System.Windows.Forms.GroupBox();
            this.cBoxFuncionario = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.id_manutencao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_manutencao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_veiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.placa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.veiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.km_veiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.km_atual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.km_rodado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao_tipo_manutencao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao_local_manutencao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.situacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor_total_manutencao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gBoxUsuario.SuspendLayout();
            this.gBoxLocalManutencao.SuspendLayout();
            this.gBoxDataManutencao.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridManutencoes)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.gBoxVeiculo.SuspendLayout();
            this.gBoxTipoManutencao.SuspendLayout();
            this.gBoxFuncionario.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBoxUsuario
            // 
            this.gBoxUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.gBoxUsuario.Controls.Add(this.cBoxUsuario);
            this.gBoxUsuario.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.gBoxUsuario.Location = new System.Drawing.Point(0, 0);
            this.gBoxUsuario.Name = "gBoxUsuario";
            this.gBoxUsuario.Size = new System.Drawing.Size(663, 46);
            this.gBoxUsuario.TabIndex = 194;
            this.gBoxUsuario.TabStop = false;
            this.gBoxUsuario.Text = "Usuário do Cadastro da Manutenção";
            // 
            // cBoxUsuario
            // 
            this.cBoxUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxUsuario.Font = new System.Drawing.Font("Calibri", 9F);
            this.cBoxUsuario.FormattingEnabled = true;
            this.cBoxUsuario.Location = new System.Drawing.Point(6, 16);
            this.cBoxUsuario.Name = "cBoxUsuario";
            this.cBoxUsuario.Size = new System.Drawing.Size(651, 22);
            this.cBoxUsuario.TabIndex = 185;
            // 
            // gBoxLocalManutencao
            // 
            this.gBoxLocalManutencao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.gBoxLocalManutencao.Controls.Add(this.cBoxLocalManutencao);
            this.gBoxLocalManutencao.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.gBoxLocalManutencao.Location = new System.Drawing.Point(349, 70);
            this.gBoxLocalManutencao.Name = "gBoxLocalManutencao";
            this.gBoxLocalManutencao.Size = new System.Drawing.Size(663, 46);
            this.gBoxLocalManutencao.TabIndex = 193;
            this.gBoxLocalManutencao.TabStop = false;
            this.gBoxLocalManutencao.Text = "Local da Manutenção";
            // 
            // cBoxLocalManutencao
            // 
            this.cBoxLocalManutencao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxLocalManutencao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxLocalManutencao.Font = new System.Drawing.Font("Calibri", 9F);
            this.cBoxLocalManutencao.FormattingEnabled = true;
            this.cBoxLocalManutencao.Location = new System.Drawing.Point(6, 16);
            this.cBoxLocalManutencao.Name = "cBoxLocalManutencao";
            this.cBoxLocalManutencao.Size = new System.Drawing.Size(651, 22);
            this.cBoxLocalManutencao.TabIndex = 185;
            // 
            // gBoxDataManutencao
            // 
            this.gBoxDataManutencao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.gBoxDataManutencao.Controls.Add(this.tBoxDataFinal);
            this.gBoxDataManutencao.Controls.Add(this.tBoxDataInicial);
            this.gBoxDataManutencao.Controls.Add(this.label1);
            this.gBoxDataManutencao.Controls.Add(this.label2);
            this.gBoxDataManutencao.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.gBoxDataManutencao.Location = new System.Drawing.Point(349, 18);
            this.gBoxDataManutencao.Name = "gBoxDataManutencao";
            this.gBoxDataManutencao.Size = new System.Drawing.Size(663, 46);
            this.gBoxDataManutencao.TabIndex = 195;
            this.gBoxDataManutencao.TabStop = false;
            this.gBoxDataManutencao.Text = "Período";
            // 
            // tBoxDataFinal
            // 
            this.tBoxDataFinal.CalendarFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBoxDataFinal.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBoxDataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tBoxDataFinal.Location = new System.Drawing.Point(232, 16);
            this.tBoxDataFinal.Name = "tBoxDataFinal";
            this.tBoxDataFinal.Size = new System.Drawing.Size(137, 22);
            this.tBoxDataFinal.TabIndex = 191;
            this.tBoxDataFinal.Value = new System.DateTime(2021, 7, 24, 0, 0, 0, 0);
            // 
            // tBoxDataInicial
            // 
            this.tBoxDataInicial.CalendarFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBoxDataInicial.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBoxDataInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tBoxDataInicial.Location = new System.Drawing.Point(38, 16);
            this.tBoxDataInicial.Name = "tBoxDataInicial";
            this.tBoxDataInicial.Size = new System.Drawing.Size(137, 22);
            this.tBoxDataInicial.TabIndex = 190;
            this.tBoxDataInicial.Value = new System.DateTime(2021, 7, 24, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 15);
            this.label1.TabIndex = 187;
            this.label1.Text = "De:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(195, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 189;
            this.label2.Text = "Até:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.groupBox3.Controls.Add(this.cBoxSituacao);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(3, 18);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(340, 46);
            this.groupBox3.TabIndex = 192;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Situação";
            // 
            // cBoxSituacao
            // 
            this.cBoxSituacao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxSituacao.Font = new System.Drawing.Font("Calibri", 9F);
            this.cBoxSituacao.FormattingEnabled = true;
            this.cBoxSituacao.Items.AddRange(new object[] {
            "Apenas Confirmadas",
            "Apenas Excluídas"});
            this.cBoxSituacao.Location = new System.Drawing.Point(6, 16);
            this.cBoxSituacao.Name = "cBoxSituacao";
            this.cBoxSituacao.Size = new System.Drawing.Size(328, 22);
            this.cBoxSituacao.TabIndex = 184;
            this.cBoxSituacao.SelectedIndexChanged += new System.EventHandler(this.cBoxSituacao_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.btnImprimirConsulta);
            this.panel1.Controls.Add(this.btnVisualizar);
            this.panel1.Controls.Add(this.btnExcluir);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 338);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1166, 92);
            this.panel1.TabIndex = 202;
            // 
            // btnImprimirConsulta
            // 
            this.btnImprimirConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImprimirConsulta.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimirConsulta.Appearance.Options.UseFont = true;
            this.btnImprimirConsulta.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnImprimirConsulta.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnImprimirConsulta.ImageOptions.SvgImage")));
            this.btnImprimirConsulta.Location = new System.Drawing.Point(3, 40);
            this.btnImprimirConsulta.Name = "btnImprimirConsulta";
            this.btnImprimirConsulta.Size = new System.Drawing.Size(233, 44);
            this.btnImprimirConsulta.TabIndex = 208;
            this.btnImprimirConsulta.TabStop = false;
            this.btnImprimirConsulta.Text = "[CTRL + P] - Imprimir consulta";
            this.btnImprimirConsulta.Click += new System.EventHandler(this.btnImprimirConsulta_Click);
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVisualizar.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVisualizar.Appearance.Options.UseFont = true;
            this.btnVisualizar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnVisualizar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnVisualizar.ImageOptions.SvgImage")));
            this.btnVisualizar.Location = new System.Drawing.Point(868, 40);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(144, 44);
            this.btnVisualizar.TabIndex = 207;
            this.btnVisualizar.TabStop = false;
            this.btnVisualizar.Text = "[F8] - Visualizar";
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcluir.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Appearance.Options.UseFont = true;
            this.btnExcluir.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnExcluir.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnExcluir.ImageOptions.SvgImage")));
            this.btnExcluir.Location = new System.Drawing.Point(1018, 40);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(144, 44);
            this.btnExcluir.TabIndex = 206;
            this.btnExcluir.TabStop = false;
            this.btnExcluir.Text = "[Del] - Excluir";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Info;
            this.panel4.Controls.Add(this.tBoxQtdRegistros);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.tBoxValorTotal);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1166, 24);
            this.panel4.TabIndex = 199;
            // 
            // tBoxQtdRegistros
            // 
            this.tBoxQtdRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tBoxQtdRegistros.BackColor = System.Drawing.SystemColors.Info;
            this.tBoxQtdRegistros.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tBoxQtdRegistros.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBoxQtdRegistros.ForeColor = System.Drawing.Color.Red;
            this.tBoxQtdRegistros.Location = new System.Drawing.Point(194, 2);
            this.tBoxQtdRegistros.Name = "tBoxQtdRegistros";
            this.tBoxQtdRegistros.ReadOnly = true;
            this.tBoxQtdRegistros.Size = new System.Drawing.Size(39, 20);
            this.tBoxQtdRegistros.TabIndex = 200;
            this.tBoxQtdRegistros.Text = "0";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 20);
            this.label4.TabIndex = 199;
            this.label4.Text = "Quantidade de Registros:";
            // 
            // tBoxValorTotal
            // 
            this.tBoxValorTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tBoxValorTotal.BackColor = System.Drawing.SystemColors.Info;
            this.tBoxValorTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tBoxValorTotal.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBoxValorTotal.ForeColor = System.Drawing.Color.Red;
            this.tBoxValorTotal.Location = new System.Drawing.Point(1067, 2);
            this.tBoxValorTotal.Name = "tBoxValorTotal";
            this.tBoxValorTotal.ReadOnly = true;
            this.tBoxValorTotal.Size = new System.Drawing.Size(95, 20);
            this.tBoxValorTotal.TabIndex = 198;
            this.tBoxValorTotal.TabStop = false;
            this.tBoxValorTotal.Text = "R$ 0,00";
            this.tBoxValorTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(973, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 20);
            this.label3.TabIndex = 197;
            this.label3.Text = "Valor Total:";
            // 
            // cBoxTipoBusca
            // 
            this.cBoxTipoBusca.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxTipoBusca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxTipoBusca.Font = new System.Drawing.Font("Calibri", 9F);
            this.cBoxTipoBusca.FormattingEnabled = true;
            this.cBoxTipoBusca.Items.AddRange(new object[] {
            "Mostrar 20 últimas manutenções",
            "Período",
            "Veículo",
            "Tipo da manutenção",
            "Local da manutenção",
            "Funcionário que fez o serviço"});
            this.cBoxTipoBusca.Location = new System.Drawing.Point(6, 16);
            this.cBoxTipoBusca.Name = "cBoxTipoBusca";
            this.cBoxTipoBusca.Size = new System.Drawing.Size(328, 22);
            this.cBoxTipoBusca.TabIndex = 184;
            this.cBoxTipoBusca.SelectedIndexChanged += new System.EventHandler(this.cBoxTipoBusca_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.dGridManutencoes);
            this.panel2.Location = new System.Drawing.Point(0, 128);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1166, 209);
            this.panel2.TabIndex = 203;
            // 
            // dGridManutencoes
            // 
            this.dGridManutencoes.AllowUserToAddRows = false;
            this.dGridManutencoes.AllowUserToDeleteRows = false;
            this.dGridManutencoes.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.dGridManutencoes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dGridManutencoes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGridManutencoes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGridManutencoes.BackgroundColor = System.Drawing.Color.White;
            this.dGridManutencoes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dGridManutencoes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dGridManutencoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGridManutencoes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_manutencao,
            this.data_manutencao,
            this.id_veiculo,
            this.placa,
            this.veiculo,
            this.km_veiculo,
            this.km_atual,
            this.km_rodado,
            this.descricao_tipo_manutencao,
            this.descricao_local_manutencao,
            this.qra,
            this.situacao,
            this.valor_total_manutencao});
            this.dGridManutencoes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dGridManutencoes.Location = new System.Drawing.Point(3, 3);
            this.dGridManutencoes.MultiSelect = false;
            this.dGridManutencoes.Name = "dGridManutencoes";
            this.dGridManutencoes.ReadOnly = true;
            this.dGridManutencoes.RowHeadersVisible = false;
            this.dGridManutencoes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dGridManutencoes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dGridManutencoes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGridManutencoes.Size = new System.Drawing.Size(1160, 206);
            this.dGridManutencoes.TabIndex = 181;
            this.dGridManutencoes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGridManutencoes_CellDoubleClick);
            // 
            // cBoxVeiculo
            // 
            this.cBoxVeiculo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxVeiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxVeiculo.Font = new System.Drawing.Font("Calibri", 9F);
            this.cBoxVeiculo.FormattingEnabled = true;
            this.cBoxVeiculo.Location = new System.Drawing.Point(6, 16);
            this.cBoxVeiculo.Name = "cBoxVeiculo";
            this.cBoxVeiculo.Size = new System.Drawing.Size(651, 22);
            this.cBoxVeiculo.TabIndex = 185;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.groupBox2.Controls.Add(this.cBoxTipoBusca);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(3, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(340, 46);
            this.groupBox2.TabIndex = 201;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Consultar Por";
            // 
            // gBoxVeiculo
            // 
            this.gBoxVeiculo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.gBoxVeiculo.Controls.Add(this.cBoxVeiculo);
            this.gBoxVeiculo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.gBoxVeiculo.Location = new System.Drawing.Point(349, 70);
            this.gBoxVeiculo.Name = "gBoxVeiculo";
            this.gBoxVeiculo.Size = new System.Drawing.Size(663, 46);
            this.gBoxVeiculo.TabIndex = 194;
            this.gBoxVeiculo.TabStop = false;
            this.gBoxVeiculo.Text = "Veículo";
            // 
            // gBoxTipoManutencao
            // 
            this.gBoxTipoManutencao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.gBoxTipoManutencao.Controls.Add(this.cBoxTipoManutencao);
            this.gBoxTipoManutencao.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.gBoxTipoManutencao.Location = new System.Drawing.Point(349, 70);
            this.gBoxTipoManutencao.Name = "gBoxTipoManutencao";
            this.gBoxTipoManutencao.Size = new System.Drawing.Size(663, 46);
            this.gBoxTipoManutencao.TabIndex = 192;
            this.gBoxTipoManutencao.TabStop = false;
            this.gBoxTipoManutencao.Text = "Tipo da Manutenção";
            // 
            // cBoxTipoManutencao
            // 
            this.cBoxTipoManutencao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxTipoManutencao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cBoxTipoManutencao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cBoxTipoManutencao.Font = new System.Drawing.Font("Calibri", 9F);
            this.cBoxTipoManutencao.FormattingEnabled = true;
            this.cBoxTipoManutencao.Location = new System.Drawing.Point(6, 16);
            this.cBoxTipoManutencao.Name = "cBoxTipoManutencao";
            this.cBoxTipoManutencao.Size = new System.Drawing.Size(651, 22);
            this.cBoxTipoManutencao.TabIndex = 185;
            // 
            // gBoxFuncionario
            // 
            this.gBoxFuncionario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.gBoxFuncionario.Controls.Add(this.cBoxFuncionario);
            this.gBoxFuncionario.Controls.Add(this.gBoxUsuario);
            this.gBoxFuncionario.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.gBoxFuncionario.Location = new System.Drawing.Point(349, 70);
            this.gBoxFuncionario.Name = "gBoxFuncionario";
            this.gBoxFuncionario.Size = new System.Drawing.Size(663, 46);
            this.gBoxFuncionario.TabIndex = 193;
            this.gBoxFuncionario.TabStop = false;
            this.gBoxFuncionario.Text = "Funcionário que fez o serviço";
            // 
            // cBoxFuncionario
            // 
            this.cBoxFuncionario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxFuncionario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxFuncionario.Font = new System.Drawing.Font("Calibri", 9F);
            this.cBoxFuncionario.FormattingEnabled = true;
            this.cBoxFuncionario.Location = new System.Drawing.Point(6, 16);
            this.cBoxFuncionario.Name = "cBoxFuncionario";
            this.cBoxFuncionario.Size = new System.Drawing.Size(651, 22);
            this.cBoxFuncionario.TabIndex = 185;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnBuscar);
            this.panel3.Controls.Add(this.gBoxLocalManutencao);
            this.panel3.Controls.Add(this.gBoxFuncionario);
            this.panel3.Controls.Add(this.gBoxTipoManutencao);
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.gBoxDataManutencao);
            this.panel3.Controls.Add(this.gBoxVeiculo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1166, 119);
            this.panel3.TabIndex = 201;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnBuscar.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Appearance.Options.UseFont = true;
            this.btnBuscar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnBuscar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBuscar.ImageOptions.SvgImage")));
            this.btnBuscar.Location = new System.Drawing.Point(1018, 18);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(144, 98);
            this.btnBuscar.TabIndex = 209;
            this.btnBuscar.Text = "[F5] - Consultar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // id_manutencao
            // 
            this.id_manutencao.DataPropertyName = "id_manutencao";
            this.id_manutencao.FillWeight = 0.5094286F;
            this.id_manutencao.HeaderText = "";
            this.id_manutencao.MinimumWidth = 2;
            this.id_manutencao.Name = "id_manutencao";
            this.id_manutencao.ReadOnly = true;
            this.id_manutencao.Visible = false;
            // 
            // data_manutencao
            // 
            this.data_manutencao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.data_manutencao.DataPropertyName = "data_manutencao";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.data_manutencao.DefaultCellStyle = dataGridViewCellStyle2;
            this.data_manutencao.FillWeight = 40.75429F;
            this.data_manutencao.HeaderText = "Data da Manutenção";
            this.data_manutencao.Name = "data_manutencao";
            this.data_manutencao.ReadOnly = true;
            this.data_manutencao.Width = 128;
            // 
            // id_veiculo
            // 
            this.id_veiculo.DataPropertyName = "id_veiculo";
            this.id_veiculo.HeaderText = "id_veiculo";
            this.id_veiculo.Name = "id_veiculo";
            this.id_veiculo.ReadOnly = true;
            this.id_veiculo.Visible = false;
            // 
            // placa
            // 
            this.placa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.placa.DataPropertyName = "placa";
            this.placa.HeaderText = "Placa";
            this.placa.Name = "placa";
            this.placa.ReadOnly = true;
            this.placa.Width = 58;
            // 
            // veiculo
            // 
            this.veiculo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.veiculo.DataPropertyName = "veiculo";
            this.veiculo.FillWeight = 66.22572F;
            this.veiculo.HeaderText = "Veículo";
            this.veiculo.Name = "veiculo";
            this.veiculo.ReadOnly = true;
            this.veiculo.Width = 69;
            // 
            // km_veiculo
            // 
            this.km_veiculo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.km_veiculo.DataPropertyName = "km_veiculo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.km_veiculo.DefaultCellStyle = dataGridViewCellStyle3;
            this.km_veiculo.FillWeight = 50F;
            this.km_veiculo.HeaderText = "Km da Manutenção";
            this.km_veiculo.Name = "km_veiculo";
            this.km_veiculo.ReadOnly = true;
            this.km_veiculo.Width = 120;
            // 
            // km_atual
            // 
            this.km_atual.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.km_atual.DataPropertyName = "km_atual";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.km_atual.DefaultCellStyle = dataGridViewCellStyle4;
            this.km_atual.HeaderText = "Km Atual";
            this.km_atual.Name = "km_atual";
            this.km_atual.ReadOnly = true;
            this.km_atual.Width = 71;
            // 
            // km_rodado
            // 
            this.km_rodado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.km_rodado.DataPropertyName = "km_rodado";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.km_rodado.DefaultCellStyle = dataGridViewCellStyle5;
            this.km_rodado.HeaderText = "Km Rodado";
            this.km_rodado.Name = "km_rodado";
            this.km_rodado.ReadOnly = true;
            this.km_rodado.Width = 84;
            // 
            // descricao_tipo_manutencao
            // 
            this.descricao_tipo_manutencao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descricao_tipo_manutencao.DataPropertyName = "descricao_tipo_manutencao";
            this.descricao_tipo_manutencao.FillWeight = 127.3572F;
            this.descricao_tipo_manutencao.HeaderText = "Tipo da Manutenção";
            this.descricao_tipo_manutencao.Name = "descricao_tipo_manutencao";
            this.descricao_tipo_manutencao.ReadOnly = true;
            // 
            // descricao_local_manutencao
            // 
            this.descricao_local_manutencao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.descricao_local_manutencao.DataPropertyName = "descricao_local_manutencao";
            this.descricao_local_manutencao.FillWeight = 91.69715F;
            this.descricao_local_manutencao.HeaderText = "Local da Manutenção";
            this.descricao_local_manutencao.Name = "descricao_local_manutencao";
            this.descricao_local_manutencao.ReadOnly = true;
            this.descricao_local_manutencao.Width = 130;
            // 
            // qra
            // 
            this.qra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.qra.DataPropertyName = "qra";
            this.qra.FillWeight = 76.41429F;
            this.qra.HeaderText = "Funcionário";
            this.qra.Name = "qra";
            this.qra.ReadOnly = true;
            this.qra.Width = 94;
            // 
            // situacao
            // 
            this.situacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.situacao.DataPropertyName = "situacao";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.situacao.DefaultCellStyle = dataGridViewCellStyle6;
            this.situacao.HeaderText = "Situação";
            this.situacao.Name = "situacao";
            this.situacao.ReadOnly = true;
            this.situacao.Width = 76;
            // 
            // valor_total_manutencao
            // 
            this.valor_total_manutencao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.valor_total_manutencao.DataPropertyName = "valor_total";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "C2";
            dataGridViewCellStyle7.NullValue = null;
            this.valor_total_manutencao.DefaultCellStyle = dataGridViewCellStyle7;
            this.valor_total_manutencao.HeaderText = "Valor da Manutenção";
            this.valor_total_manutencao.Name = "valor_total_manutencao";
            this.valor_total_manutencao.ReadOnly = true;
            this.valor_total_manutencao.Width = 130;
            // 
            // frmManutencaoConsultar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 430);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "frmManutencaoConsultar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manutenções Realizadas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmManutencaoConsultar_FormClosing);
            this.Load += new System.EventHandler(this.frmManutencaoConsultar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmManutencaoConsultar_KeyDown);
            this.gBoxUsuario.ResumeLayout(false);
            this.gBoxLocalManutencao.ResumeLayout(false);
            this.gBoxDataManutencao.ResumeLayout(false);
            this.gBoxDataManutencao.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGridManutencoes)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.gBoxVeiculo.ResumeLayout(false);
            this.gBoxTipoManutencao.ResumeLayout(false);
            this.gBoxFuncionario.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gBoxUsuario;
        private System.Windows.Forms.ComboBox cBoxUsuario;
        private System.Windows.Forms.GroupBox gBoxDataManutencao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cBoxSituacao;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox tBoxQtdRegistros;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tBoxValorTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cBoxTipoBusca;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dGridManutencoes;
        private System.Windows.Forms.ComboBox cBoxVeiculo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gBoxVeiculo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox gBoxLocalManutencao;
        private System.Windows.Forms.ComboBox cBoxLocalManutencao;
        private System.Windows.Forms.GroupBox gBoxFuncionario;
        private System.Windows.Forms.ComboBox cBoxFuncionario;
        private System.Windows.Forms.GroupBox gBoxTipoManutencao;
        private System.Windows.Forms.ComboBox cBoxTipoManutencao;
        private System.Windows.Forms.DateTimePicker tBoxDataFinal;
        private System.Windows.Forms.DateTimePicker tBoxDataInicial;
        private DevExpress.XtraEditors.SimpleButton btnVisualizar;
        private DevExpress.XtraEditors.SimpleButton btnExcluir;
        private DevExpress.XtraEditors.SimpleButton btnImprimirConsulta;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_manutencao;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_manutencao;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_veiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn placa;
        private System.Windows.Forms.DataGridViewTextBoxColumn veiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn km_veiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn km_atual;
        private System.Windows.Forms.DataGridViewTextBoxColumn km_rodado;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao_tipo_manutencao;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao_local_manutencao;
        private System.Windows.Forms.DataGridViewTextBoxColumn qra;
        private System.Windows.Forms.DataGridViewTextBoxColumn situacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor_total_manutencao;
    }
}