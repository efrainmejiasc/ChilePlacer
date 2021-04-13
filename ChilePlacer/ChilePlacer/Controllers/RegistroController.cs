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
    public class RegistroController : Controller
    {
        private readonly IUtilidad util;
        private readonly IGirlsRepository girls;
        public RegistroController(IUtilidad _util, IGirlsRepository _girls)
        {
            util = _util;
            girls = _girls;
        }

        [HttpPost]
        public JsonResult RegistroGirls(string username, string mail , string password)
        {
            var respuesta = new RespuestaModel();
            if (girls.GetExisteUserName(username))
            {
                respuesta.Descripcion ="El usuario: " + username + "ya existe en nuestro sistema";
                return Json(respuesta);
            }
            var identificador = util.NuevoIdentificador();
            var password64 = util.CodeBase64(mail + password);


            return Json("");
        }
    }
}
