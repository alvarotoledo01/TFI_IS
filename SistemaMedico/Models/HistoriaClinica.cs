namespace SistemaMedicoV3.Models
{
    public class HistoriaClinica
    {
        public int DNI { get; private set; }
        public List<Diagnostico> Diagnosticos { get; set; }

        public HistoriaClinica(int dni)
        {
            DNI = dni;
            Diagnosticos = new List<Diagnostico>();
        }

        public void AgregarDiagnostico(string enfermedad)
        {
            Diagnostico diagnostico = new Diagnostico(enfermedad);
            Diagnosticos.Add(diagnostico);
        }

        public void AgregarEvolucion(Guid idDiagnostico, string informe)
        {
            var diagnostico = Diagnosticos.FirstOrDefault(d => d.Id == idDiagnostico);
            if (diagnostico == null)
            {
                throw new Exception($"Diagnóstico con ID {idDiagnostico} no encontrado.");
            }

            diagnostico.AgregarEvolucion(informe);
        }


        //repasar el patron creador
    }
}
