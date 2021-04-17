using ChilePlacer.Application.Interfaces;
using ChilePlacer.DataModels;
using ChilePlacer.Models;
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

        public ActivacioMailModel SetEstructuraMailRegister(string enlaze, string email)
        {
            ActivacioMailModel model = new ActivacioMailModel();
            model.Link = enlaze;
            model.Saludo = "Hola: ";
            model.EmailDestinatario = email;
            model.Fecha = DateTime.UtcNow.ToString();
            model.Descripcion = "Por favor confirma la direccion de correo electronico, para saber que eres realmente tu.";
            model.ClickAqui = "Hazme Click Para Confirmar Tu Identidad!";
            model.Asunto = "Por favor completa tu perfil...";
            model.Observacion = "Bienvenido(a) a nuestro sitio ChilePlacer, haz click en el link y completa tu perfil.  </br> Todos los datos aportados seran confidenciales , no seran revelados ni compartidos con nadie.";
            model.PathLecturaArchivo = @"Template\ActivacionMail.html";
            return model;
        }

        public string ConstruirEnlazeRegistro(string email, string username,Guid identidad)
        {
            string link = EngineData.UrlServerActivacion;
            link = link + "?email=" + CodeBase64(email);
            link = link + "&username=" + CodeBase64(username);
            link = link + "&identidad=" + CodeBase64(identidad.ToString());
            link = link + "&date=" + DateTime.UtcNow.ToString();
            return link;
        }

        public bool EstatusLink(DateTime fechaEnvio, DateTime fechaActivacion)
        {
            bool resultado = false;
            if (fechaEnvio.Date != fechaActivacion.Date)
                return resultado;

            int horaEnvio = fechaEnvio.Hour;
            int horaActivacion = fechaActivacion.Hour;
            int diferenciaHora = horaActivacion - horaEnvio;
            if (diferenciaHora <= 3)
                resultado = true;
            return resultado;
        }

        public ProfileGirls SetProfileGirls(string nombre, string apellido, string dni, string telefono, string path, Guid identidad)
        {
            var profileGirls = new ProfileGirls()
            {
                Identidad = identidad,
                Nombre = nombre,
                Apellido = apellido,
                Dni =  dni,
                Telefono = telefono,
                Path = path,
                Fecha = DateTime.UtcNow
            };

            return profileGirls;
        }
    }
}
