namespace Servipol.Entidades.Classes
{
    class SessaoSistema
    {
        private static string _usuarioId;
        private static string _usuarioNome;

        public static string UsuarioId
        {
            get { return SessaoSistema._usuarioId; }
            set { SessaoSistema._usuarioId = value; }
        }

        public static string UsuarioNome
        {
            get { return SessaoSistema._usuarioNome; }
            set { SessaoSistema._usuarioNome = value; }
        }
    }
}
