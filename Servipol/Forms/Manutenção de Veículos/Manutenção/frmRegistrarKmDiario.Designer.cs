
namespace Servipol.Forms.Manutenção_de_Veículos.Manutenção
{
    partial class frmRegistrarKmDiario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistrarKmDiario));
            this.btnFechar = new DevExpress.XtraEditors.SimpleButton();
            this.btnConfirmar = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.labelUltimoKM = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labelPlaca = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelDescricao = new System.Windows.Forms.Label();
            this.gbKmAtual = new System.Windows.Forms.GroupBox();
            this.tBoxKmAtual = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cBoxVeiculo = new System.Windows.Forms.ComboBox();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbKmAtual.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.Appearance.Options.UseFont = true;
            this.btnFechar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnFechar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnFechar.ImageOptions.SvgImage")));
            this.btnFechar.Location = new System.Drawing.Point(2, 285);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(543, 36);
            this.btnFechar.TabIndex = 1005;
            this.btnFechar.TabStop = false;
            this.btnFechar.Text = "[Esc] - Sair";
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Appearance.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.Appearance.Options.UseFont = true;
            this.btnConfirmar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnConfirmar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnConfirmar.ImageOptions.SvgImage")));
            this.btnConfirmar.Location = new System.Drawing.Point(287, 71);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(258, 208);
            this.btnConfirmar.TabIndex = 1001;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.labelUltimoKM);
            this.groupBox6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(2, 210);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(279, 69);
            this.groupBox6.TabIndex = 1004;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Última Data e KM registrados";
            // 
            // labelUltimoKM
            // 
            this.labelUltimoKM.AutoSize = true;
            this.labelUltimoKM.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUltimoKM.Location = new System.Drawing.Point(7, 27);
            this.labelUltimoKM.Name = "labelUltimoKM";
            this.labelUltimoKM.Size = new System.Drawing.Size(0, 23);
            this.labelUltimoKM.TabIndex = 161;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labelPlaca);
            this.groupBox4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(2, 139);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(279, 65);
            this.groupBox4.TabIndex = 1003;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Placa";
            // 
            // labelPlaca
            // 
            this.labelPlaca.AutoSize = true;
            this.labelPlaca.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlaca.Location = new System.Drawing.Point(6, 27);
            this.labelPlaca.Name = "labelPlaca";
            this.labelPlaca.Size = new System.Drawing.Size(0, 23);
            this.labelPlaca.TabIndex = 165;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelDescricao);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(2, 71);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(279, 62);
            this.groupBox3.TabIndex = 1002;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Descrição";
            // 
            // labelDescricao
            // 
            this.labelDescricao.AutoSize = true;
            this.labelDescricao.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescricao.Location = new System.Drawing.Point(6, 27);
            this.labelDescricao.Name = "labelDescricao";
            this.labelDescricao.Size = new System.Drawing.Size(0, 23);
            this.labelDescricao.TabIndex = 163;
            // 
            // gbKmAtual
            // 
            this.gbKmAtual.Controls.Add(this.tBoxKmAtual);
            this.gbKmAtual.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbKmAtual.Location = new System.Drawing.Point(287, 3);
            this.gbKmAtual.Name = "gbKmAtual";
            this.gbKmAtual.Size = new System.Drawing.Size(258, 62);
            this.gbKmAtual.TabIndex = 1000;
            this.gbKmAtual.TabStop = false;
            this.gbKmAtual.Text = "KM Atual*";
            // 
            // tBoxKmAtual
            // 
            this.tBoxKmAtual.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tBoxKmAtual.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBoxKmAtual.ForeColor = System.Drawing.Color.Red;
            this.tBoxKmAtual.Location = new System.Drawing.Point(6, 22);
            this.tBoxKmAtual.MaxLength = 8;
            this.tBoxKmAtual.Name = "tBoxKmAtual";
            this.tBoxKmAtual.Size = new System.Drawing.Size(244, 23);
            this.tBoxKmAtual.TabIndex = 1;
            this.tBoxKmAtual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tBoxKmAtual.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBoxKmAtual_KeyDown);
            this.tBoxKmAtual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBoxKmAtual_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cBoxVeiculo);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(2, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(279, 62);
            this.groupBox2.TabIndex = 999;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Veículo*";
            // 
            // cBoxVeiculo
            // 
            this.cBoxVeiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxVeiculo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cBoxVeiculo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxVeiculo.FormattingEnabled = true;
            this.cBoxVeiculo.Items.AddRange(new object[] {
            "CARRO 1",
            "MOTO 6",
            "MOTO 8"});
            this.cBoxVeiculo.Location = new System.Drawing.Point(6, 22);
            this.cBoxVeiculo.Name = "cBoxVeiculo";
            this.cBoxVeiculo.Size = new System.Drawing.Size(265, 23);
            this.cBoxVeiculo.TabIndex = 1;
            this.cBoxVeiculo.SelectedIndexChanged += new System.EventHandler(this.cBoxVeiculo_SelectedIndexChanged);
            this.cBoxVeiculo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cBoxVeiculo_KeyDown);
            // 
            // frmRegistrarKmDiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 324);
            this.ControlBox = false;
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gbKmAtual);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MdiChildCaptionFormatString = "{0} - {1}";
            this.MinimizeBox = false;
            this.Name = "frmRegistrarKmDiario";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Km Diário";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRegistrarKmDiario_FormClosing);
            this.Load += new System.EventHandler(this.frmRegistrarKmDiario_Load);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbKmAtual.ResumeLayout(false);
            this.gbKmAtual.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnFechar;
        private DevExpress.XtraEditors.SimpleButton btnConfirmar;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label labelUltimoKM;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label labelPlaca;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labelDescricao;
        private System.Windows.Forms.GroupBox gbKmAtual;
        private System.Windows.Forms.TextBox tBoxKmAtual;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cBoxVeiculo;
    }
}