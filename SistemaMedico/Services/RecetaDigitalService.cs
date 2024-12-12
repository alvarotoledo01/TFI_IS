using SistemaMedicoV3.Models;

namespace SistemaMedico.Services
{
    public class RecetaDigitalService
    {
        private readonly MedicamentoService _medicamentoService;
        private readonly ObraSocialService _obraSocialService;
        private readonly List<RecetaDigital> _recetas = new List<RecetaDigital>();

        public RecetaDigitalService()
        {
            _medicamentoService = new MedicamentoService();
            _obraSocialService = new ObraSocialService();
        }

        public async Task<string> CrearReceta(Paciente paciente, string medicamento, string diagnostico, string firma, string qr)
        {
            bool medicamentoValido = await _medicamentoService.ValidarMedicamento(medicamento);
            if (!medicamentoValido)
            {
                return "El medicamento no esta registrado";
            }

            bool obraSocialValida = await _obraSocialService.ValidarObraSocial(paciente.ObraSocial);
            if (!obraSocialValida)
            {
                return "La obra social no esta registrada";
            }

            var receta = new RecetaDigital(
                paciente.NombreCompleto,
                paciente.ObraSocial,
                paciente.NroAfiliado,
                medicamento,
                diagnostico,
                firma,
                qr
            );

            _recetas.Add(receta);
            return "Receta creada exitosamente.";
        }

        public void AnularReceta(string codigoBarras)
        {
            var receta = _recetas.FirstOrDefault(r => r.CodigoBarras == codigoBarras);
            if (receta != null)
            {
                receta.AnularReceta();
            }
        }

        public List<RecetaDigital> ObtenerHistorialRecetas(int dni)
        {
            return _recetas.Where(r => r.NombrePaciente == dni.ToString()).ToList();
        }
    }
}
