namespace LT.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ShopOrdersInfos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ShopOrdersInfos()
        {
            ShopOrders = new HashSet<ShopOrders>();
        }

        public int Id { get; set; }

        public int? UsersId { get; set; }

        public int? CommodityId { get; set; }

        public int? ShopId { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(200)]
        public string ProductImages { get; set; }

        public int ProductCount { get; set; }

        [Required]
        [StringLength(10)]
        public string ProductRize { get; set; }

        [Required]
        [StringLength(10)]
        public string ProductColor { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalPrices { get; set; }

        public virtual LTCommoditys LTCommoditys { get; set; }

        public virtual LTUsersInfos LTUsersInfos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShopOrders> ShopOrders { get; set; }

        public virtual Shops Shops { get; set; }
    }
}
