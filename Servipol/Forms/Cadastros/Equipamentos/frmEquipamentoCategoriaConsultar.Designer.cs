
namespace Servipol.Forms.Cadastros.Equipamentos
{
    partial class frmEquipamentoCategoriaConsultar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEquipamentoCategoriaConsultar));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tBoxTextoConsulta = new System.Windows.Forms.TextBox();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cBoxSituacao = new System.Windows.Forms.ComboBox();
            this.cBoxTipoBusca = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gbConsulta = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnInativar = new DevExpress.XtraEditors.SimpleButton();
            this.btnEditar = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnIncluir = new DevExpress.XtraEditors.SimpleButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dGridCategoriaEquipamentos = new System.Windows.Forms.DataGridView();
            this.id_equipamento_categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbConsulta.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridCategoriaEquipamentos)).BeginInit();
            this.SuspendLayout();
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
            // cBoxTipoBusca
            // 
            this.cBoxTipoBusca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxTipoBusca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxTipoBusca.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxTipoBusca.FormattingEnabled = true;
            this.cBoxTipoBusca.Items.AddRange(new object[] {
            "Todos",
            "Descrição"});
            this.cBoxTipoBusca.Location = new System.Drawing.Point(6, 22);
            this.cBoxTipoBusca.Name = "cBoxTipoBusca";
            this.cBoxTipoBusca.Size = new System.Drawing.Size(212, 22);
            this.cBoxTipoBusca.TabIndex = 105;
            this.cBoxTipoBusca.TabStop = false;
            this.cBoxTipoBusca.SelectedIndexChanged += new System.EventHandler(this.cBoxTipoBusca_SelectedIndexChanged);
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
            // gbConsulta
            // 
            this.gbConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbConsulta.Controls.Add(this.tBoxTextoConsulta);
            this.gbConsulta.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbConsulta.Location = new System.Drawing.Point(363, 8);
            this.gbConsulta.Name = "gbConsulta";
            this.gbConsulta.Size = new System.Drawing.Size(722, 52);
            this.gbConsulta.TabIndex = 12;
            this.gbConsulta.TabStop = false;
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
            this.panel1.Size = new System.Drawing.Size(1238, 76);
            this.panel1.TabIndex = 208;
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
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btnInativar);
            this.panel2.Controls.Add(this.btnIncluir);
            this.panel2.Controls.Add(this.btnEditar);
            this.panel2.Location = new System.Drawing.Point(0, 452);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1238, 61);
            this.panel2.TabIndex = 209;
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
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.dGridCategoriaEquipamentos);
            this.panel4.Location = new System.Drawing.Point(0, 75);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1238, 363);
            this.panel4.TabIndex = 210;
            // 
            // dGridCategoriaEquipamentos
            // 
            this.dGridCategoriaEquipamentos.AllowUserToAddRows = false;
            this.dGridCategoriaEquipamentos.AllowUserToDeleteRows = false;
            this.dGridCategoriaEquipamentos.AllowUserToResizeColumns = false;
            this.dGridCategoriaEquipamentos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.dGridCategoriaEquipamentos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dGridCategoriaEquipamentos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGridCategoriaEquipamentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGridCategoriaEquipamentos.BackgroundColor = System.Drawing.Color.White;
            this.dGridCategoriaEquipamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGridCategoriaEquipamentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_equipamento_categoria,
            this.descricao,
            this.ativo});
            this.dGridCategoriaEquipamentos.Location = new System.Drawing.Point(0, 3);
            this.dGridCategoriaEquipamentos.MultiSelect = false;
            this.dGridCategoriaEquipamentos.Name = "dGridCategoriaEquipamentos";
            this.dGridCategoriaEquipamentos.ReadOnly = true;
            this.dGridCategoriaEquipamentos.RowHeadersVisible = false;
            this.dGridCategoriaEquipamentos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dGridCategoriaEquipamentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGridCategoriaEquipamentos.Size = new System.Drawing.Size(1238, 357);
            this.dGridCategoriaEquipamentos.TabIndex = 0;
            this.dGridCategoriaEquipamentos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGridCategoriaEquipamentos_CellDoubleClick);
            // 
            // id_equipamento_categoria
            // 
            this.id_equipamento_categoria.DataPropertyName = "id_equipamento_categoria";
            this.id_equipamento_categoria.HeaderText = "";
            this.id_equipamento_categoria.Name = "id_equipamento_categoria";
            this.id_equipamento_categoria.ReadOnly = true;
            this.id_equipamento_categoria.Visible = false;
            // 
            // descricao
            // 
            this.descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            // 
            // ativo
            // 
            this.ativo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ativo.DataPropertyName = "ativo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ativo.DefaultCellStyle = dataGridViewCellStyle2;
            this.ativo.HeaderText = "Ativo";
            this.ativo.Name = "ativo";
            this.ativo.ReadOnly = true;
            this.ativo.Width = 58;
            // 
            // frmEquipamentoCategoriaConsultar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 513);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEquipamentoCategoriaConsultar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Categoria de Equipamento";
            this.Load += new System.EventHandler(this.frmEquipamentoCategoriaConsultar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmEquipamentoCategoriaConsultar_KeyDown);
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.gbConsulta.ResumeLayout(false);
            this.gbConsulta.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGridCategoriaEquipamentos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox tBoxTextoConsulta;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cBoxSituacao;
        private System.Windows.Forms.ComboBox cBoxTipoBusca;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gbConsulta;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnInativar;
        private DevExpress.XtraEditors.SimpleButton btnEditar;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btnIncluir;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dGridCategoriaEquipamentos;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_equipamento_categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn ativo;
    }
}