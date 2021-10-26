using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Citas
{
    public class SeguridadBL
    {
        public bool Autorizar(string Usuario, string Contraseña)
        {
            if (Usuario == "admin" && Contraseña == "123")
            {
                return true;
            }
            else
            {
                if (Usuario == "user" && Contraseña == "456")
                {
                    return true;
                }
            }
            return false;
        }
    }
}
    /*public class SeguridadBL
    {
        Contexto _contexto;

        public SeguridadBL();
        {
            _contexto = new Contexto();
        }

        public bool Autorizar (string usuario, string contrasena)
        {
            var usuarios = _contexto.Usuarios.ToList();
            
            foreach (var usuarioDB in usuarios)
            {
                if (usuario ==usuarioDB.Nombre && contrasena == usuarioDB.Contrasena)
                {
                return true;
                }
             }

            return false; 
        }
    }*/
