namespace Toyshops.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("shop")]
    public partial class shop
    {
        [StringLength(10)]
        public string id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Toys { get; set; }

        [StringLength(50)]
        public string Categories { get; set; }
    }
}
