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
            profile.Nombre = !string.IsNullOrEmpty(model.Nombre) ? model.Nombre : profile.Nombre;
            profile.Apellido = !string.IsNullOrEmpty(model.Apellido) ? model.Apellido :profile.Apellido;
            profile.Telefono = !string.IsNullOrEmpty(model.Telefono) ? model.Telefono : profile.Telefono;
            profile.Dni = !string.IsNullOrEmpty(model.Dni) ? model.Dni : profile.Dni;
            profile.Path = !string.IsNullOrEmpty(model.Path) ? model.Path : profile.Path;
            profile.Username = !string.IsNullOrEmpty(model.Username) ? model.Username : profile.Username;
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

        public bool GetExisteUserName(string username,Guid identidad)
        {
            var nameUser = db.ProfileGirls.Where(x => x.Username == username && x.Identidad != identidad).Select(x => x.Username).FirstOrDefault();
            if (!string.IsNullOrEmpty(nameUser))
                return true;

            return false;
        }

        public string GetUserName (Guid identidad)
        {
            return db.ProfileGirls.Where(x => x.Identidad == identidad).Select(x => x.Username).FirstOrDefault();
        }

    }
}
