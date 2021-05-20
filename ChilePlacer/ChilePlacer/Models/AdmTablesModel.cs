using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.Models
{
    public class AdmTablesModel
    {
        public int Id { get; set; }
        public  string Ide { get; set; }
        public string Descripcion { get; set; }

        //************************************************************************
        //************************************************************************

        public string IdTabla { get; set; }
        public string NombreTabla{ get; set; }
    }
}
