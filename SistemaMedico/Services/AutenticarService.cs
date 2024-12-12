using SistemaMedicoV3.Models;
using SistemaMedicoV3.Repository;

namespace SistemaMedicoV3.Services
{
    public class AutenticarService
    {
        private readonly List<Usuario> _usuarios;

        public AutenticarService(UsuariosRepository repositorio)
        {
            _usuarios = repositorio.ObtenerUsuarios();
        }

        public Usuario? BuscarPorEmail(string email)
        {
            return _usuarios.FirstOrDefault(u => u.Email == email);
        }

        public bool IniciarSesion(string email, string password)
        {
            var usuario = BuscarPorEmail(email);
            if (usuario == null)
            {
                return false;
            }
            return BCrypt.Net.BCrypt.Verify(password, usuario.Password);
        }

    }
}
