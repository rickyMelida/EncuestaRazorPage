using EncuestaRazorPage.Models;

namespace EncuestaRazorPage.Servicios
{
    public interface IServicioEncuestas
    {
        List<Encuesta> Encuestas { get; set; }
        void Agregar(Encuesta encuesta);
    }
}
