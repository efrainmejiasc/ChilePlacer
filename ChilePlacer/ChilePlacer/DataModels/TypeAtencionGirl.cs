using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.DataModels
{
    [Table("TypeAtencionGirl")]
    public class TypeAtencionGirl
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "INT")]
        public int Id { get; set; }

        [Column(Order = 2, TypeName = "UNIQUEIDENTIFIER")]
        public Guid Identidad { get; set; }

        [Column(Order = 3, TypeName = "VARCHAR(100)")]
        public string TypeAtencion { get; set; }
    }
}
