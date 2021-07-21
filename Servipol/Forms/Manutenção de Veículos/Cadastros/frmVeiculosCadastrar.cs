﻿using DevExpress.XtraEditors;
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
    public partial class frmVeiculosCadastrar : DevExpress.XtraEditors.XtraForm
    {
        #region Instâncias
        ConexaoBD BD = new ConexaoBD();

        public static string auxTipoChamada = string.Empty;
        public static int auxIDVeiculo = 0;
        #endregion

        public frmVeiculosCadastrar(string tipoChamada, int idVeiculo)
        {
            InitializeComponent();

            auxTipoChamada = tipoChamada;
            auxIDVeiculo = idVeiculo;
        }

        private void frmVeiculosCadastrar_Load(object sender, EventArgs e)
        {

        }

        #region Methods

        public void verificaTipoChamada()
        {
            try
            {
                BD.Conectar();
                if (auxTipoChamada == "Incluir")
                {
                    this.Text = "Incluir Veículo";

                    cBoxTipoVeiculo.SelectedIndex = -1;
                    cBoxCodigoVeiculo.SelectedIndex = -1;
                    cBoxCombustivel.SelectedIndex = -1;
                    tBoxDescricaoVeiculo.Clear();
                    tBoxPlacaVeiculo.Clear();
                    tBoxDescricaoVeiculo.Focus();
                }
                else if (auxTipoChamada == "frmManutencaoVeiculo")
                {
                    this.Text = "Incluir Veículo";

                    cBoxTipoVeiculo.SelectedIndex = -1;
                    cBoxCodigoVeiculo.SelectedIndex = -1;
                    cBoxCombustivel.SelectedIndex = -1;
                    tBoxDescricaoVeiculo.Clear();
                    tBoxPlacaVeiculo.Clear();
                    tBoxDescricaoVeiculo.Focus();
                }
                else if (auxTipoChamada == "Editar")
                {
                    this.Text = "Editar Veículo";

                    #region DECLARACAO DE VARIAVEIS
                    string tipo_veiculo = string.Empty, codigo_veiculo = string.Empty, descricao_veiculo = string.Empty, placa = string.Empty, combustivel = string.Empty, faz_revisao = string.Empty;
                    #endregion

                    NpgsqlCommand com = new NpgsqlCommand($"SELECT v.tipo_veiculo, v.codigo_veiculo, v.descricao_veiculo, v.placa, v.combustivel, v.faz_revisao FROM veiculos AS v WHERE v.id_veiculo = {auxIDVeiculo}", BD.ObjetoConexao);
                    using (NpgsqlDataReader dr = com.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            tipo_veiculo = dr["tipo_veiculo"].ToString();
                            codigo_veiculo = dr["codigo_veiculo"].ToString();
                            descricao_veiculo = dr["descricao_veiculo"].ToString();
                            placa = dr["placa"].ToString();
                            combustivel = dr["combustivel"].ToString();
                            faz_revisao = dr["faz_revisao"].ToString();
                        }

                        cBoxTipoVeiculo.SelectedValue = tipo_veiculo;

                        switch (tipo_veiculo)
                        {
                            case "1":
                                carregaCodigoCarro();
                                cBoxCodigoVeiculo.SelectedValue = codigo_veiculo;
                                break;
                            case "2":
                                carregaCodigoMoto();
                                cBoxCodigoVeiculo.SelectedValue = codigo_veiculo;
                                break;
                        }

                        #region IDENTIFICA_TIPO_PLACA
                        if (placa.Contains("-"))
                        {
                            rBtnPlacaAntiga.Checked = true;
                        }
                        else
                        {
                            rBtnPlacaMercosul.Checked = true;
                        }
                        #endregion

                        tBoxDescricaoVeiculo.Text = descricao_veiculo;
                        tBoxPlacaVeiculo.Text = placa;
                        cBoxCombustivel.SelectedItem = combustivel;
                        cBoxFazRevisao.SelectedItem = faz_revisao;
                    }
                }
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
                com.CommandText = $"SELECT id_veiculo_tipo, descricao FROM veiculo_tipo WHERE ativo = 'S' ORDER BY 2 ASC";
                NpgsqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                cBoxTipoVeiculo.ValueMember = "id_veiculo_tipo";
                cBoxTipoVeiculo.DisplayMember = "descricao";
                cBoxTipoVeiculo.DataSource = dt;

                if (cBoxTipoVeiculo.SelectedValue.ToString() == "1")
                {
                    carregaCodigoCarro();
                }
                else if (cBoxTipoVeiculo.SelectedValue.ToString() == "2")
                {
                    carregaCodigoMoto();
                }
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message, "Falha na função carregaTipoVeiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                BD.Desconectar();
            }
        }

        public void carregaCodigoCarro()
        {
            try
            {
                BD.Conectar();
                NpgsqlCommand com = new NpgsqlCommand();
                com.Connection = BD.ObjetoConexao;
                com.CommandText = $"SELECT id FROM codigocarro WHERE id_veiculo = {auxIDVeiculo} OR id_veiculo IS NULL ORDER BY 1 ASC";
                NpgsqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                cBoxCodigoVeiculo.ValueMember = "id";
                cBoxCodigoVeiculo.DisplayMember = "id";
                cBoxCodigoVeiculo.DataSource = dt;
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message, "Falha na função carregaCodigoCarro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                BD.Desconectar();
            }
        }

        public void carregaCodigoMoto()
        {
            try
            {
                BD.Conectar();
                NpgsqlCommand com = new NpgsqlCommand();
                com.Connection = BD.ObjetoConexao;
                com.CommandText = $"SELECT id FROM codigomoto WHERE id_veiculo = {auxIDVeiculo} OR  id_veiculo IS NULL ORDER BY 1 ASC";
                NpgsqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                cBoxCodigoVeiculo.ValueMember = "id";
                cBoxCodigoVeiculo.DisplayMember = "id";
                cBoxCodigoVeiculo.DataSource = dt;
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message, "Falha na função carregaCodigoMoto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                BD.Desconectar();
            }
        }


        #endregion
    }
}