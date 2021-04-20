using ChilePlacer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.Repositories.Interfaces
{
    public interface IGirlsRepository
    {
        Girls InsertGirls(Girls model);
        bool GetExisteEmail(string email, bool activo);
        Girls LoginGirls(string email, string password);
        Girls ActivarUsuario(Guid identificador, bool activo);
    }
}
