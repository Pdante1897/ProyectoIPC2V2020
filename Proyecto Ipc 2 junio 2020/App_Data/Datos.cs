using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto1
{
    public class Datos
    {
        public string empleado;

        public Datos() 
        {
        }
        public void SetEmpleado(string empleado) 
        {
            this.empleado = empleado;
        }
        public string GetEmpleado() 
        {
            return empleado;
        }
    }
}