using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.DataModels
{
    [Table("GaleriaGirls")]
    public class GaleriaGirls
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "INT")]
        public int Id { get; set; }

        [Required]
        [Column(Order = 2, TypeName = "UNIQUEIDENTIFIER")]
        public Guid Identidad { get; set; }

        [Column(Order = 3, TypeName = "DATETIME")]
        public DateTime Fecha { get; set; }

        [Column(Order = 4, TypeName = "VARCHAR(250)")]
        public string PathImagen { get; set; }

        [Column(Order = 5, TypeName = "VARCHAR(MAX)")]
        public string Img64 { get; set; }

        [Column(Order = 6, TypeName = "VARCHAR(500)")]
        public string Texto { get; set; }
    }
}
