using Bombones.Entidades.Entidades;
using Bombones.Windows.Helpers;
using System.Text.RegularExpressions;

namespace Bombones.Windows.Formularios
{
    public partial class frmProvinciasEstadosAE : Form
    {
        private readonly IServiceProvider? _serviceProvider;
        private ProvinciaEstado? pe;
        private Pais? paisSeleccionado;
        public frmProvinciasEstadosAE(IServiceProvider? serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        public ProvinciaEstado GetProvEstado()
        {
            return pe;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (pe is null)
                {
                    pe = new ProvinciaEstado();
                }
                pe.NombreProvinciaEstado = txtProvEstado.Text;
                if (cboPaises.SelectedValue is not null)
                {
                    pe.PaisId = (int)cboPaises.SelectedValue;
                    pe.Pais = paisSeleccionado;

                }
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            //if (string.IsNullOrEmpty(txtProvEstado.Text))
            //{
            //    valido = false;
            //    errorProvider1.SetError(txtProvEstado, "El nombre es requerido");
            //}
            string patron = "^[a-zA-Z -']+$";
            if (!Regex.IsMatch(txtProvEstado.Text, patron))
            {
                valido = false;
                errorProvider1.SetError(txtProvEstado, "El nombre es requerido");

            }
            if (cboPaises.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboPaises, "Debe seleccionar un país");
            }
            return valido;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper.
                CargarComboPaises(ref cboPaises, _serviceProvider);
            if (pe is not null)
            {
                txtProvEstado.Text = pe.NombreProvinciaEstado;
                cboPaises.SelectedValue = pe.PaisId;
            }
        }

        private void cboPaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPaises.SelectedIndex == 0)
            {
                paisSeleccionado = null;
            }
            else
            {
                paisSeleccionado = (Pais?)cboPaises.SelectedItem;
            }
        }

        public void SetProvEstado(ProvinciaEstado pe)
        {
            this.pe = pe;
        }
    }
}
