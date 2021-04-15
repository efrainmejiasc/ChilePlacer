using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.Application
{
    public class EngineData
    {

        private static EngineData valor;
        public static EngineData Instance()
        {
            if ((valor == null))
            {
                valor = new EngineData();
            }
            return valor;
        }

        public static string UrlServerHost { get; set; }
        public static string UrlServerActivacion { get; set; }

    }
}
