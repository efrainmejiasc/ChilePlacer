using ChilePlacer.Application.Interfaces;
using ChilePlacer.Models;
using ChilePlacer.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace ChilePlacer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUtilidad util;
        private readonly IGirlsRepository girls;
        private readonly IWebHostEnvironment hostEnv;
        private readonly ISendMail sendMail;

        public HomeController(IUtilidad _util, IGirlsRepository _girls, IWebHostEnvironment _hostEnv, ISendMail _sendMail)
        {
            util = _util;
            girls = _girls;
            hostEnv = _hostEnv;
            sendMail = _sendMail;
        }

        [HttpGet]
        public IActionResult Index(string email,string identidad, string date)
        {
            var respuesta = new RespuestaModel();
            if (string.IsNullOrEmpty(email))
            {
                respuesta.Descripcion = "";
                respuesta.Status = "false";
                return View(respuesta);
            }
                
            var fechaEnvio = Convert.ToDateTime(date);
            var fechaActivacion = DateTime.UtcNow;

            if (!util.EstatusLink(fechaEnvio, fechaActivacion))
            {
                respuesta.Descripcion = "El link de activacion expiro, enviamos un nuevo email";
                respuesta.Status = "false";
                EnviarOtroEmail(email, identidad);
                return View(respuesta);
            }

            email = util.DecodeBase64(email);
            identidad = util.DecodeBase64(identidad);
            var identificador = Guid.Parse(identidad);
            var girl = girls.ActivarUsuario(identificador, true);

            respuesta.Descripcion = "La cuenta de: " + email + " fue activada...Ahora completa tu perfil";
            respuesta.Status = "true";
            respuesta.Username = email;
            respuesta.Identidad = identificador.ToString();

            return View(respuesta);
        }

        private void EnviarOtroEmail(string email, string identidad)
        {
            email = util.DecodeBase64(email);
            identidad = util.DecodeBase64(identidad);
            var identificador = Guid.Parse(identidad);

            var enlaze = util.ConstruirEnlazeRegistro(email, identificador);
            var estructuraMail = util.SetEstructuraMailRegister(enlaze, email);
            sendMail.EnviarMailNotificacion(estructuraMail, hostEnv);
        }

    }
}
