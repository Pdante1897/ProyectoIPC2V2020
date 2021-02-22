using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto1.Clases
{
    public class Orden
    {
        public int codigo;
        public string empleado;
        public int formapago;
        public List<Producto> productos;
        public double total;
        public Cliente cliente;
    }
}