using ChilePlacer.DataModels;
using ChilePlacer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.Repositories
{
    public class UserAdmRepository: IUserAdmRepository
    {
        private readonly MyAppContext db;

        public UserAdmRepository (MyAppContext _db)
        {
            db = _db;
        }

        public UserAdm LoginAdm (string email, string password)
        {
            return db.UserAdm.Where(x => x.EmailAdm == email && x.PasswordAdm == password && x.Activo == true).FirstOrDefault();
        }

        public bool GetExisteEmail(string email, bool activo)
        {
            var mail = db.UserAdm.Where(x => x.Activo == activo && x.EmailAdm == email).Select(x => x.EmailAdm).FirstOrDefault();
            if (!string.IsNullOrEmpty(mail))
                return true;

            return false;
        }

        public UserAdm GetUserAdm(string email)
        {
            return  db.UserAdm.Where(x => x.Activo == true && x.EmailAdm == email).FirstOrDefault();
        }

        public UserAdm InsertAdm(UserAdm model)
        {
            db.UserAdm.Add(model);
            db.SaveChanges();

            return model;
        }

        public UserAdm UpdateAdmPassword(string email, string password)
        {
            var adm = db.UserAdm.Where(x => x.EmailAdm == email && x.Activo == true).FirstOrDefault();
            if (adm == null)
                return null;

            db.UserAdm.Attach(adm);
            adm.PasswordAdm = password;
            db.SaveChanges();

            return adm;
        }
    }
}
