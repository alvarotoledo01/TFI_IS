using SistemaMedico.Services;

namespace SistemaMedico.Controllers
{
    public class ClinicaController
    {
        private PacienteService _service;
        public ClinicaController(PacienteService pacienteService)
        {
            _service = pacienteService;
        }

        public void AgregarEvolucion(int dni, Guid idDiagnostico, string informe)
        {
            var paciente = _service.BuscarPorDni(dni);

            if (paciente == null)
            {
                throw new Exception($"Paciente con DNI {dni} no encontrado");
            }

            paciente.AgregarEvolucion(idDiagnostico, informe);
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
    }
}
