using ChilePlacer.DataModels;
using ChilePlacer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.Repositories
{
    public class AppLogRepository:IAppLogRepository
    {
        private readonly MyAppContext db;

        public AppLogRepository(MyAppContext _db)
        {
            db = _db;
        }
        public AppLog InserAppLog (AppLog model)
        {
            db.AppLog.Add(model);
            db.SaveChanges();

            return model;
        }
    }
}
