using ChilePlacer.Application.Interfaces;
using ChilePlacer.DataModels;
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
            if (tableName == "TypeAtencion")
                types.DeleteRegistrosTypeAtencion(id);
            else if (tableName == "TypeContextura")
                types.DeleteRegistrosTypeContextura(id);
            else if (tableName == "TypeCountry")
                types.DeleteRegistrosTypeCountry(id);
            else if (tableName == "TypeDepilacion")
                types.DeleteRegistrosTypeDepilacion(id);
            else if (tableName == "TypeDrink")
                types.DeleteRegistrosTypeAtencion(id);
            else if (tableName == "TypeEscort")
                types.DeleteRegistrosTypeEscort(id);
            else if (tableName == "TypeEyes")
                types.DeleteRegistrosTypeEyes(id);
            else if (tableName == "TypeGirls")
                types.DeleteRegistrosTypeGirls(id);
            else if (tableName == "TypeHair")
                types.DeleteRegistrosTypeHair(id);
            else if (tableName == "TypeNacionalidad")
                types.DeleteRegistrosTypeNacionalidad(id);
            else if (tableName == "TypePiel")
                types.DeleteRegistrosTypePiel(id);
            else if (tableName == "TypeServicesSex")
                types.DeleteRegistrosTypeServicesSex(id);
            else if (tableName == "TypeSex")
                types.DeleteRegistrosTypeSex(id);
            else if (tableName == "TypeSmoke")
                types.DeleteRegistrosTypeSmoke(id);


            return Json("Ok");
        }

        [HttpPost]
        public JsonResult InsertRegisterTable(string tableName, string descripcion)
        {

            if (tableName == "TypeAtencion")
            {
                var model = new TypeAtencion() { Ide = descripcion, Atencion = descripcion };
                types.InsertRegistrosTypeAtencion(model);
            }
            else if (tableName == "TypeContextura")
            {
                var model = new TypeContextura() { Ide = descripcion, Contextura = descripcion };
                types.InsertRegistrosTypeContextura(model);
            }
            else if (tableName == "TypeCountry")
            {
                var model = new TypeCountry() { Ide = descripcion, Pais = descripcion };
                types.InsertRegistrosTypeCountry(model);
            }
            else if (tableName == "TypeDepilacion")
            {
                var model = new TypeDepilacion() { Ide = descripcion, Depilacion = descripcion };
                types.InsertRegistrosTypeDepilacion(model);
            }
            else if (tableName == "TypeDrink")
            {
                var model = new TypeDrink() { Ide = descripcion, Drink = descripcion };
                types.InsertRegistrosTypeDrink(model);
            }
            else if (tableName == "TypeEscort")
            {
                var model = new TypeEscort() { Ide = descripcion, Categoria = descripcion };
                types.InsertRegistrosTypeEscort(model);
            }
            else if (tableName == "TypeEyes")
            {
                var model = new TypeEyes() { Ide = descripcion, Ojos = descripcion };
                types.InsertRegistrosTypeEyes(model);
            }
            else if (tableName == "TypeGirls")
            {
                var model = new TypeGirls() { Ide = descripcion, Type = descripcion };
                types.InsertRegistrosTypeGirls(model);
            }
            else if (tableName == "TypeHair")
            {
                var model = new TypeHair() { Ide = descripcion, ColorCabello = descripcion };
                types.InsertRegistrosTypeHair(model);
            }
            else if (tableName == "TypeNacionalidad")
            {
                var model = new TypeNacionalidad() { Ide = descripcion, Nacionalidad = descripcion };
                types.InsertRegistrosTypeNacionalidad(model);
            }
            else if (tableName == "TypePiel")
            {
                var model = new TypePiel() { Ide = descripcion, Piel = descripcion };
                types.InsertRegistrosTypePiel(model);
            }
            else if (tableName == "TypeServicesSex")
            {
                var model = new TypeServicesSex() { Ide = descripcion, Servicio = descripcion };
                types.InsertRegistrosTypeServicesSex(model);
            }
            else if (tableName == "TypeSex")
            {
                var model = new TypeSex() { Ide = descripcion, Sexo = descripcion };
                types.InsertRegistrosTypeSex(model);
            }
            else if (tableName == "TypeSmoke")
            {
                var model = new TypeSmoke() { Ide = descripcion, Smoke = descripcion };
                types.InsertRegistrosTypeSmoke(model);
            }


            return Json("Ok");
        }
    }
}
