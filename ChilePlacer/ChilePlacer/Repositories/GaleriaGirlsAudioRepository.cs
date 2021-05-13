using ChilePlacer.DataModels;
using ChilePlacer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.Repositories
{
    public class GaleriaGirlsAudioRepository : IGaleriaGirlsAudioRepository
    {
        private readonly MyAppContext db;
        public GaleriaGirlsAudioRepository(MyAppContext _db)
        {
            db = _db;
        }

        public GaleriaGirlsAudio InsertGaleriaGirlAudio(GaleriaGirlsAudio model)
        {
            db.GaleriaGirlsAudio.Add(model);
            db.SaveChanges();

            return model;
        }
    }
}
