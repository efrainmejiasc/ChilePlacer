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
        bool EstatusLink(DateTime fechaEnvio, DateTime fechaActivacion);
        ActivacioMailModel SetEstructuraMailRegister(string enlaze, string email);
        string ConstruirEnlazeRegistro(string email, string username, Guid identidad);
        Girls SetGirlsModel(string username, string email, string password,Guid identiificador);
    }
}
