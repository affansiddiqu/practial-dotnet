using System;
using System.Collections.Generic;

namespace ASP.NET_Core_MVC_Practical.Models;

public partial class Genre
{
    public int GenreId { get; set; }

    public string GenreName { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
