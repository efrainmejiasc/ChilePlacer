using ChilePlacer.Application;
using ChilePlacer.Application.Interfaces;
using ChilePlacer.DataModels;
using ChilePlacer.Models;
using ChilePlacer.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUtilidad util;
        private readonly ITypesRepository types;
        private readonly IHttpContextAccessor httpContext;
        private readonly IUserAdmRepository userAdm;
        private readonly ISendMail sendMail;
        public AdminController(IUtilidad _util, ITypesRepository _types, IHttpContextAccessor _httpContext, IUserAdmRepository _userAdm, ISendMail _sendMail)
        {
            util = _util;
            types = _types;
            userAdm = _userAdm;
            sendMail = _sendMail;
            httpContext = _httpContext;
        }

        public IActionResult Index()
        {
            ViewBag.UrlAdmTable = EngineData.UrlServerHost + "Admin/AdmTable";
            ViewBag.UrlAdmConfig = EngineData.UrlServerHost + "Admin/AdmConfig";

            return View();
        }


        public IActionResult AdmTable()
        {
            return View();
        }

        public IActionResult AdmTableCountry()
        {
            return View();
        }

        public IActionResult AdmConfig()
        {
            return View();
        }


        [HttpPost]
        public JsonResult RegistroAdm(string email, string password)
        {
            var respuesta = new RespuestaModel();
            if (userAdm.GetExisteEmail(email, true))
            {
                respuesta.Descripcion = "La direccion de e-mail: " + email + " ya existe en nuestro sistema";
                return Json(respuesta);
            }

            var password64 = util.CodeBase64(email + "#" + password);
            var adm = new UserAdm()
            {
                EmailAdm = email, PasswordAdm = password64,
                Activo = true,Fecha = DateTime.UtcNow,RolAdm="administrador"
            };

           adm  = userAdm.InsertAdm(adm);

            if (adm.Id > 0)
                respuesta.Descripcion = "Registro satisfactorio";
            else
                respuesta.Descripcion = "Registro fallido";

            return Json(respuesta);
        }

        [HttpPost]
        public JsonResult UpdateAdmPassword(string email, string password)
        {
            var respuesta = new RespuestaModel();
            var password64 = util.CodeBase64(email + "#" + password);
            var adm = userAdm.UpdateAdmPassword(email,password64);
            respuesta.Descripcion = adm != null ? "Modificacion de contraseña satisfactoria" : "No existen los datos enviados";
            return Json(respuesta);
        }

        [HttpPost]
        public JsonResult OlvidoPassword(string email)
        {
            var respuesta = new RespuestaModel();
            var adm = userAdm.GetUserAdm(email);

            if(adm == null)
            {
                respuesta.Status = "false";
                return Json(respuesta);
            }

            var codigo = util.ConstruirCodigo();
            var password64 = util.CodeBase64(email + "#" + codigo);
            var user = userAdm.UpdateAdmPassword(email, password64);
            var subject = "www.chileplacer.cl , olvido de contraseña";
            var body = "Tu nueva contraseña temporal es: " + codigo;

            sendMail.EnviarMailNotificacion(subject, body, user.EmailAdm);
            respuesta.Status = "true";

            return Json(respuesta);
        }


        [HttpPost]
        public JsonResult LoginAdm(string email, string password)
        {
            RespuestaModel respuesta = new RespuestaModel();
            var password64 = util.CodeBase64(email + "#" + password);
            var s = userAdm.LoginAdm(email, password64);
            if (s != null)
            {
                if (SetIdentityUserAdm(s))
                {
                    respuesta.Status = "true";
                }
                else
                    respuesta.Status = "false" ;
            }
            else
                respuesta.Status = "false";

            return Json(respuesta);
        }

        private bool SetIdentityUserAdm(UserAdm s)
        {
            var resultado = false;
            try
            {
                httpContext.HttpContext.Session.SetString("IdAdm", s.Id.ToString());
                httpContext.HttpContext.Session.SetString("EmailAdm", s.EmailAdm);
                httpContext.HttpContext.Session.SetString("PasswordAdm", s.PasswordAdm);
                resultado = true;
            }
            catch
            {
                httpContext.HttpContext.Session.SetString("IdAdm", string.Empty);
                httpContext.HttpContext.Session.SetString("EmailAdm", string.Empty);
                httpContext.HttpContext.Session.SetString("PasswordAdm", string.Empty);
            }

            return resultado;
        }

        [HttpPost]
        public JsonResult GetIdentityUserAdm()
        {
            var usuarioAdministrado = new UserAdm();
            var test = httpContext.HttpContext.Session.GetString("EmailAdm");
            if (string.IsNullOrEmpty(test))
            {
                usuarioAdministrado = null;
                return Json(usuarioAdministrado);
            }

            usuarioAdministrado.Id = Convert.ToInt32(httpContext.HttpContext.Session.GetString("IdAdm"));
            usuarioAdministrado.EmailAdm = httpContext.HttpContext.Session.GetString("EmailAdm");
            usuarioAdministrado.PasswordAdm = httpContext.HttpContext.Session.GetString("PasswordAdm");

            return Json(usuarioAdministrado);
        }


        [HttpPost]
        public JsonResult GetNameTables()
        {
            var nameTables = new List<AdmTablesModel>();

            var s = new AdmTablesModel();
            s.IdTabla = "TypeAtencion"; s.NombreTabla = "Tipos de Atencion";
            nameTables.Add(s);
            s = new AdmTablesModel();
            s.IdTabla = "TypeContextura"; s.NombreTabla = "Tipos de Contextura";
            nameTables.Add(s);
            s = new AdmTablesModel();
            s.IdTabla = "TypeCountry"; s.NombreTabla = "Pais residencia";
             nameTables.Add(s);
            s = new AdmTablesModel();
            s.IdTabla = "TypeDepilacion"; s.NombreTabla = "Tipos de Depilacion";
            nameTables.Add(s);
            s = new AdmTablesModel();
            s.IdTabla = "TypeDrink"; s.NombreTabla = "Consumo Alchol";
            nameTables.Add(s);
            s = new AdmTablesModel();
            s.IdTabla = "TypeEscort"; s.NombreTabla = "Categoria escort";
            nameTables.Add(s);
            s = new AdmTablesModel();
            s.IdTabla = "TypeEyes"; s.NombreTabla = "Color de ojos";
            nameTables.Add(s);
            s = new AdmTablesModel();
            s.IdTabla = "TypeGirls"; s.NombreTabla = "Tipo de chicas";
            nameTables.Add(s);
            s = new AdmTablesModel();
            s.IdTabla = "TypeHair"; s.NombreTabla = "Color de cabello";
            nameTables.Add(s);
            s = new AdmTablesModel();
            s.IdTabla = "TypeNacionalidad"; s.NombreTabla = "Pais de origen";
            nameTables.Add(s);
            s = new AdmTablesModel();
            s.IdTabla = "TypePiel"; s.NombreTabla = "Color de piel";
            nameTables.Add(s);
            s = new AdmTablesModel();
            s.IdTabla = "TypeServicesSex"; s.NombreTabla = "Servicios sexuales";
            nameTables.Add(s);
            s = new AdmTablesModel();
            s.IdTabla = "TypeSex"; s.NombreTabla = "Sexos";
            nameTables.Add(s);
            s = new AdmTablesModel();
            s.IdTabla = "TypeSmoke"; s.NombreTabla = "Consumo tabaco";
            nameTables.Add(s);


            return Json(nameTables);
        }


        [HttpPost]
        public JsonResult GetRegisterTable(string tableName)
        {
            var registros = new List<AdmTablesModel>();

            if (tableName == "TypeAtencion")
                registros = types.GetRegistrosTypeAtencion();
            else if (tableName == "TypeContextura")
                registros = types.GetRegistrosTypeContextura();
             else if (tableName == "TypeCountry")
                registros = types.GetRegistrosTypeCountry();
            else if (tableName == "TypeDepilacion")
                registros = types.GetRegistrosTypeDepilacion();
            else if (tableName == "TypeDrink")
                registros = types.GetRegistrosTypeAtencion();
            else if (tableName == "TypeEscort")
                registros = types.GetRegistrosTypeEscort();
            else if (tableName == "TypeEyes")
                registros = types.GetRegistrosTypeEyes();
            else if (tableName == "TypeGirls")
                registros = types.GetRegistrosTypeGirls();
            else if (tableName == "TypeHair")
                registros = types.GetRegistrosTypeHair();
            else if (tableName == "TypeNacionalidad")
                registros = types.GetRegistrosTypeNacionalidad();
            else if (tableName == "TypePiel")
                registros = types.GetRegistrosTypePiel();
            else if (tableName == "TypeServicesSex")
                registros = types.GetRegistrosTypeServicesSex();
            else if (tableName == "TypeSex")
                registros = types.GetRegistrosTypeSex();
            else if (tableName == "TypeSmoke")
                registros = types.GetRegistrosTypeSmoke();
            

            return Json(registros);
        }


        [HttpPost]
        public JsonResult DeleteRegisterTable(string tableName, int id)
        {
            if (tableName == "TypeAtencion")
                types.DeleteRegistrosTypeAtencion(id);
            else if (tableName == "TypeContextura")
                types.DeleteRegistrosTypeContextura(id);
            else if (tableName == "TypeCountry")
                types.DeleteRegistrosTypeCountry(id);
            else if (tableName == "TypeDepilacion")
                types.DeleteRegistrosTypeDepilacion(id);
            else if (tableName == "TypeDrink")
                types.DeleteRegistrosTypeAtencion(id);
            else if (tableName == "TypeEscort")
                types.DeleteRegistrosTypeEscort(id);
            else if (tableName == "TypeEyes")
                types.DeleteRegistrosTypeEyes(id);
            else if (tableName == "TypeGirls")
                types.DeleteRegistrosTypeGirls(id);
            else if (tableName == "TypeHair")
                types.DeleteRegistrosTypeHair(id);
            else if (tableName == "TypeNacionalidad")
                types.DeleteRegistrosTypeNacionalidad(id);
            else if (tableName == "TypePiel")
                types.DeleteRegistrosTypePiel(id);
            else if (tableName == "TypeServicesSex")
                types.DeleteRegistrosTypeServicesSex(id);
            else if (tableName == "TypeSex")
                types.DeleteRegistrosTypeSex(id);
            else if (tableName == "TypeSmoke")
                types.DeleteRegistrosTypeSmoke(id);


            return Json("Ok");
        }

        [HttpPost]
        public JsonResult InsertRegisterTable(string tableName, string descripcion)
        {

            if (tableName == "TypeAtencion")
            {
                var model = new TypeAtencion() { Ide = descripcion, Atencion = descripcion };
                types.InsertRegistrosTypeAtencion(model);
            }
            else if (tableName == "TypeContextura")
            {
                var model = new TypeContextura() { Ide = descripcion, Contextura = descripcion };
                types.InsertRegistrosTypeContextura(model);
            }
            else if (tableName == "TypeCountry")
            {
                var model = new TypeCountry() { Ide = descripcion, Pais = descripcion };
                types.InsertRegistrosTypeCountry(model);
            }
            else if (tableName == "TypeDepilacion")
            {
                var model = new TypeDepilacion() { Ide = descripcion, Depilacion = descripcion };
                types.InsertRegistrosTypeDepilacion(model);
            }
            else if (tableName == "TypeDrink")
            {
                var model = new TypeDrink() { Ide = descripcion, Drink = descripcion };
                types.InsertRegistrosTypeDrink(model);
            }
            else if (tableName == "TypeEscort")
            {
                var model = new TypeEscort() { Ide = descripcion, Categoria = descripcion };
                types.InsertRegistrosTypeEscort(model);
            }
            else if (tableName == "TypeEyes")
            {
                var model = new TypeEyes() { Ide = descripcion, Ojos = descripcion };
                types.InsertRegistrosTypeEyes(model);
            }
            else if (tableName == "TypeGirls")
            {
                var model = new TypeGirls() { Ide = descripcion, Type = descripcion };
                types.InsertRegistrosTypeGirls(model);
            }
            else if (tableName == "TypeHair")
            {
                var model = new TypeHair() { Ide = descripcion, ColorCabello = descripcion };
                types.InsertRegistrosTypeHair(model);
            }
            else if (tableName == "TypeNacionalidad")
            {
                var model = new TypeNacionalidad() { Ide = descripcion, Nacionalidad = descripcion };
                types.InsertRegistrosTypeNacionalidad(model);
            }
            else if (tableName == "TypePiel")
            {
                var model = new TypePiel() { Ide = descripcion, Piel = descripcion };
                types.InsertRegistrosTypePiel(model);
            }
            else if (tableName == "TypeServicesSex")
            {
                var model = new TypeServicesSex() { Ide = descripcion, Servicio = descripcion };
                types.InsertRegistrosTypeServicesSex(model);
            }
            else if (tableName == "TypeSex")
            {
                var model = new TypeSex() { Ide = descripcion, Sexo = descripcion };
                types.InsertRegistrosTypeSex(model);
            }
            else if (tableName == "TypeSmoke")
            {
                var model = new TypeSmoke() { Ide = descripcion, Smoke = descripcion };
                types.InsertRegistrosTypeSmoke(model);
            }


            return Json("Ok");
        }


        [HttpPost]
        public JsonResult GetPaises()
        {
            var registros = new List<AdmTablesModel>();
            registros = types.GetRegistrosTypeCountry();
            return Json(registros);
        }


        [HttpPost]
        public JsonResult GetLocalidades(string pais)
        {
            var registros = new List<AdmTablesModel>();
            registros = types.GetRegistrosTypeLocation(pais);
            return Json(registros);
        }


        [HttpPost]
        public JsonResult DeletePais(int id)
        {
            types.DeleteRegistrosTypeCountry(id);

            return Json("Ok");
        }


        [HttpPost]
        public JsonResult DeleteLocalidad(int id)
        {
            types.DeleteRegistrosTypeLocation(id);

            return Json("Ok");
        }

        [HttpPost]
        public JsonResult InsertLocalidad(string pais, string localidad)
        {
            var respuesta = new RespuestaModel();
            try
            {
                var model = new TypeLocation()
                {
                    Country = pais,
                    Ide = localidad,
                    Location = localidad
                };
                types.InsertRegistrosTypeLocation(model);
                respuesta.Descripcion = "Nueva localidad creada exitosamente";
            }
            catch
            {
                respuesta.Descripcion = "La localidad ya existe";
            }

            return Json(respuesta);
        }
    }
}
