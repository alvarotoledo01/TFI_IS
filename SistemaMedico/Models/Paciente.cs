namespace SistemaMedicoV3.Models
{
    public class Paciente
    {
        public long CUIL { get; set; }
        public int DNI { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        public string NombreCompleto { get; set; }
        public string ObraSocial { get; set; }
        public string NroAfiliado { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public string Pais { get; set; }
        public HistoriaClinica HistoriaClinica { get; private set; }
        public Paciente() { }

        public Paciente(long cuil, int dni, DateTime fechaNacimiento, string email, int telefono, string nombreCompleto,
                        string obraSocial, string nroAfiliado, string direccion, string localidad, string provincia, string pais)
        {
            CUIL = cuil;
            DNI = dni;
            FechaNacimiento = fechaNacimiento;
            Email = email;
            Telefono = telefono;
            NombreCompleto = nombreCompleto;
            ObraSocial = obraSocial;
            NroAfiliado = nroAfiliado;
            Direccion = direccion;
            Localidad = localidad;
            Provincia = provincia;
            Pais = pais;
            HistoriaClinica = new HistoriaClinica(dni);

        }

        public void AgregarEvolucion(Guid idDiagnostico, string informe)
        {
            this.HistoriaClinica.AgregarEvolucion(idDiagnostico, informe);
        }

        public void AgregarDiagnostico(string enfermedad)
        {
            this.HistoriaClinica.AgregarDiagnostico(enfermedad);
        }
    }
}
