using System;
using System.Collections.Generic;

namespace Tekus.Models
{
    public partial class CountriesService
    {
        public int CountryServiceId { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime? TimeUpdated { get; set; }
        public int ServiceClientId { get; set; }
        public int CountryId { get; set; }

        public Countries Country { get; set; }
        public ServicesClient ServiceClient { get; set; }
    }
}
