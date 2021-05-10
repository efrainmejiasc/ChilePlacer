using ChilePlacer.DataModels;
using ChilePlacer.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.Application.Interfaces
{
    public interface IUtilidad
    {
        void CrearDirectorio();
        string ConstruirCodigo();
        Guid NuevoIdentificador();
        string StrFecha(DateTime fecha);
        string CodeBase64(Image image);
        string CodeBase64(string cadena);
        void CrearDirectorio(string path);
        string DecodeBase64(string cadena);
        bool CompararString(string a, string b);
        string CodeBase64(string path, bool opt = false);
        string ConstruirEnlazeRegistro(string email, Guid identidad);
        bool EstatusLink(DateTime fechaEnvio, DateTime fechaActivacion);
        Girls SetGirlsModel(string email, string password, Guid identiificador);
        GaleriaGirlsAudio SetGaleriaGirlsAudio(Guid identidad, string pathAudio);
        ActivacionMailModel SetEstructuraMailRegister(string enlaze, string email);
        ChangePassword ConstruirChangePassword(string email, string codigo, bool activo);
        List<TypeGirlServices> SetServiciosEscort(List<string> servicios, Guid identidad);
        List<TypeAtencionGirl> SetAtencionEscort(List<string> atenciones, Guid identidad);
        GaleriaGirls SetGaleriaGirls(Girls girls, string nameFile, string path, string texto = "");
        ProfileGirls SetProfileGirls(string nombre, string apellido, string dni, string telefono, string path, Guid identidad, string username, string img64,
                                     DateTime fechaNacimiento, string sexo, string presentacion, string descripcion, string escort,
                                     decimal valor1, decimal valor2, string drink, string smoke, decimal estatura, decimal peso, string medidas, string contextura,
                                     string piel, string hair, string eyes, string country, string location, string sector,string depilacion,string nacionalidad);
    }
}
