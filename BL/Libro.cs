using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Libro
    {
        public static ML.Libro GetAll() {

            ML.Libro libro = new ML.Libro();
            try
            {
                using (DL.EmaquedaKranonContext context=new DL.EmaquedaKranonContext())
                {
                    var query = context.Libros.FromSqlRaw("LibrosGetAll").ToList();
                    if (query!=null)
                    {
                        libro.Libros = new List<object>();
                        foreach (var obj in query)
                        {
							ML.Libro librotemp = new ML.Libro();

                            librotemp.IdLibro = obj.IdLibro;
                            librotemp.AñoPublicacion = obj.AñoPublicacion;
                            librotemp.Editorial = obj.Editorial;
                            librotemp.Titulo = obj.Titulo;
                            librotemp.Autor = new ML.Autor();
                            librotemp.Autor.Nombre = obj.Nombre;

                            libro.Libros.Add(librotemp);
						}
                        
                        
                    }
                }
            }
            catch (Exception )
            {

                throw;
            }

            return libro;
        }
		public static bool Add(ML.Libro libro) {
			bool bandera = false;
            
            try
			{
				using (DL.EmaquedaKranonContext context=new DL.EmaquedaKranonContext())
				{
					int query = context.Database.ExecuteSqlRaw($"LibroAdd '{libro.Autor.Nombre}','{libro.Titulo}','{libro.AñoPublicacion}',{libro.Editorial}");
					if (query>=1)
					{
						bandera= true;
					}
				}
			}
			catch (Exception ex)
			{
				bandera= false;
				throw;
			}
            return bandera;
        }
		
        public static ML.Libro GetByAutor(string autor) { 
		
			ML.Libro libro= new ML.Libro();
			try
			{
				using (DL.EmaquedaKranonContext context=new DL.EmaquedaKranonContext())
				{
					var query = context.Libros.FromSqlRaw($"LibroGetByAutor '{autor}'").ToList();
					if (query!=null)
					{
						
						libro.Libros = new List<object>();
						foreach (var obj in query)
						{
                            ML.Libro librotemp = new ML.Libro();
                            librotemp.IdLibro = obj.IdLibro;
							librotemp.Autor = new ML.Autor();
							librotemp.Autor.IdAutor = obj.IdAutor.Value;
							librotemp.Titulo = obj.Titulo;
							librotemp.AñoPublicacion = obj.AñoPublicacion;
							librotemp.Editorial = obj.Editorial;
							
							libro.Libros.Add(librotemp);
						}
					}
				}
			}
			catch (Exception ex)
			{
				
				throw;
			}
			return libro;
		}

        public static ML.Libro GetByTitulo(string titulo)
        {

            ML.Libro libro = new ML.Libro();
            try
            {
                using (DL.EmaquedaKranonContext context = new DL.EmaquedaKranonContext())
                {
                    var query = context.Libros.FromSqlRaw($"LibroGetByTitulo '{titulo}'").ToList();
                    if (query != null)
                    {
                        
                        libro.Libros = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.Libro librotemp = new ML.Libro();
                            librotemp.IdLibro = obj.IdLibro;
                            librotemp.Autor = new ML.Autor();
                            librotemp.Autor.IdAutor = obj.IdAutor.Value;
                            librotemp.Titulo = obj.Titulo;
                            librotemp.AñoPublicacion = obj.AñoPublicacion;
                            librotemp.Editorial = obj.Editorial;

                            libro.Libros.Add(librotemp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return libro;
        }

        public static ML.Libro GetByAutorAndAño(string autor,string año)
        {

            ML.Libro libro = new ML.Libro();
            try
            {
                using (DL.EmaquedaKranonContext context = new DL.EmaquedaKranonContext())
                {
                    var query = context.Libros.FromSqlRaw($"LibroGetByAñoAutor '{año}','{autor}'").ToList();
                    if (query != null)
                    {
                       
                        libro.Libros = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.Libro librotemp = new ML.Libro();
                            librotemp.IdLibro = obj.IdLibro;
                            librotemp.Autor = new ML.Autor();
                            librotemp.Autor.IdAutor = obj.IdAutor.Value;
                            librotemp.Titulo = obj.Titulo;
                            librotemp.AñoPublicacion = obj.AñoPublicacion;
                            librotemp.Editorial = obj.Editorial;

                            libro.Libros.Add(librotemp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return libro;
        }
        
        public static ML.Libro GetByEditorial(string editorial)
        {

            ML.Libro libro = new ML.Libro();
            try
            {
                using (DL.EmaquedaKranonContext context = new DL.EmaquedaKranonContext())
                {
                    var query = context.Libros.FromSqlRaw($"LibroGetByEditorial '{editorial}'").ToList();
                    if (query != null)
                    {
                        
                        libro.Libros = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.Libro librotemp = new ML.Libro();
                            librotemp.IdLibro = obj.IdLibro;
                            librotemp.Autor = new ML.Autor();
                            librotemp.Autor.IdAutor = obj.IdAutor.Value;
                            librotemp.Titulo = obj.Titulo;
                            librotemp.AñoPublicacion = obj.AñoPublicacion;
                            librotemp.Editorial = obj.Editorial;

                            libro.Libros.Add(librotemp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return libro;
        }

        public static bool DeleteByAutor(int idautor)
        {

            bool bandera=false;
            try
            {
                using (DL.EmaquedaKranonContext context = new DL.EmaquedaKranonContext())
                {
                    int query = context.Database.ExecuteSqlRaw($"LibroDeleteAutor {idautor}");
                    if (query>=1)
                    {
                        bandera=true;
                    }
                }
            }
            catch (Exception ex)
            {
                bandera=false;
            }
            return bandera;
        }

        public static bool DeleteByEditorial(string editorial)
        {

            bool bandera = false;
            try
            {
                using (DL.EmaquedaKranonContext context = new DL.EmaquedaKranonContext())
                {
                    int query = context.Database.ExecuteSqlRaw($"LibroDeleteEditorial '{editorial}'");
                    if (query >= 1)
                    {
                        bandera = true;
                    }
                }
            }
            catch (Exception ex)
            {
                bandera = false;
            }
            return bandera;
        }
    }
}