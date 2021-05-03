using ChilePlacer.DataModels;
using ChilePlacer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.Repositories
{
    public class TypesRepository: ITypesRepository
    {
        private readonly MyAppContext db;

        public TypesRepository(MyAppContext _db)
        {
            db = _db;
        }

        public List<TypeSex> GetSex()
        {
            return db.TypeSex.ToList();
        }
    }
}
