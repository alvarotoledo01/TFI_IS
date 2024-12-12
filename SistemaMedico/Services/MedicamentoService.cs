namespace SistemaMedico.Services
{
    public class MedicamentoService
    {
        private readonly HttpClient _httpClient;

        public MedicamentoService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<string>> ObtenerTodosLosMedicamentos()
        {
            string url = "https://istp1service.azurewebsites.net/api/servicio-salud/medicamentos/todos";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var contenido = await response.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(contenido);
            }
            return new List<string>();
        }

        public async Task<bool> ValidarMedicamento(string nombreMedicamento)
        {
            var medicamentos = await ObtenerTodosLosMedicamentos();
            return medicamentos.Contains(nombreMedicamento, StringComparer.OrdinalIgnoreCase);
        }
    }
}
