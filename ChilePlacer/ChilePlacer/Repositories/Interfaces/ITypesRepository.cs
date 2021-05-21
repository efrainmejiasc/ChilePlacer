using ChilePlacer.DataModels;
using ChilePlacer.Models;
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

        void DeleteTypeServiceSex(List<TypeGirlServices> model, Guid identidad);
        void DeleteTypeAtencionGirl(List<TypeAtencionGirl> model, Guid identidad);
        List<TypeGirlServices> InsertTypeServiceSex(List<TypeGirlServices> model);
        List<TypeAtencionGirl> InsertTypeAtencionGirl(List<TypeAtencionGirl> model);

        List<AdmTablesModel> GetRegistrosTypeAtencion();
        List<AdmTablesModel> GetRegistrosTypeContextura();
        List<AdmTablesModel> GetRegistrosTypeCountry();
        List<AdmTablesModel> GetRegistrosTypeDepilacion();
        List<AdmTablesModel> GetRegistrosTypeDrink();
        List<AdmTablesModel> GetRegistrosTypeEscort();
        List<AdmTablesModel> GetRegistrosTypeEyes();
        List<AdmTablesModel> GetRegistrosTypeGirls();
        List<AdmTablesModel> GetRegistrosTypeHair();
        List<AdmTablesModel> GetRegistrosTypeNacionalidad();
        List<AdmTablesModel> GetRegistrosTypePiel();
        List<AdmTablesModel> GetRegistrosTypeServicesSex();
        List<AdmTablesModel> GetRegistrosTypeSex();
        List<AdmTablesModel> GetRegistrosTypeSmoke();
    }
}
