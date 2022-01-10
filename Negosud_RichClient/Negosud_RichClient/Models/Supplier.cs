using System;
using System.Collections.Generic;

#nullable disable

namespace Negosud_RichClient.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public int AddressId { get; set; }
        public string Legal { get; set; }
        public string SocialReason { get; set; }
        public string Siret { get; set; }
        public string ApeNaf { get; set; }
        public string Tva { get; set; }
        public string Manager { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
