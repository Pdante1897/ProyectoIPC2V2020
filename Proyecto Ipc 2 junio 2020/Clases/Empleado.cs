using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto1.Clases
{
    public class Empleado
    {
        public string nit;
        public string nombres;
        public string apellidos;
        public string fecha;
        public string direccion;
        public string telefono;
        public string celular;
        public string email;
        public int puesto;
        public string pass;
        public string nitJefe;

        public Empleado() 
        {
        }
        public Empleado(string nit, string nombres, string apellidos, string fecha, string direccion,
                        string telefono, string celular, string email, int puesto, string pass, string nitJefe)
        {
            this.nit = nit;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.fecha = fecha;
            this.direccion = direccion;
            this.telefono = telefono;
            this.celular = celular;
            this.email = email;
            this.puesto = puesto;
            this.pass = pass;
            this.nitJefe = nitJefe;
        }
    }
}