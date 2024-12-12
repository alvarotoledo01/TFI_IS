namespace SistemaMedicoV3.Models
{
    public class RecetaDigital
    {
        public DateTime Fecha { get; private set; }
        public string NombrePaciente { get; private set; }
        public string ObraSocial { get; private set; }
        public string NumeroAfiliado { get; private set; }
        public string CodigoBarras { get; private set; }
        public string Medicamento { get; private set; }
        public string Diagnostico { get; private set; }
        public string FirmaElectronica { get; private set; }
        public string QR { get; private set; }
        public bool Anulada { get; private set; }

        public RecetaDigital(string nombrePaciente, string obraSocial, string numeroAfiliado,
                             string medicamento, string diagnostico, string firmaElectronica,
                             string qr)
        {
            Fecha = DateTime.Now;
            NombrePaciente = nombrePaciente;
            ObraSocial = obraSocial;
            NumeroAfiliado = numeroAfiliado;
            CodigoBarras = Guid.NewGuid().ToString();
            Medicamento = medicamento;
            Diagnostico = diagnostico;
            FirmaElectronica = firmaElectronica;
            QR = qr;
            Anulada = false;
        }
        public void AnularReceta()
        {
            Anulada = true;
        }
    }
}
