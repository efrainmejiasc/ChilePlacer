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
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace ChilePlacer.Controllers
{
    public class RegistroController : Controller
    {
        private readonly IUtilidad util;
        private readonly ISendMail sendMail;
        private readonly ITypesRepository types;
        private readonly IGirlsRepository girls;
        private readonly IWebHostEnvironment hostEnv;
        private readonly IHttpContextAccessor httpContext;
        private readonly IProfileGirlsRepository profileGirls;
        private readonly IChangePasswordRepository changePassword;


        public RegistroController(IUtilidad _util, IGirlsRepository _girls, IWebHostEnvironment _hostEnv, ISendMail _sendMail, IProfileGirlsRepository _profileGirls, IChangePasswordRepository _changePassword, IHttpContextAccessor _httpContext, ITypesRepository _types)
        {
            util = _util;
            girls = _girls;
            types = _types;
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
        public JsonResult CompletedRegistroGirls(string nombre, string apellido, string dni,string telefono,string nameFoto ,string id,string username,
                                                 DateTime fechaNacimiento, string sexo,string presentacion,string descripcion,string escort,List<string> atencion,
                                                 List<string> servicios,decimal valor1,decimal valor2,string drink,string smoke,string estatura,string peso,
                                                 string medidas,string contextura,string piel,string hair,string eyes,string country,string location,string sector,string depilacion,string nacionalidad)
        {
            var respuesta = new RespuestaModel();
            respuesta.Status = "false";

            if (string.IsNullOrEmpty(id))
            {
                respuesta.Descripcion = "Error: valores vacios";
                return Json(respuesta);
            }

            var identidad = Guid.Parse(id);
            var t = Path.Combine(hostEnv.ContentRootPath,"ClientApp/dist/assets/ProfileImageGirls", nameFoto);
            var img64 = util.CodeBase64(t, false);

            var profile = util.SetProfileGirls(nombre, apellido, dni, telefono, nameFoto, identidad,username,img64, fechaNacimiento,
                                               sexo,presentacion,descripcion,escort,valor1,valor2,drink,smoke,decimal.Parse(estatura.Replace(",",".")),
                                               decimal.Parse(peso.Replace(",", ".")), medidas,contextura,piel,hair,eyes,country,location,sector,depilacion,nacionalidad);

            var lugarAtencion = util.SetAtencionEscort(atencion,identidad);
            var serviciosSex = util.SetServiciosEscort(servicios, identidad);

            if (!profileGirls.ExisteProfileGirls(identidad))
            {
                if (profileGirls.GetExisteUserName(username))
                {
                    respuesta.Descripcion = "El nombre de usuario existe, intente con otros digitos";
                    return Json(respuesta);
                }

                profile = profileGirls.InsertProfileGirls(profile);
                lugarAtencion = types.InsertTypeAtencionGirl(lugarAtencion);
                serviciosSex = types.InsertTypeServiceSex(serviciosSex);
            }
            else
            {
                if (profileGirls.GetExisteUserName(username,identidad))
                {
                    respuesta.Descripcion = "El nombre de usuario existe, intente con otros digitos";
                    return Json(respuesta);
                }
                profile = profileGirls.UpdateProfileGirls(profile);

                if (lugarAtencion.Count > 0)
                    types.DeleteTypeAtencionGirl(lugarAtencion, identidad);

                if (serviciosSex.Count > 0)
                    types.DeleteTypeServiceSex(serviciosSex,identidad);
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
        public JsonResult ImagenProfileGirl(string username)
        {
            var respuesta = new RespuestaModel();
            respuesta.Descripcion = profileGirls.GetProfileImage(username);

            return Json(respuesta);
        }

        [HttpPost]
        public JsonResult GetProfileGirl(string id)
        {
            if (string.IsNullOrEmpty(id))
                return Json(null);

            var identidad = Guid.Parse(id);

            var profile = new ProfileGirls();
            profile = profileGirls.GetProfileGirls(identidad);

            if(profile != null)
            {
                profile.StrFechaNacimiento = util.StrFecha(profile.FechaNacimiento);
                profile.Edad = util.CalcularEdad(profile.FechaNacimiento);
            }

            return Json(profile);
        }

        [HttpPost]
        public JsonResult GetProfile(string id)
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
                if (SetIdentityUser(s))
                {
                    respuesta.Descripcion = "Usuario correctamente logeado";
                    respuesta.Identidad = s.Identidad.ToString();
                    respuesta.Username = s.Email;
                }
                else
                    respuesta.Descripcion = "Completa tu perfil,desde el enlaze que recibiste en: " + email;
            }
            else
                respuesta.Descripcion = "Usuario y password no existe";

            return Json(respuesta);
        }

        private bool SetIdentityUser(Girls s) 
        {
            var resultado = false;
            try
            {
                httpContext.HttpContext.Session.SetString("Identidad", s.Identidad.ToString());
                httpContext.HttpContext.Session.SetString("Email", s.Email);
                httpContext.HttpContext.Session.SetString("Username", profileGirls.GetUserName(s.Identidad));
                resultado = true;
            }
            catch
            {
                httpContext.HttpContext.Session.SetString("Identidad",string.Empty);
                httpContext.HttpContext.Session.SetString("Email", string.Empty);
                httpContext.HttpContext.Session.SetString("Username", string.Empty);
            }

            return resultado;
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

        [HttpPost]
        public JsonResult GetSexo () 
        {
            var tipo = types.GetSex();
            return Json(tipo);
        }

        [HttpPost]
        public JsonResult GetEscort()
        {
            var tipo= types.GetEscort();
            return Json(tipo);
        }


        [HttpPost]
        public JsonResult GetContextura()
        {
            var tipo = types.GetContextura();
            return Json(tipo);
        }


        [HttpPost]
        public JsonResult GetPiel()
        {
            var tipo = types.GetPiel();
            return Json(tipo);
        }

        [HttpPost]
        public JsonResult GetHair()
        {
            var tipo = types.GetHair();
            return Json(tipo);
        }

        [HttpPost]
        public JsonResult GetEyes()
        {
            var tipo = types.GetEyes();
            return Json(tipo);
        }

        [HttpPost]
        public JsonResult GetDrink()
        {
            var tipo = types.GetDrink();
            return Json(tipo);
        }

        [HttpPost]
        public JsonResult GetSmoke()
        {
            var tipo = types.GetSmoke();
            return Json(tipo);
        }

        [HttpPost]
        public JsonResult GetAtencion()
        {
            var tipo = types.GetAtencion();
            return Json(tipo);
        }

        [HttpPost]
        public JsonResult GetServicios()
        {
            var tipo = types.GetServicios();
            return Json(tipo);
        }

        [HttpPost]
        public JsonResult GetCountry()
        {
            var tipo = types.GetCountry();
            return Json(tipo);
        }

        [HttpPost]
        public JsonResult GetLocation()
        {
            var tipo = types.GetLocation();
            return Json(tipo);
        }


        [HttpPost]
        public JsonResult GetNacionalidad()
        {
            var tipo = types.GetNacionalidad();
            return Json(tipo);
        }


        [HttpPost]
        public JsonResult GetDepilacion()
        {
            var tipo = types.GetDepilacion();
            return Json(tipo);
        }
    }
}
