using System;
using System.Collections.Generic;

namespace Servipol.Forms.Relatorios
{
    public partial class frmRelatorio : DevExpress.XtraEditors.XtraForm
    {
        private frmRelatorio(string path, bool isEmbeddedResource, Dictionary<string, object> dataSources, Dictionary<string, object> reportParameters = null)
        {
            InitializeComponent();

            // path + isEmbeddedResource.
            if (isEmbeddedResource)
                this.reportViewer.LocalReport.ReportEmbeddedResource = path;
            else
                this.reportViewer.LocalReport.ReportPath = path;

            // dataSources.
            foreach (var dataSource in dataSources)
            {
                var reportDataSource = new Microsoft.Reporting.WinForms.ReportDataSource(dataSource.Key, dataSource.Value);
                this.reportViewer.LocalReport.DataSources.Add(reportDataSource);
            }

            // reportParameters.
            if (reportParameters != null)
            {
                var reportParameterCollection = new List<Microsoft.Reporting.WinForms.ReportParameter>();

                foreach (var parameter in reportParameters)
                {
                    var reportParameter = new Microsoft.Reporting.WinForms.ReportParameter(parameter.Key, parameter.Value.ToString());
                    reportParameterCollection.Add(reportParameter);
                }

                this.reportViewer.LocalReport.SetParameters(reportParameterCollection);
            }
        }

        private void frmRelatorio_Load(object sender, EventArgs e)
        {

            this.reportViewer.RefreshReport();
            this.reportViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
        }

        public static void ShowReport(string path, bool isEmbeddedResource, Dictionary<string, object> dataSources, Dictionary<string, object> reportParameters = null)
        {
            var frmRelatorio = new frmRelatorio(path, isEmbeddedResource, dataSources, reportParameters);
            frmRelatorio.ShowDialog();
        }
    }
}