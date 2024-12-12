using Microsoft.AspNetCore.Mvc;
using SistemaMedicoV3.Services;

namespace SistemaMedicoV3.Controllers
{
    public class LoginController : Controller
    {
        private readonly AutenticarService _autenticarService;

        // Inyección de dependencia del servicio de autenticación
        public LoginController(AutenticarService autenticarService)
        {
            _autenticarService = autenticarService;
        }

        // Acción para mostrar la vista de Login
        public IActionResult Login()
        {
            return View("~/Views/Home/Login.cshtml");
        }

        // Acción para procesar el inicio de sesión
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "Por favor, ingresa ambos campos.";
                return View("~/Views/Home/Login.cshtml");
            }

            if (_autenticarService.IniciarSesion(email, password))
            {
                // Redirige a otra acción si el inicio de sesión es exitoso
                return View("~/Views/Home/Index.cshtml");
            }

            // Devuelve un mensaje de error si el inicio de sesión falla
            ViewBag.Error = "Email o contraseña incorrectos.";
            return View("~/Views/Home/Login.cshtml");
        }
    }
}

