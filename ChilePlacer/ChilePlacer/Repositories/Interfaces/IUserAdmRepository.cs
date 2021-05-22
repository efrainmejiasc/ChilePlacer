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
        bool GetExisteEmail(string email, bool activo);
        UserAdm LoginAdm(string email, string password);
    }
}
