namespace Toyshops.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class toy
    {
       
        [StringLength(50)]
        public string id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [Column("Toy")]
        [StringLength(50)]
        public string Toy1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? age { get; set; }
    }
}
