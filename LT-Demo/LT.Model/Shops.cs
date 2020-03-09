namespace LT.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Shops
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Shops()
        {
            LTCommoditys = new HashSet<LTCommoditys>();
            ShopImgs = new HashSet<ShopImgs>();
            ShopOrdersInfos = new HashSet<ShopOrdersInfos>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string ShopLog { get; set; }

        [StringLength(200)]
        public string BackgroundImage { get; set; }

        [Required]
        [StringLength(30)]
        public string ShowName { get; set; }

        [Required]
        [StringLength(200)]
        public string SzaiAddress { get; set; }

        public int ShopNum { get; set; }

        public int? CollectNum { get; set; }

        public int? SalesNum { get; set; }

        public DateTime CreationTime { get; set; }

        [StringLength(30)]
        public string CompanyName { get; set; }

        [StringLength(200)]
        public string Descript { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LTCommoditys> LTCommoditys { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShopImgs> ShopImgs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShopOrdersInfos> ShopOrdersInfos { get; set; }
    }
}
