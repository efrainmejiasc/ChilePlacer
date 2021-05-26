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

        public List<AdmTablesModel> GetRegistrosTypeLocation(string pais)
        {
            var model = db.TypeLocation.Where(x => x.Country == pais).ToList();
            var lst = new List<AdmTablesModel>();
            var s = new AdmTablesModel();
            foreach (var x in model)
            {
                s.Id = x.Id;
                s.Ide = x.Ide;
                s.Descripcion = x.Location;
                lst.Add(s);
                s = new AdmTablesModel();
            }
            return lst;
        }


        #endregion

        #region DELETE_REGISTROS

        public void  DeleteRegistrosTypeAtencion(int id)
        {
            var m = db.TypeAtencion.Where(x => x.Id == id).FirstOrDefault();
            db.Remove(m);
            db.SaveChanges();
        }

        public void DeleteRegistrosTypeLocation(int id)
        {
            var m = db.TypeLocation.Where(x => x.Id == id).FirstOrDefault();
            db.Remove(m);
            db.SaveChanges();
        }
        public  void DeleteRegistrosTypeContextura(int id)
        {
            var m = db.TypeContextura.Where(x => x.Id == id).FirstOrDefault();
            db.Remove(m);
            db.SaveChanges();
        }

        public void DeleteRegistrosTypeCountry(int id)
        {
            var m = db.TypeCountry.Where(x => x.Id == id).FirstOrDefault();
            db.Remove(m);
            db.SaveChanges();
        }

        public void DeleteRegistrosTypeDepilacion(int id)
        {
            var m = db.TypeDepilacion.Where(x => x.Id == id).FirstOrDefault();
            db.Remove(m);
            db.SaveChanges();
        }

        public void DeleteRegistrosTypeDrink(int id)
        {
            var m = db.TypeDrink.Where(x => x.Id == id).FirstOrDefault();
            db.Remove(m);
            db.SaveChanges();
        }

        public void DeleteRegistrosTypeEscort(int id)
        {
            var m = db.TypeEscort.Where(x => x.Id == id).FirstOrDefault();
            db.Remove(m);
            db.SaveChanges();
        }

        public void DeleteRegistrosTypeEyes(int id)
        {
            var m = db.TypeEyes.Where(x => x.Id == id).FirstOrDefault();
            db.Remove(m);
            db.SaveChanges();
        }

        public void DeleteRegistrosTypeGirls(int id)
        {
            var m = db.TypeGirls.Where(x => x.Id == id).FirstOrDefault();
            db.Remove(m);
            db.SaveChanges();
        }

        public void DeleteRegistrosTypeHair(int id)
        {
            var m = db.TypeHair.Where(x => x.Id == id).FirstOrDefault();
            db.Remove(m);
            db.SaveChanges();
        }

        public void DeleteRegistrosTypeNacionalidad(int id)
        {
            var m = db.TypeNacionalidad.Where(x => x.Id == id).FirstOrDefault();
            db.Remove(m);
            db.SaveChanges();
        }

        public void DeleteRegistrosTypePiel(int id)
        {
            var m = db.TypePiel.Where(x => x.Id == id).FirstOrDefault();
            db.Remove(m);
            db.SaveChanges();
        }


        public void DeleteRegistrosTypeServicesSex(int id)
        {
            var m = db.TypeServicesSex.Where(x => x.Id == id).FirstOrDefault();
            db.Remove(m);
            db.SaveChanges();
        }

        public void DeleteRegistrosTypeSex(int id)
        {
            var m = db.TypeSex.Where(x => x.Id == id).FirstOrDefault();
            db.Remove(m);
            db.SaveChanges();
        }

        public void DeleteRegistrosTypeSmoke(int id)
        {
            var m = db.TypeSmoke.Where(x => x.Id == id).FirstOrDefault();
            db.Remove(m);
            db.SaveChanges();
        }

        #endregion

        #region INSERT_REGISTROS

        public void InsertRegistrosTypeAtencion(TypeAtencion model)
        {
            db.TypeAtencion.Add(model);
            db.SaveChanges();
        }

        public void InsertRegistrosTypeContextura(TypeContextura model)
        {
            db.TypeContextura.Add(model);
            db.SaveChanges();
        }

        public void InsertRegistrosTypeCountry(TypeCountry model)
        {
            db.TypeCountry.Add(model);
            db.SaveChanges();
        }

        public void InsertRegistrosTypeDepilacion(TypeDepilacion model)
        {
            db.TypeDepilacion.Add(model);
            db.SaveChanges();
        }

        public void InsertRegistrosTypeDrink(TypeDrink model)
        {
            db.TypeDrink.Add(model);
            db.SaveChanges();
        }

        public void InsertRegistrosTypeEscort(TypeEscort model)
        {
            db.TypeEscort.Add(model);
            db.SaveChanges();
        }

        public void InsertRegistrosTypeEyes(TypeEyes model)
        {
            db.TypeEyes.Add(model);
            db.SaveChanges();
        }

        public void InsertRegistrosTypeGirls(TypeGirls model)
        {
            db.TypeGirls.Add(model);
            db.SaveChanges();
        }

        public void InsertRegistrosTypeHair(TypeHair model)
        {
            db.TypeHair.Add(model);
            db.SaveChanges();
        }

        public void InsertRegistrosTypeNacionalidad(TypeNacionalidad model)
        {
            db.TypeNacionalidad.Add(model);
            db.SaveChanges();
        }

        public void InsertRegistrosTypePiel(TypePiel model)
        {
            db.TypePiel.Add(model);
            db.SaveChanges();
        }


        public void InsertRegistrosTypeServicesSex(TypeServicesSex model)
        {
            db.TypeServicesSex.Add(model);
            db.SaveChanges();
        }

        public void InsertRegistrosTypeSex(TypeSex model)
        {
            db.TypeSex.Add(model);
            db.SaveChanges();
        }

        public void InsertRegistrosTypeSmoke(TypeSmoke model)
        {
            db.TypeSmoke.Add(model);
            db.SaveChanges();
        }

        public void InsertRegistrosTypeLocation(TypeLocation model)
        {
            db.TypeLocation.Add(model);
            db.SaveChanges();
        }

        #endregion

    }
}
