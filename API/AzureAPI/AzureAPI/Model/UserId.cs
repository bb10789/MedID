using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureAPI.Model
{
    [Table("UserID")]
    public partial class UserId
    {
        public UserId()
        {
            //InteractionId1Navigation = new HashSet<Interaction>();

            //InteractionId2Navigation = new HashSet<Interaction>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
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
        [Required]
        [Column("email")]
        [StringLength(100)]
        public string Email { get; set; }
        [Column("location")]
        [StringLength(150)]
        public string Location { get; set; }

        //[InverseProperty(nameof(Interaction.Id1Navigation))]
        //public virtual ICollection<Interaction> InteractionId1Navigation { get; set; }
        //[InverseProperty(nameof(Interaction.Id2Navigation))]
        //public virtual ICollection<Interaction> InteractionId2Navigation { get; set; }
    }
}
