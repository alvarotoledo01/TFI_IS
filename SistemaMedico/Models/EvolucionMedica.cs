namespace SistemaMedicoV3.Models
{
    public class EvolucionMedica
    {
        public string Informe { get; set; }
        public DateTime Fecha { get; set; }

        public EvolucionMedica(string informe)
        {
            Informe = informe;
            Fecha = DateTime.Now;
        }

        public void AgregarRecetaDigital( )
        {
           // RecetaDigital receta = new RecetaDigital(); 
        }

        public void AgregarPedidoLAboratorio()
        {
           // PedidosLaboratorio pedido = new PedidosLaboratorio();

        }
    }
}
