using System;
using System.Collections.Generic;

namespace Tekus.Models
{
    public partial class Clients
    {
        public Clients()
        {
            ServicesClient = new HashSet<ServicesClient>();
        }

        public int ClientId { get; set; }
        public string Nit { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime? TimeUpdated { get; set; }

        public ICollection<ServicesClient> ServicesClient { get; set; }
    }
}
