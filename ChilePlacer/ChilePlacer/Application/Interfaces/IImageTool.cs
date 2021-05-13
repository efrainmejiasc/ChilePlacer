using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.Application.Interfaces
{
    public interface IImageTool
    {
        void MarcaDeAgua(string path, string pathName);
        void MarcaDeAguaPerfil(string path, string pathName);
        Bitmap ResizeImage(Image image, int width, int height);
    }
}
