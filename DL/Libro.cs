using System;
using System.Collections.Generic;

namespace DL;

public partial class Libro
{
    public int IdLibro { get; set; }

    public int? IdAutor { get; set; }

    public string? Titulo { get; set; }

    public string? AñoPublicacion { get; set; }

    public string? Editorial { get; set; }

    public virtual Autor? IdAutorNavigation { get; set; }

    public string Nombre { get; set; }
}
