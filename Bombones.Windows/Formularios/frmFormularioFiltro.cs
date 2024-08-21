using Bombones.Entidades.Entidades;
using Bombones.Entidades.Enumeraciones;
using Bombones.Windows.Helpers;
using System.Windows.Forms;

namespace Bombones.Windows.Formularios
{
    public partial class frmFormularioFiltro : Form
    {
        private readonly IServiceProvider? _serviceProvider;
        private readonly FiltroContexto _filtroContexto;

        private Pais? paisSeleccionado;
        public frmFormularioFiltro(IServiceProvider? service,
            FiltroContexto filtroContexto)
        {
            InitializeComponent();
            _serviceProvider = service;
            _filtroContexto = filtroContexto;
        }

        public Pais? GetPais()
        {
            return paisSeleccionado;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmFormularioFiltro_Load(object sender, EventArgs e)
        {
            CombosHelper.CargarComboPaises(ref cboPaises, _serviceProvider);

            switch (_filtroContexto)
            {
                case FiltroContexto.Pais:
                    Size = new Size(620,200);
                    lblEstado.Visible = false;
                    lblCiudad.Visible = false;
                    cboProvinciasEstados.Visible = false;
                    cboCiudades.Visible = false;
                    FormBorderStyle = FormBorderStyle.FixedSingle;
                    break;
                case FiltroContexto.Estado:
                    Size = new Size(620, 240);
                    lblCiudad.Visible = false;
                    cboCiudades.Visible = false;
                    FormBorderStyle = FormBorderStyle.FixedSingle;

                    break;
                case FiltroContexto.Ciudad:
                    break;
            }
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (cboPaises.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboPaises, "Debe seleccionar un país");
            }
            return valido;
        }

        private void cboPaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            paisSeleccionado = (Pais?)cboPaises.SelectedItem ?? null;
        }

    }
}
