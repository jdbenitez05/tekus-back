using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tekus.Models
{
    public partial class ServicesClient
    {
        public ServicesClient()
        {
            CountriesService = new HashSet<CountriesService>();
        }

        public int ServiceClientId { get; set; }
        [ForeignKey("Clients")]
        public int ClientId { get; set; }

        [ForeignKey("Services")]
        public int ServiceId { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime? TimeUpdated { get; set; }

        public Clients Client { get; set; }
        public Services Service { get; set; }
        public ICollection<CountriesService> CountriesService { get; set; }
    }
}
