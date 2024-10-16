﻿using System;
using System.Collections.Generic;

namespace ASP.NET_Core_MVC_Practical.Models;

public partial class Movie
{
    public int MovieId { get; set; }

    public string Title { get; set; } = null!;

    public int? ReleaseYear { get; set; }

    public decimal? Rating { get; set; }

    public int? DirectorId { get; set; }

    public int? GenreId { get; set; }

    public virtual Director? Director { get; set; }

    public virtual Genre? Genre { get; set; }
}
