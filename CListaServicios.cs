using System;
using System.Collections;
using System.Collections.Generic;
using Hospital;

namespace Hospital
{
    public class ListaServicios
    {
        private ArrayList listaServicios;

        public ListaServicios()
        {
            listaServicios = new ArrayList();
        }

        public void AgregarServicio(ServiciosMedicos nuevoServicio)
        {
            listaServicios.Add(nuevoServicio);
        }

        public UInt32 BuscarCodigo(UInt32 codigo)
        {
            int cont = 0;
            foreach (ServiciosMedicos aux in listaServicios)
            {
                if (aux != null)
                {
                    cont++;
                    if (aux.GetCodigo() == codigo)
                    {
                        return 0;
                    }
                }
            }
            if (cont >= 0) return 1;
            else return 0;
        }

        public ServiciosMedicos ObtenerServicio(UInt32 codigo)
        {
            foreach (ServiciosMedicos aux in listaServicios)
            {
                if (aux != null)
                {
                    if (aux.GetCodigo() == codigo)
                    {
                        return aux;
                    }
                }
            }
            return new ServiciosMedicos();
        }

        public string MostrarTrabajos(PersonalApoyo aux)
        {
            string datos = "";
            foreach (ServiciosMedicos auxiliar in listaServicios)
            {
                datos +=  auxiliar.MostrarEmpleado(aux);
            }
            return datos;
        }

        public string MostrarTrabajos(PersonalSanidad aux)
        {
            string datos = "";
            foreach (ServiciosMedicos auxiliar in listaServicios)
            {
                datos +=  auxiliar.MostrarEmpleado(aux);
            }
            return datos;
        }

        public void EmpleadosServicios()
        {
            foreach(ServiciosMedicos servicio in listaServicios)
            {
                Console.WriteLine($"\nServicio: {servicio.GetNombre()} - Cantidad empleados de sanidad: {servicio.CantEmpleadosSanidad()} - Cantidad empleados de apoyo: {servicio.CantEmpleadosApoyo()} - Sueldos totales: {servicio.SueldosEmpleados()}\n");
            }
        }
    }

}