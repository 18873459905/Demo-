namespace LT.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LTUsersInfos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LTUsersInfos()
        {
            ShopOrdersInfos = new HashSet<ShopOrdersInfos>();
        }

        public int Id { get; set; }

        public int UsersLoginId { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public DateTime? Birthday { get; set; }

        [Required]
        [StringLength(11)]
        public string TelPhone { get; set; }

        public DateTime CreateTime { get; set; }

        public virtual LTUsers LTUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShopOrdersInfos> ShopOrdersInfos { get; set; }
    }
}
