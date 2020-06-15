using FirstSessionWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstSessionWebApp.ViewModels
{
    public class MovieCategoryViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
