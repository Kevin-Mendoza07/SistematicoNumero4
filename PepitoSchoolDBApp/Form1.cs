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
    public partial class Form1 : Form
    {
        private IEstudianteService estudianteService;
        public Form1(IEstudianteService estudianteService)
        {
            this.estudianteService= estudianteService;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            lblPromedio.Visible = false;
            dataGridView1.MultiSelect = false;
        }
        private void LoadDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = estudianteService.GetAll();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }
            Estudiante estudiante = new Estudiante()
            {
                Nombres=txtNombres.Text,
                Apellidos=txtApellidos.Text,
                Carnet=txtCarnet.Text,
                Correo=txtCorreo.Text,
                Direccion=txtDireccion.Text,
                Phone=txtPhone.Text,
                Estadistica=(int)nudEstadistica.Value,
                Programacion=(int)nudProgramacion.Value,
                Contabilidad=(int)nudEstadistica.Value,
                Matematica=(int)nudMatematica.Value           
            };
            estudianteService.Create(estudiante);
            LoadDataGridView();
            ClearData();

        }
        private bool ValidarCampos()
        {
            if(string.IsNullOrWhiteSpace(txtApellidos.Text)|| string.IsNullOrWhiteSpace(txtCarnet.Text)||
                string.IsNullOrWhiteSpace(txtNombres.Text)|| string.IsNullOrWhiteSpace(txtCorreo.Text)||
                string.IsNullOrWhiteSpace(txtPhone.Text)|| string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("Debe rellenar todos los campos","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected) == 0)
            {
                MessageBox.Show("Error, seleccione");
                return;
            }
            int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
            FrmActualizar frmActualizar = new FrmActualizar();
            frmActualizar.estudianteService = estudianteService;
            Estudiante estudiante = estudianteService.FindById(id);
            frmActualizar.id = id;

            frmActualizar.txtNombres.Text = estudiante.Nombres;
            frmActualizar.txtApellidos.Text = estudiante.Apellidos;
            frmActualizar.txtCarnet.Text = estudiante.Carnet;
            frmActualizar.txtPhone.Text = estudiante.Phone;
            frmActualizar.txtCorreo.Text=estudiante.Correo;
            frmActualizar.txtDireccion.Text=estudiante.Direccion;
            frmActualizar.nudContabilidad.Value=estudiante.Contabilidad;
            frmActualizar.nudEstadistica.Value = estudiante.Estadistica;
            frmActualizar.nudMatematica.Value = estudiante.Matematica;
            frmActualizar.nudProgramacion.Value = estudiante.Programacion;

            frmActualizar.ShowDialog();
            LoadDataGridView();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected) == 0)
            {
                MessageBox.Show("Error, seleccione");
                return;
            }
            int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
            Estudiante estudiante=estudianteService.FindById(id);
            estudianteService.Delete(estudiante);
            LoadDataGridView();

        }

        private void btnCalcularPromedio_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected) == 0)
            {
                MessageBox.Show("Error, seleccione");
                return;
            }
            int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
            Estudiante estudiante = estudianteService.FindById(id);
            decimal PromedioTotal=estudianteService.CalculoPromedio(estudiante);
            
            lblPromedio.Visible = true;
            lblPromedio.Text = $"El promedio de el estudiante {estudiante.Nombres} es de: {PromedioTotal}";

        }

        private void ClearData()
        {
            txtNombres.Text = String.Empty;
            txtDireccion.Text = String.Empty;
            txtPhone.Text = String.Empty;
            txtApellidos.Text=String.Empty;
            txtCarnet.Text=String.Empty;
            txtCorreo.Text=String.Empty;
            nudContabilidad.Value = 0;
            nudEstadistica.Value = 0;
            nudMatematica.Value = 0;
            nudProgramacion.Value = 0;
        }
    }
}
