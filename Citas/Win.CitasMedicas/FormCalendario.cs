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
    public partial class FormCalendario : Form
    {
        AgendaBL _agenda;

        public FormCalendario()
        {
            InitializeComponent();

            _agenda = new AgendaBL();
            listaAgendaBindingSource.DataSource = _agenda.ObtenerAgenda();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var formClientes = new FormClientes();
            formClientes.Show();
        }
    }
}
