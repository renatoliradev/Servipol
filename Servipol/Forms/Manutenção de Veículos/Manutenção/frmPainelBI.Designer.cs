
namespace Servipol.Forms.Manutenção_de_Veículos.Manutenção
{
    partial class frmPainelBI
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tBoxValorTotal = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dGridDadosUltimaManutencaoRegistrada = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dGridTotalGastoManutencaoMes = new System.Windows.Forms.DataGridView();
            this.id_manutencao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.veiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_manutencao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.local_manutencao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor_ultima_manutencao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_veiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidade_manutencao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_manutencao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridDadosUltimaManutencaoRegistrada)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridTotalGastoManutencaoMes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, -2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 17);
            this.label1.TabIndex = 197;
            this.label1.Text = "Valor Total gasto no mês atual:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LemonChiffon;
            this.panel1.Controls.Add(this.tBoxValorTotal);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 318);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(358, 18);
            this.panel1.TabIndex = 201;
            // 
            // tBoxValorTotal
            // 
            this.tBoxValorTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tBoxValorTotal.BackColor = System.Drawing.Color.LemonChiffon;
            this.tBoxValorTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tBoxValorTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBoxValorTotal.ForeColor = System.Drawing.Color.Red;
            this.tBoxValorTotal.Location = new System.Drawing.Point(278, -3);
            this.tBoxValorTotal.Name = "tBoxValorTotal";
            this.tBoxValorTotal.ReadOnly = true;
            this.tBoxValorTotal.Size = new System.Drawing.Size(75, 18);
            this.tBoxValorTotal.TabIndex = 198;
            this.tBoxValorTotal.TabStop = false;
            this.tBoxValorTotal.Text = "R$ 0,00";
            this.tBoxValorTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1216, 339);
            this.tableLayoutPanel1.TabIndex = 202;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dGridDadosUltimaManutencaoRegistrada);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(367, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(846, 309);
            this.groupBox3.TabIndex = 131;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dados da última manutenção registrada por veículo";
            // 
            // dGridDadosUltimaManutencaoRegistrada
            // 
            this.dGridDadosUltimaManutencaoRegistrada.AllowUserToAddRows = false;
            this.dGridDadosUltimaManutencaoRegistrada.AllowUserToDeleteRows = false;
            this.dGridDadosUltimaManutencaoRegistrada.AllowUserToResizeColumns = false;
            this.dGridDadosUltimaManutencaoRegistrada.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.dGridDadosUltimaManutencaoRegistrada.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dGridDadosUltimaManutencaoRegistrada.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGridDadosUltimaManutencaoRegistrada.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGridDadosUltimaManutencaoRegistrada.BackgroundColor = System.Drawing.Color.White;
            this.dGridDadosUltimaManutencaoRegistrada.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dGridDadosUltimaManutencaoRegistrada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGridDadosUltimaManutencaoRegistrada.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_manutencao,
            this.veiculo,
            this.data_manutencao,
            this.local_manutencao,
            this.descricao,
            this.valor_ultima_manutencao});
            this.dGridDadosUltimaManutencaoRegistrada.Location = new System.Drawing.Point(6, 22);
            this.dGridDadosUltimaManutencaoRegistrada.MultiSelect = false;
            this.dGridDadosUltimaManutencaoRegistrada.Name = "dGridDadosUltimaManutencaoRegistrada";
            this.dGridDadosUltimaManutencaoRegistrada.ReadOnly = true;
            this.dGridDadosUltimaManutencaoRegistrada.RowHeadersVisible = false;
            this.dGridDadosUltimaManutencaoRegistrada.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGridDadosUltimaManutencaoRegistrada.Size = new System.Drawing.Size(834, 281);
            this.dGridDadosUltimaManutencaoRegistrada.TabIndex = 124;
            this.dGridDadosUltimaManutencaoRegistrada.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGridDadosUltimaManutencaoRegistrada_CellDoubleClick);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LemonChiffon;
            this.panel4.Controls.Add(this.textEdit1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(367, 318);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(846, 18);
            this.panel4.TabIndex = 200;
            // 
            // textEdit1
            // 
            this.textEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEdit1.EditValue = "*** OBS: Duplo clique sobre um registro vai mostrar informações mais detalhadas *" +
    "**";
            this.textEdit1.Enabled = false;
            this.textEdit1.Location = new System.Drawing.Point(0, 0);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            this.textEdit1.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.textEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit1.Properties.Appearance.Options.UseFont = true;
            this.textEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit1.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.textEdit1.Size = new System.Drawing.Size(846, 18);
            this.textEdit1.TabIndex = 0;
            this.textEdit1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dGridTotalGastoManutencaoMes);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(358, 309);
            this.groupBox2.TabIndex = 132;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Total gasto com manutenção por veículo no mês atual";
            // 
            // dGridTotalGastoManutencaoMes
            // 
            this.dGridTotalGastoManutencaoMes.AllowUserToAddRows = false;
            this.dGridTotalGastoManutencaoMes.AllowUserToDeleteRows = false;
            this.dGridTotalGastoManutencaoMes.AllowUserToResizeColumns = false;
            this.dGridTotalGastoManutencaoMes.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Lavender;
            this.dGridTotalGastoManutencaoMes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dGridTotalGastoManutencaoMes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGridTotalGastoManutencaoMes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGridTotalGastoManutencaoMes.BackgroundColor = System.Drawing.Color.White;
            this.dGridTotalGastoManutencaoMes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dGridTotalGastoManutencaoMes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGridTotalGastoManutencaoMes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_veiculo,
            this.dataGridViewTextBoxColumn2,
            this.quantidade_manutencao,
            this.total_manutencao});
            this.dGridTotalGastoManutencaoMes.Location = new System.Drawing.Point(6, 22);
            this.dGridTotalGastoManutencaoMes.MultiSelect = false;
            this.dGridTotalGastoManutencaoMes.Name = "dGridTotalGastoManutencaoMes";
            this.dGridTotalGastoManutencaoMes.ReadOnly = true;
            this.dGridTotalGastoManutencaoMes.RowHeadersVisible = false;
            this.dGridTotalGastoManutencaoMes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dGridTotalGastoManutencaoMes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGridTotalGastoManutencaoMes.Size = new System.Drawing.Size(346, 281);
            this.dGridTotalGastoManutencaoMes.TabIndex = 124;
            this.dGridTotalGastoManutencaoMes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGridTotalGastoManutencaoMes_CellDoubleClick);
            // 
            // id_manutencao
            // 
            this.id_manutencao.DataPropertyName = "id_manutencao";
            this.id_manutencao.HeaderText = "id_manutencao";
            this.id_manutencao.Name = "id_manutencao";
            this.id_manutencao.ReadOnly = true;
            this.id_manutencao.Visible = false;
            // 
            // veiculo
            // 
            this.veiculo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.veiculo.DataPropertyName = "veiculo";
            this.veiculo.HeaderText = "Veículo";
            this.veiculo.Name = "veiculo";
            this.veiculo.ReadOnly = true;
            // 
            // data_manutencao
            // 
            this.data_manutencao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.data_manutencao.DataPropertyName = "data_manutencao";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.data_manutencao.DefaultCellStyle = dataGridViewCellStyle2;
            this.data_manutencao.HeaderText = "Data";
            this.data_manutencao.Name = "data_manutencao";
            this.data_manutencao.ReadOnly = true;
            this.data_manutencao.Width = 58;
            // 
            // local_manutencao
            // 
            this.local_manutencao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.local_manutencao.DataPropertyName = "local_manutencao";
            this.local_manutencao.HeaderText = "Local";
            this.local_manutencao.Name = "local_manutencao";
            this.local_manutencao.ReadOnly = true;
            this.local_manutencao.Width = 60;
            // 
            // descricao
            // 
            this.descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Tipo";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 56;
            // 
            // valor_ultima_manutencao
            // 
            this.valor_ultima_manutencao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.valor_ultima_manutencao.DataPropertyName = "valor_ultima_manutencao";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = "0,00";
            this.valor_ultima_manutencao.DefaultCellStyle = dataGridViewCellStyle3;
            this.valor_ultima_manutencao.HeaderText = "R$";
            this.valor_ultima_manutencao.Name = "valor_ultima_manutencao";
            this.valor_ultima_manutencao.ReadOnly = true;
            this.valor_ultima_manutencao.Width = 45;
            // 
            // id_veiculo
            // 
            this.id_veiculo.DataPropertyName = "id_veiculo";
            this.id_veiculo.HeaderText = "id_veiculo";
            this.id_veiculo.Name = "id_veiculo";
            this.id_veiculo.ReadOnly = true;
            this.id_veiculo.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "veiculo";
            this.dataGridViewTextBoxColumn2.HeaderText = "Veículo";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // quantidade_manutencao
            // 
            this.quantidade_manutencao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.quantidade_manutencao.DataPropertyName = "quantidade_manutencao";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = "0";
            this.quantidade_manutencao.DefaultCellStyle = dataGridViewCellStyle5;
            this.quantidade_manutencao.HeaderText = "Qtd. total";
            this.quantidade_manutencao.Name = "quantidade_manutencao";
            this.quantidade_manutencao.ReadOnly = true;
            this.quantidade_manutencao.Width = 83;
            // 
            // total_manutencao
            // 
            this.total_manutencao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.total_manutencao.DataPropertyName = "total_manutencao";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = "0";
            this.total_manutencao.DefaultCellStyle = dataGridViewCellStyle6;
            this.total_manutencao.HeaderText = "R$ total";
            this.total_manutencao.Name = "total_manutencao";
            this.total_manutencao.ReadOnly = true;
            this.total_manutencao.Width = 74;
            // 
            // frmPainelBI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 339);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPainelBI";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Painel B.I.";
            this.Load += new System.EventHandler(this.frmPainelBI_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGridDadosUltimaManutencaoRegistrada)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGridTotalGastoManutencaoMes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tBoxValorTotal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dGridDadosUltimaManutencaoRegistrada;
        private System.Windows.Forms.Panel panel4;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dGridTotalGastoManutencaoMes;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_manutencao;
        private System.Windows.Forms.DataGridViewTextBoxColumn veiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_manutencao;
        private System.Windows.Forms.DataGridViewTextBoxColumn local_manutencao;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor_ultima_manutencao;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_veiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidade_manutencao;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_manutencao;
    }
}