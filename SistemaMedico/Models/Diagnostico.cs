namespace SistemaMedicoV3.Models
{
    public class Diagnostico
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Enfermedad { get; set; }
        public List<EvolucionMedica> Evoluciones { get; set; }
        public Diagnostico(string enfermedad)
        {
            Enfermedad = enfermedad;
            Evoluciones = new List<EvolucionMedica>();
        }
        public void AgregarEvolucion(string informe)
        {
            Evoluciones.Add(new EvolucionMedica(informe));
        }

        
    }
}
