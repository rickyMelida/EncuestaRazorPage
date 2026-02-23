using EncuestaRazorPage.Models;
using EncuestaRazorPage.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EncuestaRazorPage.Pages
{
    public class ResultadosModel : PageModel
    {
        private readonly IServicioEncuestas _servicioEncuestas;
        public List<Encuesta> Encuestas { get; set; }

        public ResultadosModel(IServicioEncuestas servicioEncuentas)
        {
            _servicioEncuestas = servicioEncuentas;
        }
        
        public void OnGet()
        {
            Encuestas = _servicioEncuestas.Encuestas.ToList();
        }
    }
}
