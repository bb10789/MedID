using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace AzureAPI.Dtos {
    public class InteractionCreateDto {
        [Key]
        [Column("Interaction_id")]
        public int InteractionId { get; set; }
        [Required]
        [Column("inter_date", TypeName = "date")]
        public DateTime InterDate { get; set; }
        [Required]
        [Column("id1")]
        public int Id1 { get; set; }
        [Required]
        [Column("id2")]
        public int Id2 { get; set; }
    }
}
