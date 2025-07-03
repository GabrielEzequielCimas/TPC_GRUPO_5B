using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum TipoUsuario
    {
        CLIENTE = 1,
        ADMIN = 2
    }
    public class Usuario
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

        public Usuario(string user, string pass, TipoUsuario tipo)
        {
            User = user;
            Password = pass;
            TipoUsuario = tipo;
        }

        public Usuario(string user,string pass,bool admin) 
        {
            User = user;
            Password = pass;
            TipoUsuario = admin ? TipoUsuario.ADMIN : TipoUsuario.CLIENTE;
        }

        public Usuario() { }

        public Cliente Cliente { get; set; }
    }
}
