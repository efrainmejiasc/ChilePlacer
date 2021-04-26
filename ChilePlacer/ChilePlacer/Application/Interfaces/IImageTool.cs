using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.Application.Interfaces
{
    public interface IImageTool
    {
        Bitmap ResizeImage(Image image, int width, int height, string path);
    }
}
