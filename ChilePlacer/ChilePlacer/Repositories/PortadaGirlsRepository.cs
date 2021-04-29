using ChilePlacer.DataModels;
using ChilePlacer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.Repositories
{
    public class PortadaGirlsRepository: IPortadaGirlsRepository
    {
        private readonly MyAppContext db;
        public PortadaGirlsRepository(MyAppContext _db)
        {
            db = _db;
        }
        public PortadaGirls InsertGaleriaGirls(PortadaGirls model)
        {
            db.PortadaGirls.Add(model);
            db.SaveChanges();

            return model;
        }
    }
}
