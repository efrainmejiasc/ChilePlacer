using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.DataModels
{
    [Table("ChangePassword")]
    public class ChangePassword
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "INT")]
        public int Id { get; set; }

        [Required]
        [Column(Order = 2, TypeName = "VARCHAR(50)")]
        public string Codigo { get; set; }

        [Required]
        [Column(Order = 3, TypeName = "VARCHAR(50)")]
        public string Email { get; set; }

        [Column(Order = 4, TypeName = "DATETIME")]
        public DateTime Fecha { get; set; }

    }
}
