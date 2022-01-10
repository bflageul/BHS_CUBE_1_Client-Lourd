using System;
using System.Collections.Generic;

#nullable disable

namespace Negosud_RichClient.Models
{
    public partial class User
    {
        public User()
        {
            AddressUsers = new HashSet<AddressUser>();
            OrderHistories = new HashSet<OrderHistory>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public byte[] HashPassword { get; set; }

        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<AddressUser> AddressUsers { get; set; }
        public virtual ICollection<OrderHistory> OrderHistories { get; set; }
    }
}
