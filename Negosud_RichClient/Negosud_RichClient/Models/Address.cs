using System;
using System.Collections.Generic;

#nullable disable

namespace Negosud_RichClient.Models
{
    public partial class Address
    {
        public Address()
        {
            AddressUsers = new HashSet<AddressUser>();
            Clients = new HashSet<Client>();
            Suppliers = new HashSet<Supplier>();
        }

        public int Id { get; set; }
        public string StreetNumber { get; set; }
        public string WayType { get; set; }
        public string StreetName { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public virtual ICollection<AddressUser> AddressUsers { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
