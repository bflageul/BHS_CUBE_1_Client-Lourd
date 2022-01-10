using System;
using System.Collections.Generic;

#nullable disable

namespace Negosud_RichClient.Models
{
    public partial class ProductOrdered
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
