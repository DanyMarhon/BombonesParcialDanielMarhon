using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.Servicios.Intefaces;
using Bombones.Windows.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Bombones.Windows.Formularios
{
    public partial class frmBombones : Form
    {
        private List<BombonListDto> lista = null!;
        private readonly IServiciosBombones? _servicio;
        public frmBombones(IServiceProvider? serviceProvider)
        {
            InitializeComponent();
            _servicio = serviceProvider?.GetService<IServiciosBombones>()
                ?? throw new ApplicationException("Dependencias no cargadas!!!"); ;
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        

        

        private void frmBombones_Load(object sender, EventArgs e)
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




    }
}
