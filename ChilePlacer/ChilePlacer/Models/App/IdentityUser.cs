using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChilePlacer.Models.App
{
    public class IdentityUser
    {
        public Guid Identidad { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public bool Activo { get; set; }

        public string Password { get; set; }
    }
}
