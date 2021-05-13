using ChilePlacer.DataModels;
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
            return db.TypeSmoke.OrderBy(x=> x.Id).ToList();
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

        public void DeleteTypeServiceSex(List<TypeGirlServices> model,Guid identidad)
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
    }
}
