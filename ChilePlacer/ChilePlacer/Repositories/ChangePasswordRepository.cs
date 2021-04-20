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
    }
}
