using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.Models
{
    public class ActivacionMailModel
    {
        public string Asunto { get; set; }

        public string Cuerpo { get; set; }

        public string PathAdjunto { get; set; }

        public string EmailDestinatario { get; set; }

        public string Fecha { get; set; }

        public string Descripcion { get; set; }

        public string Link { get; set; }

        public string ClickAqui { get; set; }

        public string Observacion { get; set; }

        public string PathLecturaArchivo { get; set; }

        public string CodigoResetPassword { get; set; }

        public string Saludo { get; set; }
    }
}
