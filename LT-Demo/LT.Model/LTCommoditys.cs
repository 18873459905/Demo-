namespace LT.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LTCommoditys
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LTCommoditys()
        {
            CommodityImages = new HashSet<CommodityImages>();
            ShopOrdersInfos = new HashSet<ShopOrdersInfos>();
        }

        public int Id { get; set; }

        public int? ShopsId { get; set; }

        [Required]
        [StringLength(100)]
        public string CommodityName { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public int Inventory { get; set; }

        [Required]
        [StringLength(200)]
        public string CommodityImage { get; set; }

        public int TypeId { get; set; }

        public DateTime PublishTime { get; set; }

        public int PublishStatus { get; set; }

        [StringLength(200)]
        public string Descript { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommodityImages> CommodityImages { get; set; }

        public virtual Shops Shops { get; set; }

        public virtual LTCommodityTypes LTCommodityTypes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShopOrdersInfos> ShopOrdersInfos { get; set; }
    }
}
