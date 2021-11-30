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
    public partial class FormReporteCitas : Form
    {
        public FormReporteCitas()
        {
            InitializeComponent();

            var _agendaBL = new AgendaBL();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = _agendaBL.ObtenerAgenda();

            var reporte = new ReporteCitas();
            reporte.SetDataSource(bindingSource);

            crystalReportViewer1.ReportSource = reporte;
            crystalReportViewer1.RefreshReport();

        }
    }
}
