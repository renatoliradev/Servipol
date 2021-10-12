using DevExpress.XtraEditors;
using Npgsql;
using Servipol.Entidades.Classes;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Servipol.Forms.Manutenção_de_Veículos.Manutenção
{
    public partial class frmManutencaoDetalhadaVeiculo : DevExpress.XtraEditors.XtraForm
    {
        #region Instâncias e Propriedades
        readonly ConexaoBD BD = new ConexaoBD();

        public int IdManutencao { get; set; }
        #endregion

        public frmManutencaoDetalhadaVeiculo(int idManutencao)
        {
            IdManutencao = idManutencao;

            InitializeComponent();
        }

        private void frmManutencaoDetalhadaVeiculo_Load(object sender, EventArgs e)
        {
            try
            {
                BD.Conectar();
                NpgsqlDataAdapter retornoBD = new NpgsqlDataAdapter($"SELECT mv.id_veiculo, mv.id_manutencao_tipo, TO_CHAR(mv.data_manutencao, 'DD/MM/YYYY') AS data_manutencao, mv.km_veiculo, CAST(CASE WHEN mv.km_validade_oleo > 0 THEN mv.km_validade_oleo ELSE NULL END AS VARCHAR) AS km_validade_oleo, CAST(CASE WHEN mv.km_validade_oleo > 0 THEN mv.km_veiculo + mv.km_validade_oleo ELSE NULL END AS VARCHAR) AS prox_troca_oleo, CAST(tv.descricao || ' 0' || v.codigo AS VARCHAR) AS veiculo, v.descricao, v.placa, tm.descricao AS tipo_manutencao, lm.descricao AS local_manutencao, mv.observacao, CAST(CASE WHEN f.id_funcionario_cargo = 1 THEN f.codigo_ase || ' - ' || f.qra_ase ELSE f.nome END AS VARCHAR) AS funcionario, uc.nome AS usuario_cadastro, mv.data_cadastro, ue.nome AS usuario_exclusao, mv.data_exclusao, mv.motivo_exclusao, mv.valor_peca, mv.valor_servico, mv.valor_desconto, mv.valor_acrescimo, mv.valor_total, mv.registro_excluido FROM manutencao AS mv INNER JOIN veiculo AS v ON(mv.id_veiculo = v.id_veiculo) INNER JOIN manutencao_tipo AS tm ON(mv.id_manutencao_tipo = tm.id_manutencao_tipo) INNER JOIN manutencao_local AS lm ON(mv.id_manutencao_local = lm.id_manutencao_local) INNER JOIN funcionario AS f ON(mv.id_funcionario = f.id_funcionario) LEFT OUTER JOIN usuario AS uc ON(mv.id_usuario_cadastro = uc.id_usuario) LEFT OUTER JOIN usuario AS ue ON(mv.id_usuario_exclusao = ue.id_usuario) INNER JOIN veiculo_tipo AS tv ON(v.tipo = tv.id_veiculo_tipo)  WHERE mv.id_manutencao = {IdManutencao}", BD.ObjetoConexao);
                DataTable dp = new DataTable();
                retornoBD.Fill(dp);

                auxIdVeiculo.DataBindings.Clear();
                auxIdTipoManutencao.DataBindings.Clear();
                tBoxDataManutencao.DataBindings.Clear();
                tBoxFuncionario.DataBindings.Clear();
                tBoxVeiculo.DataBindings.Clear();
                tBoxDescricao.DataBindings.Clear();
                tBoxPlaca.DataBindings.Clear();
                tBoxTipoManutencao.DataBindings.Clear();
                tBoxLocalManutencao.DataBindings.Clear();
                tBoxObsManutencao.DataBindings.Clear();
                tBoxKmManutencao.DataBindings.Clear();
                tBoxValidadeOleo.DataBindings.Clear();
                tBoxProxTrocaOleo.DataBindings.Clear();
                tBoxDataCadastro.DataBindings.Clear();
                tBoxUsuarioCadastro.DataBindings.Clear();
                tBoxDataExclusao.DataBindings.Clear();
                tBoxUsuarioExclusao.DataBindings.Clear();
                tBoxMotivoExclusao.DataBindings.Clear();
                tBoxValorPeca.DataBindings.Clear();
                tBoxValorServico.DataBindings.Clear();
                tBoxDesconto.DataBindings.Clear();
                tBoxAcrescimo.DataBindings.Clear();
                tBoxValorTotal.DataBindings.Clear();
                auxSituacao.DataBindings.Clear();

                auxIdVeiculo.DataBindings.Add(new Binding("Text", dp, "id_veiculo"));
                auxIdTipoManutencao.DataBindings.Add(new Binding("Text", dp, "id_manutencao_tipo"));
                tBoxDataManutencao.DataBindings.Add(new Binding("Text", dp, "data_manutencao"));
                tBoxFuncionario.DataBindings.Add(new Binding("Text", dp, "funcionario"));
                tBoxVeiculo.DataBindings.Add(new Binding("Text", dp, "veiculo"));
                tBoxDescricao.DataBindings.Add(new Binding("Text", dp, "descricao"));
                tBoxPlaca.DataBindings.Add(new Binding("Text", dp, "placa"));
                tBoxTipoManutencao.DataBindings.Add(new Binding("Text", dp, "tipo_manutencao"));
                tBoxLocalManutencao.DataBindings.Add(new Binding("Text", dp, "local_manutencao"));
                tBoxObsManutencao.DataBindings.Add(new Binding("Text", dp, "observacao"));
                tBoxKmManutencao.DataBindings.Add(new Binding("Text", dp, "km_veiculo"));
                tBoxValidadeOleo.DataBindings.Add(new Binding("Text", dp, "km_validade_oleo"));
                tBoxProxTrocaOleo.DataBindings.Add(new Binding("Text", dp, "prox_troca_oleo"));
                tBoxDataCadastro.DataBindings.Add(new Binding("Text", dp, "data_cadastro"));
                tBoxUsuarioCadastro.DataBindings.Add(new Binding("Text", dp, "usuario_cadastro"));
                tBoxDataExclusao.DataBindings.Add(new Binding("Text", dp, "data_exclusao"));
                tBoxUsuarioExclusao.DataBindings.Add(new Binding("Text", dp, "usuario_exclusao"));
                tBoxMotivoExclusao.DataBindings.Add(new Binding("Text", dp, "motivo_exclusao"));
                tBoxValorPeca.DataBindings.Add(new Binding("Text", dp, "valor_peca"));
                tBoxValorServico.DataBindings.Add(new Binding("Text", dp, "valor_servico"));
                tBoxDesconto.DataBindings.Add(new Binding("Text", dp, "valor_desconto"));
                tBoxAcrescimo.DataBindings.Add(new Binding("Text", dp, "valor_acrescimo"));
                tBoxValorTotal.DataBindings.Add(new Binding("Text", dp, "valor_total"));
                auxSituacao.DataBindings.Add(new Binding("Text", dp, "registro_excluido"));

                NpgsqlDataAdapter retornoBD2 = new NpgsqlDataAdapter($"SELECT km_anterior, km_veiculo, CAST(km_veiculo - km_anterior AS VARCHAR) AS km_rodados FROM manutencao where id_manutencao = {IdManutencao}", BD.ObjetoConexao);
                DataTable dp2 = new DataTable();
                retornoBD2.Fill(dp2);

                tBoxUltimoKmServico.DataBindings.Clear();
                tBoxKmManutencao.DataBindings.Clear();
                tBoxKmRodadoDesdeUltimaManutencao.DataBindings.Clear();
                tBoxUltimoKmServico.DataBindings.Add(new Binding("Text", dp2, "km_anterior"));
                tBoxKmManutencao.DataBindings.Add(new Binding("Text", dp2, "km_veiculo"));
                tBoxKmRodadoDesdeUltimaManutencao.DataBindings.Add(new Binding("Text", dp2, "km_rodados"));


                if (auxSituacao.Text == "S")
                {
                    tBoxDescricao.DataBindings.Clear();
                    tBoxDescricao.Text = "*** REGISTRO EXCLUÍDO ***";
                    tBoxDescricao.TextAlign = HorizontalAlignment.Center;
                    tBoxDescricao.ForeColor = Color.Red;
                }

                if (string.IsNullOrEmpty(tBoxValidadeOleo.Text))
                {
                    gbValidadeOleo.Visible = false;
                    gbKmProxTrocaOleo.Visible = false;
                }

                tBoxValorPeca.Text = Convert.ToDouble(tBoxValorPeca.Text).ToString("C");
                tBoxValorServico.Text = Convert.ToDouble(tBoxValorServico.Text).ToString("C");
                tBoxDesconto.Text = Convert.ToDouble(tBoxDesconto.Text).ToString("C");
                tBoxAcrescimo.Text = Convert.ToDouble(tBoxAcrescimo.Text).ToString("C");
                tBoxValorTotal.Text = Convert.ToDouble(tBoxValorTotal.Text).ToString("C");

            }
            catch (Exception err)
            {
                XtraMessageBox.Show(err.Message, "Erro ao carregar dados da manutenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                BD.Desconectar();

            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFechar2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManutencaoDetalhadaVeiculo_KeyDown(object sender, KeyEventArgs e)
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