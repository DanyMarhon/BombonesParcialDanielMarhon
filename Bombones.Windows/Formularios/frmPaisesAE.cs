using Bombones.Entidades.Entidades;

namespace Bombones.Windows.Formularios
{
    public partial class frmPaisesAE : Form
    {
        private Pais? pais;
        public frmPaisesAE()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (pais != null)
            {
                txtPais.Text = pais.NombrePais;
            }
        }
        public Pais? GetPais()
        {
            return pais;
        }

        public void SetPais(Pais? pais)
        {
            this.pais = pais;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (pais == null)
                {
                    pais = new Pais();
                }
                pais.NombrePais = txtPais.Text;

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtPais.Text))
            {
                valido = false;
                errorProvider1.SetError(txtPais, "El país es requerido");
            }
            return valido;
        }
    }
}
