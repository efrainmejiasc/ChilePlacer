using ChilePlacer.DataModels;
using ChilePlacer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.Repositories
{
    public class ProfileGirlsRepository: IProfileGirlsRepository
    {
        private readonly MyAppContext db;
        public ProfileGirlsRepository(MyAppContext _db)
        {
            db = _db;
        }

        public ProfileGirls InsertProfileGirls(ProfileGirls model) 
        {
            db.ProfileGirls.Add(model);
            db.SaveChanges();

            return model;
        }

        public ProfileGirls UpdateProfileGirls (ProfileGirls model)
        {
            var profile = db.ProfileGirls.Where(x => x.Identidad == model.Identidad).FirstOrDefault();
            db.ProfileGirls.Attach(profile);
            profile.Nombre = model.Nombre;
            profile.Apellido = model.Apellido;
            profile.Telefono = model.Telefono;
            profile.Dni = model.Dni;
            profile.Path = model.Path;
            db.SaveChanges();

            return profile;
        }

        public bool ExisteProfileGirls(Guid identidad)
        {
            var id = db.ProfileGirls.Where(x => x.Identidad == identidad).Select(x=> x.Id).FirstOrDefault();
            if (id > 0)
                return true;

            return false;
        }

        public string GetProfileImage(Guid identidad)
        {
            var src = db.ProfileGirls.Where(x => x.Identidad == identidad ).OrderByDescending(x => x.Fecha).Select(x => x.Path).FirstOrDefault();
            if (!string.IsNullOrEmpty(src))
                src = "assets/ProfileImageGirls/" + src;
            else
                src = "assets/ImagesSite/unphoto.jpg";

            return src;
        }

        public bool GetExisteUserName(string username)
        {
            var nameUser = db.ProfileGirls.Where(x => x.Username == username).Select(x => x.Username).FirstOrDefault();
            if (!string.IsNullOrEmpty(nameUser))
                return true;

            return false;
        }

    }
}
