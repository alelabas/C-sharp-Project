using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Hospital;

namespace Hospital
{
    public class ServiciosMedicos
    {   
        private UInt32 codigo;
        private string nombre;
        private PersonalSanidad jefeDeServicio;
        private PersonalSanidad medicoTitular;
        private PersonalSanidad medicoAsociado;
        private PersonalSanidad residente;
        private ArrayList empleadosSanidad;
        private ArrayList empleadosApoyo;
        private ArrayList consultorios;
        private ArrayList pacientes;

        public ServiciosMedicos(UInt32 cod, string nom, PersonalSanidad jefeDeServ)
        {
            this.codigo = cod;
            this.nombre = nom;
            this.jefeDeServicio = jefeDeServ;
            this.empleadosSanidad = new ArrayList();
            this.empleadosApoyo = new ArrayList();
            this.medicoTitular = new PersonalSanidad();
            this.medicoAsociado = new PersonalSanidad();
            this.residente = new PersonalSanidad();
            this.consultorios = new ArrayList();
            this.pacientes = new ArrayList();
        }

        public ServiciosMedicos()
        {
            this.codigo = 0;
            this.nombre = "";
            this.jefeDeServicio = new PersonalSanidad();
            this.empleadosSanidad = new ArrayList();
            this.empleadosApoyo = new ArrayList();
            this.medicoTitular = new PersonalSanidad();
            this.medicoAsociado = new PersonalSanidad();
            this.residente = new PersonalSanidad();
            this.consultorios = new ArrayList();
            this.pacientes = new ArrayList();
        }

        //setters
        public void SetCodigo(UInt32 codigo)
        {this.codigo = codigo;}
        public void SetNombre(string nombre)
        {this.nombre = nombre;}
        public void SetJefeDeServicio(PersonalSanidad aux)
        {this.jefeDeServicio = aux;}
        public void SetMedicoTitular(PersonalSanidad aux)
        {this.medicoTitular=aux;}
        public void SetMedicoAsociado(PersonalSanidad aux)
        {this.medicoAsociado=aux;}
        public void SetResidente(PersonalSanidad aux)
        {this.residente=aux;}


        //getters
        public UInt32 GetCodigo()
        {return this.codigo;}
        public string GetNombre()
        {return this.nombre;}
        public PersonalSanidad GetJefeDeServicio()
        {return this.jefeDeServicio;}
        public PersonalSanidad GetMedicoTitular()
        {return this.medicoTitular;}
        public PersonalSanidad GetMedicoAsociado()
        {return this.medicoAsociado;}
        public PersonalSanidad GetResidente()
        {return this.residente;}

        public void AgregarEmpleados(PersonalSanidad aux) { empleadosSanidad.Add(aux); }

        public void AgregarEmpleados(PersonalApoyo aux) { empleadosApoyo.Add(aux); }

        public void AgregarConsultorio(Consultorio aux) { consultorios.Add(aux); }

        public void AgregarPacientes(Paciente aux) { pacientes.Add(aux); }

        public uint BuscarConsultorio(uint codigo)
        {
            foreach (Consultorio aux in  consultorios)
            {
                if (aux != null)
                    if (aux.GetCodigo() == codigo)
                        return 1;
            }
            return 0;
        }

        public string MostrarConsultorios()
        {
            string datos = "";

            foreach (Consultorio aux in consultorios)
            {
                if (aux != null)
                    datos += "\n" + aux.ToString();
            }
            return datos;
        }

        public string MostrarEmpleados()
        {
            string datos="";

            foreach(PersonalSanidad aux in empleadosSanidad)
            {
                if (aux !=null)
                {
                    datos += "\n" + aux.ToString();
                }
            }
            foreach(PersonalApoyo aux2 in empleadosApoyo)
            {
                if (aux2 != null)
                {
                    datos += "\n" + aux2.ToString();
                }
            }
            return datos;
        }

        public string MostrarEmpleado(PersonalApoyo aux)
        {
            string datos="";

            foreach(PersonalApoyo auxiliar in empleadosApoyo)
            {
                if (auxiliar != null)
                {
                    if (aux == auxiliar)
                        datos += "Servicio: " + this.codigo.ToString() + " - Nombre: " + this.nombre;
                }
            }
            return datos;
        }

        public string MostrarEmpleado(PersonalSanidad aux)
        {
            string datos="";

            foreach(PersonalSanidad auxiliar in empleadosSanidad)
            {
                if (auxiliar != null)
                {
                    if (aux == auxiliar)
                        datos += "Servicio: " + this.codigo.ToString() + " - Nombre: " + this.nombre;
                }
            }
            return datos;
        }

        public UInt32 CantEmpleadosSanidad()
        {
            UInt32 contEmpleadosSanidad = 0;
            foreach (PersonalSanidad aux in empleadosSanidad)
            {
                if (aux != null)
                {
                    contEmpleadosSanidad++;
                }
            }
            return contEmpleadosSanidad;
        }

        public UInt32 CantEmpleadosApoyo()
        {
            UInt32 contEmpleadosApoyo = 0;
            foreach (PersonalApoyo aux in empleadosApoyo)
            {
                if (aux != null)
                {
                    contEmpleadosApoyo++;
                }
            }
            return contEmpleadosApoyo;
        }

        public double SueldosEmpleados()
        {
            double sueldosEmpleados= 0;
            foreach (PersonalApoyo aux in empleadosApoyo)
            {
                if (aux != null)
                {
                    sueldosEmpleados += aux.GetSueldo();
                }
            }
            foreach(PersonalSanidad aux2 in empleadosSanidad)
            {
                if (aux2 != null)
                {
                    sueldosEmpleados += aux2.GetSueldo();
                }
            }
            return sueldosEmpleados;
        }

        public string MostrarPacientesServicio(uint historia)
        {
            string datos = "";
            foreach (Paciente aux in pacientes)
            {
                if (aux != null)
                    if (aux.GetHistoriaClinica() == historia)
                        datos += "\nPaciente: " + aux.ToString();
            }
            return datos;
        }

        public override string ToString()
        {
            string datos ="";
            datos += "Codigo: " + this.codigo.ToString() + " - Nombre: " + this.nombre + "\nJefe de servicio: " + this.jefeDeServicio.ToString() + "\nMedico titular: " + this.medicoTitular.ToString() + "\nMedico asociado: " + this.medicoAsociado.ToString() + "\nResidente: " + this.residente.ToString() + "\nEmpleados: \n" + MostrarEmpleados();
            return datos;
        }
    }
}