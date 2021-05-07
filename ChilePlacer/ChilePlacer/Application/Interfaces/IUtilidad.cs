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
        string ConstruirCodigo();
        Guid NuevoIdentificador();
        void MarcaDeAgua(string path,string pathName);
        string CodeBase64(Image image);
        string CodeBase64(string cadena);
        void CrearDirectorio(string path);
        string DecodeBase64(string cadena);
        bool CompararString(string a, string b);
        string CodeBase64(string path, bool opt = false);
        string ConstruirEnlazeRegistro(string email, Guid identidad);
        bool EstatusLink(DateTime fechaEnvio, DateTime fechaActivacion);
        Girls SetGirlsModel(string email, string password, Guid identiificador);
        ActivacionMailModel SetEstructuraMailRegister(string enlaze, string email);
        ChangePassword ConstruirChangePassword(string email, string codigo, bool activo);
        GaleriaGirls SetGaleriaGirls(Girls girls, string nameFile, string path, string texto = "");
        GaleriaGirls SetGaleriaGirls(Girls girls, string nameFile, Image image, string texto = "");
        ProfileGirls SetProfileGirls(string nombre, string apellido, string dni, string telefono, string path, Guid identidad, string username, string img64,
                                     DateTime fechaNacimiento, string sexo, string presentacion, string descripcion, string escort,
                                     decimal valor1, decimal valor2, string drink, string smoke, decimal estatura, decimal peso, string medidas, string contextura,
                                     string piel, string hair, string eyes, string country, string location, string sector,string depilacion,string nacionalidad);
    }
}
