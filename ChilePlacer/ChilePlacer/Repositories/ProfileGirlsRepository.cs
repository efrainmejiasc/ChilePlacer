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
    }
}
