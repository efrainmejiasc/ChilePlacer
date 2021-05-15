using ChilePlacer.Application;
using ChilePlacer.Application.Interfaces;
using ChilePlacer.DataModels;
using ChilePlacer.Models;
using ChilePlacer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.Repositories
{
    public class GaleriaGirlsRepository : IGaleriaGirlsRepository
    {
        private readonly MyAppContext db;
        private readonly IUtilidad util;
        public GaleriaGirlsRepository(MyAppContext _db, IUtilidad _util)
        {
            db = _db;
            util = _util;
        }

        public GaleriaGirls InsertGaleriaGirls (GaleriaGirls model)
        {

            //db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Girls ON");
            db.GaleriaGirls.Add(model);
            db.SaveChanges();

            return model;
        }

        public List<ImagenPortadaModel> GetImagenesGaleria (Guid identidad)//Perfil
        {
            var model = new List<ImagenPortadaModel>();
            model = (from perfil in db.ProfileGirls
                     join galeria in db.GaleriaGirls on perfil.Identidad equals galeria.Identidad
                     where perfil.Identidad == identidad
                     select new { perfil, galeria }).AsEnumerable()
                    .Select(x => new ImagenPortadaModel
                    {
                        Id = x.galeria.Id,
                        IdGirl = x.perfil.Id,
                        Username = x.perfil.Username,
                        Identidad = x.perfil.Identidad.ToString(),
                        Texto = string.IsNullOrEmpty(x.galeria.Texto) ? x.perfil.Presentacion : x.galeria.Texto,
                        Img64 = "data:image/jpeg;base64," + x.galeria.Img64,
                        PathImagen = "assets/Girls/Photo/" + x.galeria.PathImagen,
                        UrlProfile = EngineData.UrlServerHost + "cl?user=" + x.perfil.Username + "&ide=" + util.CodeBase64(x.perfil.Identidad.ToString()),
                        Fecha = x.galeria.Fecha

                    }).OrderByDescending(x => x.Fecha).ToList();

            return model;
        }

        public List<ImagenPortadaModel> GetImagenesGaleria()//Portada
        {
            var model = new List<ImagenPortadaModel>();
            model = (from perfil in db.ProfileGirls
                     join galeria in db.GaleriaGirls on perfil.Identidad equals galeria.Identidad
                     select new { perfil, galeria }).AsEnumerable()
                    .Select(x => new ImagenPortadaModel
                    {
                        Id = x.galeria.Id,
                        IdGirl = x.perfil.Id,
                        Username = x.perfil.Username,
                        Identidad = x.perfil.Identidad.ToString(),
                        Texto = string.IsNullOrEmpty(x.galeria.Texto) ? x.perfil.Presentacion : x.galeria.Texto,
                        Img64 = "data:image/jpeg;base64," + x.galeria.Img64,
                        PathImagen = "assets/Girls/Photo/" + x.galeria.PathImagen,
                        UrlProfile = EngineData.UrlServerHost +  "cl?user=" + x.perfil.Username + "&ide=" + util.CodeBase64(x.perfil.Identidad.ToString()),
                        Fecha = x.galeria.Fecha

                    }).OrderByDescending(x => x.Fecha).ToList();

            return model;
        }

        public List<ImagenPortadaModel> GetImagenesGaleria(string username) 
        {
            var model = new List<ImagenPortadaModel>();
            model = (from perfil in db.ProfileGirls
                     join galeria in db.GaleriaGirls on perfil.Identidad equals galeria.Identidad
                     where perfil.Username == username
                     select new { perfil, galeria }).AsEnumerable()
                    .Select(x => new ImagenPortadaModel
                    {
                        Id = x.galeria.Id,
                        IdGirl = x.perfil.Id,
                        Username = x.perfil.Username,
                        Identidad = x.perfil.Identidad.ToString(),
                        Identidad64 = util.CodeBase64(x.perfil.Identidad.ToString()),
                        Texto = string.IsNullOrEmpty(x.galeria.Texto) ? x.perfil.Presentacion : x.galeria.Texto,
                        Img64 = "data:image/jpeg;base64," + x.galeria.Img64,
                        PathImagen = "assets/Girls/Photo/" + x.galeria.PathImagen,
                        UrlProfile = EngineData.UrlServerHost + "cl?user=" + x.perfil.Username + "&ide=" + util.CodeBase64(x.perfil.Identidad.ToString()),
                        Fecha = x.galeria.Fecha

                    }).OrderByDescending(x => x.Fecha).ToList();

            return model;
        }

        public void  EliminarImagenGaleria(int id)
        {
            var model = db.GaleriaGirls.Where(x => x.Id == id).FirstOrDefault();
            db.GaleriaGirls.Remove(model);
            db.SaveChanges();
        }

    }
}
