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
        public RespuestaModel UploadFileMethod(IFormFile file,string identidad)
        {
            var respuesta = new RespuestaModel();
            if (file != null)
            {
                try
                {
                    var p = file.FileName.Replace("_","").Split('.');
                    var name = p[0] + "_" + identidad + "." + p[1];
                    if (file.FileName.Contains(".JPG") || file.FileName.Contains(".JPEG") || file.FileName.Contains(".BMP") || file.FileName.Contains(".PNG"))
                    {
                        string path = "ClientApp/dist/assets/ProfileImageGirls/" + name;
                        if (!Directory.Exists("ClientApp/dist/assets/ProfileImageGirls"))
                        {
                            Directory.CreateDirectory("ClientApp/dist/assets/ProfileImageGirls/");
                        }
                        var stream = System.IO.File.Create(path);
                        file.CopyTo(stream);
                        stream.Dispose();
                    }
                    else
                    {
                        respuesta.Descripcion = "El archivo debe ser de tipo: (.jpg .jpeg .bmp .png)";
                        return respuesta;
                    }

                }
                catch (Exception ex)
                {
                    respuesta.Descripcion = ex.ToString();
                    return respuesta;
                }
            }
            else
            {
                respuesta.Descripcion = "El valor no puede ser nulo";
                return respuesta;
            }

            respuesta.Descripcion = "OK: Exito";
            return respuesta;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/PruebaApi")]
        public RespuestaModel PruebaApi (string id)
        {
            var respuesta = new RespuestaModel();
            respuesta.Descripcion = "OK: " + id;
            return respuesta;
        }
    }
}
