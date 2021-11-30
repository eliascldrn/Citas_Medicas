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
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }
        /* Este deberia de ser FormClientes*/
        private void medicamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formClientes = new FormClientes();
            formClientes.MdiParent = this;
            formClientes.Show();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            /*Esta variable viene Login (Deberia de ser FormLogin) */
            Login();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // sirve para cerrar todas las ventanas antes de cambiar de usuario
            Form[] forms = Application.OpenForms.Cast<Form>().ToArray();

            foreach (Form f in forms)
            {
                if(f.Name != "FormMenu")
                {
                    f.Close();
                }
            }


            //Esta variable viene Login (Deberia de ser FormLogin) 
            Login();
        }
        private void Login()
        {

            var form1 = new Form1();
            form1.ShowDialog();

            toolStripStatusLabel1.Text = "Usuario : "+ Utilidades.UsuarioActual.Nombre;
            if (Utilidades.UsuarioActual.EsAdmin)
            {
                usuariosToolStripMenuItem.Visible = true;
            }
            else
            {
                usuariosToolStripMenuItem.Visible = false;
                medicamentosToolStripMenuItem.Visible = Utilidades.UsuarioActual.PuedeAccederMedicamentos;
                clientesToolStripMenuItem.Visible = Utilidades.UsuarioActual.PuedeAccederClientes;
                facturaToolStripMenuItem.Visible = Utilidades.UsuarioActual.PuedeAccederFacturas;
                reportesToolStripMenuItem.Visible = Utilidades.UsuarioActual.PuedeAccederReportes;
            }
            
        }

        private void agendarCitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formAgendarCitas = new FormAgendarCitas();
            formAgendarCitas.MdiParent = this;
            formAgendarCitas.Show();
        }

        private void buscarMedicamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formMedicamentos = new FormMedicamentos();
            formMedicamentos.MdiParent = this;
            formMedicamentos.Show();
        }

        private void calendarioDeCitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formCalendario = new FormCalendario();
            formCalendario.MdiParent = this;
            formCalendario.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;

            }
            else
            {
                this.WindowState = FormWindowState.Normal;

            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void facturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formFactura = new FormFactura();
            formFactura.MdiParent = this;
            formFactura.Show();
        }

        private void seguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reporteDeMedicamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formReporteMedicamentos = new FormReporteMedicamentos();
            formReporteMedicamentos.MdiParent = this;
            formReporteMedicamentos.Show();
        }

        private void reporteDeFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formReporteFacturas = new FormReporteFacturas();
            formReporteFacturas.MdiParent = this;
            formReporteFacturas.Show();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formUsuarios = new FormUsuarios();
            formUsuarios.MdiParent = this;
            formUsuarios.Show();

        }

        private void reportesDeCitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formReporteCitas = new FormReporteCitas();
            formReporteCitas.MdiParent = this;
            formReporteCitas.Show();
        }

        private void reporteDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formReporteClientes = new FormReporteClientes();
            formReporteClientes.MdiParent = this;
            formReporteClientes.Show();
        }
    }
}
