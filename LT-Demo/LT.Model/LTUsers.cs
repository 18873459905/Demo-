namespace LT.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LTUsers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LTUsers()
        {
            LTUsersAddrs = new HashSet<LTUsersAddrs>();
            LTUsersInfos = new HashSet<LTUsersInfos>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(11)]
        public string UsersAcount { get; set; }

        [Required]
        [StringLength(50)]
        public string UsersPwd { get; set; }

        public int UsersStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LTUsersAddrs> LTUsersAddrs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LTUsersInfos> LTUsersInfos { get; set; }
    }
}
