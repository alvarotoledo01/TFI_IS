namespace SistemaMedicoV3.Models
{
    public class Usuario
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        //asigna automáticamente un valor único de tipo Guid a
        //la propiedad Id cuando se crea una instancia de la clase
        public string? Email { get; set; }
        //Como lo obtengo del medico
        public string? Password{ get; set; }
        //Para despues
        //public Medico MedicoAsociado { get; }
        //public Usuario(string Email, Medico medico)
        //{
            
        //    MedicoAsociado = medico ?? throw new ArgumentNullException(nameof(medico));
        //}

    }
}
