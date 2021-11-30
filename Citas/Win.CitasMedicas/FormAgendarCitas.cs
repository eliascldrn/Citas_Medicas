using BL.Citas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.CitasMedicas
{
    public partial class FormAgendarCitas : Form
    {

        AgendaBL _agenda;
        ClientesBL _clientes;

        public FormAgendarCitas()
        {
            InitializeComponent();

            _agenda = new AgendaBL();
            listaAgendaBindingSource.DataSource = _agenda.ObtenerAgenda();

            _clientes = new ClientesBL();
            listaClientesBindingSource.DataSource = _clientes.ObtenerClientes();
        }

        private void FormAgendarCitas_Load(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        //Guardar
        private void listaAgendaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaAgendaBindingSource.EndEdit();
            var agenda = (Agenda)listaAgendaBindingSource.Current;

            var resultado = _agenda.GuardarAgenda(agenda);

            if (resultado.Exitoso == true)
            {
                listaAgendaBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);
                MessageBox.Show("Cita Agendada");
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }
        }

        // Deshabilitando botones.
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

        private void toolStripButtonCancelar_Click(object sender, EventArgs e)
        {
            _agenda.CancelarCambios();
            DeshabilitarHabilitarBotones(true);
        }

        private void Eliminar(int id)
        {

            var resultado = _agenda.EliminarAgenda(id);

            if (resultado == true)
            {
                listaAgendaBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Ocurrio un error.");
            }
        }

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

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _agenda.AgregarAgenda();
            listaAgendaBindingSource.MoveLast();

            DeshabilitarHabilitarBotones(false);
        }
    }
}
