
namespace Servipol.Forms.Manutenção_de_Veículos.Cadastros
{
    partial class frmVeiculosConsultar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVeiculosConsultar));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cBoxSituacao = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cBoxTipoBusca = new System.Windows.Forms.ComboBox();
            this.dGridVeiculos = new System.Windows.Forms.DataGridView();
            this.auxIdUsuarioLogado = new System.Windows.Forms.Label();
            this.gbTipoVeiculoBusca = new System.Windows.Forms.GroupBox();
            this.cBoxTipoVeiculo = new System.Windows.Forms.ComboBox();
            this.btnIncluir = new DevExpress.XtraEditors.SimpleButton();
            this.btnExcluir = new DevExpress.XtraEditors.SimpleButton();
            this.btnEditar = new DevExpress.XtraEditors.SimpleButton();
            this.btnPesquisar = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.id_veiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_veiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo_veiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.placa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao_veiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.combustivel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridVeiculos)).BeginInit();
            this.gbTipoVeiculoBusca.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cBoxSituacao);
            this.groupBox4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(224, 52);
            this.groupBox4.TabIndex = 166;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Situação";
            // 
            // cBoxSituacao
            // 
            this.cBoxSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxSituacao.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxSituacao.FormattingEnabled = true;
            this.cBoxSituacao.Items.AddRange(new object[] {
            "Ativos",
            "Inativos"});
            this.cBoxSituacao.Location = new System.Drawing.Point(6, 22);
            this.cBoxSituacao.Name = "cBoxSituacao";
            this.cBoxSituacao.Size = new System.Drawing.Size(212, 22);
            this.cBoxSituacao.TabIndex = 117;
            this.cBoxSituacao.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cBoxTipoBusca);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(224, 52);
            this.groupBox2.TabIndex = 159;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Buscar Por";
            // 
            // cBoxTipoBusca
            // 
            this.cBoxTipoBusca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxTipoBusca.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxTipoBusca.FormattingEnabled = true;
            this.cBoxTipoBusca.Items.AddRange(new object[] {
            "Mostrar Todos",
            "Tipo de Veículo"});
            this.cBoxTipoBusca.Location = new System.Drawing.Point(6, 22);
            this.cBoxTipoBusca.Name = "cBoxTipoBusca";
            this.cBoxTipoBusca.Size = new System.Drawing.Size(212, 22);
            this.cBoxTipoBusca.TabIndex = 1;
            this.cBoxTipoBusca.SelectedIndexChanged += new System.EventHandler(this.cBoxTipoBusca_SelectedIndexChanged);
            // 
            // dGridVeiculos
            // 
            this.dGridVeiculos.AllowUserToAddRows = false;
            this.dGridVeiculos.AllowUserToDeleteRows = false;
            this.dGridVeiculos.AllowUserToResizeColumns = false;
            this.dGridVeiculos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.dGridVeiculos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dGridVeiculos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGridVeiculos.BackgroundColor = System.Drawing.Color.White;
            this.dGridVeiculos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dGridVeiculos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGridVeiculos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_veiculo,
            this.tipo_veiculo,
            this.codigo_veiculo,
            this.placa,
            this.descricao_veiculo,
            this.combustivel,
            this.ativo});
            this.dGridVeiculos.Location = new System.Drawing.Point(0, 140);
            this.dGridVeiculos.MultiSelect = false;
            this.dGridVeiculos.Name = "dGridVeiculos";
            this.dGridVeiculos.ReadOnly = true;
            this.dGridVeiculos.RowHeadersVisible = false;
            this.dGridVeiculos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dGridVeiculos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGridVeiculos.Size = new System.Drawing.Size(1006, 304);
            this.dGridVeiculos.TabIndex = 165;
            // 
            // auxIdUsuarioLogado
            // 
            this.auxIdUsuarioLogado.AutoSize = true;
            this.auxIdUsuarioLogado.Location = new System.Drawing.Point(1130, 495);
            this.auxIdUsuarioLogado.Name = "auxIdUsuarioLogado";
            this.auxIdUsuarioLogado.Size = new System.Drawing.Size(0, 13);
            this.auxIdUsuarioLogado.TabIndex = 167;
            // 
            // gbTipoVeiculoBusca
            // 
            this.gbTipoVeiculoBusca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTipoVeiculoBusca.Controls.Add(this.cBoxTipoVeiculo);
            this.gbTipoVeiculoBusca.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTipoVeiculoBusca.Location = new System.Drawing.Point(242, 70);
            this.gbTipoVeiculoBusca.Name = "gbTipoVeiculoBusca";
            this.gbTipoVeiculoBusca.Size = new System.Drawing.Size(585, 52);
            this.gbTipoVeiculoBusca.TabIndex = 171;
            this.gbTipoVeiculoBusca.TabStop = false;
            this.gbTipoVeiculoBusca.Text = "Tipo";
            // 
            // cBoxTipoVeiculo
            // 
            this.cBoxTipoVeiculo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxTipoVeiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxTipoVeiculo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxTipoVeiculo.FormattingEnabled = true;
            this.cBoxTipoVeiculo.Location = new System.Drawing.Point(6, 22);
            this.cBoxTipoVeiculo.Name = "cBoxTipoVeiculo";
            this.cBoxTipoVeiculo.Size = new System.Drawing.Size(573, 22);
            this.cBoxTipoVeiculo.TabIndex = 118;
            this.cBoxTipoVeiculo.SelectedIndexChanged += new System.EventHandler(this.cBoxTipoVeiculo_SelectedIndexChanged);
            // 
            // btnIncluir
            // 
            this.btnIncluir.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnIncluir.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncluir.Appearance.Options.UseFont = true;
            this.btnIncluir.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnIncluir.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnIncluir.ImageOptions.SvgImage")));
            this.btnIncluir.Location = new System.Drawing.Point(833, 3);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(170, 44);
            this.btnIncluir.TabIndex = 182;
            this.btnIncluir.Text = "[F4] - Incluir";
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnExcluir.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Appearance.Options.UseFont = true;
            this.btnExcluir.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnExcluir.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnExcluir.ImageOptions.SvgImage")));
            this.btnExcluir.Location = new System.Drawing.Point(481, 3);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(170, 44);
            this.btnExcluir.TabIndex = 183;
            this.btnExcluir.Text = "[Del] - Excluir";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnEditar.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Appearance.Options.UseFont = true;
            this.btnEditar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnEditar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEditar.ImageOptions.SvgImage")));
            this.btnEditar.Location = new System.Drawing.Point(657, 3);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(170, 44);
            this.btnEditar.TabIndex = 184;
            this.btnEditar.Text = "[F3] - Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnPesquisar.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.Appearance.Options.UseFont = true;
            this.btnPesquisar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnPesquisar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPesquisar.ImageOptions.SvgImage")));
            this.btnPesquisar.Location = new System.Drawing.Point(833, 78);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(170, 44);
            this.btnPesquisar.TabIndex = 185;
            this.btnPesquisar.Text = "[F5] - Pesquisar";
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPesquisar);
            this.panel1.Controls.Add(this.gbTipoVeiculoBusca);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1006, 134);
            this.panel1.TabIndex = 186;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnExcluir);
            this.panel2.Controls.Add(this.btnIncluir);
            this.panel2.Controls.Add(this.btnEditar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 447);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1006, 50);
            this.panel2.TabIndex = 187;
            // 
            // id_veiculo
            // 
            this.id_veiculo.DataPropertyName = "id_veiculo";
            this.id_veiculo.FillWeight = 1F;
            this.id_veiculo.HeaderText = "";
            this.id_veiculo.MinimumWidth = 2;
            this.id_veiculo.Name = "id_veiculo";
            this.id_veiculo.ReadOnly = true;
            this.id_veiculo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.id_veiculo.Width = 2;
            // 
            // tipo_veiculo
            // 
            this.tipo_veiculo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tipo_veiculo.DataPropertyName = "tipo";
            this.tipo_veiculo.FillWeight = 130F;
            this.tipo_veiculo.HeaderText = "Tipo";
            this.tipo_veiculo.Name = "tipo_veiculo";
            this.tipo_veiculo.ReadOnly = true;
            this.tipo_veiculo.Width = 55;
            // 
            // codigo_veiculo
            // 
            this.codigo_veiculo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.codigo_veiculo.DataPropertyName = "codigo";
            this.codigo_veiculo.HeaderText = "Código";
            this.codigo_veiculo.Name = "codigo_veiculo";
            this.codigo_veiculo.ReadOnly = true;
            this.codigo_veiculo.Width = 70;
            // 
            // placa
            // 
            this.placa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.placa.DataPropertyName = "placa";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.placa.DefaultCellStyle = dataGridViewCellStyle2;
            this.placa.HeaderText = "Placa";
            this.placa.Name = "placa";
            this.placa.ReadOnly = true;
            this.placa.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.placa.Width = 58;
            // 
            // descricao_veiculo
            // 
            this.descricao_veiculo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descricao_veiculo.DataPropertyName = "descricao";
            this.descricao_veiculo.FillWeight = 180F;
            this.descricao_veiculo.HeaderText = "Descrição";
            this.descricao_veiculo.Name = "descricao_veiculo";
            this.descricao_veiculo.ReadOnly = true;
            this.descricao_veiculo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // combustivel
            // 
            this.combustivel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.combustivel.DataPropertyName = "combustivel";
            this.combustivel.HeaderText = "Combustível";
            this.combustivel.Name = "combustivel";
            this.combustivel.ReadOnly = true;
            this.combustivel.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.combustivel.Width = 95;
            // 
            // ativo
            // 
            this.ativo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ativo.DataPropertyName = "ativo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ativo.DefaultCellStyle = dataGridViewCellStyle3;
            this.ativo.HeaderText = "Ativo";
            this.ativo.Name = "ativo";
            this.ativo.ReadOnly = true;
            this.ativo.Width = 58;
            // 
            // frmVeiculosConsultar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 497);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.auxIdUsuarioLogado);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dGridVeiculos);
            this.Controls.Add(this.panel1);
            this.Name = "frmVeiculosConsultar";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Veículos";
            this.Load += new System.EventHandler(this.frmVeiculosConsultar_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGridVeiculos)).EndInit();
            this.gbTipoVeiculoBusca.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cBoxSituacao;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cBoxTipoBusca;
        private System.Windows.Forms.DataGridView dGridVeiculos;
        private System.Windows.Forms.Label auxIdUsuarioLogado;
        private System.Windows.Forms.GroupBox gbTipoVeiculoBusca;
        private System.Windows.Forms.ComboBox cBoxTipoVeiculo;
        private DevExpress.XtraEditors.SimpleButton btnIncluir;
        private DevExpress.XtraEditors.SimpleButton btnExcluir;
        private DevExpress.XtraEditors.SimpleButton btnEditar;
        private DevExpress.XtraEditors.SimpleButton btnPesquisar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_veiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_veiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo_veiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn placa;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao_veiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn combustivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ativo;
    }
}