namespace ML
{
    public class Libro
    {
        public int IdLibro { get; set; }
        public ML.Autor Autor { get; set; }
        public string Titulo { get; set; }
        public string AñoPublicacion { get; set; }
        public string Editorial  { get; set; }
        public List<object> Libros { get; set; }
    }
}