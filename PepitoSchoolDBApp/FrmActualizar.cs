using PepitoSchoolDBApp.Applications.Interfaces;
using PepitoSchoolDBApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PepitoSchoolDBApp
{
    public partial class FrmActualizar : Form
    {
        public IEstudianteService estudianteService { get; set; }
        public int id;
        public FrmActualizar()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Estudiante estudiante = new Estudiante()
            {
                Id = id,
                Nombres = txtNombres.Text,
                Apellidos = txtApellidos.Text,
                Carnet = txtCarnet.Text,
                Correo = txtCorreo.Text,
                Direccion = txtDireccion.Text,
                Phone = txtPhone.Text,
                Estadistica = (int)nudEstadistica.Value,
                Programacion = (int)nudProgramacion.Value,
                Contabilidad = (int)nudEstadistica.Value,
                Matematica = (int)nudMatematica.Value
            };
            estudianteService.Update(estudiante);
            Dispose();
        }
    }
}
