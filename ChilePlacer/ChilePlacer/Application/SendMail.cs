using ChilePlacer.Application.Interfaces;
using ChilePlacer.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ChilePlacer.Application
{
    public class SendMail:ISendMail
    {
        public bool EnviarMailNotificacion(ActivacioMailModel model, IWebHostEnvironment hostEnv)
        {
            bool result = false;
            model = ConstruccionNotificacion(model,hostEnv);
            try
            {
                MailMessage mensaje = new MailMessage();
                SmtpClient servidor = new SmtpClient();
                mensaje.From = new MailAddress("www.chileplacer.cl<www.chileplacer.cl@gmail.com>");
                mensaje.Subject = model.Asunto;
                mensaje.SubjectEncoding = System.Text.Encoding.UTF8;
                mensaje.Body = model.Cuerpo;
                mensaje.BodyEncoding = System.Text.Encoding.UTF8;
                mensaje.IsBodyHtml = true;
                mensaje.To.Add(new MailAddress(model.EmailDestinatario));
                servidor.Credentials = new System.Net.NetworkCredential("www.chileplacer.cl", "1234Santiago*");
                servidor.Port = 587;
                servidor.Host = "smtp.gmail.com";
                servidor.EnableSsl = true;
                servidor.Send(mensaje);
                mensaje.Dispose();
                result = true;
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
            }

            return result;
        }


        private ActivacioMailModel ConstruccionNotificacion(ActivacioMailModel model, IWebHostEnvironment hostEnv)
        {
            string body = Path.Combine(hostEnv.WebRootPath, model.PathLecturaArchivo);
            body = File.ReadAllText(body);
            body = body.Replace("@Model.Saludo", model.Saludo);
            body = body.Replace("@Model.Fecha", model.Fecha);
            body = body.Replace("@Model.EmailDestinatario", model.EmailDestinatario);
            body = body.Replace("@Model.Observacion", model.Observacion);
            body = body.Replace("@Model.Descripcion", model.Descripcion);
            body = body.Replace("@Model.ClickAqui", model.ClickAqui);
            body = body.Replace("@Model.Link", model.Link);
            body = body.Replace("@Model.CodigoResetPassword", model.CodigoResetPassword);
            model.Cuerpo = body;
            return model;
        }

 
    }
}
