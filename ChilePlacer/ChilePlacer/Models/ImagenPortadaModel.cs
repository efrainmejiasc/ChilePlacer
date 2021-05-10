using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.Models
{
    public class ImagenPortadaModel
    {
        public int Id { get; set; }
        public int IdGirl { get; set; }
        public string Identidad { get; set; }
        public string Username { get; set; }
        public string PathImagen { get; set; }
        public string UrlProfile { get; set; }
        public string Texto { get; set; }
        public string Img64 { get; set; }
        public DateTime Fecha { get; set; }

    }
}
