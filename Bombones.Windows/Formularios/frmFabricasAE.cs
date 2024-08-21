using Bombones.Entidades.Entidades;
using Bombones.Windows.Helpers;

namespace Bombones.Windows.Formularios
{
    public partial class frmFabricasAE : Form
    {
        private readonly IServiceProvider? _servicios;
        private Pais? paisSeleccionado;
        private ProvinciaEstado? provinciaEstado;
        private Ciudad? ciudad;
        private Fabrica? fabrica;
        public frmFabricasAE(IServiceProvider? servicios)
        {
            InitializeComponent();
            _servicios = servicios;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper
                .CargarComboPaises(ref cboPaises, _servicios);
            if (fabrica is not null)
            {
                txtFabrica.Text = fabrica.NombreFabrica;
                txtDireccion.Text = fabrica.Direccion;
                cboPaises.SelectedValue = fabrica.PaisId;
                cboProvinciasEstados.SelectedValue = fabrica.ProvinciaEstadoId;
                cboCiudades.SelectedValue = fabrica.CiudadId;
            }

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (fabrica is null)
                {
                    fabrica = new Fabrica();
                }
                fabrica.NombreFabrica = txtFabrica.Text;
                fabrica.Direccion = txtDireccion.Text;
                fabrica.Pais = paisSeleccionado;
                fabrica.ProvinciaEstado = provinciaEstado;
                fabrica.PaisId = paisSeleccionado?.PaisId ?? 0;
                fabrica.ProvinciaEstadoId = provinciaEstado?.ProvinciaEstadoId ?? 0;
                fabrica.CiudadId = ciudad?.CiudadId??0;
                fabrica.Ciudad = ciudad;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtFabrica.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtFabrica, "Fabrica es requerido");
            }
            if (string.IsNullOrEmpty(txtDireccion.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtDireccion, "Dirección es requerido");
            }

            if (cboPaises.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboPaises, "Debe seleccionar país");
            }
            if (cboProvinciasEstados.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboProvinciasEstados, "Debe seleccionar una prov/estado");
            }
            if (cboCiudades.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboCiudades, "Debe seleccionar ciudad");
            }

            return valido;
        }

        private void cboPaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            paisSeleccionado = cboPaises.SelectedIndex > 0 ?
                (Pais?)cboPaises.SelectedItem : null;
            if (paisSeleccionado is not null)
            {
                CombosHelper.CargarComboProvinciaEstado(ref cboProvinciasEstados, paisSeleccionado, _servicios);
            }
            else
            {
                cboProvinciasEstados.DataSource = null;
            }
        }

        private void cboProvinciasEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            provinciaEstado = cboProvinciasEstados.SelectedIndex > 0 ?
                (ProvinciaEstado?)cboProvinciasEstados.SelectedItem : null;
            if (provinciaEstado is not null)
            {
                CombosHelper.CargarComboCiudades(ref cboCiudades, paisSeleccionado, provinciaEstado, _servicios);
            }
            else
            {
                cboCiudades.DataSource = null;
            }

        }


        public Fabrica? GetFabrica()
        {
            return fabrica;
        }

        internal void SetFabrica(Fabrica fabrica)
        {
            this.fabrica = fabrica;
        }

        private void frmFabricasAE_Load(object sender, EventArgs e)
        {

        }

        private void cboCiudades_SelectedIndexChanged(object sender, EventArgs e)
        {
            ciudad = cboCiudades.SelectedIndex > 0 ?
                    (Ciudad?)cboCiudades.SelectedItem : null;

        }
    }
}
