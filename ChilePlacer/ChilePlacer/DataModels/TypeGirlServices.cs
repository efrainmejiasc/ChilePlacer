using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.DataModels
{
    [Table("TypeGirlServices")]
    public class TypeGirlServices
    {
        [Key]
        [Column(Order = 1, TypeName = "INT")]
        public string Id { get; set; }

        [Column(Order = 2, TypeName = "VARCHAR(50)")]
        public Guid Identidad { get; set; }

        [Column(Order = 3, TypeName = "INT")]
        public string IdTypeServices { get; set; }

    }
}
