namespace Servipol.Entidades.Classes
{
    class SessaoSistema
    {
        public int UsuarioId { get; set; }
        public string UsuarioNome { get; set; }

        public SessaoSistema() { }
        public SessaoSistema(int usuarioId, string usuarioNome)
        {
            UsuarioId = usuarioId;
            UsuarioNome = usuarioNome;
        }
    }
}
