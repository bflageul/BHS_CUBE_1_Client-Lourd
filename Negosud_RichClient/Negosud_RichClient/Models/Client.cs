using System;
using System.Collections.Generic;

#nullable disable

namespace Negosud_RichClient.Models
{
    public partial class Client
    {
        public int UsersId { get; set; }
        public int AddressId { get; set; }
        public string Email { get; set; }

        public virtual Address Address { get; set; }
        public virtual User Users { get; set; }
    }
}
