using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.DataModels
{
    [Table("TypeLocation")]
    public class TypeLocation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "INT")]
        public int Id { get; set; }
        [Key]
        [Column(Order = 2, TypeName = "VARCHAR(100)")]
        public string Ide { get; set; }

        [Column(Order = 3, TypeName = "VARCHAR(100)")]
        public string Location { get; set; }

        [Column(Order = 4, TypeName = "VARCHAR(100)")]
        public string Country { get; set; }
    }
}
