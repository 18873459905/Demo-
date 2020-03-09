namespace LT.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LTUsersAddrs
    {
        public int Id { get; set; }

        public int CustomerLoginId { get; set; }

        public short ZipCode { get; set; }

        [Required]
        [StringLength(200)]
        public string UserAddress { get; set; }

        public bool IsDefault { get; set; }

        public virtual LTUsers LTUsers { get; set; }
    }
}
