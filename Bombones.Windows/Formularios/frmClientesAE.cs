using Bombones.Entidades.Entidades;
using Bombones.Entidades.ViewModels;
using Bombones.Windows.Helpers;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Bombones.Windows.Formularios
{
    public partial class frmClientesAE : Form
    {
        private readonly IServiceProvider? _serviceProvider;

        private List<DireccionConTipoVm> direcciones = new();
        private List<TelefonoConTipoVm> telefonos = new();

        private Cliente? cliente;
        public frmClientesAE(IServiceProvider? serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void btnAgregarDireccion_Click(object sender, EventArgs e)
        {
            frmDireccionAE frm = new frmDireccionAE(_serviceProvider);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;

            DireccionConTipoVm? direccionConTipo = frm.GetDireccion();
            if (direccionConTipo is null) return;
            // Verifica si la dirección ya existe en la lista
            if (direcciones.Any(dt => dt.Direccion
                .Equals(direccionConTipo?.Direccion)))
            {
                MessageBox.Show("La dirección ya existe en la lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            direcciones.Add(direccionConTipo);
            var r = GridHelper.ConstruirFila(dgvDirecciones);
            GridHelper.SetearFila(r, direccionConTipo.Direccion);
            GridHelper.AgregarFila(r, dgvDirecciones);

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (cliente is null)
                {
                    cliente = new Cliente();
                }
                cliente.Documento = int.Parse(txtDocumento.Text);
                cliente.Apellido = txtApellido.Text;
                cliente.Nombres = txtNombre.Text;
                cliente.ClienteDirecciones = direcciones.Select(dt => new ClienteDireccion
                {
                    TipoDireccionId = dt.TipoDireccion?.TipoDireccionId ?? 0,
                    Direccion = dt.Direccion,
                    TipoDireccion = dt.TipoDireccion
                }).ToList();
                cliente.ClienteTelefonos = telefonos.Select(dt => new ClienteTelefono
                {
                    TipoTelefonoId = dt.TipoTelefono?.TipoTelefonoId ?? 0,
                    Telefono = dt.Telefono,
                    TipoTelefono = dt.TipoTelefono
                }).ToList();
            }
            DialogResult = DialogResult.OK;
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (!Regex.IsMatch(txtDocumento.Text, @"^\d{8}$"))
            {
                valido = false;
                errorProvider1.SetError(txtDocumento, "Documento debe tener exactamente 8 caracteres numéricos.");
            }
            if (string.IsNullOrEmpty(txtApellido.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtApellido, "Apellido es requerido");
            }
            if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtApellido, "Nombre es requerido");
            }
            if (direcciones.Count == 0)
            {
                valido = false;
                errorProvider1.SetError(lblDirecciones,
                    "Debe ingresar al menos una dirección");
            }
            if (direcciones.Count == 0)
            {
                valido = false;
                errorProvider1.SetError(lblTelefonos,
                    "Debe ingresar al menos un teléfono");
            }

            return valido;
        }

        private void btnBorrarDireccion_Click(object sender, EventArgs e)
        {
            if (dgvDirecciones.SelectedRows.Count == 0) return;
            var r = dgvDirecciones.SelectedRows[0];
            if (r is null) return;

            DireccionConTipoVm? direccionConTipoVm = (DireccionConTipoVm?)r.Tag;
            if (direccionConTipoVm is null) return;

            DialogResult dr = MessageBox.Show("¿Desea borrar la dirección?",
                "Confirmar", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;

            direcciones.Remove(direccionConTipoVm);
            GridHelper.QuitarFila(r, dgvDirecciones);
        }

        public Cliente? GetCliente()
        {
            return cliente;
        }

        private void btnAgregarTelefono_Click(object sender, EventArgs e)
        {
            frmTelefonosAE frm = new frmTelefonosAE(_serviceProvider);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;

            TelefonoConTipoVm? telefonoConTipo = frm.GetTelefono();
            if (telefonoConTipo is null) return;
            // Verifica si la dirección ya existe en la lista
            if (telefonos.Any(dt => dt.Telefono
                .Equals(telefonoConTipo?.Telefono)))
            {
                MessageBox.Show("Teléfono ya existe en la lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            telefonos.Add(telefonoConTipo);
            var r = GridHelper.ConstruirFila(dgvTelefonos);
            GridHelper.SetearFila(r, telefonoConTipo.Telefono);
            GridHelper.AgregarFila(r, dgvTelefonos);


        }

        internal void SetCliente(Cliente cliente)
        {
            this.cliente = cliente;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (cliente is not null)
            {
                txtDocumento.Text = cliente.Documento.ToString();
                txtApellido.Text = cliente.Apellido;
                txtNombre.Text = cliente.Nombres;              

                foreach (var item in cliente.ClienteDirecciones)
                {
                    var r = GridHelper.ConstruirFila(dgvDirecciones);
                    GridHelper.SetearFila(r, item.Direccion);
                    GridHelper.AgregarFila(r, dgvDirecciones); 
                }

                foreach (var item in cliente.ClienteTelefonos)
                {
                    var r = GridHelper.ConstruirFila(dgvTelefonos);
                    GridHelper.SetearFila(r, item.Telefono);
                    GridHelper.AgregarFila(r, dgvTelefonos);
                }
            }
        }
    }
}