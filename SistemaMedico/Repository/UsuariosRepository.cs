using SistemaMedicoV3.Models;

namespace SistemaMedicoV3.Repository
{
    public class UsuariosRepository
    {
        public List<Usuario> ObtenerUsuarios()
        {
            return new List<Usuario>
            {
                new Usuario
                {
                    Email = "usuario1@example.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("Password1")
                },
                new Usuario
                {
                    Email = "usuario2@example.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("Password2")
                },
                new Usuario
                {
                    Email = "usuario3@example.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("Password3")
                }
            };
        }

        //private readonly List<Usuario> _usuarios;

        //public  UsuariosRepository()
        //{
        //    // Precargar usuarios con contraseñas hasheadas
        //    _usuarios = new List<Usuario>
        //    {
        //        new Usuario
        //        {
        //            Email = "usuario1@example.com",
        //            PasswordHash = BCrypt.Net.BCrypt.HashPassword("Password1")
        //        },
        //        new Usuario
        //        {
        //            Email = "usuario2@example.com",
        //            PasswordHash = BCrypt.Net.BCrypt.HashPassword("Password2")
        //        },
        //        new Usuario
        //        {
        //            Email = "usuario3@example.com",
        //            PasswordHash = BCrypt.Net.BCrypt.HashPassword("Password3")
        //        }
        //    };
        //}

        //// Buscar un usuario por email
        //public Usuario? BuscarPorEmail(string email)
        //{
        //    return _usuarios.FirstOrDefault(u => u.Email == email);
        //}

        //// Agregar un nuevo usuario al repositorio
        //public void AgregarUsuario(Usuario usuario)
        //{
        //    if (_usuarios.Any(u => u.Email == usuario.Email))
        //    {
        //        throw new InvalidOperationException("El email ya está registrado.");
        //    }

        //    _usuarios.Add(usuario);
        //}
    }
}
