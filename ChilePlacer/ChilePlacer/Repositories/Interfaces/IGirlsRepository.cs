using ChilePlacer.DataModels;
using ChilePlacer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.Repositories.Interfaces
{
    public interface IGirlsRepository
    {
        Girls InsertGirls(Girls model);
        Girls GetGirls(Guid identidad);
        GirlProfileModel GetGirls(string username);
        bool GetExisteEmail(string email, bool activo);
        Girls LoginGirls(string email, string password);
        Girls ChangePassword(string email, string password);
        Girls ActivarUsuario(Guid identificador, bool activo);
        GirlProfileModel GetGirls(string username, bool activo);
        GirlProfileModel GetUsuario(string username, bool activo);
    }
}
