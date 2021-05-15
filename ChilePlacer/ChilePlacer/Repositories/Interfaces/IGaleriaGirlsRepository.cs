using ChilePlacer.DataModels;
using ChilePlacer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.Repositories.Interfaces
{
    public interface IGaleriaGirlsRepository
    {
        void EliminarImagenGaleria(int id);
        List<ImagenPortadaModel> GetImagenesGaleria();
        GaleriaGirls InsertGaleriaGirls(GaleriaGirls model);
        List<ImagenPortadaModel> GetImagenesGaleria(Guid identidad);
        List<ImagenPortadaModel> GetImagenesGaleria(string username);
    }
}
