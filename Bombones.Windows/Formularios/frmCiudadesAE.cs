using Bombones.Entidades.Entidades;
using Bombones.Windows.Helpers;

namespace Bombones.Windows.Formularios
{
    public partial class frmCiudadesAE : Form
    {
        private readonly IServiceProvider? _servicios;
        private Pais? paisSeleccionado;
        private ProvinciaEstado? provinciaEstado;
        private Ciudad? ciudad;
        public frmCiudadesAE(IServiceProvider? servicios)
        {
            InitializeComponent();
            _servicios = servicios;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper
                .CargarComboPaises(ref cboPaises, _servicios);
            if (ciudad is not null)
            {
                txtCiudad.Text = ciudad.NombreCiudad;
                cboPaises.SelectedValue = ciudad.PaisId;
                cboProvinciasEstados.SelectedValue = ciudad.ProvinciaEstadoId;
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
                if (ciudad is null)
                {
                    ciudad = new Ciudad();
                }
                ciudad.NombreCiudad = txtCiudad.Text;
                ciudad.Pais = paisSeleccionado;
                ciudad.ProvinciaEstado=provinciaEstado;
                ciudad.PaisId = paisSeleccionado?.PaisId??0;
                ciudad.ProvinciaEstadoId = provinciaEstado?.ProvinciaEstadoId ?? 0;

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtCiudad.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtCiudad, "Ciudad es requerido");
            }
            if (cboPaises.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(cboPaises, "Debe seleccionar país");
            }
            if (cboProvinciasEstados.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboProvinciasEstados, "Debe seleccionar una prov/estado");
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
        }

        public Ciudad? GetCiudad()
        {
            return ciudad;
        }

        public void SetCiudad(Ciudad ciudad)
        {
            this.ciudad = ciudad;
        }

    }
}
