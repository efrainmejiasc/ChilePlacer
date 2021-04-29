using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.DataModels
{
    [Table("Girls")]
    public class Girls
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "INT")]
        public int Id { get; set; }

        [Required]
        [Column(Order = 2, TypeName = "UNIQUEIDENTIFIER")]
        public Guid Identidad { get; set; }

        [Required]
        [Column(Order = 3, TypeName = "VARCHAR(50)")]
        public string Email { get; set; }

        [Column(Order = 4, TypeName = "DATETIME")]
        public DateTime Fecha { get; set; }

        [Column(Order = 5, TypeName = "BIT")]
        public  bool Activo{ get; set; }

        [Required]
        [Column(Order = 6, TypeName = "VARCHAR(250)")]
        public string Password { get; set; }

       // [Column(Order = 5, TypeName = "DATETIME")]
        //public DateTime FechaNacimiento { get; set; }

    }
}
