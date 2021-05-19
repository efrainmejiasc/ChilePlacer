using ChilePlacer.Application.Interfaces;
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
        private readonly IUtilidad util;
        public ProfileGirlsRepository(MyAppContext _db, IUtilidad _util)
        {
            db = _db;
            util = _util;
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
            profile.FechaNacimiento = !string.IsNullOrEmpty(model.FechaNacimiento.ToString()) ? model.FechaNacimiento : profile.FechaNacimiento;
            profile.Dni = !string.IsNullOrEmpty(model.Dni) ? model.Dni : profile.Dni;
            profile.Telefono = !string.IsNullOrEmpty(model.Telefono) ? model.Telefono : profile.Telefono;
            profile.Sexo = !string.IsNullOrEmpty(model.Sexo) ? model.Sexo : profile.Sexo;
            profile.Username = !string.IsNullOrEmpty(model.Username) ? model.Username : profile.Username;
            profile.Presentacion = !string.IsNullOrEmpty(model.Presentacion) ? model.Presentacion : profile.Presentacion;
            profile.Descripcion = !string.IsNullOrEmpty(model.Descripcion) ? model.Descripcion : profile.Descripcion;
            profile.Path = !string.IsNullOrEmpty(model.Path) ? model.Path : profile.Path;
            profile.Img64 = !string.IsNullOrEmpty(model.Img64) ? model.Img64 : profile.Img64;
            profile.ValorHora = model.ValorHora > 0 ? model.ValorHora : profile.ValorHora;
            profile.ValorMediaHora = model.ValorMediaHora > 0? model.ValorMediaHora : profile.ValorMediaHora;
            profile.Estatura = model.Estatura > 0 ? model.Estatura : profile.Estatura;
            profile.Peso = model.Peso > 0 ? model.Peso : profile.Peso;
            profile.Medidas = !string.IsNullOrEmpty(model.Medidas) ? model.Medidas : profile.Medidas;
            profile.Contextura = !string.IsNullOrEmpty(model.Contextura) ? model.Contextura : profile.Contextura;
            profile.Piel = !string.IsNullOrEmpty(model.Piel) ? model.Piel : profile.Piel;
            profile.Hair = !string.IsNullOrEmpty(model.Hair) ? model.Hair : profile.Hair;
            profile.Eyes = !string.IsNullOrEmpty(model.Eyes) ? model.Eyes : profile.Eyes;
            profile.Depilacion = !string.IsNullOrEmpty(model.Depilacion) ? model.Depilacion : profile.Depilacion;
            profile.Drink = !string.IsNullOrEmpty(model.Drink) ? model.Drink : profile.Drink;
            profile.Smoke = !string.IsNullOrEmpty(model.Smoke) ? model.Smoke : profile.Smoke;
            profile.Country = !string.IsNullOrEmpty(model.Country) ? model.Country : profile.Country;
            profile.Location = !string.IsNullOrEmpty(model.Location) ? model.Location : profile.Location;
            profile.Nacionalidad = !string.IsNullOrEmpty(model.Nacionalidad) ? model.Nacionalidad : profile.Nacionalidad;
            profile.Sector = !string.IsNullOrEmpty(model.Sector) ? model.Sector : profile.Sector;
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

        public ProfileGirls GetProfileGirls(Guid identidad)
        {
            return db.ProfileGirls.Where(x => x.Identidad == identidad).FirstOrDefault();
        }

        public string GetProfileImage(Guid identidad)
        {
            var src = db.ProfileGirls.Where(x => x.Identidad == identidad ).OrderByDescending(x => x.Fecha).Select(x => x.Path).FirstOrDefault();
            if (!string.IsNullOrEmpty(src))
                src = "dist/assets/ProfileImageGirls/" + src;
            else
                src = "dist/assets/ImagesSite/unphoto.jpg";

            return src;
        }

        public string GetProfileImage(string username)
        {
            var src = db.ProfileGirls.Where(x => x.Username == username).OrderByDescending(x => x.Fecha).Select(x => x.Img64).FirstOrDefault();
            if (string.IsNullOrEmpty(src))
                src = "data:image/jpeg;base64," + util.CodeBase64("assets/ImagesSite/unphoto.jpg", false);
            else
               src = "data:image/jpeg;base64," + src;

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
