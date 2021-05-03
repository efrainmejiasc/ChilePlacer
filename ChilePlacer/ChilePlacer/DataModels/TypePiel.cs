using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.DataModels
{

    [Table("TypeEyes")]
    public class TypePiel
    {
        [Key]
        [Column(Order = 1, TypeName = "VARCHAR(50)")]
        public string Id { get; set; }

        [Column(Order = 2, TypeName = "VARCHAR(50)")]
        public string Piel { get; set; }
    }
}
