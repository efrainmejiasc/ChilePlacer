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

        [Column(Order = 6, TypeName = "VARCHAR(100)")]
        public string Path { get; set; }

        [Column(Order = 7, TypeName = "DATETIME")]
        public DateTime Fecha { get; set; }

        [Column(Order = 8, TypeName = "VARCHAR(50)")]
        public string Dni { get; set; }

        [Column(Order = 9, TypeName = "VARCHAR(100)")]
        public string Username { get; set; }

        [Column(Order = 10, TypeName = "VARCHAR(MAX)")]
        public string Img64 { get; set; }

        [Column(Order = 11, TypeName = "DATETIME")]
        public DateTime FechaNacimiento { get; set; }

        [Column(Order = 12, TypeName = "VARCHAR(100)")]
        public string Sexo { get; set; }

        [Column(Order = 13, TypeName = "DECIMAL")]
        public decimal Estatura { get; set; }

        [Column(Order = 14, TypeName = "DECIMAL")]
        public decimal Peso { get; set; }

        [Column(Order = 15, TypeName = "VARCHAR(100)")]
        public string Medidas { get; set; }

        [Column(Order = 16, TypeName = "VARCHAR(100)")]
        public string Contextura { get; set; }

        [Column(Order = 17, TypeName = "VARCHAR(100)")]
        public string Hair { get; set; }

        [Column(Order = 18, TypeName = "VARCHAR(100)")]
        public string Piel { get; set; }

        [Column(Order = 19, TypeName = "VARCHAR(100)")]
        public string Eyes { get; set; }

        [Column(Order = 19, TypeName = "VARCHAR(100)")]
        public string Depilacion { get; set; }

        [Column(Order = 20, TypeName = "VARCHAR(100)")]
        public string Drink { get; set; }

        [Column(Order = 21, TypeName = "VARCHAR(100)")]
        public string  Smoke { get; set; }

        [Column(Order = 22, TypeName = "VARCHAR(150)")]
        public string Country { get; set; }

        [Column(Order = 23, TypeName = "VARCHAR(150)")]
        public string Location { get; set; }

        [Column(Order = 24, TypeName = "VARCHAR(200)")]
        public string Presentacion { get; set; }

        [Column(Order = 25, TypeName = "VARCHAR(200)")]
        public string Descripcion { get; set; }

        [Column(Order = 26, TypeName = "VARCHAR(50)")]
        public string WhatsApp { get; set; }

        [Column(Order = 27, TypeName = "DECIMAL")]
        public decimal ValorHora{ get; set; }

        [Column(Order = 28, TypeName = "DECIMAL")]
        public decimal ValorMediaHora { get; set; }

        [Column(Order = 29, TypeName = "VARCHAR(100)")]
        public string Atencion { get; set; }
    }
}
