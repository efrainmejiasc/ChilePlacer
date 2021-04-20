using ChilePlacer.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.Application.Interfaces
{
    public interface ISendMail
    {
        bool EnviarMailNotificacion(string subject, string body, string emailDestiny);
        bool EnviarMailNotificacion(ActivacioMailModel model, IWebHostEnvironment _hostEnv);
    }
}
