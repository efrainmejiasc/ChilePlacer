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
            s.IdTabla = "TypeContextura"; s.NombreTabla = "Tipos de Contextura";
            nameTables.Add(s);
            s = new AdmTablesModel();
            s.IdTabla = "TypeCountry"; s.NombreTabla = "Pais residencia";
            nameTables.Add(s);
            s = new AdmTablesModel();
            s.IdTabla = "TypeDepilacion"; s.NombreTabla = "Tipos de Depilacion";
            nameTables.Add(s);
            s = new AdmTablesModel();
            s.IdTabla = "TypeDrink"; s.NombreTabla = "Consumo Alchol";
            nameTables.Add(s);
            s = new AdmTablesModel();
            s.IdTabla = "TypeEscort"; s.NombreTabla = "Categoria escort";
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
            s.IdTabla = "TypeNacionalidad"; s.NombreTabla = "Pais de origen";
            nameTables.Add(s);
            s = new AdmTablesModel();
            s.IdTabla = "TypePiel"; s.NombreTabla = "Color de piel";
            nameTables.Add(s);
            s = new AdmTablesModel();
            s.IdTabla = "TypeServicesSex"; s.NombreTabla = "Servicios sexuales";
            nameTables.Add(s);
            s = new AdmTablesModel();
            s.IdTabla = "TypeSex"; s.NombreTabla = "Sexos";
            nameTables.Add(s);
            s = new AdmTablesModel();
            s.IdTabla = "TypeSmoke"; s.NombreTabla = "Consumo tabaco";
            nameTables.Add(s);


            return Json(nameTables);
        }


        [HttpPost]
        public JsonResult GetRegisterTable(string tableName)
        {
            var registros = new List<AdmTablesModel>();

            if (tableName == "TypeAtencion")
                registros = types.GetRegistrosTypeAtencion();
            else if (tableName == "TypeContextura")
                registros = types.GetRegistrosTypeContextura();
            else if (tableName == "TypeCountry")
                registros = types.GetRegistrosTypeCountry();
            else if (tableName == "TypeDepilacion")
                registros = types.GetRegistrosTypeDepilacion();
            else if (tableName == "TypeDrink")
                registros = types.GetRegistrosTypeAtencion();
            else if (tableName == "TypeEscort")
                registros = types.GetRegistrosTypeEscort();
            else if (tableName == "TypeEyes")
                registros = types.GetRegistrosTypeEyes();
            else if (tableName == "TypeGirls")
                registros = types.GetRegistrosTypeGirls();
            else if (tableName == "TypeHair")
                registros = types.GetRegistrosTypeHair();
            else if (tableName == "TypeNacionalidad")
                registros = types.GetRegistrosTypeNacionalidad();
            else if (tableName == "TypePiel")
                registros = types.GetRegistrosTypePiel();
            else if (tableName == "TypeServicesSex")
                registros = types.GetRegistrosTypeServicesSex();
            else if (tableName == "TypeSex")
                registros = types.GetRegistrosTypeSex();
            else if (tableName == "TypeSmoke")
                registros = types.GetRegistrosTypeSmoke();
            

            return Json(registros);
        }


        [HttpPost]
        public JsonResult DeleteRegisterTable(string tableName, int id)
        {
            var registros = new List<AdmTablesModel>();

            if (tableName == "TypeAtencion")
                registros = types.GetRegistrosTypeAtencion();
            else if (tableName == "TypeContextura")
                registros = types.GetRegistrosTypeContextura();
            else if (tableName == "TypeCountry")
                registros = types.GetRegistrosTypeCountry();
            else if (tableName == "TypeDepilacion")
                registros = types.GetRegistrosTypeDepilacion();
            else if (tableName == "TypeDrink")
                registros = types.GetRegistrosTypeAtencion();
            else if (tableName == "TypeEscort")
                registros = types.GetRegistrosTypeEscort();
            else if (tableName == "TypeEyes")
                registros = types.GetRegistrosTypeEyes();
            else if (tableName == "TypeGirls")
                registros = types.GetRegistrosTypeGirls();
            else if (tableName == "TypeHair")
                registros = types.GetRegistrosTypeHair();
            else if (tableName == "TypeNacionalidad")
                registros = types.GetRegistrosTypeNacionalidad();
            else if (tableName == "TypePiel")
                registros = types.GetRegistrosTypePiel();
            else if (tableName == "TypeServicesSex")
                registros = types.GetRegistrosTypeServicesSex();
            else if (tableName == "TypeSex")
                registros = types.GetRegistrosTypeSex();
            else if (tableName == "TypeSmoke")
                registros = types.GetRegistrosTypeSmoke();


            return Json(registros);
        }

        [HttpPost]
        public JsonResult InsertRegisterTable(string tableName, string descripcion)
        {
            var registros = new List<AdmTablesModel>();

            if (tableName == "TypeAtencion")
                registros = types.GetRegistrosTypeAtencion();
            else if (tableName == "TypeContextura")
                registros = types.GetRegistrosTypeContextura();
            else if (tableName == "TypeCountry")
                registros = types.GetRegistrosTypeCountry();
            else if (tableName == "TypeDepilacion")
                registros = types.GetRegistrosTypeDepilacion();
            else if (tableName == "TypeDrink")
                registros = types.GetRegistrosTypeAtencion();
            else if (tableName == "TypeEscort")
                registros = types.GetRegistrosTypeEscort();
            else if (tableName == "TypeEyes")
                registros = types.GetRegistrosTypeEyes();
            else if (tableName == "TypeGirls")
                registros = types.GetRegistrosTypeGirls();
            else if (tableName == "TypeHair")
                registros = types.GetRegistrosTypeHair();
            else if (tableName == "TypeNacionalidad")
                registros = types.GetRegistrosTypeNacionalidad();
            else if (tableName == "TypePiel")
                registros = types.GetRegistrosTypePiel();
            else if (tableName == "TypeServicesSex")
                registros = types.GetRegistrosTypeServicesSex();
            else if (tableName == "TypeSex")
                registros = types.GetRegistrosTypeSex();
            else if (tableName == "TypeSmoke")
                registros = types.GetRegistrosTypeSmoke();


            return Json(registros);
        }
    }
}
