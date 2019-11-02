using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeedleBuddy.DB
{
    [Table("pickuprequest")]
    public partial class Pickuprequest
    {
        [Column("phone_number")]
        [StringLength(24)]
        public string PhoneNumber { get; set; }
        [Column("description")]
        [StringLength(1000)]
        public string Description { get; set; }
        [Column("count")]
        public int? Count { get; set; }
        [Column("status")]
        [StringLength(8)]
        public string Status { get; set; }
        [Column("location_lat")]
        public double LocationLat { get; set; }
        [Column("location_long")]
        public double LocationLong { get; set; }
        [Column("last_modified", TypeName = "date")]
        public DateTime? LastModified { get; set; }
        [Key]
        [Column("id")]
        public int Id { get; set; }
    }
}
