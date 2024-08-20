using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace acceso
{
    public class AccesoCategorias
    {
        public List<Categoria> listar()
        {
            List<Categoria>lista = new List<Categoria>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("Select Id, Descripcion From Categorias");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Categoria auxiliar = new Categoria();
                    auxiliar.IdCategoria = (int)accesoDatos.Lector["Id"];
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
        public void agregar(Categoria nuevaCategoria)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO Categorias (Descripcion) VALUES (@Descripcion)");
                accesoDatos.setearParametro("@Descripcion", nuevaCategoria.Descripcion);
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
