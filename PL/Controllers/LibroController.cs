using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace PL.Controllers
{
    public class LibroController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var sesion = HttpContext.Session.GetString("Libro");
            ML.Autor autor = BL.Autor.GetAll();

			if (sesion == null)
            {
				ML.Libro libro = BL.Libro.GetAll();
				autor.Libros = libro.Libros;
			}
            else {
                autor.Libros = new List<object>();
				var str = HttpContext.Session.GetString("Libro");
				var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ML.Libro>>(str);
                HttpContext.Session.Remove("Libro");
                foreach (ML.Libro item in obj)
                {
                    autor.Libros.Add(item);
                }
            
            }
            
            return View(autor);
        }

        [HttpGet]

        public IActionResult BusquedaAutor(string? autor) {
            if (autor == null)
            {
				return RedirectToAction("Index");
			}
            else {
				ML.Autor autortemp = new ML.Autor();
				ML.Libro libro = BL.Libro.GetByAutor(autor);
				autortemp.Libros = libro.Libros;
				HttpContext.Session.SetString("Libro", JsonConvert.SerializeObject(autortemp.Libros));
				return RedirectToAction("Index");

			}
			
        }

		public IActionResult BusquedaTitulo(string? titulo)
		{
			if (titulo == null)
			{
				return RedirectToAction("Index");
			}
			else
			{
				ML.Autor autortemp = new ML.Autor();
				ML.Libro libro = BL.Libro.GetByTitulo(titulo);
				autortemp.Libros = libro.Libros;
				HttpContext.Session.SetString("Libro", JsonConvert.SerializeObject(autortemp.Libros));
				return RedirectToAction("Index");

			}

		}

	}
}
