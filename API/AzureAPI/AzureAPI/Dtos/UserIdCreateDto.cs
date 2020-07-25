using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AzureAPI.Dtos {
    public class UserIdCreateDto { 
        [Required]
        [Column("fname")]
        [StringLength(20)]
    public string Fname { get; set; }
        [Required]
        [Column("lname")]
        [StringLength(20)]
        public string Lname { get; set; }
        [Required]
        [Column("phone")]
        [StringLength(14)]
        public string Phone { get; set; }
        [Column("email")]
        [StringLength(100)]
        [Required]
        public string Email { get; set; }
        [Column("location")]
        [StringLength(150)]
        public string Location { get; set; }
        [Required]
        [Column("password")]
        [StringLength(128)]
        public string Password { get; set; }
        [Required]
        [Column("salt")]
        [StringLength(70)]
        public string Salt { get; set; }
    }
}
