using DevExpress.XtraEditors;
using Npgsql;
using Servipol.Entidades.Classes;
using System;
using System.Windows.Forms;

namespace Servipol.Forms.Manutenção_de_Veículos.Manutenção
{
    public partial class frmManutencaoMotivoExcluir : DevExpress.XtraEditors.XtraForm
    {
        #region Instâncias e Propriedades
        readonly ConexaoBD BD = new ConexaoBD();

        public int IdRegistroSelecionado { get; set; }

        #endregion

        public frmManutencaoMotivoExcluir(int idRegistroSelecionado)
        {
            InitializeComponent();

            IdRegistroSelecionado = idRegistroSelecionado;
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                BD.Conectar();
                if (string.IsNullOrEmpty(tBoxMotivoExcluirManutencao.Text))
                {
                    XtraMessageBox.Show("Informe o motivo da exclusão da manutenção selecionada!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tBoxMotivoExcluirManutencao.Focus();
                }
                else if (tBoxMotivoExcluirManutencao.Text.Length < 10)
                {
                    XtraMessageBox.Show("O motivo da exclusão deve ter no mínimo 10 caracteres.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tBoxMotivoExcluirManutencao.Focus();
                }
                else
                {
                    if (XtraMessageBox.Show("********** OPERAÇÃO IRREVERSÍVEL **********\n\nConfirma exclusão da manutenção selecionada ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        NpgsqlCommand update1 = new NpgsqlCommand($"UPDATE manutencao SET registro_excluido = 'S', id_usuario_exclusao = {SessaoSistema.UsuarioId}, data_exclusao = CURRENT_TIMESTAMP, motivo_exclusao = '{tBoxMotivoExcluirManutencao.Text.Trim().ToUpper()}' WHERE id_manutencao = {IdRegistroSelecionado}", BD.ObjetoConexao);
                        update1.ExecuteNonQuery();

                        XtraMessageBox.Show("Manutenção Excluída com Sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ((frmManutencaoConsultar)this.Owner).AtualizaDGDepoisDeExcluir(sender, e);

                        Close();
                    }
                }
            }
            finally
            {
                BD.Desconectar();
            }
        }

        #endregion
    }
}