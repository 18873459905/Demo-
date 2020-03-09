namespace LT.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ShopImgs
    {
        public int Id { get; set; }

        public int? ShopsId { get; set; }

        [Required]
        [StringLength(200)]
        public string PicUrl { get; set; }

        [StringLength(200)]
        public string ImgDescribe { get; set; }

        public virtual Shops Shops { get; set; }
    }
}
