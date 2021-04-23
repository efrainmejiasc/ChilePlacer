using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.DataModels
{
    [Table("PortadaGirls")]
    public class PortadaGirls
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "INT")]
        public int Id { get; set; }

        [Column(Order = 2, TypeName = "INT")]
        public int IdGirls { get; set; }

        [Column(Order = 3, TypeName = "DATETIME")]
        public DateTime Fecha { get; set; }

        [Column(Order = 4, TypeName = "VARCHAR(250)")]
        public string PathImagen { get; set; }
    }
}
