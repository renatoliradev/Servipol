﻿using DevExpress.XtraEditors;
using Npgsql;
using Servipol.Entidades.Classes;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Servipol.Forms.Manutenção_de_Veículos.Manutenção
{
    public partial class frmProxTrocaOleoRevisao : DevExpress.XtraEditors.XtraForm
    {
        #region Instâncias e Propriedades
        readonly ConexaoBD BD = new ConexaoBD();


        #endregion

        public frmProxTrocaOleoRevisao()
        {
            InitializeComponent();
        }

        private void frmProxTrocaOleoRevisao_Load(object sender, EventArgs e)
        {
            BD.Conectar();

            CarregaTabelaProxTrocaOleo();
            //CarregaTabelaProxRevisao();
        }

        #region Methods
        public void CarregaTabelaProxTrocaOleo()
        {
            try
            {
                NpgsqlDataAdapter retornoBD = new NpgsqlDataAdapter("SELECT mv.id_manutencao AS id_manutencao_veiculo, v.placa, CAST(CASE WHEN tv.descricao = 'CARRO' THEN v.descricao ELSE tv.descricao || ' ' || v.codigo END AS VARCHAR) AS veiculo, mv.data_manutencao, CAST(CASE WHEN f.id_funcionario_cargo = 1 THEN f.codigo_ase || ' - ' || f.qra_ase ELSE f.nome END AS VARCHAR) AS funcionario_ultima_troca, lm.descricao AS local_troca, CAST(mv.km_veiculo + km_validade_oleo AS NUMERIC) AS km_prox_troca, MAX(kmd.km_veiculo) AS km_atual, CAST(mv.km_veiculo + km_validade_oleo AS NUMERIC) - CAST(MAX(kmd.km_veiculo) AS numeric) AS km_falta_troca, kmd.data_km_diario FROM manutencao AS mv INNER JOIN veiculo AS v ON(mv.id_veiculo = v.id_veiculo) INNER JOIN veiculo_tipo AS tv ON(v.tipo = tv.id_veiculo_tipo) INNER JOIN funcionario AS f ON(mv.id_funcionario = f.id_funcionario) INNER JOIN manutencao_local AS lm ON(mv.id_manutencao_local = lm.id_manutencao_local) INNER JOIN km_diario AS kmd ON(kmd.id_veiculo = v.id_veiculo) WHERE mv.id_manutencao IN(SELECT MAX(id_manutencao) FROM manutencao WHERE id_manutencao_tipo = 1 AND registro_excluido = 'N' GROUP BY id_veiculo) AND kmd.id_km_diario IN(SELECT MAX(id_km_diario) FROM km_diario GROUP BY id_veiculo)  AND v.ativo = 'S' GROUP BY mv.id_manutencao, tv.descricao, v.descricao, v.placa, v.codigo, f.id_funcionario_cargo, f.codigo_ase, f.qra_ase, f.nome, lm.descricao, kmd.data_km_diario ORDER BY tv.descricao DESC, v.codigo", BD.ObjetoConexao);
                DataTable dp = new DataTable();
                retornoBD.Fill(dp);
                dGrid.DataSource = dp;
                dGrid.ClearSelection();
            }
            catch (Exception err)
            {
                XtraMessageBox.Show(err.Message, "Erro ao carregar Próxima Troca de Óleo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CarregaTabelaProxRevisao()
        {
            try
            {
                NpgsqlDataAdapter retornoBD = new NpgsqlDataAdapter("SELECT mv.id AS id_manutencao_veiculo, v.placa, CAST(CASE WHEN tv.descricao = 'CARRO' THEN v.descricao_veiculo ELSE tv.descricao || ' ' || v.codigo_veiculo END AS VARCHAR) AS veiculo, mv.data_manutencao AS data_ultima_revisao, CAST(CASE WHEN f.id_tipo_funcionario = 1 THEN f.codigo || ' - ' || f.qra ELSE f.nome END AS VARCHAR) AS funcionario_ultima_revisao, lm.descricao AS local_revisao, MIN(scr.km_limite_revisao) AS km_prox_revisao, MAX(kmd.km_veiculo) AS km_atual, CAST(MIN(scr.km_limite_revisao) AS NUMERIC) - CAST(MAX(kmd.km_veiculo) AS numeric) AS km_falta_revisao, kmd.data_km_diario FROM manutencao_veiculo AS mv INNER JOIN veiculos AS v ON(mv.id_veiculo = v.id) INNER JOIN tipo_veiculo AS tv ON(v.tipo_veiculo = tv.id) INNER JOIN funcionarios AS f ON(mv.id_funcionario = f.id) INNER JOIN local_manutencao AS lm ON(mv.local_manutencao = lm.id_local_manutencao) INNER JOIN km_diario AS kmd ON(kmd.id_veiculo = v.id) INNER JOIN sis_configuracao_revisao AS scr ON(scr.id_veiculo = v.id) WHERE mv.id IN(SELECT MAX(id) FROM manutencao_veiculo WHERE id_tipo_manutencao = (SELECT id_tipo_manutencao FROM tipo_manutencao WHERE descricao_manutencao = 'REVISÃO') AND registro_excluido = 'N' GROUP BY id_veiculo) AND kmd.id_km_diario IN(SELECT MAX(id_km_diario) FROM km_diario GROUP BY id_veiculo) AND scr.concluida = 'N' AND v.faz_revisao = 'Sim' AND v.ativo = 'S' GROUP BY mv.id, tv.descricao, v.descricao_veiculo, v.placa, v.codigo_veiculo, f.id_tipo_funcionario, f.codigo, f.qra, f.nome, lm.descricao, kmd.data_km_diario ORDER BY tv.descricao DESC, v.codigo_veiculo", BD.ObjetoConexao);
                DataTable dp = new DataTable();
                retornoBD.Fill(dp);
                dGridRevisao.DataSource = dp;
                dGridRevisao.ClearSelection();
            }
            catch (Exception err)
            {
                XtraMessageBox.Show(err.Message, "Erro ao carregar Próxima Revisão.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void dGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string data_km_diario = dGrid.SelectedRows[0].Cells["data_km_diario"].Value.ToString();

            try
            {
                string idRegistroSelecionadoGrid = dGrid.SelectedRows[0].Cells[0].Value.ToString();
                frmManutencaoDetalhadaVeiculo frmManutencaoDetalhadaVeiculo = new frmManutencaoDetalhadaVeiculo(Convert.ToInt32(idRegistroSelecionadoGrid));
                frmManutencaoDetalhadaVeiculo.ShowInTaskbar = false;
                frmManutencaoDetalhadaVeiculo.ShowDialog();
            }
            catch { }
        }

        private void dGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string _data_km_diario = DateTime.Now.ToString("dd/MM/yyyy 00:00:00");
            string _data_km_diario_tabela = Convert.ToString(dGrid.Rows[e.RowIndex].Cells["data_km_diario"].Value);

            foreach (DataGridViewRow row in dGrid.Rows)
            {
                if (_data_km_diario_tabela != _data_km_diario)
                {
                    dGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                    dGrid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;

                    //tBoxInfo.Text = "Os registros em VERMELHO indicam que ainda não foi lançado o KM Diário para o veículo. Verifique!";
                    //tBoxInfo.ForeColor = Color.Red;
                }
                else
                {
                    dGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Lavender;
                    dGrid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;

                    //tBoxInfo.Text = "O KM Diário foi lançado para todos os veículos.";
                    //tBoxInfo.ForeColor = Color.Blue;
                }
            }
        }

        #endregion

        private void frmProxTrocaOleoRevisao_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }
    }
}