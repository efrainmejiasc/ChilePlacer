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
        public Guid Identidad { get; set; }
        public string Username { get; set; }
        public string PathImagen { get; set; }
    }
}
