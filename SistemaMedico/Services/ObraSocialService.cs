namespace SistemaMedico.Services
{
    public class ObraSocialService
    {
        private readonly HttpClient _httpClient;

        public ObraSocialService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<string>> ObtenerTodasLasObrasSociales()
        {
            string url = "https://istp1service.azurewebsites.net/api/servicio-salud/obras-sociales";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var contenido = await response.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(contenido);
            }
            return new List<string>();
        }

        public async Task<bool> ValidarObraSocial(string nombreObraSocial)
        {
            var obrasSociales = await ObtenerTodasLasObrasSociales();
            return obrasSociales.Contains(nombreObraSocial, StringComparer.OrdinalIgnoreCase);
        }
    }
}
