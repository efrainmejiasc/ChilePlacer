using ChilePlacer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.Repositories.Interfaces
{
    public interface IProfileGirlsRepository
    {
        string GetUserName(Guid identidad);
        string GetProfileImage(Guid identidad);
        bool ExisteProfileGirls(Guid identidad);
        bool GetExisteUserName(string username);
        ProfileGirls InsertProfileGirls(ProfileGirls model);
        ProfileGirls UpdateProfileGirls(ProfileGirls model);
        bool GetExisteUserName(string username, Guid identidad);
    }
}
