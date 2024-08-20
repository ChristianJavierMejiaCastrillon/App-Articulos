using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;

namespace acceso
{
    public class AccesoArticulos
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos accesoDatos = new AccesoDatos();
            
            try
            {
                accesoDatos.setearConsulta("SELECT A.Codigo, A.Nombre, A.Descripcion, A.ImagenUrl, M.Descripcion AS Marca, C.Descripcion AS Categoria, A.Id, A.IdMarca, A.IdCategoria, A.Precio " +
                                    "FROM ARTICULOS A " +
                                    "INNER JOIN Marcas M ON A.IdMarca = M.Id " +
                                    "INNER JOIN Categorias C ON A.IdCategoria = C.Id");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Articulo auxiliar = new Articulo();
                    auxiliar.Id = (int)accesoDatos.Lector["Id"];
                    auxiliar.Codigo = accesoDatos.Lector["Codigo"] != DBNull.Value ? (string)accesoDatos.Lector["Codigo"] : "Sin código";
                    auxiliar.Nombre = accesoDatos.Lector["Nombre"] != DBNull.Value ? (string)accesoDatos.Lector["Nombre"] : "Sin nombre";
                    auxiliar.Descripcion = accesoDatos.Lector["Descripcion"] != DBNull.Value ? (string)accesoDatos.Lector["Descripcion"] : "Sin descripción";
                    auxiliar.Precio = accesoDatos.Lector["Precio"] != DBNull.Value ? (decimal)accesoDatos.Lector["Precio"] : 0;

                    auxiliar.Imagen = accesoDatos.Lector["ImagenUrl"] != DBNull.Value ? (string)accesoDatos.Lector["ImagenUrl"] : "https://img.freepik.com/premium-vector/modern-flat-icon-landscape_203633-11062.jpg";

                    auxiliar.marca = new Marca();
                    auxiliar.marca.IdMarca = (int)accesoDatos.Lector["IdMarca"];
                    auxiliar.marca.Descripcion = accesoDatos.Lector["Marca"] != DBNull.Value ? (string)accesoDatos.Lector["Marca"] : "Sin marca";

                    auxiliar.categoria = new Categoria();
                    auxiliar.categoria.IdCategoria = (int)accesoDatos.Lector["IdCategoria"];
                    auxiliar.categoria.Descripcion = accesoDatos.Lector["Categoria"] != DBNull.Value ? (string)accesoDatos.Lector["Categoria"] : "Sin categoría";

                    lista.Add(auxiliar);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }
        public void agregar(Articulo nuevo)
        { 
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                // Usa parámetros SQL en la consulta
                accesoDatos.setearConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) VALUES (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @ImagenUrl, @Precio)");

