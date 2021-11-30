using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Citas
{
    public class AgendaBL
    {
        Contexto _contexto;

        public BindingList<Agenda> ListaAgenda { get; set; }

        public AgendaBL()
        {
            _contexto = new Contexto();
            ListaAgenda = new BindingList<Agenda>();
        }

        public BindingList<Agenda> ObtenerAgenda()
        {
            _contexto.Agenda.Load();
            ListaAgenda = _contexto.Agenda.Local.ToBindingList();

            return ListaAgenda;
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

        public Resultado GuardarAgenda(Agenda agenda)
        {
            var resultado = Validar(agenda);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }
            else
            {
                _contexto.SaveChanges();
                resultado.Exitoso = true;
            }
            return resultado;
        }

        public void AgregarAgenda()
        {
            var nuevoAgenda = new Agenda();
            _contexto.Agenda.Add(nuevoAgenda);
        }

        public bool EliminarAgenda(int id)
        {
            foreach (var cliente in ListaAgenda.ToList())
            {
                if (cliente.Id == id)
                {
                    ListaAgenda.Remove(cliente);
                    _contexto.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        private Resultado Validar(Agenda agenda)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            if (agenda == null)
            {
                resultado.Mensaje = "Formato invalido.";
                resultado.Exitoso = false;

                return resultado;
            }

            //VALIDACION PARA LA PROPIEDAD CLIENTE
            if(string.IsNullOrEmpty(agenda.Nombre) == true)
            {
                resultado.Mensaje = "Ingrese un nombre";
                resultado.Exitoso = false;
            }

            if (string.IsNullOrEmpty(agenda.Fecha) == true)
            {
                resultado.Mensaje = "Ingrese una fecha";
                resultado.Exitoso = false;
            }

            if (string.IsNullOrEmpty(agenda.Hora) == true)
            {
                resultado.Mensaje = "Ingrese una fecha";
                resultado.Exitoso = false;
            }

            if (string.IsNullOrEmpty(agenda.Medico) == true)
            {
                resultado.Mensaje = "Ingrese un medico valido";
                resultado.Exitoso = false;
            }

            if (string.IsNullOrEmpty(agenda.Servicio) == true)
            {
                resultado.Mensaje = "Ingrese un servicio";
                resultado.Exitoso = false;
            }

            return resultado;
        }
    }

    public class Agenda
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Medico { get; set; }
        public string Servicio { get; set; }
    }
}