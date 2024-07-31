using Hospital;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class ListaEmpleados
    {
        private ArrayList listaEmpleadosSanidad;
        private ArrayList listaEmpleadosApoyo;

        public ListaEmpleados()
        {
            listaEmpleadosSanidad = new ArrayList();
            listaEmpleadosApoyo = new ArrayList();
        }

        //METODOS

        public void AgregarSanidad(PersonalSanidad nuevoEmpleado) { listaEmpleadosSanidad.Add(nuevoEmpleado); }

        public void AgregarApoyo(PersonalApoyo nuevoEmpleado) { listaEmpleadosApoyo.Add(nuevoEmpleado); }

        public PersonalSanidad BuscarMedico(UInt32 legajo)
        {
            foreach (PersonalSanidad aux in listaEmpleadosSanidad)
            {
                if (aux != null)
                {
                    if (aux.GetLegajo() == legajo && aux.GetCategoriaProfesional().ToLower() == "medico")
                    {
                        return aux;
                    }
                }
            }
            return new PersonalSanidad();
        }

        public PersonalSanidad BuscarPersonalSanidad(UInt32 legajo)
        {
            foreach (PersonalSanidad aux in listaEmpleadosSanidad)
            {
                if (aux != null)
                {
                    if (aux.GetLegajo() == legajo)
                    {
                        return aux;
                    }
                }
            }
            return new PersonalSanidad();
        }

        public PersonalApoyo BuscarPersonalApoyo(UInt32 legajo)
        { 
            foreach (PersonalApoyo empleadoApoyo in listaEmpleadosApoyo)
            {
                if (empleadoApoyo != null)
                {
                    if (empleadoApoyo.GetLegajo() == legajo)
                        return empleadoApoyo;
                }
            }
            return new PersonalApoyo();
        }

        public void CargarSueldos()
        {
            foreach (PersonalApoyo aux in listaEmpleadosApoyo)
            {
                if (aux != null)
                {
                    aux.EstablecerSueldo();
                }
            }

            //Seguramente necesite pasar por parametros los roles de los medicos
            foreach (PersonalSanidad aux in listaEmpleadosSanidad)
            {
                if (aux != null)
                {
                    aux.EstablecerSueldoProfesional();
                }
            }
        }

        public void EliminarEmpleadoApoyo(PersonalApoyo aux)
        {
            foreach (PersonalApoyo aux2 in listaEmpleadosApoyo.ToArray())
                if (aux2 != null)
                    if (aux2 == aux) { listaEmpleadosApoyo.Remove(aux); }
        }

        public void EliminarEmpleadoSanidad(PersonalSanidad aux)
        {
            foreach (PersonalSanidad aux2 in listaEmpleadosSanidad.ToArray())
            {
                if ( aux2 != null)
                    if (aux2 == aux) { listaEmpleadosSanidad.Remove(aux); }
            }
        }

        public UInt32 BuscarLegajo(UInt32 leg)
        {
            int cont = 0;
            foreach (PersonalSanidad aux in listaEmpleadosSanidad)
            {
                if (aux != null)
                {
                    cont++;
                    if (aux.GetLegajo() == leg)
                    {
                        return 0;
                    }
                }
            }
            foreach (PersonalApoyo aux in listaEmpleadosApoyo)
            {
                if (aux != null)
                {
                    cont++;
                    if (aux.GetLegajo() == leg) return 0;

                }
            }
            if (cont >= 0) return 1;
            else return 0;
        }

        public UInt32 BuscarMatricula(ulong matricula)
        {
            foreach (PersonalSanidad aux in listaEmpleadosSanidad)
            {
                if (aux != null)
                    if (aux.GetMatricula() == matricula) return 0;
            }
            return 1;
        }

        public override string ToString()
        {
            string datosApoyo = "\nPersonal Apoyo: ";
            foreach (PersonalApoyo aux in listaEmpleadosApoyo)
            {
                datosApoyo += "\n" + aux.ToString() + "\n";
            }

            if (datosApoyo == "Personal Apoyo: ") datosApoyo = "";
            
            string datosSanidad = "\nPersonal Sanidad: ";
            foreach (PersonalSanidad aux in listaEmpleadosSanidad)
            {
                datosSanidad += "\n" + aux.ToString() + "\n";
            }

            if (datosSanidad == "Personal Sanidad: ") datosSanidad = "";

            string datos = datosApoyo + datosSanidad;

            if (datos != "") 
                return datos;
            else 
                return "No hay empleados cargados";
        }
    }
}
