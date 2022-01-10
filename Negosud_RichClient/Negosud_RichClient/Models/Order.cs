using System;
using System.Collections.Generic;

#nullable disable

namespace Negosud_RichClient.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderHistories = new HashSet<OrderHistory>();
            ProductOrdereds = new HashSet<ProductOrdered>();
        }

        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public virtual Product Product { get; set; }
        public virtual ICollection<OrderHistory> OrderHistories { get; set; }
        public virtual ICollection<ProductOrdered> ProductOrdereds { get; set; }
    }
}
