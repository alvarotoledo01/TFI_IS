namespace SistemaMedico.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<bool> ValidarMedicamento(string nombreMedicamento)
        {
            string url = $"https://istp1service.azurewebsites.net/api/servicio-salud/medicamentos?nombre={nombreMedicamento}";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var contenido = await response.Content.ReadAsStringAsync();
                return !string.IsNullOrEmpty(contenido);
            }
            return false;
        }
    }
}
