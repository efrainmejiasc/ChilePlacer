using ChilePlacer.Application.Interfaces;
using ChilePlacer.Models;
using ChilePlacer.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.Controllers
{
    public class AdmTablesController : Controller
    {
        private readonly IUtilidad util;
        private readonly ITypesRepository types;
        public AdmTablesController(IUtilidad _util, ITypesRepository _types)
        {
            util = _util;
            types = _types;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetNameTables()
        {
            var nameTables = new List<AdmTablesModel>();
            var s = new AdmTablesModel();

            s.IdTabla = "TypeAtencion"; s.NombreTabla = "Tipos de Atencion";
            nameTables.Add(s);
            s = new AdmTablesModel();
            s.IdTabla = "TypeDepilacion"; s.NombreTabla = "Tipos de Depilacion";
            nameTables.Add(s);
            s = new AdmTablesModel();
            s.IdTabla = "TypeDrink"; s.NombreTabla = "Consumo Alchol";
            nameTables.Add(s);
            s = new AdmTablesModel();
            s.IdTabla = "TypeEyes"; s.NombreTabla = "Color de ojos";
            nameTables.Add(s);
            s = new AdmTablesModel();
            s.IdTabla = "TypeGirls"; s.NombreTabla = "Tipo de chicas";
            nameTables.Add(s);
            s = new AdmTablesModel();
            s.IdTabla = "TypeHair"; s.NombreTabla = "Color de cabello";
            nameTables.Add(s);
            s = new AdmTablesModel();
            s.IdTabla = "TypePiel"; s.NombreTabla = "Color de piel";
            nameTables.Add(s);
            s = new AdmTablesModel();
            s.IdTabla = "TypeServicesSex"; s.NombreTabla = "Servvicios sexuales";
            nameTables.Add(s);
            s = new AdmTablesModel();
            s.IdTabla = "TypeSex"; s.NombreTabla = "Sexos";
            nameTables.Add(s);
            s = new AdmTablesModel();
            s.IdTabla = "TypeSmoke"; s.NombreTabla = "Consumo tabaco";
            nameTables.Add(s);
            s = new AdmTablesModel();
            s.IdTabla = "TypeDrink"; s.NombreTabla = "TypeDrink";
            nameTables.Add(s);
            s = new AdmTablesModel();
            s.IdTabla = "TypeCountry"; s.NombreTabla = "Pais residencia";
            nameTables.Add(s);
            s = new AdmTablesModel();
            s.IdTabla = "TypeLocation"; s.NombreTabla = "Ubicacion en pais";
            nameTables.Add(s);
            s = new AdmTablesModel();
            s.IdTabla = "TypeNacionalidad"; s.NombreTabla = "Pais de origen";
            nameTables.Add(s);
            s = new AdmTablesModel();
            s.IdTabla = "TypeAtencionGirl"; s.NombreTabla = "tipos de atencion";
            nameTables.Add(s);
            s = new AdmTablesModel();
            s.IdTabla = "TypeGirlServices"; s.NombreTabla = "Servicios Ofrecidos";
            nameTables.Add(s);

            return Json(nameTables);
        }


        [HttpPost]
        public JsonResult GetRegisterTable()
        {
            var registros = new List<AdmTablesModel>();
            registros = types.GetRegistrosTypeEscort();
            return Json(registros);
        }
    }
}
