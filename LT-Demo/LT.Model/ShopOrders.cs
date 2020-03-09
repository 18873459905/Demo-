namespace LT.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ShopOrders
    {
        public int Id { get; set; }

        public int? OrderId { get; set; }

        [Required]
        [StringLength(100)]
        public string OrderSn { get; set; }

        public int CustomerId { get; set; }

        [Required]
        [StringLength(10)]
        public string ShipingUser { get; set; }

        [Required]
        [StringLength(300)]
        public string Address { get; set; }

        [Required]
        [StringLength(11)]
        public string TelPhone { get; set; }

        public int PayMethod { get; set; }

        [Column(TypeName = "money")]
        public decimal PayMoney { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime? ShippingTime { get; set; }

        public DateTime? ReceiveTime { get; set; }

        public int OrderStatus { get; set; }

        [StringLength(10)]
        public string ShippingCompName { get; set; }

        [StringLength(50)]
        public string ShippingNo { get; set; }

        public virtual ShopOrdersInfos ShopOrdersInfos { get; set; }
    }
}
