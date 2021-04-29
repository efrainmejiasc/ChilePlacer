using ChilePlacer.DataModels;
using ChilePlacer.Models;
using ChilePlacer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.Repositories
{
    public class GirlsRepository:IGirlsRepository
    {
        private readonly MyAppContext db;
        public GirlsRepository(MyAppContext _db)
        {
            db = _db;
        }
   
        public bool GetExisteEmail(string email,bool activo)
        {
            var mail = db.Girls.Where(x => x.Activo == activo && x.Email == email).Select(x => x.Email).FirstOrDefault();
            if (!string.IsNullOrEmpty(mail))
                return true;

            return false;
        }

        public Girls InsertGirls(Girls model)
        {
            db.Girls.Add(model);
            db.SaveChanges();

            return model;
        }

        public Girls ActivarUsuario (Guid identificador, bool activo)
        {
            var girl = db.Girls.Where(x => x.Identidad == identificador).FirstOrDefault();
            db.Girls.Attach(girl);
            girl.Activo = activo;
            db.SaveChanges();

            return girl;
        }

        public Girls LoginGirls(string email, string password)
        {
            return db.Girls.Where(x => x.Email == email && x.Password == password && x.Activo == true).FirstOrDefault();
        }

        public Girls ChangePassword(string email,string password)
        {
            var girl = db.Girls.Where(x => x.Email == email).FirstOrDefault();
            db.Girls.Attach(girl);
            girl.Password = password;
            db.SaveChanges();

            return girl;
        }


        public GirlProfileModel GetUsuario(string username, bool activo)
        {
            var model = (from girl in db.Girls
                         join profile in db.ProfileGirls on girl.Identidad equals profile.Identidad
                         where girl.Activo == activo && profile.Username == username
                         select new { girl, profile }).AsEnumerable()
                        .Select(x => new GirlProfileModel
                        {
                            Id = x.girl.Id,
                            Identidad = x.girl.Identidad.ToString(),
                            Username = x.profile.Username

                        }).FirstOrDefault();

            return model;
        }

        public GirlProfileModel GetGirls(string username, bool activo)
        {
            var model = (from girl in db.Girls
                         join profile in db.ProfileGirls on girl.Identidad equals profile.Identidad
                         where girl.Activo == activo && profile.Username == username
                         select new { girl, profile}).AsEnumerable()
                        .Select(x => new GirlProfileModel
                        {
                            Id = x.girl.Id,
                            Identidad = x.girl.Identidad.ToString(),
                            Username = x.profile.Username,
                            Imagenes = db.GaleriaGirls.Where(y => y.Identidad == x.girl.Identidad).OrderByDescending(y => y.Fecha).Select(y => y.PathImagen).ToList()
                        }).FirstOrDefault();

            return model;
        }

        public Girls GetGirls(Guid identidad)
        {
            return db.Girls.Where(x => x.Identidad == identidad).FirstOrDefault();
        }
    }
}
