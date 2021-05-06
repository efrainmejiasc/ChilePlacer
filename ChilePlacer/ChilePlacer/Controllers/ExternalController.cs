using ChilePlacer.Application;
using ChilePlacer.Application.Interfaces;
using ChilePlacer.DataModels;
using ChilePlacer.Models;
using ChilePlacer.Repositories.Interfaces;
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
        private readonly IUtilidad util;
        private readonly IGirlsRepository girls;
        private readonly IGaleriaGirlsRepository galeriaGirls;
        private readonly IAppLogRepository log;
        public ExternalController(IWebHostEnvironment _hostEnv, IUtilidad _util, IGaleriaGirlsRepository _galeriaGirls, IGirlsRepository _girls, IAppLogRepository _log)
        {
            util = _util;
            hostEnv = _hostEnv;
            girls = _girls;
            galeriaGirls = _galeriaGirls;
            log = _log;
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
                    if (file.FileName.ToUpper().Contains(".JPG") || file.FileName.ToUpper().Contains(".JPEG") || file.FileName.ToUpper().Contains(".BMP") || file.FileName.ToUpper().Contains(".PNG"))
                    {
                        util.CrearDirectorio("ClientApp/dist/assets/ProfileImageGirls");
                        string path = "ClientApp/dist/assets/ProfileImageGirls/" + file.FileName.Replace("_", "");
                        string pathName = "ClientApp/dist/assets/ProfileImageGirls/" + name;
                        var stream = System.IO.File.Create(path);
                        file.CopyTo(stream);
                        stream.Dispose();
                        util.MarcaDeAgua(path,pathName);
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
        [Route("api/UploadFilePublication")]
        public RespuestaModel UploadFilePublication(IFormFile file, string identidad,string texto = "")
        {
            var respuesta = new RespuestaModel();
            if (file != null)
            {
                try
                {
                    var p = file.FileName.Replace("_", "").Split('.');
                    var name = p[0] + "_" + identidad + "." + p[1];
                    string path = "ClientApp/dist/assets/Girls/";
                    util.CrearDirectorio("ClientApp/dist/assets/Girls");

                    if (file.FileName.ToUpper().Contains(".JPG") || file.FileName.ToUpper().Contains(".JPEG") || file.FileName.ToUpper().Contains(".BMP") || file.FileName.ToUpper().Contains(".PNG"))
                    {
                        util.CrearDirectorio("ClientApp/dist/assets/Girls/Photo");
                        path = "ClientApp/dist/assets/Girls/Photo/" + name;
                    }
                    else if (file.FileName.ToUpper().Contains(".GIF"))
                    {
                        util.CrearDirectorio("ClientApp/dist/assets/Girls/Gift");
                        path = "ClientApp/dist/assets/Girls/Gift/" + name;
                    }
                    else if (file.FileName.ToUpper().Contains(".MP3") || file.FileName.ToUpper().Contains(".MP4"))
                    {
                        util.CrearDirectorio("ClientApp/dist/assets/Girls/Audio");
                        path = "ClientApp/dist/assets/Girls/Audio/" + name;
                    }
                    else
                    {
                        respuesta.Descripcion = "El archivo debe ser de tipo: (.jpg .jpeg .bmp .png .gif)";
                        return respuesta;
                    }

                    var stream = System.IO.File.Create(path);
                    file.CopyTo(stream);
                    stream.Dispose();

                    var girlsModel = girls.GetGirls(Guid.Parse(identidad));
                    var galeria = util.SetGaleriaGirls(girlsModel, name, path, texto);
                    galeriaGirls.InsertGaleriaGirls(galeria);
                   
                }
                catch (Exception ex)
                {
                    var error = new AppLog()
                    {
                        Error = ex.ToString(),
                        Metodo = "ExternalController,UploadFilePublication",
                        Fecha = DateTime.UtcNow,
                    };
                    log.InserAppLog(error);
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

        [HttpGet]
        [AllowAnonymous]
        [Route("api/{id?}")]
        public RedirectResult PruebaApi (string id) // id = username
        {
            if (string.IsNullOrEmpty(id))
                return RedirectPermanent(EngineData.UrlServerHost);

            var girl = girls.GetGirls(id);
            if (girl == null)
                 return RedirectPermanent(EngineData.UrlServerHost);
            else
                return RedirectPermanent(EngineData.UrlServerHost + "cl?user=" + girl.Username + "&ide=" + util.CodeBase64(girl.Identidad));
        }

    }
}
