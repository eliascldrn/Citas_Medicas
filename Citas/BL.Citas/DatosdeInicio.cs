using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Citas
{
    public class DatosdeInicio : CreateDatabaseIfNotExists<Contexto>
    {
        protected override void Seed(Contexto contexto)
        {

            var usuarioAdmin = new Usuario();
            usuarioAdmin.Nombre = "admin";
            usuarioAdmin.Contrasena = "123";
            usuarioAdmin.EsAdmin = true;

            contexto.Usuarios.Add(usuarioAdmin);

            var usuarioCaja = new Usuario();
            usuarioCaja.Nombre = "caja";
            usuarioCaja.Contrasena = "456";
         

            contexto.Usuarios.Add(usuarioCaja);

            var usuarioGerente = new Usuario();
            usuarioGerente.Nombre = "gerente";
            usuarioGerente.Contrasena = "789";
            usuarioGerente.PuedeAccederFacturas = false;
            usuarioGerente.PuedeAccederReportes = true;


            contexto.Usuarios.Add(usuarioGerente);

            var categoria1 = new Categoria();
            categoria1.Descripcion = "Analgesico";
            contexto.Categorias.Add(categoria1);

            var categoria2 = new Categoria();
            categoria2.Descripcion = "Antibiotico";
            contexto.Categorias.Add(categoria2);

            var categoria3 = new Categoria();
            categoria3.Descripcion = "Antiflamatorio";
            contexto.Categorias.Add(categoria3);

            var categoria4 = new Categoria();
            categoria4.Descripcion = "Anitseptico";
            contexto.Categorias.Add(categoria4);

            var categoria5 = new Categoria();
            categoria5.Descripcion = "Vacuna";
            contexto.Categorias.Add(categoria5);

            var categoria6 = new Categoria();
            categoria6.Descripcion = "Suero";
            contexto.Categorias.Add(categoria6);

            var categoria7 = new Categoria();
            categoria7.Descripcion = "Higiene y Salud";
            contexto.Categorias.Add(categoria7);

            var categoria8 = new Categoria();
            categoria8.Descripcion = "Snacks";
            contexto.Categorias.Add(categoria8);

            var categoria9 = new Categoria();
            categoria9.Descripcion = "Accesorios";
            contexto.Categorias.Add(categoria9);

            var tipo1 = new Tipo();
            tipo1.Descripcion = "Medicina";
            contexto.Tipos.Add(tipo1);

            var tipo2 = new Tipo();
            tipo2.Descripcion = "Higiene y Salud";
            contexto.Tipos.Add(tipo2);

            var tipo3 = new Tipo();
            tipo3.Descripcion = "Snacks";
            contexto.Tipos.Add(tipo3);

            var tipo4 = new Tipo();
            tipo4.Descripcion = "Accesorios";
            contexto.Tipos.Add(tipo4);

            var cliente1 = new Cliente();
            cliente1.Nombre = "Karl";
            cliente1.Telefono = "1345-7776";
            cliente1.Direccion = "Debajo de un punete";
            cliente1.Email = "kar2@gmail.com";
            cliente1.Activo = true;
            contexto.Clientes.Add(cliente1);

            var cliente2 = new Cliente();
            cliente2.Nombre = "Roberto";
            cliente2.Telefono = "4951-7186";
            cliente2.Direccion = "Power Chicken";
            cliente2.Email = "nibel@gmail.com";
            cliente2.Activo = true;
            contexto.Clientes.Add(cliente2);

            var agenda1 = new Agenda();
            agenda1.Nombre = "Charly";
            agenda1.Fecha = "11-11-2021";
            agenda1.Hora = "10:30 PM";
            agenda1.Medico = "Fernando Molina";
            agenda1.Servicio = "Consulta problmea gastrointestinal";
            contexto.Agenda.Add(agenda1);


            base.Seed(contexto);
        }
    }
}
