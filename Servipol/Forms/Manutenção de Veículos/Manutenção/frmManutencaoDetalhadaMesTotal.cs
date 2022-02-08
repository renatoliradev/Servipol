using Npgsql;
using Servipol.Entidades.Classes;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Servipol.Forms.Manutenção_de_Veículos.Manutenção
{
    public partial class frmManutencaoDetalhadaMesTotal : DevExpress.XtraEditors.XtraForm
    {
        #region INSTÂNCIAS E PROPRIEDADES
        readonly ConexaoBD BD = new ConexaoBD();
        public string PrimeiroDiaMes { get; set; }
        public int IdVeiculo { get; set; }
        #endregion

        public frmManutencaoDetalhadaMesTotal(int _idVeiculo)
        {
            InitializeComponent();

            IdVeiculo = _idVeiculo;
        }

        private void frmManutencaoDetalhadaMesTotal_Load(object sender, EventArgs e)
        {
            BD.Conectar();

            CarregaDadosVeiculo();
            CapturaPrimeiroDiaMesAtual();
            CarregaTabelaTotalManutDetalhadaMes();
        }

        #region Methods

        public void CarregaDadosVeiculo()
        {
            try
            {
                NpgsqlCommand com = new NpgsqlCommand($"SELECT CAST(CASE WHEN vt.descricao = 'CARRO' THEN '[' || v.placa || '] - ' || v.descricao ELSE '[' || v.placa || '] - ' || vt.descricao || ' ' || v.codigo END AS VARCHAR) AS veiculo FROM veiculo AS v INNER JOIN veiculo_tipo AS vt ON(v.id_veiculo_tipo = vt.id_veiculo_tipo) WHERE v.id_veiculo = {IdVeiculo}", BD.ObjetoConexao);
                using (NpgsqlDataReader dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        tBoxVeiculo.Text = dr["veiculo"].ToString();
                    }
                }
            }
            catch { }
        }

        public void CapturaPrimeiroDiaMesAtual()
        {
            try
            {
                NpgsqlCommand com = new NpgsqlCommand($"SELECT TO_CHAR(min(dias), 'YYYY-MM-DD') AS primeiro_dia_mes FROM generate_series(date_trunc('month',current_date),date_trunc('month',current_date) + INTERVAL'1 month' - INTERVAL'1 day',INTERVAL'1 day') AS dias", BD.ObjetoConexao);
                using (NpgsqlDataReader dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        PrimeiroDiaMes = dr["primeiro_dia_mes"].ToString();
                    }
                }
            }
            catch { }
        }

        public void CarregaTabelaTotalManutDetalhadaMes()
        {
            try
            {
                NpgsqlDataAdapter retornoBD = new NpgsqlDataAdapter($"SELECT m.id_manutencao, m.data_manutencao, mt.descricao, m.valor_total FROM manutencao AS m INNER JOIN veiculo AS v ON(m.id_veiculo = v.id_veiculo) INNER JOIN manutencao_tipo AS mt ON(m.id_manutencao_tipo = mt.id_manutencao_tipo) WHERE m.confirmada = 'S' AND m.registro_excluido = 'N' AND m.id_veiculo = {IdVeiculo} AND DATE(m.data_manutencao) BETWEEN '{PrimeiroDiaMes}' AND current_date GROUP BY m.id_manutencao, mt.descricao, m.valor_total ORDER BY m.id_manutencao DESC, m.data_manutencao", BD.ObjetoConexao);
                DataTable dp = new DataTable();
                retornoBD.Fill(dp);
                dGridManutencoes.DataSource = dp;

                tBoxValorTotal.Text = dGridManutencoes.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells[valor_total.Name].Value ?? 0)).ToString("C");
            }
            catch
            {
                tBoxValorTotal.Text = "R$0,00";
            }
            finally
            {
                tBoxQtdRegistros.Text = dGridManutencoes.RowCount.ToString();
            }
        }

        private void frmManutencaoDetalhadaMesTotal_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void frmManutencaoDetalhadaMesTotal_FormClosing(object sender, FormClosingEventArgs e)
        {
            BD.Desconectar();
            this.Dispose();
        }

        private void dGridManutencoes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int idRegistroSelecionadoGrid = int.Parse(dGridManutencoes.SelectedRows[0].Cells[0].Value.ToString());
                frmManutencaoDetalhadaVeiculo frmManutencaoDetalhadaVeiculo = new frmManutencaoDetalhadaVeiculo(idRegistroSelecionadoGrid);
                frmManutencaoDetalhadaVeiculo.ShowDialog();
            }
            catch { }
        }

        #endregion
    }
}