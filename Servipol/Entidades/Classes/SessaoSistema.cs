namespace Servipol.Entidades.Classes
{
    class SessaoSistema
    {
        private static string _userId;
        private static string _userName;
        private static string _userPermission;

        public static string UserId
        {
            get { return SessaoSistema._userId; }
            set { SessaoSistema._userId = value; }
        }

        public static string UserName
        {
            get { return SessaoSistema._userName; }
            set { SessaoSistema._userName = value; }
        }

        public static string UserPermission
        {
            get { return SessaoSistema._userPermission; }
            set { SessaoSistema._userPermission = value; }
        }
    }
}
