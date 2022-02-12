namespace Servipol.Forms.Relatórios.Manutenção_de_Veículos
{
    partial class frmRelManutencaoRealizadaResumo
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
            this.reportViewerResumoManutRealizada = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerResumoManutRealizada
            // 
            this.reportViewerResumoManutRealizada.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerResumoManutRealizada.LocalReport.ReportEmbeddedResource = "Servipol.Forms.Relatorios.RelManutencaoRealizadaResumo.rdlc";
            this.reportViewerResumoManutRealizada.Location = new System.Drawing.Point(0, 0);
            this.reportViewerResumoManutRealizada.Name = "reportViewerResumoManutRealizada";
            this.reportViewerResumoManutRealizada.ServerReport.BearerToken = null;
            this.reportViewerResumoManutRealizada.ShowBackButton = false;
            this.reportViewerResumoManutRealizada.ShowRefreshButton = false;
            this.reportViewerResumoManutRealizada.Size = new System.Drawing.Size(643, 509);
            this.reportViewerResumoManutRealizada.TabIndex = 0;
            // 
            // frmRelManutencaoRealizadaResumo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 509);
            this.Controls.Add(this.reportViewerResumoManutRealizada);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRelManutencaoRealizadaResumo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resumo de manutenções realizadas";
            this.Load += new System.EventHandler(this.frmRelManutencaoRealizadaResumo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerResumoManutRealizada;
    }
}