                // Configura los parámetros correctamente
                accesoDatos.setearParametro("@Codigo", nuevo.Codigo);
                accesoDatos.setearParametro("@Nombre", nuevo.Nombre);
                accesoDatos.setearParametro("@Descripcion", nuevo.Descripcion);
                accesoDatos.setearParametro("@IdMarca", nuevo.marca.IdMarca);
                accesoDatos.setearParametro("@IdCategoria", nuevo.categoria.IdCategoria);
                accesoDatos.setearParametro("@ImagenUrl", nuevo.Imagen);
                accesoDatos.setearParametro("@Precio", nuevo.Precio);
                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }
    
        public void modificar (Articulo modificar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idmarca, IdCategoria = @idcategoria, ImagenUrl = @imagen, Precio = @precio where Id = @id");
                datos.setearParametro("@codigo", modificar.Codigo);
                datos.setearParametro("@nombre", modificar.Nombre);
                datos.setearParametro("@descripcion", modificar.Descripcion);
                datos.setearParametro("@idmarca", modificar.marca.IdMarca);
                datos.setearParametro("@idcategoria", modificar.categoria.IdCategoria);
                datos.setearParametro("@imagen", modificar.Imagen);
                // Depuración: Imprimir el valor del precio antes de guardarlo
                Console.WriteLine($"Precio antes de guardar: {modificar.Precio}");

                // Asigna el valor del precio al parámetro SQL
                datos.setearParametro("@precio", modificar.Precio);

                // Asigna el valor del Id al parámetro SQL
                datos.setearParametro("@id", modificar.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void eliminar (int id)
        {
            try
            {
                AccesoDatos accesoDatos = new AccesoDatos();
                accesoDatos.setearConsulta("delete from ARTICULOS where id = @id");
                accesoDatos.setearParametro("@id", id);
                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int ObtenerIdMarcaPorDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
            {
                throw new ArgumentException("La descripción de la marca no puede estar vacía.");
            }

            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearConsulta("SELECT Id FROM Marcas WHERE Descripcion = @Descripcion");
                accesoDatos.setearParametro("@Descripcion", descripcion);
                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.Read())
                {
                    return (int)accesoDatos.Lector["Id"];
                }
                else
                {
                    throw new Exception("Marca no encontrada.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public int ObtenerIdCategoriaPorDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
            {
                throw new ArgumentException("La descripción de la categoría no puede estar vacía.");
            }

            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearConsulta("SELECT Id FROM Categorias WHERE Descripcion = @Descripcion");
                accesoDatos.setearParametro("@Descripcion", descripcion);
                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.Read())
                {
                    return (int)accesoDatos.Lector["Id"];
                }
                else
                {
                    throw new Exception("Categoría no encontrada.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }
        public List<Articulo> filtrarPorCategoriaYMarca(int idCategoria, int idMarca)
        {
            // Crea una nueva lista vacía para almacenar los artículos resultantes
            List<Articulo> lista = new List<Articulo>();
            // Crea una instancia de AccesoDatos para manejar la conexión y las consultas a la base de datos
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                // Define la consulta SQL para obtener los artículos que coincidan con la categoría y marca especificadas
                accesoDatos.setearConsulta("SELECT A.Codigo, A.Nombre, A.Descripcion, A.ImagenUrl, M.Descripcion AS Marca, C.Descripcion AS Categoria, A.Id, A.IdMarca, A.IdCategoria, A.Precio " +
                                   "FROM ARTICULOS A " +
                                   "INNER JOIN Marcas M ON A.IdMarca = M.Id " +
                                   "INNER JOIN Categorias C ON A.IdCategoria = C.Id " +
                                   "WHERE A.IdCategoria = @idCategoria AND A.IdMarca = @idMarca");

                // Establece los parámetros de la consulta SQL para evitar inyecciones SQL
                accesoDatos.setearParametro("@idCategoria", idCategoria);
                accesoDatos.setearParametro("@idMarca", idMarca);
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    // Crea un nuevo objeto Articulo para cada fila del resultado
                    Articulo auxiliar = new Articulo();

                    // Asigna valores a las propiedades del objeto Articulo, manejando posibles valores nulos en la base de datos
                    auxiliar.Id = (int)accesoDatos.Lector["Id"];
                    auxiliar.Codigo = accesoDatos.Lector["Codigo"] != DBNull.Value ? (string)accesoDatos.Lector["Codigo"] : "Sin código";
                    auxiliar.Nombre = accesoDatos.Lector["Nombre"] != DBNull.Value ? (string)accesoDatos.Lector["Nombre"] : "Sin nombre";
                    auxiliar.Descripcion = accesoDatos.Lector["Descripcion"] != DBNull.Value ? (string)accesoDatos.Lector["Descripcion"] : "Sin descripción";
                    auxiliar.Precio = accesoDatos.Lector["Precio"] != DBNull.Value ? (decimal)accesoDatos.Lector["Precio"] : 0;

                    // Si la URL de la imagen es nula, se asigna una imagen predeterminada
                    auxiliar.Imagen = accesoDatos.Lector["ImagenUrl"] != DBNull.Value ? (string)accesoDatos.Lector["ImagenUrl"] : "https://img.freepik.com/premium-vector/modern-flat-icon-landscape_203633-11062.jpg";

                    // Maneja los datos de la marca
                    auxiliar.marca = new Marca();
                    auxiliar.marca.IdMarca = (int)accesoDatos.Lector["IdMarca"];
                    auxiliar.marca.Descripcion = accesoDatos.Lector["Marca"] != DBNull.Value ? (string)accesoDatos.Lector["Marca"] : "Sin marca";

                    // Maneja los datos de la categoría
                    auxiliar.categoria = new Categoria();
                    auxiliar.categoria.IdCategoria = (int)accesoDatos.Lector["IdCategoria"];
                    auxiliar.categoria.Descripcion = accesoDatos.Lector["Categoria"] != DBNull.Value ? (string)accesoDatos.Lector["Categoria"] : "Sin categoría";

                    // Agrega el objeto Articulo a la lista
                    lista.Add(auxiliar);
                }
                // Retorna la lista completa de artículos filtrados
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }
    }
}
