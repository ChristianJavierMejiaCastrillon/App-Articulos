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
    public partial class AgregarCategoria : Form
    {
        public string NuevaCategoria { get; private set; }
        public AgregarCategoria()
        {
            InitializeComponent();
        }

        private void buttonAceptarCategoria_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxAgregarCategoria.Text))
            {
                MessageBox.Show("Por favor, ingrese un nombre de categoría antes de aceptar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NuevaCategoria = textBoxAgregarCategoria.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancelarCategoria_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
