using System;
using System.Collections.Generic;

#nullable disable

namespace Negosud_RichClient.Models
{
    public partial class Employee
    {
        public int UsersId { get; set; }
        public string Position { get; set; }

        public virtual User Users { get; set; }
    }
}
