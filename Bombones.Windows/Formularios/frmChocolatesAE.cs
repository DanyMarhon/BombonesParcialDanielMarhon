using Bombones.Entidades.Entidades;

namespace Bombones.Windows
{
    public partial class frmChocolatesAE : Form
    {
        public frmChocolatesAE()
        {
            InitializeComponent();
        }

        private TipoDeChocolate tipoChocolate=null!;      // variable de tipo TipoDeChocolate
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Dado que Cancel es una propiedad estática de la enumeración DialogResult
            //(pertenece a la clase, no a los objetos) no es necesario utilizar el operador
            //de asignación (=) para asignarle un valor.
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                // Significa que el objeto es nuevo. Se crea una instancia tipoChocolate de la clase TipoDeChocolate

                if (tipoChocolate == null)
                {
                    tipoChocolate = new TipoDeChocolate();
                }
                tipoChocolate.Descripcion = txtChocolate.Text;      // la propiedad Descripcion toma el texto del textbox txtChocolate

                DialogResult = DialogResult.OK;     // Indica que el usuario presionó Ok
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;     // se declara e inicializa valido en true
            errorProvider1.Clear();     // Se limpia el formulario de cualquier tipo de error

            // Si el texto dentro del textbox txtChocolate no es vacío ni nulo
            if (string.IsNullOrEmpty(txtChocolate.Text))
            {
                valido = false;     // valido ahora es false
                // El textbox txtChocolate muestra el error correspondiente
                errorProvider1.SetError(txtChocolate, "El chocolate es requerido");
                // No hace falta codificar el stock, porque desde el formulario se establece
                // que como mínimo tendrá el valor 1, con lo cual, nunca será nulo ni vacío
            }
            return valido;      // devuelve válido
        }

        public TipoDeChocolate GetTipo()
        {
            return tipoChocolate;     // Retorna el tipo de chocolate
        }

        public void SetTipo(TipoDeChocolate chocolate)
        {
            // El objeto tipoDeChocolate de frmChocolateAE toma los datos nuevos que le pasó el usuario
            tipoChocolate = chocolate;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Si el objeto ya está en la grilla, toma los datos de ahí y los muestra en frmChocolatesAE
            if (tipoChocolate != null)
            {
                txtChocolate.Text = tipoChocolate.Descripcion;
            }
        }
    }
}
