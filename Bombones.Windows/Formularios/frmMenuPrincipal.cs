using Bombones.Servicios.Intefaces;
using Bombones.Windows.Formularios;
using Microsoft.Extensions.DependencyInjection;

namespace Bombones.Windows
{
    public partial class frmMenuPrincipal : Form
    {
        private readonly IServiceProvider? _serviceProvider;
        public frmMenuPrincipal(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }
        private void btnChocolates_Click(object sender, EventArgs e)
        {
            var frm = new frmChocolates(_serviceProvider);   // Crea frm, un objeto del tipo formulario frmChocolates
            frm.ShowDialog();       // muestra frm de forma modal
        }

        private void btnPaises_Click(object sender, EventArgs e)
        {
            var frm = new frmPaises(_serviceProvider);
            frm.ShowDialog();
        }

        private void btnRellenos_Click(object sender, EventArgs e)
        {
            var frm = new frmRellenos(
                _serviceProvider);
            frm.ShowDialog();
        }

        private void btnNueces_Click(object sender, EventArgs e)
        {
            var frm = new frmNueces(_serviceProvider);
            frm.ShowDialog();
        }

        private void btnProvinciasEstados_Click(object sender, EventArgs e)
        {
            var frm = new frmProvinciasEstados(
                _serviceProvider);
            frm.ShowDialog();
        }

        private void btnCiudades_Click(object sender, EventArgs e)
        {
            var frm = new frmCiudades(
                    _serviceProvider);
            frm.ShowDialog();

        }

        private void btnFabricas_Click(object sender, EventArgs e)
        {
            var frm = new frmFabricas(_serviceProvider);
            frm.ShowDialog();

        }

        private void frmMenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            frmClientes frm = new frmClientes(_serviceProvider);
            frm.ShowDialog();
        }

        private void btnBombones_Click(object sender, EventArgs e)
        {
            frmBombones frm = new frmBombones(_serviceProvider);
            frm.ShowDialog();
        }

        private void btnFormasDeVenta_Click(object sender, EventArgs e)
        {
            frmFormasDeVenta frm = new frmFormasDeVenta();
            frm.ShowDialog();
        }

        private void btnFormasDePago_Click(object sender, EventArgs e)
        {
            frmFormasDePago frm = new frmFormasDePago();
            frm.ShowDialog();
        }
    }
}
