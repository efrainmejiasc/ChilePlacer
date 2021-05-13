using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ChilePlacer.Application.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ChilePlacer.Controllers
{
    public class TestController : Controller
    {
        private readonly IWebHostEnvironment hostEnv;
        private readonly IImageTool imageTool;
        public TestController(IWebHostEnvironment _hostEnv, IImageTool _imageTool)
        {
            hostEnv = _hostEnv;
            imageTool = _imageTool;
        }
        public IActionResult Index()
        {
           /* var list = PathImagenes();
            foreach(var x in list)
            {
                var nameFile = x.Split('\\');
                var path = Path.Combine(hostEnv.ContentRootPath,@"ClientApp\dist", x);
                var imagen = Image.FromFile(path);
                var img = (Image) imageTool.ResizeImage(imagen, 312, 240, path);
                img.Save(Path.Combine(hostEnv.ContentRootPath, @"ClientApp\dist", @"assets\PortadaGirls\" + nameFile[2]), ImageFormat.Jpeg);
            }*/


            return View();
        }

        private List<string> PathImagenes()
        {
            var list = new List<string>();
            var a = @"assets\Imagenes\Brus.jpg";
            list.Add(a);
            var b = @"assets\Imagenes\Geraldin.jpg";
            list.Add(b);
            var c = @"assets\Imagenes\Karelis.jpg";
            list.Add(c);
            var d = @"assets\Imagenes\Katerina.jpg";
            list.Add(d);
            var e = @"assets\Imagenes\Melissa.jpg";
            list.Add(e);
            var f = @"assets\Imagenes\Yorkira.jpg";
            list.Add(f);

            return list;
        }
    }
}
