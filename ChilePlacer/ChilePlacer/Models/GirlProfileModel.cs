using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.Models
{
    public class GirlProfileModel
    {
        public int Id { get; set; }

        public string Identidad { get; set; }
        public string Identidad64 { get; set; }

        public string Username { get; set; }

        public  List<string> Imagenes { get; set; }
    }
}
