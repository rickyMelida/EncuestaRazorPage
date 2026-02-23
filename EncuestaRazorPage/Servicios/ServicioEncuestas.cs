using EncuestaRazorPage.Models;

namespace EncuestaRazorPage.Servicios
{
    public class ServicioEncuestas : IServicioEncuestas
    {
        public List<Encuesta> Encuestas { get; set; } = new List<Encuesta>();

        public void Agregar(Encuesta encuesta)
        {
            Encuestas.Add(encuesta);
        }
    }
}
