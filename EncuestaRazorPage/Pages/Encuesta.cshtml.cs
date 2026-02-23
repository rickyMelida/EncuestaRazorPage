using EncuestaRazorPage.Models;
using EncuestaRazorPage.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EncuestaRazorPage.Pages
{
    public class EncuestaModel : PageModel
    {
        private readonly IServicioEncuestas _servicioEncuestas;
        [BindProperty]
        public Encuesta Encuesta { get; set; }

        public EncuestaModel(IServicioEncuestas servicioEncuestas)
        {
            _servicioEncuestas = servicioEncuestas;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _servicioEncuestas.Agregar(Encuesta);

            return RedirectToPage("Gracias");
        }
    }
}
