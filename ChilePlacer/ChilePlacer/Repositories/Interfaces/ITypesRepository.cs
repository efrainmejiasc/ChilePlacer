using ChilePlacer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.Repositories.Interfaces
{
    public interface ITypesRepository
    {
        List<TypeSex> GetSex();
        List<TypeEyes> GetEyes();
        List<TypeHair> GetHair();
        List<TypePiel> GetPiel();
        List<TypeDrink> GetDrink();
        List<TypeSmoke> GetSmoke();
        List<TypeEscort> GetEscort();
        List<TypeCountry> GetCountry();
        List<TypeLocation> GetLocation();
        List<TypeAtencion> GetAtencion();
        List<TypeContextura> GetContextura();
        List<TypeServicesSex> GetServicios();
        List<TypeDepilacion> GetDepilacion();
        List<TypeNacionalidad> GetNacionalidad();
    }
}
