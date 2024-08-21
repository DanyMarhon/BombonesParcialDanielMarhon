using Bombones.Entidades.Entidades;

namespace Bombones.Windows.Formularios
{
    public partial class frmRellenosAE : Form
    {
        private TipoDeRelleno? tipo;
        public frmRellenosAE()
        {
            InitializeComponent();
        }

        private void frmRellenosAE_Load(object sender, EventArgs e)
        {

        }
        public TipoDeRelleno? GetRelleno()
        {
            return tipo;
        }

        public void SetRelleno(TipoDeRelleno? tipo)
        {
            this.tipo = tipo;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (tipo != null)
            {
                txtRelleno.Text = tipo.Descripcion;
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
                if (tipo == null)
                {
                    tipo = new TipoDeRelleno();
                }
                tipo.Descripcion = txtRelleno.Text;

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtRelleno.Text))
            {
                valido = false;
                errorProvider1.SetError(txtRelleno, "El relleno es requerido");
            }
            return valido;
        }

    }
}
