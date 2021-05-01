using ChilePlacer.Application.Interfaces;
using ChilePlacer.Models;
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
    public class AplicacionController : Controller
    {
        private readonly IUtilidad util;
        private readonly ISendMail sendMail;
        private readonly IGirlsRepository girls;
        private readonly IWebHostEnvironment hostEnv;
        private readonly IHttpContextAccessor httpContext;
        private readonly IProfileGirlsRepository profileGirls;
        private readonly IGaleriaGirlsRepository galeriaGirls;


        public AplicacionController(IUtilidad _util, IGirlsRepository _girls, IWebHostEnvironment _hostEnv, ISendMail _sendMail, IProfileGirlsRepository _profileGirls, IGaleriaGirlsRepository _galeriaGirls, IHttpContextAccessor _httpContext)
        {
            util = _util;
            girls = _girls;
            hostEnv = _hostEnv;
            sendMail = _sendMail;
            httpContext = _httpContext;
            profileGirls = _profileGirls;
            galeriaGirls = _galeriaGirls;
        }

        [HttpPost]
        public List<ImagenPortadaModel> GetImagenesPortada()
        {
            var portadaContent = new List<ImagenPortadaModel>();
            portadaContent = galeriaGirls.GetImagenesGaleria();
            return portadaContent;
        }

        [HttpPost]
        public List<ImagenPortadaModel> GetImagenesPerfil(string identidad)
        {
            var perfilContent = new List<ImagenPortadaModel>();
            perfilContent = galeriaGirls.GetImagenesGaleria(Guid.Parse(identidad));
            return perfilContent;
        }

        [HttpPost]
        public JsonResult GetUsuario(string username)
        {
            var model = new GirlProfileModel();
            model = girls.GetUsuario(username, true);

            return Json(model);
        }

        [HttpPost]
        public JsonResult GetUsuarioProfile(string username)
        {
            var  model = new GirlProfileModel();
            model = girls.GetGirls(username, true);

            return Json(model);
        }


    }
}
