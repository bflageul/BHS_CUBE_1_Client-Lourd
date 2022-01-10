using System;
using System.Collections.Generic;

#nullable disable

namespace Negosud_RichClient.Models
{
    public partial class GrapeVariety
    {
        public GrapeVariety()
        {
            GrapeRates = new HashSet<GrapeRate>();
        }

        public int Id { get; set; }
        public string Color { get; set; }
        public string GrapeName { get; set; }

        public virtual ICollection<GrapeRate> GrapeRates { get; set; }
    }
}
