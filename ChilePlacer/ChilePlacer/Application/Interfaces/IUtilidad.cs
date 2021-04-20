﻿using ChilePlacer.DataModels;
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
        bool EstatusLink(DateTime fechaEnvio, DateTime fechaActivacion);
        Girls SetGirlsModel(string email, string password, Guid identiificador);
        ActivacioMailModel SetEstructuraMailRegister(string enlaze, string email);
        ProfileGirls SetProfileGirls(string nombre, string apellido, string dni, string telefono, string path, Guid identidad,string username);
    }
}
