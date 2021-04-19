using ChilePlacer.Application.Interfaces;
using ChilePlacer.Models;
using ChilePlacer.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.Controllers
{
    public class RegistroController : Controller
    {
        private readonly IUtilidad util;
        private readonly ISendMail sendMail;
        private readonly IGirlsRepository girls;
        private readonly IWebHostEnvironment hostEnv;
        private readonly IProfileGirlsRepository profileGirls;

        public RegistroController(IUtilidad _util, IGirlsRepository _girls, IWebHostEnvironment _hostEnv, ISendMail _sendMail, IProfileGirlsRepository _profileGirls)
        {
            util = _util;
            girls = _girls;
            hostEnv = _hostEnv;
            sendMail = _sendMail;
            profileGirls = _profileGirls;
        }

        [HttpPost]
        public JsonResult RegistroGirls(string username, string mail , string password)
        {
            var respuesta = new RespuestaModel();
            if (girls.GetExisteUserName(username))
            {
                respuesta.Descripcion ="El usuario: " + username + " ya existe en nuestro sistema";
                return Json(respuesta);
            }
            else if (girls.GetExisteEmail(mail,true))
            {
                respuesta.Descripcion = "La direccion de e-mail: " + mail + " ya existe en nuestro sistema";
                return Json(respuesta);
            }

            var identificador = util.NuevoIdentificador();
            var password64 = util.CodeBase64(mail + password);
            var modelGirl = util.SetGirlsModel(username, mail, password64,identificador);
            modelGirl = girls.InsertGirls(modelGirl);

            var enlaze = util.ConstruirEnlazeRegistro(mail,username,identificador);
            var estructuraMail = util.SetEstructuraMailRegister(enlaze,mail);
            sendMail.EnviarMailNotificacion(estructuraMail, hostEnv);

            if(modelGirl.Id > 0)
                respuesta.Descripcion = "Registro satisfactorio, fue enviado un email a tu direccion electronica para la activacion de tu cuenta";
            else
                respuesta.Descripcion = "Registro fallido";

            return Json(respuesta);
        }

        [HttpPost]
        public JsonResult CompletedRegistroGirls(string nombre, string apellido, string dni,string telefono,string nameFoto ,string id)
        {
            var respuesta = new RespuestaModel();
            if (string.IsNullOrEmpty(id))
            {
                respuesta.Descripcion = "Error: valores vacios";
                return Json(respuesta);
            }

            var identidad = Guid.Parse(id);
            var profile = util.SetProfileGirls(nombre, apellido, dni, telefono, nameFoto, identidad);
            if (!profileGirls.ExisteProfileGirls(identidad))
                profile = profileGirls.InsertProfileGirls(profile);
            else
                profile = profileGirls.UpdateProfileGirls(profile);

            respuesta.Descripcion = "Perfil actualizado correctamente";

            return Json(respuesta);
        }

        [HttpPost]
        public JsonResult ImagenGirls(string id)
        {
            var respuesta = new RespuestaModel();
            if (string.IsNullOrEmpty(id))
            {
                respuesta.Descripcion = "Error: valores vacios";
                return Json(respuesta);
            }

            return Json(respuesta);
        }

        [HttpPost]
        public JsonResult GetProfileImage(string id)
        {
            var respuesta = new RespuestaModel();
            var identificador = Guid.Parse(id);
            respuesta.Descripcion = profileGirls.GetProfileImage(identificador);

            return Json(respuesta);
        }
    }
}
