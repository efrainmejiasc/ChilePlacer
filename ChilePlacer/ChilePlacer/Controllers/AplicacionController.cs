using ChilePlacer.Application.Interfaces;
using ChilePlacer.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
    }
}
