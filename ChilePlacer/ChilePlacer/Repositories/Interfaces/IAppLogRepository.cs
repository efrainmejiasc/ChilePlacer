using ChilePlacer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.Repositories.Interfaces
{
    public interface IAppLogRepository
    {
        AppLog InserAppLog(AppLog model);
    }
}
