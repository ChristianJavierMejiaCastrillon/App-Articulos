using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Codigo {  get; set; }
        public string Nombre { get; set; }
        [DisplayName("Descripcíon")]
        public string Descripcion { get; set;}
        public string Imagen { get; set;}
        public decimal Precio { get; set; }
        public Marca marca { get; set; }
        public Categoria categoria { get; set; }

    }
}
