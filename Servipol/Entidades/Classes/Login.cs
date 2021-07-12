using DevExpress.XtraEditors;
using Npgsql;
using System;
using System.Windows.Forms;

namespace Servipol.Entidades.Classes
{
    class Login
    {
        ConexaoBD BD = new ConexaoBD();

        public string UsuarioNome { get; set; }
        public int UsuarioId { get; set; }

        public void SessaoLogin()
        {
            try
            {
                BD.Conectar();

                NpgsqlCommand com = new NpgsqlCommand("SELECT u.id AS id_usuario_logado, u.login AS nome_usuario_logado, cp.permissao, u.id_perfil FROM usuarios AS u INNER JOIN controle_permissao AS cp ON(cp.id_usuario = u.id) WHERE u.id = (SELECT id_usuario FROM sessao_login WHERE nome_pc = '" + Environment.MachineName + "' AND online = 'S')", BD.ObjetoConexao);
                using (NpgsqlDataReader dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        UsuarioNome = dr["nome_usuario_logado"].ToString();
                        UsuarioId = int.Parse(dr["id_usuario_logado"].ToString());
                    }
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show(err.Message, "Erro ao obter dados do usuário logado.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                BD.Desconectar();
            }
        }
    }
}
