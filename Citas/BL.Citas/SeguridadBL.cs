using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Citas
{
    public class SeguridadBL
    {
        Contexto _contexto;
        private BindingList<Usuario> ListaUsuarios;

        public BindingList<Usuario> ListaClientes { get; set; }

        public SeguridadBL()
        {
            _contexto = new Contexto();
            ListaUsuarios = new BindingList<Usuario>();
        }

        public Usuario Autorizar(string usuario, string contrasena)
        {
            var usuarios = _contexto.Usuarios.ToList();

            foreach (var usuarioDB in usuarios)
            {
                if (usuario == usuarioDB.Nombre && contrasena == usuarioDB.Contrasena)
                {
                    return usuarioDB;
                }
            }

            return null;
        }

        public BindingList<Usuario> ObtenerUsuarios()
        {
            _contexto.Usuarios.Load();
            ListaUsuarios = _contexto.Usuarios.Local.ToBindingList();

            return ListaUsuarios;
        }

        // CANCELAR
        public void CancelarCambios()
        {
            foreach (var item in _contexto.ChangeTracker.Entries())
            {
                item.State = EntityState.Unchanged;
                item.Reload();
            }
        }

        public Resultado GuardarUsuario(Usuario usuario)
        {
            var resultado = Validar(usuario);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }

            _contexto.SaveChanges();
            resultado.Exitoso = true;
            return resultado;
        }

        public void AgregarUsuario()
        {
            var nuevoUsuario = new Usuario();
            _contexto.Usuarios.Add(nuevoUsuario);
        }

        public bool EliminarUsuario(int id)
        {
            foreach (var usuario in ListaUsuarios.ToList())
            {
                if (usuario.Id == id)
                {
                    ListaUsuarios.Remove(usuario);
                    _contexto.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        private Resultado Validar(Usuario usuario)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            // Agregando anulacion de factura.//
            if (usuario == null)
            {
                resultado.Mensaje = "Ingrese un usuario valido.";
                resultado.Exitoso = false;

                return resultado;
            }

            if (usuario == null)
            {
                resultado.Mensaje = "Agregue un usuario valido";
                resultado.Exitoso = false;

                return resultado;
            }

            if (string.IsNullOrEmpty(usuario.Nombre) == true)
            {
                resultado.Mensaje = "Ingrese el nombre del usuario";
                resultado.Exitoso = false;
            }

          /*  if (string.IsNullOrEmpty(usuario.Telefono) == true)
            {
                resultado.Mensaje = "Ingrese el numero celular del usuario.";
                resultado.Exitoso = false;
            }*/

          /*  if (string.IsNullOrEmpty(usuario.Direccion) == true)
            {
                resultado.Mensaje = "Ingrese la direccion del usuario.";
                resultado.Exitoso = false;
            }*/

           /* if (string.IsNullOrEmpty(usuario.Email) == true)
            {
                resultado.Mensaje = "Ingrese el correo del usuario.";
                resultado.Exitoso = false;
            }*/
            return resultado;
        }
    }

    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }

        public bool EsAdmin { get; set; }
        public bool PuedeAccederMedicamentos { get; set; }
        public bool PuedeAccederClientes { get; set; }
        public bool PuedeAccederFacturas { get; set; }
        public bool PuedeAccederReportes { get; set; }

        public Usuario()
        {
            PuedeAccederMedicamentos = false;
            PuedeAccederClientes = false;
            PuedeAccederFacturas = true;
            PuedeAccederReportes = false;
        }
    }
}