using Bombones.Entidades.Entidades;

namespace Bombones.Windows.Formularios
{
    public partial class frmNuecesAE : Form
    {
        private TipoDeNuez? tipo;
        public frmNuecesAE()
        {
            InitializeComponent();
        }

        public TipoDeNuez? GetNuez()
        {
            return tipo;
        }

        public void SetNuez(TipoDeNuez? tipo)
        {
            this.tipo = tipo;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (tipo != null)
            {
                txtNuez.Text = tipo.Descripcion;
            }
        }

        internal TipoDeRelleno GetRelleno()
        {
            throw new NotImplementedException();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (tipo == null)
                {
                    tipo = new TipoDeNuez();
                }
                tipo.Descripcion = txtNuez.Text;

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtNuez.Text))
            {
                valido = false;
                errorProvider1.SetError(txtNuez, "La nuez es requerida");
            }
            return valido;
        }

    }
}
