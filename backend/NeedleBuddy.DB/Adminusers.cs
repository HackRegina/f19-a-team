using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeedleBuddy.DB
{
    [Table("adminusers")]
    public partial class Adminusers
    {
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("username")]
        [StringLength(64)]
        public string Username { get; set; }
        [Required]
        [StringLength(64)]
        public string Password { get; set; }
        [StringLength(12)]
        public string Role { get; set; }
    }
}
