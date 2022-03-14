
namespace Servipol.Forms.Cadastros.Equipamentos
{
    partial class frmEquipamentosConsultar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEquipamentosConsultar));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dGridEquipamentos = new System.Windows.Forms.DataGridView();
            this.btnImprimirConsulta = new DevExpress.XtraEditors.SimpleButton();
            this.btnIncluir = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnInativar = new DevExpress.XtraEditors.SimpleButton();
            this.btnEditar = new DevExpress.XtraEditors.SimpleButton();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cBoxSituacao = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cBoxTipoBusca = new System.Windows.Forms.ComboBox();
            this.gbConsulta = new System.Windows.Forms.GroupBox();
            this.tBoxTextoConsulta = new System.Windows.Forms.TextBox();
            this.cBoxCategoriaEquipamento = new System.Windows.Forms.ComboBox();
            this.id_equipamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao_categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao_equipamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estoque_atual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preco_venda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridEquipamentos)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbConsulta.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.dGridEquipamentos);
            this.panel4.Location = new System.Drawing.Point(0, 83);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1238, 363);
            this.panel4.TabIndex = 207;
            // 
            // dGridEquipamentos
            // 
            this.dGridEquipamentos.AllowUserToAddRows = false;
            this.dGridEquipamentos.AllowUserToDeleteRows = false;
            this.dGridEquipamentos.AllowUserToResizeColumns = false;
            this.dGridEquipamentos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.dGridEquipamentos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dGridEquipamentos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGridEquipamentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGridEquipamentos.BackgroundColor = System.Drawing.Color.White;
            this.dGridEquipamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGridEquipamentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_equipamento,
            this.codigo,
            this.descricao_categoria,
            this.descricao_equipamento,
            this.estoque_atual,
            this.preco_venda,
            this.ativo});
            this.dGridEquipamentos.Location = new System.Drawing.Point(0, 3);
            this.dGridEquipamentos.MultiSelect = false;
            this.dGridEquipamentos.Name = "dGridEquipamentos";
            this.dGridEquipamentos.ReadOnly = true;
            this.dGridEquipamentos.RowHeadersVisible = false;
            this.dGridEquipamentos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dGridEquipamentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGridEquipamentos.Size = new System.Drawing.Size(1238, 357);
            this.dGridEquipamentos.TabIndex = 0;
            this.dGridEquipamentos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGridEquipamentos_CellDoubleClick);
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
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btnInativar);
            this.panel2.Controls.Add(this.btnImprimirConsulta);
            this.panel2.Controls.Add(this.btnIncluir);
            this.panel2.Controls.Add(this.btnEditar);
            this.panel2.Location = new System.Drawing.Point(0, 452);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1238, 61);
            this.panel2.TabIndex = 206;
            // 
            // btnInativar
            // 
            this.btnInativar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInativar.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInativar.Appearance.Options.UseFont = true;
            this.btnInativar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnInativar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnInativar.ImageOptions.SvgImage")));
            this.btnInativar.Location = new System.Drawing.Point(791, 9);
            this.btnInativar.Name = "btnInativar";
            this.btnInativar.Size = new System.Drawing.Size(144, 44);
            this.btnInativar.TabIndex = 190;
            this.btnInativar.TabStop = false;
            this.btnInativar.Text = "[Del] - Inativar";
            this.btnInativar.Click += new System.EventHandler(this.btnInativar_Click);
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
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnConsultar);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.gbConsulta);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1238, 77);
            this.panel1.TabIndex = 205;
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
            "Descrição",
            "Categoria"});
            this.cBoxTipoBusca.Location = new System.Drawing.Point(6, 22);
            this.cBoxTipoBusca.Name = "cBoxTipoBusca";
            this.cBoxTipoBusca.Size = new System.Drawing.Size(212, 22);
            this.cBoxTipoBusca.TabIndex = 105;
            this.cBoxTipoBusca.TabStop = false;
            this.cBoxTipoBusca.SelectedIndexChanged += new System.EventHandler(this.cBoxTipoBusca_SelectedIndexChanged);
            // 
            // gbConsulta
            // 
            this.gbConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbConsulta.Controls.Add(this.tBoxTextoConsulta);
            this.gbConsulta.Controls.Add(this.cBoxCategoriaEquipamento);
            this.gbConsulta.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbConsulta.Location = new System.Drawing.Point(363, 8);
            this.gbConsulta.Name = "gbConsulta";
            this.gbConsulta.Size = new System.Drawing.Size(722, 52);
            this.gbConsulta.TabIndex = 12;
            this.gbConsulta.TabStop = false;
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
            // cBoxCategoriaEquipamento
            // 
            this.cBoxCategoriaEquipamento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxCategoriaEquipamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxCategoriaEquipamento.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxCategoriaEquipamento.FormattingEnabled = true;
            this.cBoxCategoriaEquipamento.Location = new System.Drawing.Point(6, 22);
            this.cBoxCategoriaEquipamento.Name = "cBoxCategoriaEquipamento";
            this.cBoxCategoriaEquipamento.Size = new System.Drawing.Size(710, 22);
            this.cBoxCategoriaEquipamento.TabIndex = 106;
            this.cBoxCategoriaEquipamento.TabStop = false;
            this.cBoxCategoriaEquipamento.SelectedIndexChanged += new System.EventHandler(this.cBoxCategoriaEquipamento_SelectedIndexChanged);
            // 
            // id_equipamento
            // 
            this.id_equipamento.DataPropertyName = "id_equipamento";
            this.id_equipamento.HeaderText = "";
            this.id_equipamento.Name = "id_equipamento";
            this.id_equipamento.ReadOnly = true;
            this.id_equipamento.Visible = false;
            // 
            // codigo
            // 
            this.codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.codigo.DataPropertyName = "codigo";
            this.codigo.HeaderText = "Código";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            this.codigo.Width = 70;
            // 
            // descricao_categoria
            // 
            this.descricao_categoria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.descricao_categoria.DataPropertyName = "descricao_categoria";
            this.descricao_categoria.HeaderText = "Categoria";
            this.descricao_categoria.Name = "descricao_categoria";
            this.descricao_categoria.ReadOnly = true;
            this.descricao_categoria.Width = 82;
            // 
            // descricao_equipamento
            // 
            this.descricao_equipamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descricao_equipamento.DataPropertyName = "descricao_equipamento";
            this.descricao_equipamento.HeaderText = "Descrição";
            this.descricao_equipamento.Name = "descricao_equipamento";
            this.descricao_equipamento.ReadOnly = true;
            // 
            // estoque_atual
            // 
            this.estoque_atual.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.estoque_atual.DataPropertyName = "estoque_atual";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.estoque_atual.DefaultCellStyle = dataGridViewCellStyle2;
            this.estoque_atual.HeaderText = "Quantidade em Estoque";
            this.estoque_atual.Name = "estoque_atual";
            this.estoque_atual.ReadOnly = true;
            this.estoque_atual.Width = 105;
            // 
            // preco_venda
            // 
            this.preco_venda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.preco_venda.DataPropertyName = "preco_venda";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.preco_venda.DefaultCellStyle = dataGridViewCellStyle3;
            this.preco_venda.HeaderText = "Preço Venda";
            this.preco_venda.Name = "preco_venda";
            this.preco_venda.ReadOnly = true;
            this.preco_venda.Width = 87;
            // 
            // ativo
            // 
            this.ativo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ativo.DataPropertyName = "ativo";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ativo.DefaultCellStyle = dataGridViewCellStyle4;
            this.ativo.HeaderText = "Ativo";
            this.ativo.Name = "ativo";
            this.ativo.ReadOnly = true;
            this.ativo.Width = 58;
            // 
            // frmEquipamentosConsultar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 513);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEquipamentosConsultar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Equipamentos";
            this.Load += new System.EventHandler(this.frmEquipamentosConsultar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmEquipamentosConsultar_KeyDown);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGridEquipamentos)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.gbConsulta.ResumeLayout(false);
            this.gbConsulta.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dGridEquipamentos;
        private DevExpress.XtraEditors.SimpleButton btnImprimirConsulta;
        private DevExpress.XtraEditors.SimpleButton btnIncluir;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btnEditar;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cBoxSituacao;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cBoxTipoBusca;
        private System.Windows.Forms.GroupBox gbConsulta;
        private System.Windows.Forms.TextBox tBoxTextoConsulta;
        private DevExpress.XtraEditors.SimpleButton btnInativar;
        private System.Windows.Forms.ComboBox cBoxCategoriaEquipamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_equipamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao_categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao_equipamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn estoque_atual;
        private System.Windows.Forms.DataGridViewTextBoxColumn preco_venda;
        private System.Windows.Forms.DataGridViewTextBoxColumn ativo;
    }
}