using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace AzureAPI.Dtos {
    public class InteractionCreateDto {
        private DateTime current;
        [Required]
        [Column("inter_date", TypeName = "dateTime")]
        public DateTime InterDate {
            set {
                current = DateTime.Now;
            }
            get {
                return DateTime.Now;
            }
        }
        [Required]
        [Column("id1")]
        public int Id1 { get; set; }
        [Required]
        [Column("id2")]
        public int Id2 { get; set; }
    }
}
