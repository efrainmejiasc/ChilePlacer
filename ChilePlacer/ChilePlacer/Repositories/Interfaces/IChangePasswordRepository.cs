using ChilePlacer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.Repositories.Interfaces
{
    public interface IChangePasswordRepository
    {
        void ActualizarCodigos(string email);
        ChangePassword InsertChangePassword(ChangePassword model);
        ChangePassword GetChangePassword(string email, string codigo,bool activo);
    }
}
