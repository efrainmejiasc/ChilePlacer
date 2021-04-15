﻿using ChilePlacer.DataModels;
using ChilePlacer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.Repositories
{
    public class GirlsRepository:IGirlsRepository
    {
        private readonly MyAppContext db;
        public GirlsRepository(MyAppContext _db)
        {
            db = _db;
        }
        public bool GetExisteUserName (string username)
        {
            var nameUser = db.Girls.Where(x => x.Activo == true && x.Username == username).Select(x => x.Username).FirstOrDefault();
            if (!string.IsNullOrEmpty(nameUser))
                return true;

            return false;
        }

        public bool GetExisteEmail(string email,bool activo)
        {
            var mail = db.Girls.Where(x => x.Activo == activo && x.Email == email).Select(x => x.Email).FirstOrDefault();
            if (!string.IsNullOrEmpty(mail))
                return true;

            return false;
        }

        public Girls InsertGirls(Girls model)
        {
            db.Girls.Add(model);
            db.SaveChanges();

            return model;
        }

        public Girls ActivarUsuario (Guid identificador, bool activo)
        {
            var girl = db.Girls.Where(x => x.Identidad == identificador).FirstOrDefault();
            db.Girls.Attach(girl);
            girl.Activo = activo;
            db.SaveChanges();

            return girl;
        }
    }
}
