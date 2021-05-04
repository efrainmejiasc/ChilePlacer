﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.DataModels
{
    [Table("TypeCountry")]
    public class TypeCountry
    {
        [Key]
        [Column(Order = 1, TypeName = "VARCHAR(100)")]
        public string Id { get; set; }

        [Column(Order = 2, TypeName = "VARCHAR(100)")]
        public string Country { get; set; }

        [Column(Order = 3, TypeName = "VARCHAR(100)")]
        public string Descripcion{ get; set; }
    }
}
