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
    public partial class AgregarMarca : Form
    {
        public string NuevaMarca { get; private set; }
        public AgregarMarca()
        {
            InitializeComponent();
        }

        private void buttonAceptarMarca_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxAgregarMarca.Text))
            {
                MessageBox.Show("Por favor, ingrese un nombre de marca antes de aceptar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NuevaMarca = textBoxAgregarMarca.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancelarMarca_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
