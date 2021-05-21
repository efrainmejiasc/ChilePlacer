using ChilePlacer.DataModels;
using ChilePlacer.Models;
using ChilePlacer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.Repositories
{
    public class TypesRepository: ITypesRepository
    {
        private readonly MyAppContext db;

        public TypesRepository(MyAppContext _db)
        {
            db = _db;
        }

        #region GETREGISTROS_TABLA

        public List<TypeSex> GetSex()
        {
            return db.TypeSex.OrderBy(x => x.Id).ToList();
        }

        public List<TypeEscort> GetEscort()
        {
            return db.TypeEscort.OrderBy(x => x.Id).ToList();
        }

        public List<TypeContextura> GetContextura()
        {
            return db.TypeContextura.OrderBy(x => x.Id).ToList();
        }

        public List<TypePiel> GetPiel()
        {
            return db.TypePiel.OrderBy(x => x.Id).ToList();
        }


        public List<TypeHair> GetHair()
        {
            return db.TypeHair.OrderBy(x => x.Id).ToList();
        }

        public List<TypeEyes> GetEyes()
        {
            return db.TypeEyes.OrderBy(x => x.Id).ToList();
        }

        public List<TypeDrink> GetDrink()
        {
            return db.TypeDrink.OrderBy(x => x.Id).ToList();
        }

        public List<TypeSmoke> GetSmoke()
        {
            return db.TypeSmoke.OrderBy(x => x.Id).ToList();
        }

        public List<TypeAtencion> GetAtencion()
        {
            return db.TypeAtencion.OrderBy(x => x.Id).ToList();
        }

        public List<TypeServicesSex> GetServicios()
        {
            return db.TypeServicesSex.OrderBy(x => x.Id).ToList();
        }

        public List<TypeCountry> GetCountry()
        {
            return db.TypeCountry.OrderBy(x => x.Id).ToList();
        }

        public List<TypeLocation> GetLocation()
        {
            return db.TypeLocation.OrderBy(x => x.Id).ToList();
        }

        public List<TypeNacionalidad> GetNacionalidad()
        {
            return db.TypeNacionalidad.OrderBy(x => x.Id).ToList();
        }

        public List<TypeDepilacion> GetDepilacion()
        {
            return db.TypeDepilacion.OrderBy(x => x.Id).ToList();
        }


        #endregion


        #region APLICACION
        public List<TypeGirlServices> InsertTypeServiceSex(List<TypeGirlServices> model)
        {
            db.TypeGirlServices.AddRange(model);
            db.SaveChanges();

            return model;
        }

        public List<TypeAtencionGirl> InsertTypeAtencionGirl(List<TypeAtencionGirl> model)
        {
            db.TypeAtencionGirl.AddRange(model);
            db.SaveChanges();

            return model;
        }

        public void DeleteTypeServiceSex(List<TypeGirlServices> model, Guid identidad)
        {
            var l = db.TypeGirlServices.Where(x => x.Identidad == identidad).ToList();
            db.RemoveRange(l);
            db.SaveChanges();

            InsertTypeServiceSex(model);
        }

        public void DeleteTypeAtencionGirl(List<TypeAtencionGirl> model, Guid identidad)
        {
            var l = db.TypeAtencionGirl.Where(x => x.Identidad == identidad).ToList();
            db.RemoveRange(l);
            db.SaveChanges();

            InsertTypeAtencionGirl(model);
        }
        #endregion


        #region GET_REGISTROS

        public List<AdmTablesModel> GetRegistrosTypeAtencion()
        {
            var model = GetAtencion();
            var lst = new List<AdmTablesModel>();
            var s = new AdmTablesModel();
            foreach (var x in model)
            {
                s.Id = x.Id;
                s.Ide = x.Ide;
                s.Descripcion = x.Atencion;
                lst.Add(s);
                s = new AdmTablesModel();
            }
            return lst;
        }

        public List<AdmTablesModel> GetRegistrosTypeContextura()
        {
            var model = GetContextura();
            var lst = new List<AdmTablesModel>();
            var s = new AdmTablesModel();
            foreach (var x in model)
            {
                s.Id = x.Id;
                s.Ide = x.Ide;
                s.Descripcion = x.Contextura;
                lst.Add(s);
                s = new AdmTablesModel();
            }
            return lst;
        }

        public List<AdmTablesModel> GetRegistrosTypeCountry()
        {
            var model = GetCountry();
            var lst = new List<AdmTablesModel>();
            var s = new AdmTablesModel();
            foreach (var x in model)
            {
                s.Id = x.Id;
                s.Ide = x.Ide;
                s.Descripcion = x.Pais;
                lst.Add(s);
                s = new AdmTablesModel();
            }
            return lst;
        }

        public List<AdmTablesModel> GetRegistrosTypeDepilacion()
        {
            var model = GetDepilacion();
            var lst = new List<AdmTablesModel>();
            var s = new AdmTablesModel();
            foreach (var x in model)
            {
                s.Id = x.Id;
                s.Ide = x.Ide;
                s.Descripcion = x.Depilacion;
                lst.Add(s);
                s = new AdmTablesModel();
            }
            return lst;
        }

        public List<AdmTablesModel> GetRegistrosTypeDrink()
        {
            var model = GetDrink();
            var lst = new List<AdmTablesModel>();
            var s = new AdmTablesModel();
            foreach (var x in model)
            {
                s.Id = x.Id;
                s.Ide = x.Ide;
                s.Descripcion = x.Drink;
                lst.Add(s);
                s = new AdmTablesModel();
            }
            return lst;
        }

        public List<AdmTablesModel> GetRegistrosTypeEscort()
        {
            var model = GetEscort();
            var lst = new List<AdmTablesModel>();
            var s = new AdmTablesModel();
            foreach (var x in model)
            {
                s.Id = x.Id;
                s.Ide = x.Ide;
                s.Descripcion = x.Categoria;
                lst.Add(s);
                s = new AdmTablesModel();
            }
            return lst;
        }

        public List<AdmTablesModel> GetRegistrosTypeEyes()
        {
            var model = GetEyes();
            var lst = new List<AdmTablesModel>();
            var s = new AdmTablesModel();
            foreach (var x in model)
            {
                s.Id = x.Id;
                s.Ide = x.Ide;
                s.Descripcion = x.Ojos;
                lst.Add(s);
                s = new AdmTablesModel();
            }
            return lst;
        }

        public List<AdmTablesModel> GetRegistrosTypeGirls()
        {
            var model = db.TypeGirls.ToList();
            var lst = new List<AdmTablesModel>();
            var s = new AdmTablesModel();
            foreach (var x in model)
            {
                s.Id = x.Id;
                s.Ide = x.Ide;
                s.Descripcion = x.Type;
                lst.Add(s);
                s = new AdmTablesModel();
            }
            return lst;
        }

        public List<AdmTablesModel> GetRegistrosTypeHair()
        {
            var model = GetHair();
            var lst = new List<AdmTablesModel>();
            var s = new AdmTablesModel();
            foreach (var x in model)
            {
                s.Id = x.Id;
                s.Ide = x.Ide;
                s.Descripcion = x.ColorCabello;
                lst.Add(s);
                s = new AdmTablesModel();
            }
            return lst;
        }

        public List<AdmTablesModel> GetRegistrosTypeNacionalidad()
        {
            var model = GetNacionalidad();
            var lst = new List<AdmTablesModel>();
            var s = new AdmTablesModel();
            foreach (var x in model)
            {
                s.Id = x.Id;
                s.Ide = x.Ide;
                s.Descripcion = x.Nacionalidad;
                lst.Add(s);
                s = new AdmTablesModel();
            }
            return lst;
        }

        public List<AdmTablesModel> GetRegistrosTypePiel()
        {
            var model = GetPiel();
            var lst = new List<AdmTablesModel>();
            var s = new AdmTablesModel();
            foreach (var x in model)
            {
                s.Id = x.Id;
                s.Ide = x.Ide;
                s.Descripcion = x.Piel;
                lst.Add(s);
                s = new AdmTablesModel();
            }
            return lst;
        }


        public List<AdmTablesModel> GetRegistrosTypeServicesSex()
        {
            var model = GetServicios();
            var lst = new List<AdmTablesModel>();
            var s = new AdmTablesModel();
            foreach (var x in model)
            {
                s.Id = x.Id;
                s.Ide = x.Ide;
                s.Descripcion = x.Servicio;
                lst.Add(s);
                s = new AdmTablesModel();
            }
            return lst;
        }

        public List<AdmTablesModel> GetRegistrosTypeSex()
        {
            var model = GetSex();
            var lst = new List<AdmTablesModel>();
            var s = new AdmTablesModel();
            foreach (var x in model)
            {
                s.Id = x.Id;
                s.Ide = x.Ide;
                s.Descripcion = x.Sexo;
                lst.Add(s);
                s = new AdmTablesModel();
            }
            return lst;
        }

        public List<AdmTablesModel> GetRegistrosTypeSmoke()
        {
            var model = GetSmoke();
            var lst = new List<AdmTablesModel>();
            var s = new AdmTablesModel();
            foreach (var x in model)
            {
                s.Id = x.Id;
                s.Ide = x.Ide;
                s.Descripcion = x.Smoke;
                lst.Add(s);
                s = new AdmTablesModel();
            }
            return lst;
        }


        #endregion


    }
}
