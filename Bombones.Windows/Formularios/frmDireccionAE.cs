using Bombones.Entidades.Entidades;
using Bombones.Entidades.ViewModels;
using Bombones.Windows.Helpers;

namespace Bombones.Windows.Formularios
{
    public partial class frmDireccionAE : Form
    {
        private readonly IServiceProvider? _serviceProvider;

        private DireccionConTipoVm? direccionTipoVm;
        private Direccion? direccion;

        private Pais? pais;
        private ProvinciaEstado? provinciaEstado;
        private Ciudad? ciudad;
        private TipoDireccion? tipoDireccion;
        public frmDireccionAE(IServiceProvider? serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper.CargarComboTipoDireccion(ref cboTipoDireccion, _serviceProvider);
            CombosHelper.CargarComboPaises(ref cboPaises, _serviceProvider);
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (direccion is null)
                {
                    direccion = new Direccion();
                }

                direccion.Calle = txtCalle.Text;
                direccion.Altura = txtAltura.Text;
                direccion.Entre1 = txtEntre1.Text;
                direccion.Entre2 = txtEntre2.Text;
                direccion.Piso = string.IsNullOrEmpty(txtPiso.Text) ? null : int.Parse(txtPiso.Text);
                direccion.Depto = txtDepto.Text;
                direccion.PaisId = pais?.PaisId ?? 0;
                direccion.Pais = pais;
                direccion.ProvinciaEstadoId = provinciaEstado?.ProvinciaEstadoId ?? 0;
                direccion.ProvinciaEstado = provinciaEstado;
                direccion.Ciudad = ciudad;
                direccion.CiudadId = ciudad?.CiudadId ?? 0;
                direccion.CodPostal = txtCodPostal.Text;


                var tipoDireccion = (TipoDireccion?)cboTipoDireccion.SelectedItem;


                direccionTipoVm = new DireccionConTipoVm(direccion, tipoDireccion);
                DialogResult = DialogResult.OK;

            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (cboTipoDireccion.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboTipoDireccion, "Debe seleccionar tipo de dirección");
            }
            if (cboPaises.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboPaises, "Debe seleccionar un país");
            }
            if (cboProvinciasEstados.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboProvinciasEstados, "Debe seleccionar un estado");
            }
            if (cboCiudades.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboCiudades, "Debe seleccionar una ciudad");
            }
            if (string.IsNullOrEmpty(txtCalle.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtCalle, "Calle es requerido");
            }


            return valido;
        }

        private void cboPaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            pais = cboPaises.SelectedIndex > 0 ?
                (Pais?)cboPaises.SelectedItem : null;
            if (pais is not null)
            {
                CombosHelper.CargarComboProvinciaEstado(ref cboProvinciasEstados, pais, _serviceProvider);
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
                CombosHelper.CargarComboCiudades(ref cboCiudades, pais,
                    provinciaEstado,
                     _serviceProvider);
            }
            else
            {
                cboCiudades.DataSource = null;
            }

        }

        private void cboCiudades_SelectedIndexChanged(object sender, EventArgs e)
        {
            ciudad = cboCiudades.SelectedIndex > 0 ?
                (Ciudad?)cboCiudades.SelectedItem : null;
        }

        private void cboTipoDireccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            tipoDireccion = cboTipoDireccion.SelectedIndex > 0 ?
                (TipoDireccion?)cboTipoDireccion.SelectedItem : null;
        }

        public DireccionConTipoVm? GetDireccion()
        {
            return direccionTipoVm;
        }
    }
}
