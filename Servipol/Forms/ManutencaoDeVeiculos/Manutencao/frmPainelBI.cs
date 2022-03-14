using DevExpress.XtraEditors;
using Npgsql;
using Servipol.Entidades.Classes;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Servipol.Forms.Manutenção_de_Veículos.Manutenção
{
    public partial class frmPainelBI : DevExpress.XtraEditors.XtraForm
    {
        #region INSTÂNCIAS E PROPRIEDADES
        readonly ConexaoBD BD = new ConexaoBD();

        public string PrimeiroDiaMes { get; set; }
        #endregion

        public frmPainelBI()
        {
            InitializeComponent();
        }

        private void frmPainelBI_Load(object sender, EventArgs e)
        {
            BD.Conectar();

            CapturaPrimeiroDiaMesAtual();
            CarregaTabelaDadosUltimaManutencao();
            CarregaTabelaTotalGastoNoMesManutencao();
        }

        #region Methods

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

        public void CarregaTabelaDadosUltimaManutencao()
        {
            try
            {
                NpgsqlDataAdapter retornoBD = new NpgsqlDataAdapter($"SELECT m.id_manutencao, CAST(CASE WHEN v.ativo = 'N' AND vt.descricao = 'Moto' THEN '>>>>>> REGISTRO INATIVO <<<<<< | ' || vt.descricao || ' 0' || v.codigo || ' - [' || v.placa || ']' WHEN v.ativo = 'N' AND vt.descricao = 'Carro' THEN '>>>>>> REGISTRO INATIVO <<<<<< | ' || v.descricao || ' - [' || v.placa || ']' WHEN v.ativo = 'S' AND vt.descricao = 'Moto' THEN vt.descricao || ' 0' || v.codigo || ' - [' || v.placa|| ']' WHEN v.ativo = 'S' AND vt.descricao = 'Carro' THEN v.descricao || ' - [' || v.placa || ']' ELSE vt.descricao || ' ' || v.codigo || ' - [' || v.placa || ']' END AS VARCHAR) AS veiculo, TO_CHAR(m.data_manutencao, 'DD/MM/YYYY') AS data_manutencao, ml.descricao AS local_manutencao, mt.descricao, CAST(m.valor_total AS NUMERIC(13,2)) AS valor_ultima_manutencao FROM manutencao AS m INNER JOIN veiculo AS v ON(m.id_veiculo = v.id_veiculo) INNER JOIN veiculo_tipo AS vt ON(v.id_veiculo_tipo = vt.id_veiculo_tipo) INNER JOIN manutencao_local AS ml ON(m.id_manutencao_local = ml.id_manutencao_local) INNER JOIN manutencao_tipo AS mt ON(m.id_manutencao_tipo = mt.id_manutencao_tipo) WHERE m.id_manutencao IN(SELECT MAX(id_manutencao) FROM manutencao WHERE registro_excluido = 'N' AND confirmada = 'S' GROUP BY id_veiculo) GROUP BY m.id_manutencao, vt.descricao, v.descricao, v.placa, v.codigo, v.ativo, ml.descricao, m.data_manutencao, mt.descricao, m.valor_total ORDER BY vt.descricao DESC, v.codigo", BD.ObjetoConexao);
                DataTable dp = new DataTable();
                retornoBD.Fill(dp);
                dGridDadosUltimaManutencaoRegistrada.DataSource = dp;
            }
            catch { }
        }

        public void CarregaTabelaTotalGastoNoMesManutencao()
        {
            try
            {
                NpgsqlDataAdapter retornoBD = new NpgsqlDataAdapter($"SELECT v.id_veiculo, CAST(CASE WHEN v.ativo = 'N' AND vt.descricao = 'Moto' THEN '>>>>>> REGISTRO INATIVO <<<<<< | ' || vt.descricao || ' 0' || v.codigo || ' - [' || v.placa || ']' WHEN v.ativo = 'N' AND vt.descricao = 'Carro' THEN '>>>>>> REGISTRO INATIVO <<<<<< | ' || v.descricao || ' - [' || v.placa || ']' WHEN v.ativo = 'S' AND vt.descricao = 'Moto' THEN vt.descricao || ' 0' || v.codigo || ' - [' || v.placa|| ']' WHEN v.ativo = 'S' AND vt.descricao = 'Carro' THEN v.descricao || ' - [' || v.placa || ']' ELSE vt.descricao || ' ' || v.codigo || ' - [' || v.placa || ']' END AS VARCHAR) AS veiculo, COUNT(m.id_manutencao) AS quantidade_manutencao, SUM(m.valor_total) AS total_manutencao FROM manutencao AS m INNER JOIN veiculo AS v ON(m.id_veiculo = v.id_veiculo) INNER JOIN veiculo_tipo AS vt ON(v.id_veiculo_tipo = vt.id_veiculo_tipo) INNER JOIN manutencao_local AS ml ON(m.id_manutencao_local = ml.id_manutencao_local) INNER JOIN manutencao_tipo AS mt ON(m.id_manutencao_tipo = mt.id_manutencao_tipo) WHERE m.confirmada = 'S' AND m.registro_excluido = 'N' AND m.data_manutencao BETWEEN '2022-03-01' AND current_date GROUP BY v.id_veiculo, vt.descricao, v.descricao, v.placa, v.codigo ORDER BY vt.descricao DESC, v.codigo", BD.ObjetoConexao);
                DataTable dp = new DataTable();
                retornoBD.Fill(dp);
                dGridTotalGastoManutencaoMes.DataSource = dp;

                tBoxValorTotal.Text = dGridTotalGastoManutencaoMes.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells[total_manutencao.Name].Value ?? 0)).ToString("C");
            }
            catch { }
        }

        private void dGridTotalGastoManutencaoMes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int idRegistroSelecionadoGrid = int.Parse(dGridTotalGastoManutencaoMes.SelectedRows[0].Cells[0].Value.ToString());
                frmManutencaoDetalhadaMesTotal frmManutencaoDetalhadaMesTotal = new frmManutencaoDetalhadaMesTotal(idRegistroSelecionadoGrid);
                frmManutencaoDetalhadaMesTotal.ShowInTaskbar = false;
                frmManutencaoDetalhadaMesTotal.ShowDialog();
            }
            catch { }
        }

        private void dGridDadosUltimaManutencaoRegistrada_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int idRegistroSelecionadoGrid = int.Parse(dGridDadosUltimaManutencaoRegistrada.SelectedRows[0].Cells[0].Value.ToString());
                frmManutencaoDetalhadaVeiculo frmManutencaoDetalhadaVeiculo = new frmManutencaoDetalhadaVeiculo(idRegistroSelecionadoGrid);
                frmManutencaoDetalhadaVeiculo.ShowDialog();
            }
            catch { }
        }

        #endregion

        #region Buttons
        private void btnImprimirConsulta_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("Funcionalidade em desenvolvimento.", "Em breve", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        private void frmPainelBI_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Close();
                    break;
            }
            if (e.Control && e.KeyCode == Keys.P)
            {
                btnImprimirConsulta_Click(sender, e);
            }
        }
    }
}