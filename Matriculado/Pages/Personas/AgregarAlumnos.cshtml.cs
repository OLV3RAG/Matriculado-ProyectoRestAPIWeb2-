using Aplicacion;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Matriculado.Pages.Personas
{
    public class AgregarAlumnosModel : PageModel
    {
        [TempData]
        public bool showModal { get; set; }
        [BindProperty]
        public int TipoPersonaSeleccionado { get; set; }
        public SelectList TipoPersonaas { get; set; }

        [BindProperty]
        public int GeneroSeleccionado { get; set; }

        public SelectList Generoos { get; set; }

        [BindProperty]
        public Persona persona { get; set; }

        public AgregarAlumnosModel()
        {
            GetGenero();
            GetTipoPersona();
        }

        public async Task OnPostAsync()
        {
            GetGenero();
            GetTipoPersona();
        }
        public async Task<IActionResult> OnPostPersonas()
        {
            GetGenero();
            GetTipoPersona();       
            if (!ModelState.IsValid)
            {
                return Page();
            }
            ;
            List<Registros> per = new List<Registros>();
            AlumnoNegocio alNeg = new AlumnoNegocio();
            per = await alNeg.RegistrarInfo(persona);
            return Page();
        }

        public async Task GetGenero()
        {
            List<Genero> gene = new List<Genero>();
            List<SelectListItem> selectIt = new List<SelectListItem>();
            SelectListItem select = new SelectListItem();
            AlumnoNegocio alNeg = new AlumnoNegocio();
            gene = await alNeg.CargarGen();
            foreach (var gen in gene)
            {
                select = new SelectListItem
                {
                    Value = gen.id.ToString(),
                    Text = gen.descripcion
                };
                selectIt.Add(select);
            }
            Generoos = new SelectList(selectIt, "Value", "Text");
        }

        public async Task GetTipoPersona()
        {
            List<TipoPersona> tipoPer = new List<TipoPersona>();
            List<SelectListItem> selectIt = new List<SelectListItem>();
            SelectListItem select = new SelectListItem();
            AlumnoNegocio alNeg = new AlumnoNegocio();
            tipoPer = await alNeg.CargarTipoPer();
            foreach (var tp in tipoPer)
            {
                select = new SelectListItem
                {
                    Value = tp.id.ToString(),
                    Text = tp.descripcion
                };
                selectIt.Add(select);
            }
            TipoPersonaas = new SelectList(selectIt, "Value", "Text");
        }
    }
}
