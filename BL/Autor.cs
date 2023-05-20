using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Autor
    {
        public static ML.Autor GetAll()
        {

            ML.Autor autor= new ML.Autor();
            try
            {
                using (DL.EmaquedaKranonContext context = new DL.EmaquedaKranonContext())
                {
                    var query = context.Autors.FromSqlRaw($"AutorGetAll").ToList();
                    if (query != null)
                    {

                        autor.Autores = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.Autor autotemp= new ML.Autor();
                            autotemp.IdAutor = obj.IdAutor;
                            autotemp.Nombre = obj.Nombre;

                            autor.Autores.Add(autotemp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return autor;
        }
    }
}
