using ChilePlacer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.Repositories.Interfaces
{
    public interface IUserAdmRepository
    {
        UserAdm InsertAdm(UserAdm model);
        UserAdm GetUserAdm(string email);
        bool GetExisteEmail(string email, bool activo);
        UserAdm LoginAdm(string email, string password);
        UserAdm UpdateAdmPassword(string email, string password);
    }
}
