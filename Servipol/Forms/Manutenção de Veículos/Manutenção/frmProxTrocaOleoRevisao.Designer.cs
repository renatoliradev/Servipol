
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tBoxInfo = new System.Windows.Forms.TextBox();
            this.data_km_diario1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.km_falta_prox_revisao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.placa_veiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dGridRevisao = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.data_km_diario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.km_falta_troca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.km_atual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.km_prox_troca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.local_troca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.funcionario_ultima_troca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_manutencao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.veiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.placa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_manutencao_veiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dGridRevisao)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tBoxInfo
            // 
            this.tBoxInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tBoxInfo.BackColor = System.Drawing.SystemColors.Info;
            this.tBoxInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tBoxInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBoxInfo.ForeColor = System.Drawing.Color.Red;
            this.tBoxInfo.Location = new System.Drawing.Point(0, 13);
            this.tBoxInfo.Name = "tBoxInfo";
            this.tBoxInfo.ReadOnly = true;
            this.tBoxInfo.Size = new System.Drawing.Size(1196, 18);
            this.tBoxInfo.TabIndex = 0;
            this.tBoxInfo.TabStop = false;
            this.tBoxInfo.Text = "Os registros em VERMELHO indicam que ainda não foi lançado o KM Diário para o veí" +
    "culo. Verifique!";
            this.tBoxInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // data_km_diario1
            // 
            this.data_km_diario1.DataPropertyName = "data_km_diario";
            this.data_km_diario1.HeaderText = "data_km_diario";
            this.data_km_diario1.Name = "data_km_diario1";
            this.data_km_diario1.ReadOnly = true;
            this.data_km_diario1.Visible = false;
            // 
            // km_falta_prox_revisao
            // 
            this.km_falta_prox_revisao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.km_falta_prox_revisao.DataPropertyName = "km_falta_revisao";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.km_falta_prox_revisao.DefaultCellStyle = dataGridViewCellStyle1;
            this.km_falta_prox_revisao.HeaderText = "Km Falta Próxima Revisão";
            this.km_falta_prox_revisao.Name = "km_falta_prox_revisao";
            this.km_falta_prox_revisao.ReadOnly = true;
            this.km_falta_prox_revisao.Width = 146;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "km_atual";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn8.HeaderText = "Km Atual";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 71;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "km_prox_revisao";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn6.HeaderText = "Km Próxima Revisão";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 121;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "local_revisao";
            this.dataGridViewTextBoxColumn5.HeaderText = "Local Última Revisão";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 124;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "funcionario_ultima_revisao";
            this.dataGridViewTextBoxColumn4.FillWeight = 76.41429F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Funcionário Última Revisão";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 122;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "data_ultima_revisao";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn3.FillWeight = 40.75429F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Data Última Revisão";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 123;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "veiculo";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn2.FillWeight = 66.22572F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Veículo";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // placa_veiculo
            // 
            this.placa_veiculo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.placa_veiculo.DataPropertyName = "placa";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.placa_veiculo.DefaultCellStyle = dataGridViewCellStyle6;
            this.placa_veiculo.HeaderText = "Placa";
            this.placa_veiculo.Name = "placa_veiculo";
            this.placa_veiculo.ReadOnly = true;
            this.placa_veiculo.Width = 58;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id_manutencao_veiculo";
            dataGridViewCellStyle7.Format = "G";
            dataGridViewCellStyle7.NullValue = null;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn1.FillWeight = 0.5094286F;
            this.dataGridViewTextBoxColumn1.HeaderText = "";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 2;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dGridRevisao
            // 
            this.dGridRevisao.AllowUserToAddRows = false;
            this.dGridRevisao.AllowUserToDeleteRows = false;
            this.dGridRevisao.AllowUserToResizeRows = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Lavender;
            this.dGridRevisao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dGridRevisao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGridRevisao.BackgroundColor = System.Drawing.Color.White;
            this.dGridRevisao.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dGridRevisao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGridRevisao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.placa_veiculo,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn8,
            this.km_falta_prox_revisao,
            this.data_km_diario1});
            this.dGridRevisao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGridRevisao.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dGridRevisao.Location = new System.Drawing.Point(2, 22);
            this.dGridRevisao.MultiSelect = false;
            this.dGridRevisao.Name = "dGridRevisao";
            this.dGridRevisao.ReadOnly = true;
            this.dGridRevisao.RowHeadersVisible = false;
            this.dGridRevisao.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dGridRevisao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dGridRevisao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGridRevisao.Size = new System.Drawing.Size(1196, 179);
            this.dGridRevisao.TabIndex = 226;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tBoxInfo);
            this.groupBox1.Location = new System.Drawing.Point(2, 306);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1196, 41);
            this.groupBox1.TabIndex = 232;
            this.groupBox1.TabStop = false;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.dGridRevisao);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl2.Location = new System.Drawing.Point(0, 353);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1200, 203);
            this.groupControl2.TabIndex = 234;
            this.groupControl2.Text = "PRÓXIMA REVISÃO";
            // 
            // data_km_diario
            // 
            this.data_km_diario.DataPropertyName = "data_km_diario";
            dataGridViewCellStyle9.Format = "G";
            dataGridViewCellStyle9.NullValue = null;
            this.data_km_diario.DefaultCellStyle = dataGridViewCellStyle9;
            this.data_km_diario.HeaderText = "data_km_diario";
            this.data_km_diario.Name = "data_km_diario";
            this.data_km_diario.ReadOnly = true;
            this.data_km_diario.Visible = false;
            // 
            // km_falta_troca
            // 
            this.km_falta_troca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.km_falta_troca.DataPropertyName = "km_falta_troca";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle10.Format = "N0";
            this.km_falta_troca.DefaultCellStyle = dataGridViewCellStyle10;
            this.km_falta_troca.HeaderText = "Km Falta Próxima Troca de Óleo";
            this.km_falta_troca.Name = "km_falta_troca";
            this.km_falta_troca.ReadOnly = true;
            this.km_falta_troca.Width = 137;
            // 
            // km_atual
            // 
            this.km_atual.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.km_atual.DataPropertyName = "km_atual";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N0";
            dataGridViewCellStyle11.NullValue = null;
            this.km_atual.DefaultCellStyle = dataGridViewCellStyle11;
            this.km_atual.HeaderText = "Km Atual";
            this.km_atual.Name = "km_atual";
            this.km_atual.ReadOnly = true;
            this.km_atual.Width = 71;
            // 
            // km_prox_troca
            // 
            this.km_prox_troca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.km_prox_troca.DataPropertyName = "km_prox_troca";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N0";
            dataGridViewCellStyle12.NullValue = null;
            this.km_prox_troca.DefaultCellStyle = dataGridViewCellStyle12;
            this.km_prox_troca.FillWeight = 91.69715F;
            this.km_prox_troca.HeaderText = "Km Próxima Troca de Óleo";
            this.km_prox_troca.Name = "km_prox_troca";
            this.km_prox_troca.ReadOnly = true;
            this.km_prox_troca.Width = 112;
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
            // data_manutencao
            // 
            this.data_manutencao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.data_manutencao.DataPropertyName = "data_manutencao";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.data_manutencao.DefaultCellStyle = dataGridViewCellStyle13;
            this.data_manutencao.FillWeight = 40.75429F;
            this.data_manutencao.HeaderText = "Data Última Troca de Óleo";
            this.data_manutencao.Name = "data_manutencao";
            this.data_manutencao.ReadOnly = true;
            this.data_manutencao.Width = 114;
            // 
            // veiculo
            // 
            this.veiculo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.veiculo.DataPropertyName = "veiculo";
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.veiculo.DefaultCellStyle = dataGridViewCellStyle14;
            this.veiculo.FillWeight = 66.22572F;
            this.veiculo.HeaderText = "Veículo";
            this.veiculo.Name = "veiculo";
            this.veiculo.ReadOnly = true;
            // 
            // placa
            // 
            this.placa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.placa.DataPropertyName = "placa";
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.placa.DefaultCellStyle = dataGridViewCellStyle15;
            this.placa.HeaderText = "Placa";
            this.placa.Name = "placa";
            this.placa.ReadOnly = true;
            this.placa.Width = 58;
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
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dGrid);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1200, 302);
            this.groupControl1.TabIndex = 233;
            this.groupControl1.Text = "PRÓXIMA TROCA DE ÓLEO";
            // 
            // dGrid
            // 
            this.dGrid.AllowUserToAddRows = false;
            this.dGrid.AllowUserToDeleteRows = false;
            this.dGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.Lavender;
            this.dGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.dGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dGrid.Location = new System.Drawing.Point(2, 22);
            this.dGrid.MultiSelect = false;
            this.dGrid.Name = "dGrid";
            this.dGrid.ReadOnly = true;
            this.dGrid.RowHeadersVisible = false;
            this.dGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGrid.Size = new System.Drawing.Size(1196, 278);
            this.dGrid.TabIndex = 226;
            this.dGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGrid_CellDoubleClick);
            this.dGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dGrid_CellFormatting);
            // 
            // frmProxTrocaOleoRevisao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 556);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupControl2);
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
            this.Load += new System.EventHandler(this.frmProxTrocaOleoRevisao_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmProxTrocaOleoRevisao_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dGridRevisao)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tBoxInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_km_diario1;
        private System.Windows.Forms.DataGridViewTextBoxColumn km_falta_prox_revisao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn placa_veiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridView dGridRevisao;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_km_diario;
        private System.Windows.Forms.DataGridViewTextBoxColumn km_falta_troca;
        private System.Windows.Forms.DataGridViewTextBoxColumn km_atual;
        private System.Windows.Forms.DataGridViewTextBoxColumn km_prox_troca;
        private System.Windows.Forms.DataGridViewTextBoxColumn local_troca;
        private System.Windows.Forms.DataGridViewTextBoxColumn funcionario_ultima_troca;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_manutencao;
        private System.Windows.Forms.DataGridViewTextBoxColumn veiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn placa;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_manutencao_veiculo;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.DataGridView dGrid;
    }
}