using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.DataModels
{
    [Table("AppLog")]
    public class AppLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "INT")]
        public int Id { get; set; }

        [Required]
        [Column(Order = 2, TypeName = "VARCHAR(50)")]
        public string Metodo { get; set; }

        [Required]
        [Column(Order = 3, TypeName = "VARCHAR(MAX)")]
        public string Error { get; set; }

        [Column(Order = 4, TypeName = "DATETIME")]
        public DateTime Fecha { get; set; }
    }
}
