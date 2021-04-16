using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.api
{

    [ApiController]
    public class ExternalController : ControllerBase
    {

        [HttpPost]
        [AllowAnonymous]
        [Route("api/UploadFileMethod")]
        public string UploadFileMethod(IFormFile file)
        {
            if (file != null)
            {                try
                {
                    if (!file.FileName.Contains(".csv"))
                    {
                        //ViewBag.Message = "El archivo debe ser con extenxion .csv";
                        return "Test";
                    }
                    string path = Path.Combine("ArchivosFTP", file.FileName);
                    var stream = System.IO.File.Create(path);
                    file.CopyTo(stream);
                    stream.Dispose();
                    //ViewBag.Message = "Archivo " + file.FileName + " cargado correctamente";
                }
                catch (Exception ex)
                {
                    //ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            }
            else
            {
                //ViewBag.Message = "Selecciona un archivp";
            }
            return "Test";
        }
    }
}
