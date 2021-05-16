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
using System.Drawing;
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
        private readonly IGaleriaGirlsAudioRepository galeriaGirlsAudio;
        private readonly IAppLogRepository log;
        private readonly IImageTool imageTool;
        public ExternalController(IWebHostEnvironment _hostEnv, IUtilidad _util, IGaleriaGirlsRepository _galeriaGirls, IGirlsRepository _girls, IAppLogRepository _log, IImageTool _imageTool, IGaleriaGirlsAudioRepository _galeriaGirlsAudio)
        {
            util = _util;
            hostEnv = _hostEnv;
            girls = _girls;
            galeriaGirls = _galeriaGirls;
            galeriaGirlsAudio = _galeriaGirlsAudio;
            imageTool = _imageTool;
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
                        imageTool.MarcaDeAguaPerfil(path,pathName);
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
                    string path = "ClientApp/dist/assets/Girls";
                    string pathAll = path + "/All/";
                    string pathAll2 = path + "/All2/";
                    string pathName = string.Empty;

                    util.CrearDirectorio(path);
                    util.CrearDirectorio();
                    var nameFile = file.FileName.Replace("_", "");
                    var p = nameFile.Split('.');
                    var name = p[0] + "_" + identidad + "." + p[1];


                    if (file.FileName.ToUpper().Contains(".JPG") || file.FileName.ToUpper().Contains(".JPEG") || file.FileName.ToUpper().Contains(".BMP") || file.FileName.ToUpper().Contains(".PNG"))
                    {
                        var stream = System.IO.File.Create(pathAll + nameFile);
                        file.CopyTo(stream);
                        stream.Dispose();

                        Image image = Image.FromFile(pathAll + nameFile);
                        image = (Image)imageTool.ResizeImage(image, 360, 250);
                        image.Save(pathAll2 + nameFile);

                        pathName = path + "/Photo/" + name;
                        imageTool.MarcaDeAgua(pathAll2 + nameFile, pathName);

                        var girlsModel = girls.GetGirls(Guid.Parse(identidad));
                        var galeria = util.SetGaleriaGirls(girlsModel, name, pathName, texto);
                        galeriaGirls.InsertGaleriaGirls(galeria);
                    }
                    else if (file.FileName.ToUpper().Contains(".GIF"))
                    {
                        var stream = System.IO.File.Create(pathAll + nameFile);
                        file.CopyTo(stream);
                        stream.Dispose();

                        Image image = Image.FromFile(pathAll + nameFile);
                        image = (Image)imageTool.ResizeImage(image, 360, 250);
                        image.Save(pathAll2 + nameFile);

                        pathName = path + "/Gift/" + name;
                        imageTool.MarcaDeAguaPerfil(pathAll2 + nameFile, pathName);

                        var girlsModel = girls.GetGirls(Guid.Parse(identidad));
                        var galeria = util.SetGaleriaGirls(girlsModel, name, pathName, texto);
                        galeriaGirls.InsertGaleriaGirls(galeria);
                    }
                    else if (file.FileName.ToUpper().Contains(".MP3") || file.FileName.ToUpper().Contains(".MP4"))
                    {
                        pathName = path + "/Audio/" + nameFile;
                        var stream = System.IO.File.Create(pathName);
                        file.CopyTo(stream);
                        stream.Dispose();

                        var galeria = util.SetGaleriaGirlsAudio(Guid.Parse(identidad), pathName);
                        galeriaGirlsAudio.InsertGaleriaGirlAudio(galeria);
                    }
                    else
                    {
                        respuesta.Descripcion = "El archivo debe ser de tipo: (.jpg .jpeg .bmp .png .gif)";
                        return respuesta;
                    }
                 
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
