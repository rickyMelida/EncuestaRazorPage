namespace EncuestaRazorPage.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public enum EstadoDocumento
    {
        Iniciado = 1,
        EnRevision = 2,
        Rechazado = 3,
        Cancelado = 4,
        Aprobado = 5,
    }
}

