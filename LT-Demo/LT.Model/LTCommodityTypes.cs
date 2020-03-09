namespace LT.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LTCommodityTypes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LTCommodityTypes()
        {
            LTCommoditys = new HashSet<LTCommoditys>();
            LTCommodityTypes1 = new HashSet<LTCommodityTypes>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(200)]
        public string CommodityDesc { get; set; }

        public int CostLevel { get; set; }

        public int SumLevel { get; set; }

        public int ParentId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LTCommoditys> LTCommoditys { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LTCommodityTypes> LTCommodityTypes1 { get; set; }

        public virtual LTCommodityTypes LTCommodityTypes2 { get; set; }
    }
}
