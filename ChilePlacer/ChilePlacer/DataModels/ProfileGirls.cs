using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.DataModels
{
    [Table("ProfileGirls")]
    public class ProfileGirls
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "INT")]
        public int Id { get; set; }

        [Required]
        [Column(Order = 2, TypeName = "UNIQUEIDENTIFIER")]
        public Guid Identidad { get; set; }

        [Column(Order = 3, TypeName = "VARCHAR(80)")]
        public string Nombre { get; set; }

        [Column(Order = 4, TypeName = "VARCHAR(80)")]
        public string Apellido { get; set; }

        [Column(Order = 5, TypeName = "VARCHAR(50)")]
        public string Telefono { get; set; }

        [Column(Order = 6, TypeName = "VARCHAR(400)")]
        public string Path { get; set; }

        [Column(Order = 7, TypeName = "DATETIME")]
        public DateTime Fecha { get; set; }
    }
}
