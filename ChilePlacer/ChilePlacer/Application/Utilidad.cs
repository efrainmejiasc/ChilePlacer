using ChilePlacer.Application.Interfaces;
using ChilePlacer.DataModels;
using ChilePlacer.Models;
using ChilePlacer.Repositories.Interfaces;
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
        private readonly IAppLogRepository log;
        public Utilidad(IAppLogRepository _log)
        {
            log = _log;
        }

        public string CodeBase64(string cadena)
        {
            var comprobanteXmlPlainTextBytes = Encoding.UTF8.GetBytes(cadena);
            var cadenaBase64 = Convert.ToBase64String(comprobanteXmlPlainTextBytes);
            return cadenaBase64;
        }

        public string CodeBase64(string path, bool opt = false)
        {
            string cadenaBase64 = string.Empty;
            if (string.IsNullOrEmpty(path))
                return cadenaBase64;


            try {
                using (Image image = Image.FromFile(path))
                {
                    using (MemoryStream m = new MemoryStream())
                    {
                        image.Save(m, image.RawFormat);
                        byte[] imageBytes = m.ToArray();
                        cadenaBase64 = Convert.ToBase64String(imageBytes);
                    }
                }
            }
            catch(Exception ex)
            {
                var error = new AppLog()
                {
                    Error = ex.ToString(),
                    Metodo = "Utilidad,CodeBase64(string path, bool opt = false)",
                    Fecha = DateTime.UtcNow,
                };
                log.InserAppLog(error);
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
            if (diferenciaHora <= 72)
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
            model.Img64 = CodeBase64(path,false);
            model.Texto = texto;

            return model;
        }

        public GaleriaGirlsAudio SetGaleriaGirlsAudio(Guid identidad, string pathAudio)
        {
            var model = new GaleriaGirlsAudio();
            model.Identidad = identidad;
            model.Fecha = DateTime.UtcNow;
            model.PathAudio = pathAudio;

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

        public void CrearDirectorio()
        {
            string path = "ClientApp/dist/assets/Girls/";
            string []  folders = { "All", "All2", "Audio", "Gift", "Photo" };
            foreach(var folder in folders)
            {
                path = path + folder;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
          
        }

        public List<TypeGirlServices> SetServiciosEscort(List<string> servicios,Guid identidad)
        {
            var lst = new List<TypeGirlServices>();
            var s = new TypeGirlServices();

            foreach(var x in servicios)
            {
                s.Identidad = identidad;
                s.TypeServices = x;
                lst.Add(s);
                s = new TypeGirlServices();
            }

            return lst;
        }

        public List<TypeAtencionGirl> SetAtencionEscort(List<string> atenciones, Guid identidad)
        {
            var lst = new List<TypeAtencionGirl>();
            var s = new TypeAtencionGirl();

            foreach (var x in atenciones)
            {
                s.Identidad = identidad;
                s.TypeAtencion = x;
                lst.Add(s);
                s = new TypeAtencionGirl();
            }

            return lst;
        }

        public string StrFecha(DateTime fecha)
        {
            int  year = fecha.Year;
            int  month = fecha.Month;
            int day = fecha.Day;
            string mes = string.Empty;
            string dia = string.Empty;

            if (month < 10)
                mes = "0" + month.ToString();
            else
                mes = month.ToString();

            if (day < 10)
                dia = "0" + day.ToString();
            else
                dia = day.ToString();

            return  year.ToString()  + "-" + mes + "-" + dia;

        }

    }
}
