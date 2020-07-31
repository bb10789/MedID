using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureAPI.Model
{
    [Table("Interaction")]
    public partial class Interaction
    {
        [Key]
        [Column("Interaction_id")]
        public int InteractionId { get; set; }
        [Required]
        [Column("inter_date", TypeName = "dateTime")]
        public DateTime InterDate { get; set; }
        [Required]
        [Column("id1")]
        public int Id1 { get; set; }
        [Required]
        [Column("id2")]
        public int Id2 { get; set; }

    //    [ForeignKey(nameof(Id1))]
    //    [InverseProperty(nameof(UserId.InteractionId1Navigation))]
    //    public virtual UserId Id1Navigation { get; set; }
    //    [ForeignKey(nameof(Id2))]
    //    [InverseProperty(nameof(UserId.InteractionId2Navigation))]
    //    public virtual UserId Id2Navigation { get; set; }
    }
}
