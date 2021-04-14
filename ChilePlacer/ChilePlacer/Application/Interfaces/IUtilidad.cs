using ChilePlacer.DataModels;
using ChilePlacer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.Application.Interfaces
{
    public interface IUtilidad
    {
        Guid NuevoIdentificador();
        string CodeBase64(string cadena);
        string DecodeBase64(string cadena);
        bool CompararString(string a, string b);
        string ConstruirEnlazeRegistro(string email, Guid identidad);
        ActivacioMailModel SetEstructuraMailRegister(string enlaze, string email);
        Girls SetGirlsModel(string username, string email, string password,Guid identiificador);
    }
}
