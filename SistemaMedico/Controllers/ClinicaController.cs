using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using SistemaMedico.Services;
using SistemaMedicoV3.Models;

namespace SistemaMedico.Controllers
{
    public class ClinicaController : Controller
    {
        private PacienteService _service;
        public ClinicaController(PacienteService pacienteService)
        {
            _service = pacienteService;
        }

        [HttpPost]
        public IActionResult AgregarEvolucion(int dni, Guid idDiagnostico, string informe)
        {
            var paciente = _service.BuscarPorDni(dni);
            if (paciente == null)
            {
                return NotFound($"Paciente con DNI {dni} no encontrado.");
            }

            try
            {
                paciente.AgregarEvolucion(idDiagnostico, informe);
                return View("~/Views/Paciente/Evolucion.cshtml", paciente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        public void AgregarDiagnostico(int dni, string enfermedad)
        {
            var paciente = _service.BuscarPorDni(dni);

            if (paciente == null)
            {
                throw new Exception($"Paciente con DNI {dni} no encontrado");
            }

            paciente.HistoriaClinica.AgregarDiagnostico(enfermedad);
        }
        
        [HttpGet]
        public IActionResult Evolucion(int dni)
        {
            var paciente = _service.BuscarPorDni(dni);
            if (paciente == null)
            {
                return NotFound($"Paciente con DNI {dni} no encontrado.");
            }

            return View("~/Views/Paciente/Evolucion.cshtml", paciente); // Carga la vista Evolucion.cshtml con el modelo del paciente
        }


    }
}
