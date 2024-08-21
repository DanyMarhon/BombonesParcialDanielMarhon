using Bombones.Entidades.Entidades;
using Bombones.Servicios.Intefaces;
using Bombones.Windows.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Bombones.Windows
{
    public partial class frmChocolates : Form
    {
        private List<TipoDeChocolate> lista = null!;
        private readonly IServiciosTiposDeChocolates? _servicio;
        public frmChocolates(IServiceProvider? serviceProvider)
        {
            InitializeComponent();
            _servicio = serviceProvider?.GetService<IServiciosTiposDeChocolates>()
                ?? throw new ApplicationException("Dependencias no cargadas!!!"); ;
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmChocolates_Load(object sender, EventArgs e)
        {
            try
            {

                lista = _servicio!.GetLista();      // la lista guarda el listado de los registros con los tipos de chocolate
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            foreach (var chocolate in lista)      // Recorre la lista de chocoltes
            {
                var r = GridHelper.ConstruirFila(dgvDatos);       // Se inicialia r con el resultado de ConstruirFila
                GridHelper.SetearFila(r, chocolate);         // Completa la fila r con el objeto chocolate, que es una fila de lista
                GridHelper.AgregarFila(r, dgvDatos);
            }
        }



        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmChocolatesAE frm = new frmChocolatesAE() { Text = "Nuevo chocolate" };
            DialogResult dr = frm.ShowDialog(this);

            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                TipoDeChocolate tipoDeChocolate = frm.GetTipo();
                if (!_servicio!.Existe(tipoDeChocolate))
                {
                    _servicio!.Guardar(tipoDeChocolate);
                    var r = GridHelper.ConstruirFila(dgvDatos);
                    GridHelper.SetearFila(r, tipoDeChocolate);
                    GridHelper.AgregarFila(r, dgvDatos);
                    MessageBox.Show("Registro agregado",
                                    "Mensaje",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Registro existente\nAlta denegada",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];

            TipoDeChocolate? chocolate = null!;
            if (r.Tag != null)
            {
                chocolate = (TipoDeChocolate)r.Tag;

            }
            try
            {
                DialogResult dr = MessageBox.Show($"¿Desea dar de baja al chocolate {chocolate.Descripcion}?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);

                if (dr == DialogResult.No)
                {
                    return;     // Si se presiona No, cancelar
                }

                if (!_servicio!.EstaRelacionado(chocolate.TipoDeChocolateId))
                {
                    _servicio!.Borrar(chocolate.TipoDeChocolateId);

                    GridHelper.QuitarFila(r, dgvDatos);
                    MessageBox.Show("Registro eliminado satisfactoriamente",
                        "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Registro relacionado\nBaja Denegada",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)   // Si no hay filas seleccionadas, salgo
            {
                return;
            }
            try
            {
                var r = dgvDatos.SelectedRows[0];
                TipoDeChocolate tipoChocolate;
                if (r.Tag != null)
                {
                    tipoChocolate = (TipoDeChocolate)r.Tag;
                    frmChocolatesAE frm = new frmChocolatesAE { Text = "Editar chocolate" };
                    frm.SetTipo(tipoChocolate);
                    DialogResult dr = frm.ShowDialog(this);

                    if (dr == DialogResult.Cancel)
                    {
                        return;
                    }
                    tipoChocolate = frm.GetTipo();

                    if (!_servicio!.Existe(tipoChocolate))       // Si no existe el chocolate, lo edita
                    {
                        // Servicios ordena a Datos que guarde la edición en la BASE DE DATOS
                        _servicio!.Guardar(tipoChocolate);
                        GridHelper.SetearFila(r, tipoChocolate);    // Agrega los datos en las celdas de una la fila que YA ESTÁ CREADA.
                        MessageBox.Show("Chocolate editado satisfactoriamente",
                            "Mensaje",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Registro existente\nEdición denegada",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }

                }

            }
            catch (Exception)
            {

            }
        }

    }
}
