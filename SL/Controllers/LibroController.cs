using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    public class LibroController : Controller
    {
       
        [Route("Api/LibroAdd")]
        [HttpPost]
        public IActionResult LibroAdd([FromBody]ML.Libro libro)
        {
            bool correct=BL.Libro.Add(libro);
            var respone = new { estatus = "Completado", Mensaje = "Libro Agregado Correctamente" };
            if (correct == true)
            {
                return Ok(respone);
            }
            else { 
                return NotFound();
            }
            
        }

        [Route("Api/LibroGetByAutor/{Autor}")]
        [HttpGet]
        public IActionResult LibroGetByAutor(string Autor) {
            ML.Libro libro=BL.Libro.GetByAutor(Autor);
            if (libro.Libros.Count > 0)
            {
                return Ok(libro);
            }
            else { 
                return NotFound();
            }
        }
        
        [Route("Api/LibroGetByTitulo/{Titulo}")]
        [HttpGet]
        public IActionResult LibroGetByTitulo(string Titulo) {
            ML.Libro libro = BL.Libro.GetByTitulo(Titulo);
            if (libro.Libros.Count > 0)
            {
                return Ok(libro);
            }
            else { 
                return NotFound();
            }
        }

        [Route("Api/LibroGetByAutorFecha/{Año}/{Autor}")]
        [HttpGet]
        public IActionResult LibroGetByAutorFecha(string Año,string Autor)
        {
            ML.Libro libro = BL.Libro.GetByAutorAndAño(Autor,Año);
            if (libro.Libros.Count>0)
            {
                return Ok(libro);
            }
            else
            {
                return NotFound();
            }
        }
        
        [Route("Api/LigroGetByEditorial/{Editorial}")]
        [HttpGet]
        public IActionResult LibroGetByEditorial(string Editorial) { 
        
            ML.Libro libro=BL.Libro.GetByEditorial(Editorial);
            if (libro.Libros.Count > 0)
            {
                return Ok(libro);
            }
            else {
            
                return NotFound();
            }
        }
        
        [Route("Api/LibroDeleteByAutor/{IdAutor}")]
        [HttpDelete]
        public IActionResult LibroDeleteByAutor(int IdAutor) {

            bool correct = BL.Libro.DeleteByAutor(IdAutor);
            if (correct == true)
            {
                var response = new { Estatus = "Correct", Mensaje = "Libro Borrado Exitosamente" };
                return Ok(response);
            }
            else { 
            
                return NotFound();
            }
          
        }

        [Route("Api/LibroDeleteByEditorial/{Editorial}")]
        [HttpDelete]
        public IActionResult LibroDeleteByEditorial(string Editorial)
        {

            bool correct = BL.Libro.DeleteByEditorial(Editorial);
            if (correct == true)
            {
                var response = new { Estatus = "Correct", Mensaje = "Libro Borrado Exitosamente" };
                return Ok(response);
            }
            else
            {

                return NotFound();
            }

        }
    }
}
