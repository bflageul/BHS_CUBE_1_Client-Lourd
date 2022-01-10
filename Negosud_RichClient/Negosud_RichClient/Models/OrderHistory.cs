using System;
using System.Collections.Generic;

#nullable disable

namespace Negosud_RichClient.Models
{
    public partial class OrderHistory
    {
        public int UsersId { get; set; }
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
        public virtual User Users { get; set; }
    }
}
