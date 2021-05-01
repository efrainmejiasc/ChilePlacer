using ChilePlacer.Application.Interfaces;
using ChilePlacer.DataModels;
using ChilePlacer.Models;
using ChilePlacer.Models.App;
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
        private readonly IHttpContextAccessor httpContext;
        private readonly IProfileGirlsRepository profileGirls;
        private readonly IChangePasswordRepository changePassword;


        public RegistroController(IUtilidad _util, IGirlsRepository _girls, IWebHostEnvironment _hostEnv, ISendMail _sendMail, IProfileGirlsRepository _profileGirls, IChangePasswordRepository _changePassword, IHttpContextAccessor _httpContext)
        {
            util = _util;
            girls = _girls;
            hostEnv = _hostEnv;
            sendMail = _sendMail;
            httpContext = _httpContext;
            profileGirls = _profileGirls;
            changePassword = _changePassword;
        }

        [HttpPost]
        public JsonResult RegistroGirls(string mail , string password)
        {
            var respuesta = new RespuestaModel();
            if (girls.GetExisteEmail(mail,true))
            {
                respuesta.Descripcion = "La direccion de e-mail: " + mail + " ya existe en nuestro sistema";
                return Json(respuesta);
            }

            var identificador = util.NuevoIdentificador();
            var password64 = util.CodeBase64(mail + "#" + password);
            var modelGirl = util.SetGirlsModel(mail, password64,identificador);
            modelGirl = girls.InsertGirls(modelGirl);

            var enlaze = util.ConstruirEnlazeRegistro(mail,identificador);
            var estructuraMail = util.SetEstructuraMailRegister(enlaze,mail);
            sendMail.EnviarMailNotificacion(estructuraMail, hostEnv);

            if(modelGirl.Id > 0)
                respuesta.Descripcion = "Registro satisfactorio, fue enviado un email a tu direccion electronica para la activacion de tu cuenta";
            else
                respuesta.Descripcion = "Registro fallido";

            return Json(respuesta);
        }

        [HttpPost]
        public JsonResult CompletedRegistroGirls(string nombre, string apellido, string dni,string telefono,string nameFoto ,string id,string username)
        {
            var respuesta = new RespuestaModel();
            respuesta.Status = "false";

            if (string.IsNullOrEmpty(id))
            {
                respuesta.Descripcion = "Error: valores vacios";
                return Json(respuesta);
            }

            var identidad = Guid.Parse(id);
            var img64 = util.CodeBase64("ClientApp/dist/assets/ProfileImageGirls/" + nameFoto);
            var profile = util.SetProfileGirls(nombre, apellido, dni, telefono, nameFoto, identidad,username,img64);
            if (!profileGirls.ExisteProfileGirls(identidad))
            {
                if (profileGirls.GetExisteUserName(username))
                {
                    respuesta.Descripcion = "El nombre de usuario existe, intente con otros digitos";
                    return Json(respuesta);
                }
                profile = profileGirls.InsertProfileGirls(profile);
            }
            else
            {
                if (profileGirls.GetExisteUserName(username,identidad))
                {
                    respuesta.Descripcion = "El nombre de usuario existe, intente con otros digitos";
                    return Json(respuesta);
                }
                profile = profileGirls.UpdateProfileGirls(profile);
            }

            respuesta.Descripcion = "Perfil actualizado correctamente";
            respuesta.Status = "true";

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

        [HttpPost]
        public JsonResult LoginGirls(string email, string password)
        {
            RespuestaModel respuesta = new RespuestaModel();
            var password64 = util.CodeBase64(email + "#" + password);
            var s = girls.LoginGirls(email, password64);
            if (s != null)
            {
                respuesta.Descripcion = "Usuario correctamente logeado";
                respuesta.Identidad = s.Identidad.ToString();
                respuesta.Username = s.Email;
                SetIdentityUser(s);
            }
            else
                respuesta.Descripcion = "Usuario y password no existe";

            return Json(respuesta);
        }

        private void SetIdentityUser(Girls s) 
        {
            httpContext.HttpContext.Session.SetString("Identidad", s.Identidad.ToString());
            httpContext.HttpContext.Session.SetString("Email", s.Email);
            httpContext.HttpContext.Session.SetString("Username", profileGirls.GetUserName(s.Identidad));
        }

        [HttpPost]
        public JsonResult GetIdentityUser()
        {
            var identityUser = new IdentityUser();
            var test = httpContext.HttpContext.Session.GetString("Identidad");
            if (string.IsNullOrEmpty(test))
            {
                identityUser = null;
                return Json(identityUser);
            }

            identityUser.Identidad = Guid.Parse(httpContext.HttpContext.Session.GetString("Identidad"));
            identityUser.Email = httpContext.HttpContext.Session.GetString("Email");
            identityUser.Username = httpContext.HttpContext.Session.GetString("Username");

            return Json(identityUser);
        }

        [HttpPost]
        public JsonResult ChangePassword(string email, string password)
        {
            RespuestaModel respuesta = new RespuestaModel();
            var password64 = util.CodeBase64(email + "#" + password);
            var s = girls.ChangePassword(email, password64);
            respuesta.Descripcion = "Actualizacion de contraseña exitosa";
            respuesta.Status = "true";

            return Json(respuesta);
        }


        [HttpPost]
        public JsonResult SendMailChangePassword(string email)
        {
            RespuestaModel respuesta = new RespuestaModel();
            if (!girls.GetExisteEmail(email, true))
            {
                respuesta.Descripcion = "El email:" + email  + " no esta registrado o puede estar inactivo";
                respuesta.Status = "false";
                return Json(respuesta);
            }

            var codigo = util.ConstruirCodigo();
            var subject = "Cambio de contraseña Chileplacer";
            var body = "Tu codigo para cambio de contraseña es : " + codigo;

            var model=  util.ConstruirChangePassword(email, codigo,false);
            changePassword.InsertChangePassword(model);
            sendMail.EnviarMailNotificacion(subject, body, email);

            respuesta.Descripcion = "Enviamos un codigo a la cuenta: " + email + " revise su bandeja de entrada";
            respuesta.Status = "true";

            return Json(respuesta);
        }

        [HttpPost]
        public JsonResult ValidarCodigoChangePassword (string email, string codigo)
        {
            RespuestaModel respuesta = new RespuestaModel();
            var model = changePassword.GetChangePassword(email, codigo, false);
            if (model == null)
            {
                respuesta.Descripcion = "El email y el codigo no coinciden";
                respuesta.Status = "false";
                return Json(respuesta);
            }

            changePassword.ActualizarCodigos(email);

            respuesta.Descripcion = "OK";
            respuesta.Status = "true";
            respuesta.Username = email;
            respuesta.Email = util.CodeBase64(email);

            return Json(respuesta);
        }
    }
}
