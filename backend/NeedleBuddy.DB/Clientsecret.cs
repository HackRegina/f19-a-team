using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeedleBuddy.DB
{
    [Table("clientsecret")]
    public partial class Clientsecret
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("clientsecret")]
        [StringLength(64)]
        public string Clientsecret1 { get; set; }
    }
}
