using ChilePlacer.DataModels;
using ChilePlacer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.Repositories
{
    public class ChangePasswordRepository: IChangePasswordRepository
    {
        private readonly MyAppContext db;
        public ChangePasswordRepository(MyAppContext _db)
        {
            db = _db;
        }

        public ChangePassword InsertChangePassword (ChangePassword model)
        {
            db.ChangePassword.Add(model);
            db.SaveChanges();

            return model;
        }

        public ChangePassword GetChangePassword (string email , string codigo,bool activo)
        {
            var model = db.ChangePassword.Where(x => x.Email == email && x.Codigo == codigo && x.Activo == activo).OrderByDescending(x => x.Fecha).FirstOrDefault();
           
            return model;
        }

        public void ActualizarCodigos (string email)
        {
            var list = db.ChangePassword.Where(x => x.Email == email && x.Activo == false).ToList();

            foreach (var s in list)
                ActualizarCodigos(s.Email, s.Codigo);
        }

        private  void ActualizarCodigos (string email, string codigo)
        {
            var model = db.ChangePassword.Where(x => x.Email == email && x.Codigo == codigo).FirstOrDefault();
            db.ChangePassword.Attach(model);
            model.Activo = true;
            db.SaveChanges();
        }
    }
}
