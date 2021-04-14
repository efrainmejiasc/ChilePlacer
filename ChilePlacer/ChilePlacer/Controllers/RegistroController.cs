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
            var modelGirl = util.SetGirlsModel(username, mail, password64,identificador);
            modelGirl = girls.InsertGirls(modelGirl);

            if(modelGirl.Id > 0)
                respuesta.Descripcion = "Registro satisfactorio, fue enviado un email a tu direccion electronica para la activacion de tu cuenta";
            else
                respuesta.Descripcion = "Registro fallido";

            return Json(respuesta);
        }
    }
}
