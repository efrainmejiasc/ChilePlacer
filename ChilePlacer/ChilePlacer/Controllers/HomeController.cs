using ChilePlacer.Application.Interfaces;
using ChilePlacer.Models;
using ChilePlacer.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUtilidad util;
        private readonly IGirlsRepository girls;

        public HomeController(IUtilidad _util, IGirlsRepository _girls)
        {
            util = _util;
            girls = _girls;
        }

        [HttpGet]
        public IActionResult Index(string email,string username, string identidad, string date)
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
            username = util.DecodeBase64(username);


            if (!util.EstatusLink(fechaEnvio, fechaActivacion))
            {
                respuesta.Descripcion = "El link de activacion expiro";
                respuesta.Status = "false";
                return View(respuesta);
            }
            else if (girls.GetExisteUserName(username))
            {
                respuesta.Descripcion = "El usuario: " + username + " ya existe en nuestro sistema";
                respuesta.Status = "false";
                return View(respuesta);
            }

            identidad = util.DecodeBase64(identidad);
            var identificador = Guid.Parse(identidad);
            var girl = girls.ActivarUsuario(identificador, true);

            respuesta.Descripcion = "El usuario: " + username + " fue activado...Ahora completa tu perfil";
            respuesta.Status = "true";
            return View(respuesta);
        }
    }
}
