using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using acceso;
using System.Globalization;

namespace presentacion
{
    public partial class FormularioArticulos : Form
    {
        private List<Articulo> listaArticulos;
        public FormularioArticulos(bool esAdministrador)
        {
            InitializeComponent();
            if (!esAdministrador)
            {
                buttonAgregar.Visible = false;
                buttonModificar.Visible = false;
                buttonEliminar.Visible = false;
            }
        }
        private void FormularioArticulos_Load(object sender, EventArgs e)
        {
            cargar();

            AccesoCategorias accesoCategorias = new AccesoCategorias();
            List<Categoria> categorias = accesoCategorias.listar();

            comboBoxCategoria.DataSource = categorias;
            comboBoxCategoria.DisplayMember = "Descripcion";  // El nombre que se mostrará en el ComboBox
            comboBoxCategoria.ValueMember = "IdCategoria";    // El valor asociado (IdCategoria)

            
        }
        public void cargar()
        {
            AccesoArticulos acceso = new AccesoArticulos();
            try
            {
                listaArticulos = acceso.listar();
                dataGridViewArticulos.DataSource = listaArticulos;
                ocultarColumnas();

                // Formatear la columna Precio en el DataGridView para mostrar siempre dos decimales
                dataGridViewArticulos.Columns["Precio"].DefaultCellStyle.Format = "F2";

                // Si cargar la primera imagen de la tabla al ejecutar:
                if (listaArticulos.Count > 0)
                {
                    cargarImagen(listaArticulos[0].Imagen);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void cargarImagen(string imagen)
        {
            try
            {
                if (!string.IsNullOrEmpty(imagen))
                {
                    pictureBoxArticulos.Load(imagen);
                }
                else
                {
                    throw new Exception("La URL de la imagen está vacía.");
                }
            }
            catch (Exception)
            {
                // Cargar una imagen predeterminada si no se puede cargar la imagen desde la URL proporcionada
                pictureBoxArticulos.Load("https://img.freepik.com/premium-vector/modern-flat-icon-landscape_203633-11062.jpg");
            }
        }
        private void ocultarColumnas()
        {
            dataGridViewArticulos.Columns["Imagen"].Visible = false;
            dataGridViewArticulos.Columns["Id"].Visible = false;
        }
        private void dataGridViewArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewArticulos.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dataGridViewArticulos.CurrentRow.DataBoundItem;
                cargarImagen(seleccionado.Imagen);
            }
        }

        private void dataGridViewArticulos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Verifica si la columna "Precio" existe
            if (dataGridViewArticulos.Columns["Precio"] != null)
            {
                // Obtén la columna "Precio"
                var precioColumn = dataGridViewArticulos.Columns["Precio"];

                // Mueve la columna a la última posición
                precioColumn.DisplayIndex = dataGridViewArticulos.Columns.Count - 1;
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            Nuevo_Articulo nuevo = new Nuevo_Articulo(this);
            nuevo.ShowDialog();
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {// Verificar si hay una fila seleccionada
            if (dataGridViewArticulos.CurrentRow != null)
            {
                // Obtener el artículo seleccionado
                Articulo seleccionado = (Articulo)dataGridViewArticulos.CurrentRow.DataBoundItem;

                // Crear una instancia del formulario de modificación y pasarle el artículo seleccionado
                Nuevo_Articulo modificar = new Nuevo_Articulo(this,seleccionado);
                modificar.ShowDialog();

                // Recargar los datos después de la modificación
                cargar();
            }
            else
            {
                // Mostrar un mensaje si no hay ninguna fila seleccionada
                MessageBox.Show("Por favor, seleccione un artículo para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            eliminarArticulo();
        }

        private void eliminarArticulo(bool logico = false)
        {
            AccesoArticulos acceso = new AccesoArticulos();
            Articulo seleccionado;
            try
            {
                DialogResult respuesta = MessageBox.Show("¿Esta seguro que desea eliminarlo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (Articulo)dataGridViewArticulos.CurrentRow.DataBoundItem;

                    acceso.eliminar(seleccionado.Id);
                    cargar();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;
            string filtro = textBoxFiltro.Text;
            if (filtro.Length >= 3)
            {
                listaFiltrada = listaArticulos.FindAll(x => x.Codigo.ToUpper().Contains(filtro.ToUpper()) || x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.marca.Descripcion.ToUpper().Contains(filtro.ToUpper()) || x.categoria.Descripcion.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                listaFiltrada = listaArticulos;
            }
            dataGridViewArticulos.DataSource = null;
            dataGridViewArticulos.DataSource = listaFiltrada;
            ocultarColumnas();
        }

        private void comboBoxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener la categoría seleccionada como objeto Categoria
            Categoria categoriaSeleccionada = (Categoria)comboBoxCategoria.SelectedItem;

            if (categoriaSeleccionada != null)
            {
                AccesoMarcas accesoMarcas = new AccesoMarcas();
                List<Marca> marcas = accesoMarcas.listarPorCategoria(categoriaSeleccionada.IdCategoria);

                comboBoxMarca.DataSource = marcas;
                comboBoxMarca.DisplayMember = "Descripcion";
                comboBoxMarca.ValueMember = "IdMarca";
            }

        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            if (validarFiltro())
                return;

            Categoria categoriaSeleccionada = (Categoria)comboBoxCategoria.SelectedItem;
            Marca marcaSeleccionada = (Marca)comboBoxMarca.SelectedItem;

            AccesoArticulos accesoArticulos = new AccesoArticulos();
            List<Articulo> articulos = accesoArticulos.filtrarPorCategoriaYMarca(categoriaSeleccionada.IdCategoria, marcaSeleccionada.IdMarca);

            dataGridViewArticulos.DataSource = articulos;
            ocultarColumnas();
        }
        private bool validarFiltro()
        {
            if (comboBoxMarca.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor seleccione una Marca para poder realizar la busqueda");
                return true;
            }
            else if (comboBoxCategoria.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor seleccione una Categoria para poder realizar la busqueda");
                return true;
            }
            return false;
        }

        private void dataGridViewArticulos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Obtiene el valor de la celda que causó el error utilizando el índice de fila y columna proporcionado por el evento
            var valorCelda = dataGridViewArticulos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

            // Verifica si el valor de la celda es nulo o vacío
            if (string.IsNullOrEmpty(valorCelda?.ToString()))
            {
                // Si el valor es nulo o vacío, registra un mensaje en la consola informando sobre la celda problemática
                Console.WriteLine($"Celda vacía o nula en columna {e.ColumnIndex} y fila {e.RowIndex}. No se aplicará formato.");
            }
            else
            {
                // Si el valor no es nulo ni vacío, muestra un MessageBox con detalles del error
                MessageBox.Show($"Error en la columna {e.ColumnIndex} con el valor '{valorCelda}'. Detalles: {e.Exception.Message}", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // También imprime en la consola detalles adicionales sobre el valor de la celda y la excepción que ocurrió
                Console.WriteLine($"Valor de la celda problemático: {valorCelda} (Tipo: {valorCelda?.GetType()})");
                Console.WriteLine($"Excepción completa: {e.Exception.ToString()}");
            }
            // Indica que la excepción no debe propagarse más allá de este punto, lo que evita que la aplicación se cierre
            e.ThrowException = false;  // Evita que la excepción se propague
        }

        private void buttonRestablecer_Click(object sender, EventArgs e)
        {
            // Restablecer los ComboBoxes de Categoría y Marca
            comboBoxCategoria.SelectedIndex = -1;  // Des-seleccionar cualquier selección en Categoría
            comboBoxMarca.SelectedIndex = -1;      // Des-seleccionar cualquier selección en Marca

            // Limpiar el filtro de texto
            textBoxFiltro.Text = "";

            // Recargar todos los artículos en el DataGridView
            cargar();
        }

        private void dataGridViewArticulos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verifica si la columna actual que se está formateando es la columna "Precio"
            if (dataGridViewArticulos.Columns[e.ColumnIndex].Name == "Precio" && e.Value != null)
            {
                // Intenta convertir el valor de la celda a un decimal
                if (decimal.TryParse(e.Value.ToString(), out decimal precio))
                {
                    // Si la conversión es exitosa, formatea el valor a dos decimales (F2)
                    // usando la configuración de cultura invariante para garantizar el formato numérico consistente
                    e.Value = precio.ToString("F2", CultureInfo.InvariantCulture);

                    // Indica que la celda ha sido formateada y no necesita más procesamiento
                    e.FormattingApplied = true;
                }
                else
                {
                    // Si la conversión falla (por ejemplo, si el valor no es numérico),
                    // establece un valor predeterminado "0.00" para la celda
                    e.Value = "0.00";

                    // Marca que el formato ha sido aplicado
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
