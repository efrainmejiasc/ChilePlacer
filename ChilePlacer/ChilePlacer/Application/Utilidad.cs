using ChilePlacer.Application.Interfaces;
using ChilePlacer.DataModels;
using ChilePlacer.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChilePlacer.Application
{
    public class Utilidad : IUtilidad
    {
        public string CodeBase64(string cadena)
        {
            var comprobanteXmlPlainTextBytes = Encoding.UTF8.GetBytes(cadena);
            var cadenaBase64 = Convert.ToBase64String(comprobanteXmlPlainTextBytes);
            return cadenaBase64;
        }

        public string CodeBase64(string path, bool opt = false)
        {
            string cadenaBase64 = string.Empty;
            using (Image image = Image.FromFile(path))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();
                    cadenaBase64 = Convert.ToBase64String(imageBytes);
                }
            }

            return cadenaBase64;
        }

        public  string CodeBase64(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return Convert.ToBase64String(ms.ToArray());
            }
        }


        public string DecodeBase64(string cadena)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(cadena);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }


        public bool CompararString(string a, string b)
        {
            bool resultado = false;
            if (a == b)
            {
                resultado = true;
            }
            return resultado;
        }

        public Guid NuevoIdentificador()
        {
            Guid g = CrearGuid();
            while (g == Guid.Empty)
            {
                g = CrearGuid();
            }
            return g;
        }

        private Guid CrearGuid()
        {
            return Guid.NewGuid();
        }

        public Girls SetGirlsModel (string email, string password,Guid identificador)
        {
            var girl = new Girls()
            {
                Identidad = identificador,
                Password = password,
                Email = email,
                Activo = false,
                Fecha = DateTime.UtcNow
            };

            return girl;
        }

        public ActivacionMailModel SetEstructuraMailRegister(string enlaze, string email)
        {
            ActivacionMailModel model = new ActivacionMailModel();
            model.Link = enlaze;
            model.Saludo = "Hola: ";
            model.EmailDestinatario = email;
            model.Fecha = DateTime.UtcNow.ToString();
            model.Descripcion = "Por favor confirma la direccion de correo electronico, para saber que eres realmente tu.";
            model.ClickAqui = "Hazme Click Para Confirmar Tu Identidad!";
            model.Asunto = "Por favor completa tu perfil...";
            model.Observacion = "Bienvenido(a) a nuestro sitio ChilePlacer, haz click en el link y completa tu perfil.  </br> Todos los datos aportados seran confidenciales , no seran revelados ni compartidos con nadie.";
            model.PathLecturaArchivo = @"Template\ActivacionMail.html";
            return model;
        }

        public string ConstruirEnlazeRegistro(string email, Guid identidad)
        {
            string link = EngineData.UrlServerActivacion;
            link = link + "?email=" + CodeBase64(email);
            link = link + "&identidad=" + CodeBase64(identidad.ToString());
            link = link + "&date=" + DateTime.UtcNow.ToString();
            return link;
        }

        public bool EstatusLink(DateTime fechaEnvio, DateTime fechaActivacion)
        {
            bool resultado = false;
            //if (fechaEnvio.Date != fechaActivacion.Date)
                //return resultado;

            int horaEnvio = fechaEnvio.Hour;
            int horaActivacion = fechaActivacion.Hour;
            int diferenciaHora = horaActivacion - horaEnvio;
            if (diferenciaHora <= 120)
                resultado = true;
            return resultado;
        }

        public ProfileGirls SetProfileGirls(string nombre, string apellido, string dni, string telefono, string path, Guid identidad,string username,string img64, 
                                           DateTime fechaNacimiento, string sexo, string presentacion, string descripcion, string escort, 
                                           decimal valor1, decimal valor2, string drink, string smoke, decimal estatura, decimal peso,
                                           string medidas, string contextura, string piel, string hair, string eyes, string country, string location, string sector,string depilacion,string nacionalidad)
        {
            var profileGirls = new ProfileGirls()
            {
                Identidad = identidad,
                Nombre = nombre,
                Apellido = apellido,
                Dni =  dni,
                Telefono = telefono,
                Path = path,
                Fecha = DateTime.UtcNow,
                Username = username,
                Img64 = string.IsNullOrEmpty(path)?string.Empty:img64,
                FechaNacimiento = fechaNacimiento,
                Sexo = sexo,
                Presentacion = presentacion,
                Descripcion = descripcion,
                CategoriaEscort = escort,
                ValorHora = valor1,
                ValorMediaHora = valor2,
                Drink = drink,
                Smoke = smoke,
                Estatura = estatura,
                Peso= peso,
                Medidas = medidas,
                Contextura = contextura,
                Piel= piel,
                Hair = hair,
                Eyes = eyes,
                Country = country,
                Location = location,
                Sector = sector,
                Depilacion = depilacion,
                Nacionalidad = nacionalidad,
            };

            return profileGirls;
        }

        public ChangePassword ConstruirChangePassword(string email,string codigo,bool activo)
        {
            ChangePassword model = new ChangePassword()
            {
                Email = email,
                Codigo = codigo,
                Fecha = DateTime.UtcNow,
                Activo = activo
            };

            return model;
        }

        public GaleriaGirls SetGaleriaGirls (Girls girls,string nameFile,string path,string texto = "")
        {
            var model = new GaleriaGirls();
            model.Identidad= girls.Identidad;
            model.Fecha = DateTime.UtcNow;
            model.PathImagen = nameFile;
            model.Img64 = CodeBase64(path);
            model.Texto = texto;

            return model;
        }

        public GaleriaGirls SetGaleriaGirls(Girls girls, string nameFile, Image image, string texto = "")
        {
            var model = new GaleriaGirls();
            model.Identidad = girls.Identidad;
            model.Fecha = DateTime.UtcNow;
            model.PathImagen = nameFile;
            model.Img64 = CodeBase64(image);
            model.Texto = texto;

            return model;
        }

        public string ConstruirCodigo()
        {
            string codigo = string.Empty;
            for (int i = 0; i <= 5; i++)
            {
                if (i % 2 == 0)
                    codigo = codigo + AleatorioLetra(i + DateTime.Now.Millisecond);
                else
                    codigo = codigo + AleatorioNumero(i + DateTime.Now.Millisecond);
            }
            return codigo.Trim();
        }

        private string AleatorioLetra(int semilla)
        {
            string letra = string.Empty;
            Random rnd = new Random(semilla);
            int n = rnd.Next(0, 26);
            double d = AleatorioDoble(semilla);
            if (d > 0.5)
                letra = EngineData.AlfabetoG[n];
            else
                letra = EngineData.AlfabetoP[n];

            return letra;
        }

        private string AleatorioNumero(int semilla)
        {
            Random rnd = new Random(semilla);
            int n = rnd.Next(0, 9);
            return n.ToString();
        }

        private double AleatorioDoble(int semilla)
        {
            Random rnd = new Random(semilla);
            double n = rnd.NextDouble();
            return n;
        }

        public void CrearDirectorio(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

        }

        public void MarcaDeAgua(string path,string pathName)
        {
            Image image = Image.FromFile(path);
            Bitmap bmp = new Bitmap(image);
            Graphics graphicsobj = Graphics.FromImage(bmp);
            Brush brush = new SolidBrush(Color.FromArgb(80, 255, 255, 255));
            Point postionWaterMark = new Point((bmp.Width / 6), (bmp.Height / 4));
            graphicsobj.DrawString("www.chilePlacer.com", new System.Drawing.Font("Arial", 30, FontStyle.Bold, GraphicsUnit.Pixel), brush, postionWaterMark);
            Image img = (Image)bmp;
            img.Save(pathName, System.Drawing.Imaging.ImageFormat.Jpeg);
            graphicsobj.Dispose();
        }

    }
}
