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
        private readonly IPortadaGirlsRepository portadaGirls;


        public AplicacionController(IUtilidad _util, IGirlsRepository _girls, IWebHostEnvironment _hostEnv, ISendMail _sendMail, IProfileGirlsRepository _profileGirls, IPortadaGirlsRepository _portadaGirls, IHttpContextAccessor _httpContext)
        {
            util = _util;
            girls = _girls;
            hostEnv = _hostEnv;
            sendMail = _sendMail;
            httpContext = _httpContext;
            profileGirls = _profileGirls;
            portadaGirls = _portadaGirls;
        }

        [HttpPost]
        public List<ImagenPortadaModel> GetImagenesPortada()
        {
            var imagenes = new List<ImagenPortadaModel>();
            imagenes = MockImagenes();
            return imagenes;
        }

        [HttpPost]
        public List<ImagenPortadaModel> GetImagenesPerfil(string identidad)
        {
            var imagenes = new List<ImagenPortadaModel>();
            imagenes = MockImagenes();
            return imagenes;
        }

        public List<ImagenPortadaModel> MockImagenes()
        {
            var list = new List<ImagenPortadaModel>();

            var a = new ImagenPortadaModel()
            {
                Id = 1,
                IdGirl = 1,
                Identidad = "BCDE6EC1-D8FA-4D4C-ACB9-86FD213B2B2E",
                Username = "Katerina",
                PathImagen =  "assets/PortadaGirls/Katerina.jpg",
                UrlProfile = "http://localhost:4200/profile-girl?user=" + "EfrainMejiasC-2020",
                Texto = "Una chica de compañía, acompañante o escort es una mujer remunerada para eventos sociales"
            };
            list.Add(a);

            var b = new ImagenPortadaModel()
            {
                Id = 2,
                IdGirl = 2,
                Identidad = "1B9CC4D1-2319-4F5C-ACC8-03C8F357EA4A",
                Username = "Melissa",
                PathImagen = "assets/PortadaGirls/Melissa.jpg",
                UrlProfile = "http://localhost:4200/profile-girl?user=" + "yahoo-3456",
                Texto = "Una chica de compañía, acompañante o escort es una mujer remunerada para eventos sociales"
            };
            list.Add(b);

            var c= new ImagenPortadaModel()
            {
                Id = 3,
                IdGirl = 3,
                Identidad = "61F8BE30-6AE1-45E2-97A9-D0AC2D8CE3A6",
                Username = "Yorkira",
                PathImagen = "assets/PortadaGirls/Yorkina.jpg",
                UrlProfile = "http://localhost:4200/profile-girl?user=" + "Katerina",
                Texto = "Una chica de compañía, acompañante o escort es una mujer remunerada para eventos sociales"
            };

            list.Add(c);

            var d = new ImagenPortadaModel()
            {
                Id = 4,
                IdGirl = 4,
                Identidad = "61F8BE30-6AE1-45E2-97A9-D0AC2D8CE3A6",
                Username = "Karelis",
                PathImagen = "assets/PortadaGirls/Karelis.jpg",
                UrlProfile = "http://localhost:4200/profile-girl?user=" + "Katerina",
                 Texto = "Una chica de compañía, acompañante o escort es una mujer remunerada para eventos sociales"
            };

            list.Add(d);

            var e = new ImagenPortadaModel()
            {
                Id = 5,
                IdGirl = 5,
                Identidad = "61F8BE30-6AE1-45E2-97A9-D0AC2D8CE3A6",
                Username = "Brus",
                PathImagen = "assets/PortadaGirls/Brus.jpg",
                UrlProfile = "http://localhost:4200/profile-girl?user=" + "Katerina",
                Texto = "Una chica de compañía, acompañante o escort es una mujer remunerada para eventos sociales",
            };

            list.Add(e);

            var f = new ImagenPortadaModel()
            {
                Id = 6,
                IdGirl = 6,
                Identidad = "61F8BE30-6AE1-45E2-97A9-D0AC2D8CE3A6",
                Username = "Geraldin",
                PathImagen = "assets/PortadaGirls/Geraldin.jpg",
                UrlProfile = "http://localhost:4200/profile-girl?user=" + "Katerina",
                Texto = "Una chica de compañía, acompañante o escort es una mujer remunerada para eventos sociales",
            };

            list.Add(f);

            return list;
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
