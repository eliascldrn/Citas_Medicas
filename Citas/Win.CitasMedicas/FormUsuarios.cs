using BL.Citas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.CitasMedicas
{
    public partial class FormUsuarios : Form
    {
        SeguridadBL _usuariosBL;

        public FormUsuarios()
        {
            InitializeComponent();

            _usuariosBL = new SeguridadBL();
            listaUsuariosBindingSource.DataSource = _usuariosBL.ObtenerUsuarios();
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {

        }

        //AGREGAR
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _usuariosBL.AgregarUsuario();
            listaUsuariosBindingSource.MoveLast();
            DeshabilitarHabilitarBotones(false);
        }

        //FUNCION PARA DESHABILITAR LOS BOTONES AL DARLE AGREGAR
        private void DeshabilitarHabilitarBotones(bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;

            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;
            toolStripButtonCancelar.Visible = !valor;
        }

        //ELIMINAR CLIENTE
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text != "")
            {
                var resultado = MessageBox.Show("Desea eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(idTextBox.Text);
                    Eliminar(id);
                }
            }
        }

        //GUARDAR CLIENTE
        private void listaUsuariosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaUsuariosBindingSource.EndEdit();
            var usuario = (Usuario)listaUsuariosBindingSource.Current;

            var resultado = _usuariosBL.GuardarUsuario(usuario);

            if (resultado.Exitoso == true)
            {
                listaUsuariosBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);
                MessageBox.Show("Usuario guardado");
            }
            else
            {
                MessageBox.Show("Ocurrio un error al guardar.");
            }
        }

        //Aparicion y desaparicion del boton cancelar
        private void toolStripButtonCancelar_Click(object sender, EventArgs e)
        {
            _usuariosBL.CancelarCambios();
            DeshabilitarHabilitarBotones(true);
        }

        //BOTON ELIMINAR
        private void Eliminar(int id)
        {
            var resultado = _usuariosBL.EliminarUsuario(id);

            if (resultado == true)
            {
                listaUsuariosBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Ocurrio un error al eliminar el Usuario");
            }
        }

    }
}
