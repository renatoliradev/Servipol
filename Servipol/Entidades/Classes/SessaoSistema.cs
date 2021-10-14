namespace Servipol.Entidades.Classes
{
    class SessaoSistema
    {
        private static string _userId;
        private static string _userName;

        public static string UsuarioId
        {
            get { return SessaoSistema._userId; }
            set { SessaoSistema._userId = value; }
        }

        public static string UsuarioNome
        {
            get { return SessaoSistema._userName; }
            set { SessaoSistema._userName = value; }
        }
    }
}
