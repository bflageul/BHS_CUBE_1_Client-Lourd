using System;
using System.Collections.Generic;

#nullable disable

namespace Negosud_RichClient.Models
{
    public partial class Product
    {
        public Product()
        {
            GrapeRates = new HashSet<GrapeRate>();
            Orders = new HashSet<Order>();
            ProductOrdereds = new HashSet<ProductOrdered>();
        }

        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int AlcoholId { get; set; }
        public string Name { get; set; }
        public bool? Stock { get; set; }
        public string Description { get; set; }
        public string Medal { get; set; }
        public int? YearOrAge { get; set; }
        public bool? Cubitainer { get; set; }

        public virtual Alcohol Alcohol { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<GrapeRate> GrapeRates { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ProductOrdered> ProductOrdereds { get; set; }
    }
}
