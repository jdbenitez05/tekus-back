using System;
using System.Collections.Generic;

namespace Tekus.Models
{
    public partial class Countries
    {
        public Countries()
        {
            CountriesService = new HashSet<CountriesService>();
        }

        public int CountryId { get; set; }
        public string Name { get; set; }

        public ICollection<CountriesService> CountriesService { get; set; }
    }
}
