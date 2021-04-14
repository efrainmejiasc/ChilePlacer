using ChilePlacer.Application.Interfaces;
using ChilePlacer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChilePlacer.Application
{
    public class Utilidad : IUtilidad
    {
        public string CodeBase64(string cadena)
        {
            var comprobanteXmlPlainTextBytes = Encoding.UTF8.GetBytes(cadena);
            var cadenaBase64 = Convert.ToBase64String(comprobanteXmlPlainTextBytes);
            return cadenaBase64;
        }

        public string DecodeBase64(string cadena)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(cadena);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }


        public bool CompararString(string a, string b)
        {
            bool resultado = false;
            if (a == b)
            {
                resultado = true;
            }
            return resultado;
        }

        public Guid NuevoIdentificador()
        {
            Guid g = CrearGuid();
            while (g == Guid.Empty)
            {
                g = CrearGuid();
            }
            return g;
        }

        private Guid CrearGuid()
        {
            return Guid.NewGuid();
        }

        public Girls SetGirlsModel (string username, string email, string password,Guid identificador)
        {
            var girl = new Girls()
            {
                Identidad = identificador,
                Username = username,
                Password = password,
                Email = email,
                Activo = false,
                Fecha = DateTime.UtcNow
             
            };

            return girl;
        }
    }
}
