using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto1.Clases
{
    public class Cliente
    {
        public string nit;
        public string nombres;
        public string apellidos;
        public string fecha;
        public string direccion;
        public string telefono;
        public string celular;
        public string email;
        public int ciudad;
        public int departamento;
        public double limite;
        public int dias;
        public int lista;

        public Cliente() 
        {
        }

        public Cliente(string nit, string nombres, string apellidos, string fecha, string direccion,
                        string telefono, string celular, string email, int ciudad, int departamento, double limite, int dias) 
        {
            this.nit = nit;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.fecha = fecha;
            this.direccion = direccion;
            this.telefono = telefono;
            this.celular = celular;
            this.email = email;
            this.ciudad = ciudad;
            this.departamento = departamento;
            this.limite = limite;
            this.dias = dias;
        }

        public string GetNit() 
        {
            return nit;
        }
        public string GetNom()
        {
            return nombres;
        }
        public string GetAp()
        {
            return apellidos;
        }
        public string GetNac()
        {
            return fecha;
        }
        public string Getdir()
        {
            return direccion;
        }
        public string GetTel()
        {
            return telefono;
        }
        public string GetCel()
        {
            return celular;
        }
        public string GetEmail()
        {
            return email;
        }
        public int GetCi()
        {
            return ciudad;
        }
        public int GetDep()
        {
            return departamento;
        }
        public double GetLim()
        {
            return limite;
        }
        public int GetDias()
        {
            return dias;
        }
        public void SetNit(string nit) 
        {
            this.nit = nit;
        }
    }
}