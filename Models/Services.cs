using System;
using System.Collections.Generic;

namespace Tekus.Models
{
    public partial class Services
    {
        public Services()
        {
            ServicesClient = new HashSet<ServicesClient>();
        }

        public int ServiceId { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime? TimeUpdated { get; set; }

        public ICollection<ServicesClient> ServicesClient { get; set; }
    }
}
