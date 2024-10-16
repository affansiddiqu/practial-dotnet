using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ASP.NET_Core_MVC_Practical.Models;

public partial class Director
{
    public int DirectorId { get; set; }

    [DisplayName("Director Name")]
    public string DirectorName { get; set; } = null!;

    public string Country { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
