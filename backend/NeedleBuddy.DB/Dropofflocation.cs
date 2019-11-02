using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeedleBuddy.DB
{
    [Table("dropofflocation")]
    public partial class Dropofflocation
    {
        [Column("description")]
        [StringLength(1000)]
        public string Description { get; set; }
        [Column("isinsidebuilding")]
        public bool? Isinsidebuilding { get; set; }
        [Column("location_lat")]
        public double? LocationLat { get; set; }
        [Column("location_long")]
        public double? LocationLong { get; set; }
    }
}
