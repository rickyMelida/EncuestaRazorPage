using EncuestaRazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EncuestaRazorPage.Pages
{
    public class TagHelpersModel : PageModel
    {
        [DataType(DataType.EmailAddress)]
        [Required]
        [Display(Name="Correo Electrónico")]
        public string CorreoElectronico { get; set; }
        public List<SelectListItem> Numeros = Enumerable.Range(1, 10)
                                                 .Select(n => new SelectListItem
                                                 {
                                                     Value = n.ToString(),
                                                     Text = n.ToString()
                                                 }).ToList();

        public int NumeroSeleccionado { get; set; } = 5;

        [BindProperty]
        public int PersonaSeleccionada { get; set; }
        public List<Persona> Personas { get; set; }
        public EstadoDocumento Estado { get; set; }

        [MinLength(5)]
        [MaxLength(200)]
        public string Observaciones { get; set; }

        public void OnGet()
        {
            Personas = new List<Persona>
            {
                new Persona { Id = 1, Nombre = "Jorge" },
                new Persona { Id = 2, Nombre = "Dario" },
                new Persona { Id = 3, Nombre = "Mario" },
                new Persona { Id = 4, Nombre = "Joel" },
            };
        }

    }
}
