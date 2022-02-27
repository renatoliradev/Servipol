
namespace Servipol.Forms.Manutenção_de_Veículos.Manutenção
{
    partial class frmProxTrocaOleoRevisao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProxTrocaOleoRevisao));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tBoxInfo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dGrid = new System.Windows.Forms.DataGridView();
            this.btnImprimirConsulta = new DevExpress.XtraEditors.SimpleButton();
            this.id_manutencao_veiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.placa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.veiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_manutencao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.funcionario_ultima_troca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.local_troca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.km_prox_troca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.km_atual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.km_falta_troca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_km_diario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tBoxInfo
            // 
            this.tBoxInfo.BackColor = System.Drawing.SystemColors.Info;
            this.tBoxInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tBoxInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tBoxInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBoxInfo.ForeColor = System.Drawing.Color.Red;
            this.tBoxInfo.Location = new System.Drawing.Point(3, 18);
            this.tBoxInfo.Name = "tBoxInfo";
            this.tBoxInfo.ReadOnly = true;
            this.tBoxInfo.Size = new System.Drawing.Size(1194, 18);
            this.tBoxInfo.TabIndex = 0;
            this.tBoxInfo.TabStop = false;
            this.tBoxInfo.Text = "Os registros em VERMELHO indicam que ainda não foi lançado o KM Diário para o veí" +
    "culo. Verifique!";
            this.tBoxInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tBoxInfo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 416);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1200, 41);
            this.groupBox1.TabIndex = 232;
            this.groupBox1.TabStop = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dGrid);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1200, 369);
            this.groupControl1.TabIndex = 233;
            // 
            // dGrid
            // 
            this.dGrid.AllowUserToAddRows = false;
            this.dGrid.AllowUserToDeleteRows = false;
            this.dGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.dGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGrid.BackgroundColor = System.Drawing.Color.White;
            this.dGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_manutencao_veiculo,
            this.placa,
            this.veiculo,
            this.data_manutencao,
            this.funcionario_ultima_troca,
            this.local_troca,
            this.km_prox_troca,
            this.km_atual,
            this.km_falta_troca,
            this.data_km_diario});
            this.dGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dGrid.Location = new System.Drawing.Point(2, 22);
            this.dGrid.MultiSelect = false;
            this.dGrid.Name = "dGrid";
            this.dGrid.ReadOnly = true;
            this.dGrid.RowHeadersVisible = false;
            this.dGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGrid.Size = new System.Drawing.Size(1196, 345);
            this.dGrid.TabIndex = 226;
            this.dGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGrid_CellDoubleClick);
            this.dGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dGrid_CellFormatting);
            // 
            // btnImprimirConsulta
            // 
            this.btnImprimirConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImprimirConsulta.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimirConsulta.Appearance.Options.UseFont = true;
            this.btnImprimirConsulta.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnImprimirConsulta.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnImprimirConsulta.ImageOptions.SvgImage")));
            this.btnImprimirConsulta.Location = new System.Drawing.Point(2, 375);
            this.btnImprimirConsulta.Name = "btnImprimirConsulta";
            this.btnImprimirConsulta.Size = new System.Drawing.Size(1196, 44);
            this.btnImprimirConsulta.TabIndex = 234;
            this.btnImprimirConsulta.TabStop = false;
            this.btnImprimirConsulta.Text = "[CTRL + P] - Imprimir consulta";
            this.btnImprimirConsulta.Click += new System.EventHandler(this.btnImprimirConsulta_Click);
            // 
            // id_manutencao_veiculo
            // 
            this.id_manutencao_veiculo.DataPropertyName = "id_manutencao_veiculo";
            this.id_manutencao_veiculo.FillWeight = 0.5094286F;
            this.id_manutencao_veiculo.HeaderText = "";
            this.id_manutencao_veiculo.MinimumWidth = 2;
            this.id_manutencao_veiculo.Name = "id_manutencao_veiculo";
            this.id_manutencao_veiculo.ReadOnly = true;
            this.id_manutencao_veiculo.Visible = false;
            // 
            // placa
            // 
            this.placa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.placa.DataPropertyName = "placa";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.placa.DefaultCellStyle = dataGridViewCellStyle2;
            this.placa.HeaderText = "Placa";
            this.placa.Name = "placa";
            this.placa.ReadOnly = true;
            this.placa.Width = 58;
            // 
            // veiculo
            // 
            this.veiculo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.veiculo.DataPropertyName = "veiculo";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.veiculo.DefaultCellStyle = dataGridViewCellStyle3;
            this.veiculo.FillWeight = 66.22572F;
            this.veiculo.HeaderText = "Veículo";
            this.veiculo.Name = "veiculo";
            this.veiculo.ReadOnly = true;
            // 
            // data_manutencao
            // 
            this.data_manutencao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.data_manutencao.DataPropertyName = "data_manutencao";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.data_manutencao.DefaultCellStyle = dataGridViewCellStyle4;
            this.data_manutencao.FillWeight = 40.75429F;
            this.data_manutencao.HeaderText = "Data Última Troca de Óleo";
            this.data_manutencao.Name = "data_manutencao";
            this.data_manutencao.ReadOnly = true;
            this.data_manutencao.Width = 114;
            // 
            // funcionario_ultima_troca
            // 
            this.funcionario_ultima_troca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.funcionario_ultima_troca.DataPropertyName = "funcionario_ultima_troca";
            this.funcionario_ultima_troca.FillWeight = 76.41429F;
            this.funcionario_ultima_troca.HeaderText = "Funcionário Última Troca de Óleo";
            this.funcionario_ultima_troca.Name = "funcionario_ultima_troca";
            this.funcionario_ultima_troca.ReadOnly = true;
            this.funcionario_ultima_troca.Width = 148;
            // 
            // local_troca
            // 
            this.local_troca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.local_troca.DataPropertyName = "local_troca";
            this.local_troca.HeaderText = "Local Última Troca de Óleo";
            this.local_troca.Name = "local_troca";
            this.local_troca.ReadOnly = true;
            this.local_troca.Width = 115;
            // 
            // km_prox_troca
            // 
            this.km_prox_troca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.km_prox_troca.DataPropertyName = "km_prox_troca";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.km_prox_troca.DefaultCellStyle = dataGridViewCellStyle5;
            this.km_prox_troca.FillWeight = 91.69715F;
            this.km_prox_troca.HeaderText = "Km da Próxima Troca de Óleo ( A )";
            this.km_prox_troca.Name = "km_prox_troca";
            this.km_prox_troca.ReadOnly = true;
            this.km_prox_troca.Width = 127;
            // 
            // km_atual
            // 
            this.km_atual.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.km_atual.DataPropertyName = "km_atual";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.km_atual.DefaultCellStyle = dataGridViewCellStyle6;
            this.km_atual.HeaderText = "Km Atual ( B )";
            this.km_atual.Name = "km_atual";
            this.km_atual.ReadOnly = true;
            this.km_atual.ToolTipText = "Km diário informado pelo usuário";
            this.km_atual.Width = 79;
            // 
            // km_falta_troca
            // 
            this.km_falta_troca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.km_falta_troca.DataPropertyName = "km_falta_troca";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle7.Format = "N0";
            this.km_falta_troca.DefaultCellStyle = dataGridViewCellStyle7;
            this.km_falta_troca.HeaderText = "Km falta para Próxima Troca de Óleo ( A - B )";
            this.km_falta_troca.Name = "km_falta_troca";
            this.km_falta_troca.ReadOnly = true;
            this.km_falta_troca.Width = 157;
            // 
            // data_km_diario
            // 
            this.data_km_diario.DataPropertyName = "data_km_diario";
            dataGridViewCellStyle8.Format = "G";
            dataGridViewCellStyle8.NullValue = null;
            this.data_km_diario.DefaultCellStyle = dataGridViewCellStyle8;
            this.data_km_diario.HeaderText = "data_km_diario";
            this.data_km_diario.Name = "data_km_diario";
            this.data_km_diario.ReadOnly = true;
            this.data_km_diario.Visible = false;
            // 
            // frmProxTrocaOleoRevisao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 457);
            this.Controls.Add(this.btnImprimirConsulta);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupControl1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProxTrocaOleoRevisao";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Próxima Troca de Óleo";
            this.Load += new System.EventHandler(this.frmProxTrocaOleoRevisao_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmProxTrocaOleoRevisao_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tBoxInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.DataGridView dGrid;
        private DevExpress.XtraEditors.SimpleButton btnImprimirConsulta;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_manutencao_veiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn placa;
        private System.Windows.Forms.DataGridViewTextBoxColumn veiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_manutencao;
        private System.Windows.Forms.DataGridViewTextBoxColumn funcionario_ultima_troca;
        private System.Windows.Forms.DataGridViewTextBoxColumn local_troca;
        private System.Windows.Forms.DataGridViewTextBoxColumn km_prox_troca;
        private System.Windows.Forms.DataGridViewTextBoxColumn km_atual;
        private System.Windows.Forms.DataGridViewTextBoxColumn km_falta_troca;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_km_diario;
    }
}