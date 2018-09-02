using System;
using System.Collections.Generic;

namespace Tekus.Models
{
    public partial class ServicesClient
    {
        public ServicesClient()
        {
            CountriesService = new HashSet<CountriesService>();
        }

        public int ServiceClientId { get; set; }
        public int ClientId { get; set; }
        public int ServiceId { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime? TimeUpdated { get; set; }

        public Clients Client { get; set; }
        public Services Service { get; set; }
        public ICollection<CountriesService> CountriesService { get; set; }
    }
}
