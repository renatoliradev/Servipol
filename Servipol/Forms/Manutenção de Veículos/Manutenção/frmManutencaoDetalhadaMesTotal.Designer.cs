
namespace Servipol.Forms.Manutenção_de_Veículos.Manutenção
{
    partial class frmManutencaoDetalhadaMesTotal
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tBoxQtdRegistros = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tBoxValorTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tBoxVeiculo = new System.Windows.Forms.TextBox();
            this.dGridManutencoes = new System.Windows.Forms.DataGridView();
            this.id_manutencao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_manutencao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridManutencoes)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox6, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dGridManutencoes, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(551, 513);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Info;
            this.panel4.Controls.Add(this.tBoxQtdRegistros);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.tBoxValorTotal);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 490);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(545, 20);
            this.panel4.TabIndex = 200;
            // 
            // tBoxQtdRegistros
            // 
            this.tBoxQtdRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tBoxQtdRegistros.BackColor = System.Drawing.SystemColors.Info;
            this.tBoxQtdRegistros.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tBoxQtdRegistros.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBoxQtdRegistros.ForeColor = System.Drawing.Color.Red;
            this.tBoxQtdRegistros.Location = new System.Drawing.Point(173, 3);
            this.tBoxQtdRegistros.Name = "tBoxQtdRegistros";
            this.tBoxQtdRegistros.ReadOnly = true;
            this.tBoxQtdRegistros.Size = new System.Drawing.Size(39, 18);
            this.tBoxQtdRegistros.TabIndex = 200;
            this.tBoxQtdRegistros.TabStop = false;
            this.tBoxQtdRegistros.Text = "0";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 17);
            this.label4.TabIndex = 199;
            this.label4.Text = "Quantidade de Registros:";
            // 
            // tBoxValorTotal
            // 
            this.tBoxValorTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tBoxValorTotal.BackColor = System.Drawing.SystemColors.Info;
            this.tBoxValorTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tBoxValorTotal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBoxValorTotal.ForeColor = System.Drawing.Color.Red;
            this.tBoxValorTotal.Location = new System.Drawing.Point(447, 2);
            this.tBoxValorTotal.Name = "tBoxValorTotal";
            this.tBoxValorTotal.ReadOnly = true;
            this.tBoxValorTotal.Size = new System.Drawing.Size(95, 18);
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
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(362, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 197;
            this.label3.Text = "Valor Total:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tBoxVeiculo);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(3, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(545, 45);
            this.groupBox6.TabIndex = 195;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Veículo";
            // 
            // tBoxVeiculo
            // 
            this.tBoxVeiculo.BackColor = System.Drawing.Color.White;
            this.tBoxVeiculo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tBoxVeiculo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tBoxVeiculo.Enabled = false;
            this.tBoxVeiculo.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBoxVeiculo.Location = new System.Drawing.Point(3, 19);
            this.tBoxVeiculo.Name = "tBoxVeiculo";
            this.tBoxVeiculo.ReadOnly = true;
            this.tBoxVeiculo.Size = new System.Drawing.Size(539, 24);
            this.tBoxVeiculo.TabIndex = 167;
            this.tBoxVeiculo.TabStop = false;
            // 
            // dGridManutencoes
            // 
            this.dGridManutencoes.AllowUserToAddRows = false;
            this.dGridManutencoes.AllowUserToDeleteRows = false;
            this.dGridManutencoes.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.dGridManutencoes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dGridManutencoes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGridManutencoes.BackgroundColor = System.Drawing.Color.White;
            this.dGridManutencoes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dGridManutencoes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dGridManutencoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGridManutencoes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_manutencao,
            this.data_manutencao,
            this.descricao,
            this.valor_total});
            this.dGridManutencoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGridManutencoes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dGridManutencoes.Location = new System.Drawing.Point(3, 54);
            this.dGridManutencoes.MultiSelect = false;
            this.dGridManutencoes.Name = "dGridManutencoes";
            this.dGridManutencoes.ReadOnly = true;
            this.dGridManutencoes.RowHeadersVisible = false;
            this.dGridManutencoes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dGridManutencoes.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dGridManutencoes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dGridManutencoes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGridManutencoes.Size = new System.Drawing.Size(545, 430);
            this.dGridManutencoes.TabIndex = 196;
            this.dGridManutencoes.TabStop = false;
            this.dGridManutencoes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGridManutencoes_CellDoubleClick);
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
            this.data_manutencao.HeaderText = "Data";
            this.data_manutencao.Name = "data_manutencao";
            this.data_manutencao.ReadOnly = true;
            this.data_manutencao.Width = 56;
            // 
            // descricao
            // 
            this.descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descricao.DataPropertyName = "descricao";
            this.descricao.FillWeight = 127.3572F;
            this.descricao.HeaderText = "Tipo";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            // 
            // valor_total
            // 
            this.valor_total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.valor_total.DataPropertyName = "valor_total";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.valor_total.DefaultCellStyle = dataGridViewCellStyle3;
            this.valor_total.HeaderText = "Valor";
            this.valor_total.Name = "valor_total";
            this.valor_total.ReadOnly = true;
            this.valor_total.Width = 58;
            // 
            // frmManutencaoDetalhadaMesTotal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 513);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManutencaoDetalhadaMesTotal";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manutenções por Veículo no Mês Atual";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmManutencaoDetalhadaMesTotal_FormClosing);
            this.Load += new System.EventHandler(this.frmManutencaoDetalhadaMesTotal_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmManutencaoDetalhadaMesTotal_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridManutencoes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox tBoxQtdRegistros;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tBoxValorTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox tBoxVeiculo;
        private System.Windows.Forms.DataGridView dGridManutencoes;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_manutencao;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_manutencao;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor_total;
    }
}