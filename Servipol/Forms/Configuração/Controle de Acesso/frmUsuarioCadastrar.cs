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

namespace Servipol.Forms.Configuração.Controle_de_Acesso
{
    public partial class frmUsuarioCadastrar : DevExpress.XtraEditors.XtraForm
    {
        #region Instâncias e Propriedades

        readonly ConexaoBD BD = new ConexaoBD();
        public string TipoChamada { get; set; }
        public int IdUsuario { get; set; }

        #endregion

        public frmUsuarioCadastrar(string _tipoChamada, int _idUsuario)
        {
            InitializeComponent();

            IdUsuario = _idUsuario;
        }

        private void frmUsuarioCadastrar_Load(object sender, EventArgs e)
        {

        }

        #region Methods

        public void CarregaUsuario()
        {
            try
            {
                BD.Conectar();
                string nome = string.Empty, login = string.Empty, senha_atual = string.Empty;

                NpgsqlCommand com = new NpgsqlCommand($"SELECT login, nome FROM usuario WHERE id_usuario = {IdUsuario}", BD.ObjetoConexao);
                using (NpgsqlDataReader dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        nome = dr["nome"].ToString();
                        login = dr["login"].ToString();
                    }
                    tBoxNome.Text = nome;
                    tBoxLogin.Text = login;
                }
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message, "Erro na função CarregaUsuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                BD.Desconectar();
            }

            #endregion



            #region Buttons



            #endregion
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

        }
    }