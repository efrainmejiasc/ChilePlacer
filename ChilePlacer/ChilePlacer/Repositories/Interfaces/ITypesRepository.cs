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
        List<AdmTablesModel> GetRegistrosTypeLocation(string pais);


        void DeleteRegistrosTypeAtencion(int id);
        void DeleteRegistrosTypeContextura(int id);
        void DeleteRegistrosTypeCountry(int id);
        void DeleteRegistrosTypeDepilacion(int id);
        void DeleteRegistrosTypeDrink(int id);
        void DeleteRegistrosTypeEscort(int id);
        void DeleteRegistrosTypeEyes(int id);
        void DeleteRegistrosTypeGirls(int id);
        void DeleteRegistrosTypeHair(int id);
        void DeleteRegistrosTypeNacionalidad(int id);
        void DeleteRegistrosTypePiel(int id);
        void DeleteRegistrosTypeServicesSex(int id);
        void DeleteRegistrosTypeSex(int id);
        void DeleteRegistrosTypeSmoke(int id);
        void DeleteRegistrosTypeLocation(int id);


        void InsertRegistrosTypeAtencion(TypeAtencion model);
        void InsertRegistrosTypeContextura(TypeContextura model);
        void InsertRegistrosTypeCountry(TypeCountry model);
        void InsertRegistrosTypeDepilacion(TypeDepilacion model);
        void InsertRegistrosTypeDrink(TypeDrink model);
        void InsertRegistrosTypeEscort(TypeEscort model);
        void InsertRegistrosTypeEyes(TypeEyes model);
        void InsertRegistrosTypeGirls(TypeGirls model);
        void InsertRegistrosTypeHair(TypeHair model);
        void InsertRegistrosTypeNacionalidad(TypeNacionalidad model);
        void InsertRegistrosTypePiel(TypePiel model);
        void InsertRegistrosTypeServicesSex(TypeServicesSex model);
        void InsertRegistrosTypeSex(TypeSex model);
        void InsertRegistrosTypeSmoke(TypeSmoke model);
        void InsertRegistrosTypeLocation(TypeLocation model);
    }
}
