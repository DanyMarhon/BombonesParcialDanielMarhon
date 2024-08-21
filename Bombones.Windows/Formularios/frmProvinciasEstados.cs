using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.Entidades.Enumeraciones;
using Bombones.Servicios.Intefaces;
using Bombones.Windows.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Bombones.Windows.Formularios
{
    public partial class frmProvinciasEstados : Form
    {
        private readonly IServiceProvider? _serviceProvider;
        private readonly IServiciosProvinciasEstados? _servicio;
        private List<ProvinciaEstadoListDto>? lista;
        private Orden orden = Orden.ProvinciaEstadoAZ;

        private int currentPage = 1;//pagina actual
        private int totalPages = 0;//total de paginas
        private int pageSize = 10;//registros por página
        private int totalRecords = 0;//cantidad de registros

        private FiltroContexto filtroContexto = FiltroContexto.Pais;
        private Pais? paisFiltro = null;
        private bool filterOn = false;
        public frmProvinciasEstados(IServiceProvider? serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider?? throw new ApplicationException("Dependencias no cargadas");
            _servicio = _serviceProvider?.GetService<IServiciosProvinciasEstados>()
                ?? throw new ApplicationException("Dependencias no cargadas!!!"); ;
        }

        private void frmProvinciasEstados_Load(object sender, EventArgs e)
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

                lista = _servicio?.GetLista(currentPage, pageSize, orden, paisFiltro);
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

        private void cboPaginas_SelectedIndexChanged(object? sender, EventArgs e)
        {
            currentPage = int.Parse(cboPaginas.Text);
            LoadData();
        }

        private void MostrarDatosEnGrilla(List<ProvinciaEstadoListDto>? lista)
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            if (lista is not null)
            {
                foreach (var item in lista)
                {
                    var r = GridHelper.ConstruirFila(dgvDatos);
                    GridHelper.SetearFila(r, item);
                    GridHelper.AgregarFila(r, dgvDatos);
                }

            }
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmProvinciasEstadosAE frm = new frmProvinciasEstadosAE(_serviceProvider)
            { Text = "Agregar Prov./Estado" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            try
            {
                ProvinciaEstado pe = frm.GetProvEstado();

                if (!_servicio!.Existe(pe))
                {
                    _servicio!.Guardar(pe);
                    totalRecords = _servicio!.GetCantidad();
                    totalPages = (int)Math.Ceiling((decimal)totalRecords / pageSize);
                    currentPage = _servicio!.GetPaginaPorRegistro(pe.NombreProvinciaEstado, pageSize);
                    LoadData();
                    int row = GridHelper.ObtenerRowIndex(dgvDatos, pe.ProvinciaEstadoId);
                    GridHelper.MarcarRow(dgvDatos, row);

                    MessageBox.Show("Registro agregado",
                        "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Registro Duplicado!!!",
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
            if (r.Tag is null) return;
            var peDto = (ProvinciaEstadoListDto)r.Tag;
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja el/la estado/pcia. {peDto.NombreProvinciaEstado}?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;
            try
            {
                if (!_servicio!.EstaRelacionado(peDto.ProvinciaEstadoId))
                {
                    _servicio!.Borrar(peDto.ProvinciaEstadoId);
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
            if (r.Tag is null) return;
            var peDto = (ProvinciaEstadoListDto)r.Tag;

            var pe = _servicio!.GetProvinciaEstadoPorId(peDto.ProvinciaEstadoId); ;
            if (pe is null) return;
            frmProvinciasEstadosAE frm = new frmProvinciasEstadosAE(_serviceProvider) { Text = "Editar Prov/Estado" };
            frm.SetProvEstado(pe);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            try
            {
                pe = frm.GetProvEstado();
                if (pe is null) return;
                if (!_servicio!.Existe(pe))
                {
                    _servicio!.Guardar(pe);
                    currentPage = _servicio!.GetPaginaPorRegistro(pe.NombreProvinciaEstado, pageSize);
                    LoadData();
                    int row = GridHelper.ObtenerRowIndex(dgvDatos, pe.ProvinciaEstadoId);
                    GridHelper.MarcarRow(dgvDatos, row);

                    MessageBox.Show("Registro modificado",
                        "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Registro existente!!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbFiltrar_Click(object sender, EventArgs e)
        {
            frmFormularioFiltro frm = new frmFormularioFiltro(_serviceProvider, filtroContexto) { Text = "Seleccionar Pais para Filtrar" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            paisFiltro = frm.GetPais();
            if (paisFiltro is null) return;

            //lista = _servicio!?.GetLista(currentPage, pageSize, orden, paisFiltro);
            totalRecords = _servicio!?.GetCantidad(paisFiltro) ?? 0;
            totalPages = (int)Math.Ceiling((decimal)totalRecords / pageSize);

            LoadData();
            filterOn = true;
            tsbFiltrar.Enabled = false;

        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            paisFiltro = null;
            //lista = _servicio!?.GetLista(currentPage, pageSize, orden);
            totalRecords = _servicio!?.GetCantidad() ?? 0;
            totalPages = (int)Math.Ceiling((decimal)totalRecords / pageSize);

            LoadData();
            filterOn = false;
            tsbFiltrar.Enabled = true;

        }


        private void aZPorPaísToolStripMenuItem_Click(object sender, EventArgs e)
        {
            orden = Orden.PaisAZ;
            LoadData();

        }

        private void zAPorEstadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            orden = Orden.ProvinciaEstadoZA;
            LoadData();
        }

        private void aZPorEstadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            orden = Orden.ProvinciaEstadoAZ;
            LoadData();
        }

        private void zAPorPaísToolStripMenuItem_Click(object sender, EventArgs e)
        {
            orden = Orden.PaisZA;
            LoadData();
        }
    }
}
