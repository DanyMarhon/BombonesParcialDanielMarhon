using Bombones.Entidades.Entidades;
using Bombones.Entidades.ViewModels;
using Bombones.Windows.Helpers;

namespace Bombones.Windows.Formularios
{
    public partial class frmTelefonosAE : Form
    {
        private readonly IServiceProvider? _serviceProvider;
        private TelefonoConTipoVm? telefonoTipoVm;

        public frmTelefonosAE(IServiceProvider? serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper.CargarComboTipoTelefono(ref cboTipoTelefono, _serviceProvider);
        }

        public TelefonoConTipoVm? GetTelefono()
        {
            return telefonoTipoVm;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                var telefono = new Telefono
                {
                    Numero = txtTelefono.Text,

                };

                var tipoTelefono = (TipoTelefono?)cboTipoTelefono.SelectedItem;


                telefonoTipoVm = new TelefonoConTipoVm(telefono, tipoTelefono);
                DialogResult = DialogResult.OK;

            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (cboTipoTelefono.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboTipoTelefono, "Debe seleccionar tipo de teléfono");
            }
            if (string.IsNullOrEmpty(txtTelefono.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtTelefono, "Teléfono es requerido");
            }


            return valido;
        }
    }
}
