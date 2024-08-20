using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace acceso
{
    public class AccesoMarcas
    {
        public List<Marca> listar()
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("Select Id, Descripcion From Marcas");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Marca auxiliar = new Marca();
                    auxiliar.IdMarca = (int)accesoDatos.Lector["Id"];
                    auxiliar.Descripcion = (string)accesoDatos.Lector["Descripcion"];

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

        public List<Marca> listarPorCategoria(int idCategoria)
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta(@"
            SELECT DISTINCT M.Id, M.Descripcion 
            FROM Marcas M 
            INNER JOIN Articulos A ON M.Id = A.IdMarca 
            WHERE A.IdCategoria = @idCategoria");

                accesoDatos.setearParametro("@idCategoria", idCategoria);
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Marca auxiliar = new Marca();
                    auxiliar.IdMarca = (int)accesoDatos.Lector["Id"];
                    auxiliar.Descripcion = (string)accesoDatos.Lector["Descripcion"];
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
        public void agregar(Marca nuevaMarca)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO Marcas (Descripcion) VALUES (@Descripcion)");
                accesoDatos.setearParametro("@Descripcion", nuevaMarca.Descripcion);
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
    }
}
