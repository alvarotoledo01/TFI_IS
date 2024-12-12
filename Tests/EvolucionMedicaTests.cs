using SistemaMedico.Controllers;
using SistemaMedico.Services;
using SistemaMedicoV3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class EvolucionMedicaTests
    {
        [Fact]
        public void AgregarEvolucionExitoUsandoControladorClinica()
        {
            // Arrange
            var repositorio = new PacientesRepository();
            var pacienteService = new PacienteService(repositorio);
            var controlador = new ClinicaController(pacienteService);

            var paciente = new Paciente(1, 12345, DateTime.Now, "email@test.com", 123456, "Juan", "OSDE", "123", "Calle", "Ciudad", "Provincia", "Pais");
            pacienteService.AgregarPaciente(paciente);

            // Act
            controlador.AgregarDiagnostico(12345, "Gripe");
            var diagnosticoId = paciente.HistoriaClinica.Diagnosticos[0].Id;
            controlador.AgregarEvolucion(12345, diagnosticoId, "Evolución positiva");

            // Assert
            Assert.Single(paciente.HistoriaClinica.Diagnosticos[0].Evoluciones);
            Assert.Equal("Evolución positiva", paciente.HistoriaClinica.Diagnosticos[0].Evoluciones[0].Informe);
        }
        [Fact]
        public void AgregarEvolucionDiagnosticoNoEncontradoExcepcion()
        {
            // Arrange
            var repositorio = new PacientesRepository();
            var pacienteService = new PacienteService(repositorio);
            var controlador = new ClinicaController(pacienteService);

            var paciente = new Paciente(1, 12345, DateTime.Now, "email@test.com", 123456, "Juan", "OSDE", "123", "Calle", "Ciudad", "Provincia", "Pais");
            pacienteService.AgregarPaciente(paciente);

            var diagnosticoIdInexistente = Guid.NewGuid();

            // Act & Assert
            Assert.Throws<Exception>(() => controlador.AgregarEvolucion(12345, diagnosticoIdInexistente, "Evolución nueva"));
        }
        [Fact]
        public void AgregarEvolucionMultiplesEvoluciones()
        {
            // Arrange
            var repositorio = new PacientesRepository();
            var pacienteService = new PacienteService(repositorio);
            var controlador = new ClinicaController(pacienteService);

            var paciente = new Paciente(1, 12345, DateTime.Now, "email@test.com", 123456, "Juan", "OSDE", "123", "Calle", "Ciudad", "Provincia", "Pais");
            paciente.AgregarDiagnostico("Diabetes");
            var diagnosticoId = paciente.HistoriaClinica.Diagnosticos[0].Id;

            pacienteService.AgregarPaciente(paciente);

            // Act
            controlador.AgregarEvolucion(12345, diagnosticoId, "Primera evolución");
            controlador.AgregarEvolucion(12345, diagnosticoId, "Segunda evolución");

            // Assert
            Assert.Equal(2, paciente.HistoriaClinica.Diagnosticos[0].Evoluciones.Count);
            Assert.Equal("Segunda evolución", paciente.HistoriaClinica.Diagnosticos[0].Evoluciones[1].Informe);
        }

        [Fact]
        public void AgregarEvolucionSinDiagnosticoLanzarExcepcion()
        {
            // Arrange
            var repositorio = new PacientesRepository();
            var pacienteService = new PacienteService(repositorio);
            var controlador = new ClinicaController(pacienteService);

            var paciente = new Paciente(1, 12345, DateTime.Now, "email@test.com", 123456, "Juan", "OSDE", "123", "Calle", "Ciudad", "Provincia", "Pais");
            pacienteService.AgregarPaciente(paciente);

            // Act & Assert
            Assert.Throws<Exception>(() => controlador.AgregarEvolucion(12345, Guid.NewGuid(), "Evolución sin diagnóstico"));
        }
    }
}
