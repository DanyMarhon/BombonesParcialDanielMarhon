using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.Servicios.Intefaces;
using Bombones.Windows.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Bombones.Windows.Formularios
{
    public partial class frmFabricas : Form
    {
        private readonly IServiceProvider? _serviceProvider;
        private readonly IServiciosFabricas? _servicio;
        private List<FabricaListDto>? lista;

        private int currentPage = 1;//pagina actual
        private int totalPages = 0;//total de paginas
        private int pageSize = 10;//registros por página
        private int totalRecords = 0;//cantidad de registros

        public frmFabricas(IServiceProvider? serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _servicio = _serviceProvider?.GetService<IServiciosFabricas>();
        }

        private void frmFabricas_Load(object sender, EventArgs e)
        {
            try
            {
                totalRecords = _servicio!.GetCantidad();
                totalPages = (int)Math.Ceiling((decimal)totalRecords / pageSize);
                LoadData();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void LoadData()
        {
            try
            {
                lista = _servicio!.GetLista(currentPage, pageSize);
                MostrarDatosEnGrilla(lista);
                if (cboPaginas.Items.Count != totalPages)
                {
                    CombosHelper.CargarComboPaginas(ref cboPaginas, totalPages);
                }
                txtCantidadPaginas.Text = totalPages.ToString();
                cboPaginas.SelectedIndexChanged -= cboPaginas_SelectedIndexChanged;
                cboPaginas.SelectedIndex = currentPage == 1 ? 0 : currentPage - 1;
                cboPaginas.SelectedIndexChanged += cboPaginas_SelectedIndexChanged;

            }
            catch (Exception)
            {

                throw;
            }
        }
        private void btnPrimero_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadData();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadData();
            }
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            currentPage = totalPages;
            LoadData();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadData();
            }
        }

        private void cboPaginas_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPage = int.Parse(cboPaginas.Text);
            LoadData();
        }

        private void MostrarDatosEnGrilla(List<FabricaListDto> lista)
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            if (lista is not null)
            {
                foreach (var c in lista)
                {
                    var r = GridHelper.ConstruirFila(dgvDatos);
                    GridHelper.SetearFila(r, c);
                    GridHelper.AgregarFila(r, dgvDatos);
                }

            }
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmFabricasAE frm = new frmFabricasAE(_serviceProvider);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            try
            {
                Fabrica? fabrica = frm.GetFabrica();
                if (fabrica is null) return;
                if (!_servicio!.Existe(fabrica))
                {
                    _servicio.Guardar(fabrica);


                    totalRecords = _servicio?.GetCantidad() ?? 0;
                    totalPages = (int)Math.Ceiling((decimal)totalRecords / pageSize);
                    currentPage = _servicio?.GetPaginaPorRegistro(fabrica.NombreFabrica, pageSize) ?? 0;
                    LoadData();

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            if (r.Tag is null) return;
            var fabricaDto = (FabricaListDto)r.Tag;
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja la fabrica. {fabricaDto.NombreCiudad}?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;
            try
            {
                if (!_servicio!.EstaRelacionado(fabricaDto.FabricaId))
                {
                    _servicio!.Borrar(fabricaDto.FabricaId);
                    totalRecords = _servicio!.GetCantidad();
                    totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                    if (currentPage > totalPages) currentPage = totalPages; // Ajustar la página actual si se reduce el total de páginas

                    LoadData();
                    MessageBox.Show("Registro eliminado",
                        "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Registro relacionado!!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            if (r.Tag == null) return;
            FabricaListDto fabricaDto = (FabricaListDto)r.Tag;
            Fabrica? fabrica = _servicio?.GetFabricaPorId(fabricaDto.FabricaId);
            if (fabrica is null) return;
            frmFabricasAE frm = new frmFabricasAE(_serviceProvider) { Text = "Editar Fabrica" };
            frm.SetFabrica(fabrica);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            fabrica = frm.GetFabrica();

            if (fabrica == null) return;
            try
            {

                if (!_servicio!.Existe(fabrica))
                {
                    _servicio!?.Guardar(fabrica);


                    currentPage = _servicio!.GetPaginaPorRegistro(fabrica.NombreFabrica, pageSize);
                    LoadData();
                    int row = GridHelper.ObtenerRowIndex(dgvDatos, fabrica.FabricaId);
                    GridHelper.MarcarRow(dgvDatos, row);
                }
                else
                {
                    MessageBox.Show("Registro existente\nEdición denegada",
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

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
