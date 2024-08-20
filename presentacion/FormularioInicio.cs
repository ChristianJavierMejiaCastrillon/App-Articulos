using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace presentacion
{
    public partial class FormularioInicio : Form
    {
        public FormularioInicio()
        {
            InitializeComponent();
        }

        private void FormularioInicio_Load(object sender, EventArgs e)
        {
            labelBienvenida.Text = "BIENVENIDO A LA APLICACION:";
            labelCliente.Text = "INGRESAR COMO CLIENTE:";
            labelCliente1.Text = "Podra realizar busquedas por Codigo, Nombre, Marca y Categoria del Articulo.";
            labelAdministrador.Text = "INGRESAR COMO ADMINISTRADOR:";
            labelAdministrador2.Text = "Podra realizar busquedas, tambien podra Agregar, Modificar y Eliminar articulos.";
        }

        private void buttonCliente_Click(object sender, EventArgs e)
        {
            FormularioArticulos formularioArticulos = new FormularioArticulos(false);
            formularioArticulos.ShowDialog();
        }

        private void buttonAdministrador_Click(object sender, EventArgs e)
        {
            FormularioArticulos formularioArticulos = new FormularioArticulos(true);
            formularioArticulos.ShowDialog();
        }

        private void buttonSalirInicio_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
