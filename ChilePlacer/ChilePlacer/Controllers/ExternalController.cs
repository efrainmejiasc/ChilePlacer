using ChilePlacer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace ChilePlacer.Controllers
{

    [ApiController]
    public class ExternalController : ControllerBase
    {
        private readonly IWebHostEnvironment hostEnv;

        public ExternalController(IWebHostEnvironment _hostEnv)
        {
            hostEnv = _hostEnv;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/UploadFileMethod")]
        public string UploadFileMethod(IFormFile file,string username,string identidad)
        {
            if (file != null)
            {
                try
                {
                    var p = file.FileName.Replace("_","").Split('.');
                    var name = p[0] + "_" + identidad + "." + p[1];
                    if (file.FileName.Contains(".JPG") || file.FileName.Contains(".JPEG") || file.FileName.Contains(".BMP") || file.FileName.Contains(".PNG"))
                    {
                        string path = Path.Combine(hostEnv.WebRootPath, "ClientApp/dis/assets/ProfileImageGirls", name);
                        var stream = System.IO.File.Create(path);
                        file.CopyTo(stream);
                        stream.Dispose();
                    }
                    else
                        return "El archivo debe ser de tipo: (.jpg .jpeg .bmp .png)";

                }
                catch (Exception ex)
                {
                    return ex.ToString(); ;
                }
            }
            else
            {
                return "El valor no puede ser nulo";
            }

            return "OK";
        }
    }
}
