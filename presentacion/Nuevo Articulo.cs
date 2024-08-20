using acceso;
using dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Configuration;
using System.Globalization;

namespace presentacion
{
    public partial class Nuevo_Articulo : Form
    {
        private Articulo articulo = null;
        private OpenFileDialog archivo = null;
        private FormularioArticulos formularioArticulos;
        public Nuevo_Articulo(FormularioArticulos formulario)
        {
            InitializeComponent();
            formularioArticulos = formulario;
            Text = "Nuevo Articulo";

            textBoxImagenUrl2.Text = "Ingresa la Url...";
            textBoxImagenUrl2.ForeColor = Color.Black;
        }
        public Nuevo_Articulo(FormularioArticulos formulario, Articulo articulo)
        {
            InitializeComponent();
            formularioArticulos = formulario;
            this.articulo = articulo;
            Text = "Modificar Articulo";

            textBoxImagenUrl2.Text = "Ingresa la Url...";
            textBoxImagenUrl2.ForeColor = Color.Black;

        }
        private void buttonCancelarNuevoArticulo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonAceptarNuevoArticulo_Click(object sender, EventArgs e)
        {
            // Primero, elimina cualquier espacio en blanco en el campo de la URL de la imagen
            textBoxImagenUrl2.Text = textBoxImagenUrl2.Text.Trim();

            // Luego, realiza la validación
            if (!validarCampos())
            {
                // Si la validación falla, detener la ejecución
                return;
            }
            AccesoArticulos accesoArticulos = new AccesoArticulos();
            try
            {
                if(articulo == null)
                    articulo = new Articulo();

                articulo.Codigo = textBoxCodigo2.Text;
                articulo.Nombre = textBoxNombre2.Text;
                articulo.Descripcion = textBoxDescripcion2.Text;
                // Se asigna IdMarca e IdCategoria en lugar de solo la descripción
                articulo.marca = new Marca { IdMarca =accesoArticulos.ObtenerIdMarcaPorDescripcion(comboBoxMarca2.Text) }; // se invoca ObtenerIdMarcaPorDescripcion
                articulo.categoria = new Categoria { IdCategoria =accesoArticulos.ObtenerIdCategoriaPorDescripcion(comboBoxCategoria2.Text) }; // se invoca ObtenerIdCategoriaPorDescripcion


                // Formatear correctamente el valor del precio antes de guardarlo
                if (decimal.TryParse(textBoxPrecio2.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal precio))
                {
                    textBoxPrecio2.Text = precio.ToString("F2", CultureInfo.InvariantCulture);

                    // Limpiar ceros y puntos adicionales
                    textBoxPrecio2.Text = textBoxPrecio2.Text.TrimEnd('0').TrimEnd('.');

                    articulo.Precio = precio;  // Asignar el precio al objeto artículo
                }
                else
                {
                    MessageBox.Show("Por favor, ingresa un valor numérico válido para el precio.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //guardo la imagen si la levanto localmente:
                if (archivo != null && !(textBoxImagenUrl2.Text.ToLower().Contains("http")))
                {
                    string rutaDestino = Path.Combine(ConfigurationManager.AppSettings["Imagenes"], archivo.SafeFileName);
                    File.Copy(archivo.FileName, rutaDestino);
                    articulo.Imagen = rutaDestino;  // Guarda la ruta local en ImagenUrl
                }
                else
                {
                    articulo.Imagen = textBoxImagenUrl2.Text;
                }

                if (articulo.Id != 0)
                {
                    accesoArticulos.modificar(articulo);
                    MessageBox.Show("Modificado Exitosamente");
                }
                else
                {
                    accesoArticulos.agregar(articulo);
                    MessageBox.Show("Agregado Exitosamente");
                }
                // Llama a un método en FormularioArticulos para actualizar la lista
                formularioArticulos.cargar();

                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Por favor diligencie todos los campos...","Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void buttonImagenLocal_Click(object sender, EventArgs e)
        {
            OpenFileDialog  archivo = new OpenFileDialog();
            archivo.Filter = "jpg|*.jpg; |png|*.png";
            if (archivo.ShowDialog() == DialogResult.OK)
            {
                textBoxImagenUrl2.Text = archivo.FileName;
                cargarImagen(archivo.FileName);
            }
        }
        private void cargarImagen(string imagen)
        {
            try
            {
                pictureBoxNuevo.Load(imagen);
            }
            catch (Exception)
            {

                pictureBoxNuevo.Load("https://img.freepik.com/premium-vector/modern-flat-icon-landscape_203633-11062.jpg");
                MessageBox.Show("No se pudo cargar la imagen. Por favor verifica la URL o la ruta de la imagen.", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Nuevo_Articulo_Load(object sender, EventArgs e)
        {
            try
            {
                // Cargar todas las categorías
                AccesoCategorias accesoCategorias = new AccesoCategorias();
                List<Categoria> categorias = accesoCategorias.listar();
                comboBoxCategoria2.DataSource = categorias;
                comboBoxCategoria2.DisplayMember = "Descripcion";
                comboBoxCategoria2.ValueMember = "IdCategoria";

                // Cargar todas las marcas
                AccesoMarcas accesoMarcas = new AccesoMarcas();
                List<Marca> marcas = accesoMarcas.listar();
                comboBoxMarca2.DataSource = marcas;
                comboBoxMarca2.DisplayMember = "Descripcion";
                comboBoxMarca2.ValueMember = "IdMarca";

                if (articulo != null)
                {
                    // Si se está modificando un artículo existente, selecciona las categorías y marcas correctas
                    comboBoxCategoria2.SelectedValue = articulo.categoria.IdCategoria;
                    comboBoxMarca2.SelectedValue = articulo.marca.IdMarca;
                    textBoxCodigo2.Text = articulo.Codigo;
                    textBoxNombre2.Text = articulo.Nombre;
                    textBoxDescripcion2.Text = articulo.Descripcion;
                    textBoxPrecio2.Text = articulo.Precio.ToString();
                    textBoxImagenUrl2.Text = articulo.Imagen;
                    cargarImagen(articulo.Imagen);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void comboBoxMarca2_DropDown(object sender, EventArgs e)
        {
            AccesoMarcas accesoMarcas = new AccesoMarcas();

            // Obtener la categoría seleccionada como objeto Categoria
            Categoria categoriaSeleccionada = comboBoxCategoria2.SelectedItem as Categoria;

            if (categoriaSeleccionada != null)
            {
                comboBoxMarca2.DataSource = accesoMarcas.listar(); // Asigna la fuente de datos real
                comboBoxMarca2.ValueMember = "IdMarca";
                comboBoxMarca2.DisplayMember = "Descripcion";
            }
        }

        private void comboBoxCategoria2_DropDown(object sender, EventArgs e)
        {
            AccesoCategorias accesoCategorias = new AccesoCategorias();
            if (comboBoxCategoria2.SelectedIndex == 0 && comboBoxCategoria2.Items[0].ToString() == "Selecciona una categoria...")
            {
                comboBoxCategoria2.Items.Clear();
                comboBoxCategoria2.DataSource = accesoCategorias.listar(); // Asigna la fuente de datos real
                comboBoxCategoria2.ValueMember = "IdCategoria";
                comboBoxCategoria2.DisplayMember = "Descripcion";
            }
        }
        private void textBoxImagenUrl2_Leave(object sender, EventArgs e)
        {
            cargarImagen(textBoxImagenUrl2.Text);
        }
        private bool validarCampos()
        {
            // Verificar que todos los campos obligatorios estén diligenciados
            if (string.IsNullOrWhiteSpace(textBoxCodigo2.Text))
            {
                MessageBox.Show("El campo 'Código' es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxNombre2.Text))
            {
                MessageBox.Show("El campo 'Nombre' es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxDescripcion2.Text))
            {
                MessageBox.Show("El campo 'Descripción' es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (comboBoxMarca2.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar una 'Marca'.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (comboBoxCategoria2.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar una 'Categoría'.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxPrecio2.Text) || !decimal.TryParse(textBoxPrecio2.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("El campo 'Precio' debe contener un valor numérico mayor a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Verificar si la imagen es una URL remota o una ruta local
            if (Uri.IsWellFormedUriString(textBoxImagenUrl2.Text, UriKind.Absolute))
            {
                // Aquí podrías hacer una validación adicional para comprobar si la URL remota es accesible
                try
                {
                    var request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(textBoxImagenUrl2.Text);
                    request.Method = "HEAD";
                    using (var response = (System.Net.HttpWebResponse)request.GetResponse())
                    {
                        if (response.StatusCode != System.Net.HttpStatusCode.OK)
                        {
                            throw new Exception();
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Debe proporcionar una URL de imagen válida o una ruta local existente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else if (!File.Exists(textBoxImagenUrl2.Text))
            {
                MessageBox.Show("Debe proporcionar una URL de imagen válida o una ruta local existente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Si todas las validaciones pasan, retornar true
            return true;
        }

        private void buttonAgregarMarca_Click(object sender, EventArgs e)
        {
            AgregarMarca agregarMarcaForm = new AgregarMarca();
            if (agregarMarcaForm.ShowDialog() == DialogResult.OK)
            {
                // Agregar la nueva marca a la base de datos
                AccesoMarcas accesoMarcas = new AccesoMarcas();
                Marca nuevaMarca = new Marca { Descripcion = agregarMarcaForm.NuevaMarca };
                accesoMarcas.agregar(nuevaMarca); // Implementa el método agregar en AccesoMarcas

                // Actualizar el ComboBox de marcas
                comboBoxMarca2.DataSource = accesoMarcas.listar();
            }
        }

        private void buttonAgregarCategoria_Click(object sender, EventArgs e)
        {
            AgregarCategoria agregarCategoriaForm = new AgregarCategoria();
            if (agregarCategoriaForm.ShowDialog() == DialogResult.OK)
            {
                // Agregar la nueva categoría a la base de datos
                AccesoCategorias accesoCategorias = new AccesoCategorias();
                Categoria nuevaCategoria = new Categoria { Descripcion = agregarCategoriaForm.NuevaCategoria };
                accesoCategorias.agregar(nuevaCategoria); // Implementa el método agregar en AccesoCategorias

                // Actualizar el ComboBox de categorías
                comboBoxCategoria2.DataSource = accesoCategorias.listar();
            }
        }

        private void textBoxPrecio2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el carácter es un número o el separador decimal adecuado
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.' && e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // Permitir solo un separador decimal
            if ((e.KeyChar == '.' || e.KeyChar == ',') && (sender as TextBox).Text.Contains(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxPrecio2_Enter(object sender, EventArgs e)
        {
            textBoxPrecio2.Text = string.Empty;
        }

        private void textBoxImagenUrl2_Enter(object sender, EventArgs e)
        {
            textBoxImagenUrl2.Text = string.Empty;
        }
    }
}
