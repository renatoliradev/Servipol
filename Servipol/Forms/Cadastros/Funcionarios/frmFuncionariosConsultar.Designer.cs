
namespace Servipol.Forms.Cadastros.Funcionários
{
    partial class frmFuncionariosConsultar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFuncionariosConsultar));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cBoxSituacao = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tBoxTextoConsulta = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cBoxTipoBusca = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.dGridFuncionarios = new System.Windows.Forms.DataGridView();
            this.id_funcionario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao_funcionario_cargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_admissao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo_ase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_sanguineo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefone_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefone_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefone_3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefone_4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnVisualizar = new DevExpress.XtraEditors.SimpleButton();
            this.btnImprimirConsulta = new DevExpress.XtraEditors.SimpleButton();
            this.btnIncluir = new DevExpress.XtraEditors.SimpleButton();
            this.btnEditar = new DevExpress.XtraEditors.SimpleButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridFuncionarios)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cBoxSituacao);
            this.groupBox4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(12, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(115, 52);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Situação";
            // 
            // cBoxSituacao
            // 
            this.cBoxSituacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxSituacao.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxSituacao.FormattingEnabled = true;
            this.cBoxSituacao.Items.AddRange(new object[] {
            "Ativos",
            "Inativos"});
            this.cBoxSituacao.Location = new System.Drawing.Point(6, 22);
            this.cBoxSituacao.Name = "cBoxSituacao";
            this.cBoxSituacao.Size = new System.Drawing.Size(103, 22);
            this.cBoxSituacao.TabIndex = 117;
            this.cBoxSituacao.TabStop = false;
            this.cBoxSituacao.SelectedIndexChanged += new System.EventHandler(this.cBoxSituacao_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.tBoxTextoConsulta);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(363, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(722, 52);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            // 
            // tBoxTextoConsulta
            // 
            this.tBoxTextoConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tBoxTextoConsulta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tBoxTextoConsulta.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBoxTextoConsulta.Location = new System.Drawing.Point(6, 22);
            this.tBoxTextoConsulta.Name = "tBoxTextoConsulta";
            this.tBoxTextoConsulta.Size = new System.Drawing.Size(710, 22);
            this.tBoxTextoConsulta.TabIndex = 106;
            this.tBoxTextoConsulta.TabStop = false;
            this.tBoxTextoConsulta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBoxTextoConsulta_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cBoxTipoBusca);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(133, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(224, 52);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Consultar Por";
            // 
            // cBoxTipoBusca
            // 
            this.cBoxTipoBusca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxTipoBusca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxTipoBusca.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxTipoBusca.FormattingEnabled = true;
            this.cBoxTipoBusca.Items.AddRange(new object[] {
            "Todos",
            "Nome"});
            this.cBoxTipoBusca.Location = new System.Drawing.Point(6, 22);
            this.cBoxTipoBusca.Name = "cBoxTipoBusca";
            this.cBoxTipoBusca.Size = new System.Drawing.Size(212, 22);
            this.cBoxTipoBusca.TabIndex = 105;
            this.cBoxTipoBusca.TabStop = false;
            this.cBoxTipoBusca.SelectedIndexChanged += new System.EventHandler(this.cBoxTipoBusca_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnConsultar);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1238, 77);
            this.panel1.TabIndex = 135;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConsultar.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultar.Appearance.Options.UseFont = true;
            this.btnConsultar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnConsultar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnConsultar.ImageOptions.SvgImage")));
            this.btnConsultar.Location = new System.Drawing.Point(1091, 14);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(144, 44);
            this.btnConsultar.TabIndex = 3;
            this.btnConsultar.Text = "[F5] - Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // dGridFuncionarios
            // 
            this.dGridFuncionarios.AllowUserToAddRows = false;
            this.dGridFuncionarios.AllowUserToDeleteRows = false;
            this.dGridFuncionarios.AllowUserToResizeColumns = false;
            this.dGridFuncionarios.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.dGridFuncionarios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dGridFuncionarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGridFuncionarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGridFuncionarios.BackgroundColor = System.Drawing.Color.White;
            this.dGridFuncionarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGridFuncionarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_funcionario,
            this.descricao_funcionario_cargo,
            this.data_admissao,
            this.codigo_ase,
            this.nome,
            this.tipo_sanguineo,
            this.telefone_1,
            this.telefone_2,
            this.telefone_3,
            this.telefone_4,
            this.ativo});
            this.dGridFuncionarios.Location = new System.Drawing.Point(0, 3);
            this.dGridFuncionarios.MultiSelect = false;
            this.dGridFuncionarios.Name = "dGridFuncionarios";
            this.dGridFuncionarios.ReadOnly = true;
            this.dGridFuncionarios.RowHeadersVisible = false;
            this.dGridFuncionarios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dGridFuncionarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGridFuncionarios.Size = new System.Drawing.Size(1238, 357);
            this.dGridFuncionarios.TabIndex = 0;
            this.dGridFuncionarios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGridFuncionarios_CellDoubleClick);
            // 
            // id_funcionario
            // 
            this.id_funcionario.DataPropertyName = "id_funcionario";
            this.id_funcionario.FillWeight = 1F;
            this.id_funcionario.HeaderText = "ID";
            this.id_funcionario.MinimumWidth = 2;
            this.id_funcionario.Name = "id_funcionario";
            this.id_funcionario.ReadOnly = true;
            this.id_funcionario.Visible = false;
            // 
            // descricao_funcionario_cargo
            // 
            this.descricao_funcionario_cargo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.descricao_funcionario_cargo.DataPropertyName = "descricao_funcionario_cargo";
            this.descricao_funcionario_cargo.HeaderText = "Cargo";
            this.descricao_funcionario_cargo.Name = "descricao_funcionario_cargo";
            this.descricao_funcionario_cargo.ReadOnly = true;
            this.descricao_funcionario_cargo.Width = 63;
            // 
            // data_admissao
            // 
            this.data_admissao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.data_admissao.DataPropertyName = "data_admissao";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.data_admissao.DefaultCellStyle = dataGridViewCellStyle2;
            this.data_admissao.HeaderText = "Data Admissão";
            this.data_admissao.Name = "data_admissao";
            this.data_admissao.ReadOnly = true;
            this.data_admissao.Width = 99;
            // 
            // codigo_ase
            // 
            this.codigo_ase.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.codigo_ase.DataPropertyName = "codigo_ase";
            this.codigo_ase.FillWeight = 80F;
            this.codigo_ase.HeaderText = "Cód. Agente";
            this.codigo_ase.Name = "codigo_ase";
            this.codigo_ase.ReadOnly = true;
            this.codigo_ase.Width = 88;
            // 
            // nome
            // 
            this.nome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nome.DataPropertyName = "nome";
            this.nome.FillWeight = 180F;
            this.nome.HeaderText = "Nome";
            this.nome.Name = "nome";
            this.nome.ReadOnly = true;
            // 
            // tipo_sanguineo
            // 
            this.tipo_sanguineo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tipo_sanguineo.DataPropertyName = "tipo_sanguineo";
            this.tipo_sanguineo.HeaderText = "Tipo Sanguíneo";
            this.tipo_sanguineo.Name = "tipo_sanguineo";
            this.tipo_sanguineo.ReadOnly = true;
            this.tipo_sanguineo.Width = 105;
            // 
            // telefone_1
            // 
            this.telefone_1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.telefone_1.DataPropertyName = "telefone_1";
            this.telefone_1.HeaderText = "Telefone 1";
            this.telefone_1.Name = "telefone_1";
            this.telefone_1.ReadOnly = true;
            this.telefone_1.Width = 78;
            // 
            // telefone_2
            // 
            this.telefone_2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.telefone_2.DataPropertyName = "telefone_2";
            this.telefone_2.HeaderText = "Telefone 2";
            this.telefone_2.Name = "telefone_2";
            this.telefone_2.ReadOnly = true;
            this.telefone_2.Width = 78;
            // 
            // telefone_3
            // 
            this.telefone_3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.telefone_3.DataPropertyName = "telefone_3";
            this.telefone_3.HeaderText = "Telefone 3";
            this.telefone_3.Name = "telefone_3";
            this.telefone_3.ReadOnly = true;
            this.telefone_3.Width = 78;
            // 
            // telefone_4
            // 
            this.telefone_4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.telefone_4.DataPropertyName = "telefone_4";
            this.telefone_4.HeaderText = "Telefone 4";
            this.telefone_4.Name = "telefone_4";
            this.telefone_4.ReadOnly = true;
            this.telefone_4.Width = 78;
            // 
            // ativo
            // 
            this.ativo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ativo.DataPropertyName = "ativo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ativo.DefaultCellStyle = dataGridViewCellStyle3;
            this.ativo.FillWeight = 50F;
            this.ativo.HeaderText = "Ativo";
            this.ativo.Name = "ativo";
            this.ativo.ReadOnly = true;
            this.ativo.Width = 58;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btnVisualizar);
            this.panel2.Controls.Add(this.btnImprimirConsulta);
            this.panel2.Controls.Add(this.btnIncluir);
            this.panel2.Controls.Add(this.btnEditar);
            this.panel2.Location = new System.Drawing.Point(0, 452);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1238, 61);
            this.panel2.TabIndex = 137;
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVisualizar.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVisualizar.Appearance.Options.UseFont = true;
            this.btnVisualizar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnVisualizar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnVisualizar.ImageOptions.SvgImage")));
            this.btnVisualizar.Location = new System.Drawing.Point(791, 9);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(144, 44);
            this.btnVisualizar.TabIndex = 189;
            this.btnVisualizar.TabStop = false;
            this.btnVisualizar.Text = "[F8] - Visualizar";
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // btnImprimirConsulta
            // 
            this.btnImprimirConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImprimirConsulta.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimirConsulta.Appearance.Options.UseFont = true;
            this.btnImprimirConsulta.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnImprimirConsulta.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnImprimirConsulta.ImageOptions.SvgImage")));
            this.btnImprimirConsulta.Location = new System.Drawing.Point(3, 9);
            this.btnImprimirConsulta.Name = "btnImprimirConsulta";
            this.btnImprimirConsulta.Size = new System.Drawing.Size(233, 44);
            this.btnImprimirConsulta.TabIndex = 188;
            this.btnImprimirConsulta.TabStop = false;
            this.btnImprimirConsulta.Text = "[CTRL + P] - Imprimir consulta";
            this.btnImprimirConsulta.Click += new System.EventHandler(this.btnImprimirConsulta_Click);
            // 
            // btnIncluir
            // 
            this.btnIncluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIncluir.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncluir.Appearance.Options.UseFont = true;
            this.btnIncluir.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnIncluir.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnIncluir.ImageOptions.SvgImage")));
            this.btnIncluir.Location = new System.Drawing.Point(1091, 9);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(144, 44);
            this.btnIncluir.TabIndex = 185;
            this.btnIncluir.TabStop = false;
            this.btnIncluir.Text = "[F4] - Incluir";
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Appearance.Options.UseFont = true;
            this.btnEditar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnEditar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEditar.ImageOptions.SvgImage")));
            this.btnEditar.Location = new System.Drawing.Point(941, 9);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(144, 44);
            this.btnEditar.TabIndex = 187;
            this.btnEditar.TabStop = false;
            this.btnEditar.Text = "[F3] - Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.dGridFuncionarios);
            this.panel4.Location = new System.Drawing.Point(0, 83);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1238, 363);
            this.panel4.TabIndex = 204;
            // 
            // frmFuncionariosConsultar
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 513);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFuncionariosConsultar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Funcionários";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.frmFuncionariosConsultar_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFuncionariosConsultar_FormClosing);
            this.Load += new System.EventHandler(this.frmFuncionariosConsultar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmFuncionariosConsultar_KeyDown);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGridFuncionarios)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cBoxSituacao;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tBoxTextoConsulta;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cBoxTipoBusca;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dGridFuncionarios;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btnImprimirConsulta;
        private DevExpress.XtraEditors.SimpleButton btnIncluir;
        private DevExpress.XtraEditors.SimpleButton btnEditar;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private DevExpress.XtraEditors.SimpleButton btnVisualizar;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_funcionario;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao_funcionario_cargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_admissao;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo_ase;
        private System.Windows.Forms.DataGridViewTextBoxColumn nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_sanguineo;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefone_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefone_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefone_3;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefone_4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ativo;
        private System.Windows.Forms.Panel panel4;
    }
}