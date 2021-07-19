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

namespace Servipol.Forms.Manutenção_de_Veículos.Manutenção
{
    public partial class frmManutencaoMotivoExcluir : DevExpress.XtraEditors.XtraForm
    {
        #region Instâncias
        ConexaoBD BD = new ConexaoBD();

        public static int auxIdRegistroSelecionado = 0;
        public static string tipo_manutencao = string.Empty;
        public static int km_veiculo = 0;
        public static int id_veiculo = 0;
        #endregion

        public frmManutencaoMotivoExcluir(int idRegistroSelecionado, string tipoManutencaoSelecionada, int kmVeiculo, int idVeiculo)
        {
            InitializeComponent();

            auxIdRegistroSelecionado = idRegistroSelecionado;
            tipo_manutencao = tipoManutencaoSelecionada;
            km_veiculo = kmVeiculo;
            id_veiculo = idVeiculo;
        }

        private void frmManutencaoMotivoExcluir_Load(object sender, EventArgs e)
        {

        }

        #region Methods

        private void frmManutencaoMotivoExcluir_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Close();
                    break;
                case Keys.F12:
                    btnConfirmar_Click(sender, e);
                    break;
            }
        }

        #endregion

        #region Buttons



        #endregion

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                BD.Conectar();
                if (tBoxMotivoExcluirManutencao.Text == string.Empty)
                {
                    XtraMessageBox.Show("Informe o motivo da exclusão da manutenção selecionada!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tBoxMotivoExcluirManutencao.Focus();
                }
                else if (tBoxMotivoExcluirManutencao.Text.Length < 10)
                {
                    XtraMessageBox.Show("O motivo da exclusão deve ter no mínimo 10 caracteres.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tBoxMotivoExcluirManutencao.Focus();
                }
                else
                {
                    if (XtraMessageBox.Show("***** OPERAÇÃO IRREVERSÍVEL *****\n\nConfirma exclusão da manutenção selecionada ?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        //if (tipo_manutencao == "REVISÃO")
                        //{
                        //    NpgsqlCommand update2 = new NpgsqlCommand($"UPDATE sis_configuracao_revisao SET concluida = 'N' WHERE id_veiculo = {id_veiculo} AND km_limite_revisao BETWEEN ({km_veiculo} - 999) AND ({km_veiculo} + 999) AND concluida = 'S'", BD.ObjetoConexao);
                        //    update2.ExecuteNonQuery();
                        //}

                        NpgsqlCommand update1 = new NpgsqlCommand($"UPDATE manutencao SET registro_excluido = 'S', id_usuario_exclusao = {SessaoSistema.UsuarioId}, data_exclusao = CURRENT_TIMESTAMP, motivo_exclusao = '{tBoxMotivoExcluirManutencao.Text.Trim().ToUpper()}' WHERE id_manutencao = {auxIdRegistroSelecionado}", BD.ObjetoConexao);
                        update1.ExecuteNonQuery();

                        XtraMessageBox.Show("Manutenção Excluída com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //((frmManutencoesRealizadas)this.Owner).atualizaCamposDepoisDeExcluir();

                        Close();
                    }
                }
            }
            finally
            {
                bd.Desconectar();
            }
        }

    }
}