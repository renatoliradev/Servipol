using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Servipol.Entidades.Classes;
using Npgsql;

namespace Servipol.Forms.Manutenção_de_Veículos.Cadastros
{
    public partial class frmVeiculosConsultar : DevExpress.XtraEditors.XtraForm
    {
        #region Instâncias
        ConexaoBD BD = new ConexaoBD();
        #endregion

        public frmVeiculosConsultar()
        {
            InitializeComponent();
        }

        private void frmVeiculosConsultar_Load(object sender, EventArgs e)
        {
            carregaTipoVeiculo();
            carregaTipoVeiculo();

            cBoxSituacao.SelectedIndex = 0;
            cBoxTipoBusca.SelectedIndex = 0;
        }

        #region Methods

        public void CarregaTabelaVeiculos()
        {
            string situacao = string.Empty;
            switch (cBoxSituacao.Text)
            {
                case "Ativos":
                    situacao = "S";
                    break;
                case "Inativos":
                    situacao = "N";
                    break;
            }

            try
            {
                BD.Conectar();
                NpgsqlDataAdapter retornoBD = new NpgsqlDataAdapter($"SELECT v.id_veiculo AS id_veiculo, tv.descricao AS tipo, v.codigo, v.descricao, v.placa, v.combustivel, CASE WHEN v.ativo = 'S' THEN 'Sim' ELSE 'Não' END AS ativo FROM veiculos AS v INNER JOIN veiculo_tipo AS tv ON(v.tipo = tv.id_veiculo_tipo) WHERE v.ativo = '{situacao}' ORDER BY v.codigo", BD.ObjetoConexao);
                DataTable dp = new DataTable();
                retornoBD.Fill(dp);

                dGridVeiculos.DataSource = dp;
            }
            finally
            {
                BD.Desconectar();
            }
        }

        public void carregaTipoVeiculo()
        {
            try
            {
                BD.Conectar();
                NpgsqlCommand com = new NpgsqlCommand();
                com.Connection = BD.ObjetoConexao;
                com.CommandText = $"SELECT id_veiculo_tipo, descricao FROM veiculo_tipo WHERE ativo = 'S' ORDER BY 1 ASC";
                NpgsqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                cBoxTipoVeiculo.ValueMember = "id_veiculo_tipo";
                cBoxTipoVeiculo.DisplayMember = "descricao";
                cBoxTipoVeiculo.DataSource = dt;
            }
            finally
            {
                BD.Desconectar();
            }
        }

        public void BuscaPorTipo()
        {
            string situacao = string.Empty;
            switch (cBoxSituacao.Text)
            {
                case "Ativos":
                    situacao = "S";
                    break;
                case "Inativos":
                    situacao = "N";
                    break;
            }

            try
            {
                BD.Conectar();
                NpgsqlDataAdapter retornoBD = new NpgsqlDataAdapter($"SELECT v.id_veiculo AS id_veiculo, tv.descricao AS tipo, v.codigo, v.descricao, v.placa, v.combustivel, CASE WHEN v.ativo = 'S' THEN 'Sim' ELSE 'Não' END AS ativo FROM veiculos AS v INNER JOIN veiculo_tipo AS tv ON(v.tipo = tv.id_veiculo_tipo) WHERE v.tipo = {cBoxTipoVeiculo.SelectedValue} AND v.ativo = '{situacao}' ORDER BY v.codigo", BD.ObjetoConexao);
                DataTable dp = new DataTable();
                retornoBD.Fill(dp);

                dGridVeiculos.DataSource = dp;
            }
            catch { }
            finally
            {
                BD.Desconectar();
            }
        }

        private void cBoxTipoBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            //mostrar todos
            if (cBoxTipoBusca.SelectedIndex == 0)
            {
                cBoxTipoVeiculo.SelectedIndex = -1;
                gbTipoVeiculoBusca.Text = string.Empty;
                cBoxTipoVeiculo.Visible = false;
                CarregaTabelaVeiculos();
            }
            //busca por Tipo
            else if (cBoxTipoBusca.SelectedIndex == 1)
            {
                cBoxTipoVeiculo.Visible = true;
                cBoxTipoVeiculo.SelectedIndex = -1;
                gbTipoVeiculoBusca.Text = "Tipo";
                gbTipoVeiculoBusca.Focus();
                cBoxTipoVeiculo.Select();
                CarregaTabelaVeiculos();
            }
        }

        private void cBoxTipoVeiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscaPorTipo();
        }

        #endregion

        #region Buttons

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (cBoxTipoBusca.SelectedIndex == 0)
            {
                CarregaTabelaVeiculos();
            }
            else if (cBoxTipoBusca.SelectedIndex == 1)
            {
                BuscaPorTipo();
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            frmVeiculosCadastrar frmVeiculosCadastrar = new frmVeiculosCadastrar("Incluir", 0);
            frmVeiculosCadastrar.Owner = this;
            frmVeiculosCadastrar.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string idVeiculoGrid = dGridVeiculos.SelectedRows[0].Cells[0].Value.ToString();
            frmVeiculosCadastrar frmVeiculosCadastrar = new frmVeiculosCadastrar("Editar", int.Parse(idVeiculoGrid));
            frmVeiculosCadastrar.Owner = this;
            frmVeiculosCadastrar.ShowDialog();        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }

        #endregion

        
    }
}