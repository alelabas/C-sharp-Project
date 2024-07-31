using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using Hospital;

namespace Hospital
{
    public class PersonalSanidad:Empleado
    {
        private ulong matricula; 
        private string especializacion;
        private bool esJefe;
        private bool esTitular;
        private bool esAsociado;
        private bool esResidente;
        private bool esEmpleado;


        public PersonalSanidad(UInt32 leg, string ape, string nom, UInt32 anio, string categoria, ulong mat, string espe):base(leg, ape, nom, anio, categoria)
        {;
            this.matricula = mat;
            this.especializacion = espe;
            this.esJefe = false;
            this.esTitular = false;
            this.esAsociado = false;
            this.esResidente = false;
            this.esEmpleado = false;
        } 

        public PersonalSanidad():base(0, "", "", 0, "")
        {
            this.matricula = 0;
            this.especializacion = "";
        }


        // Setters
        public void SetMatricula(ulong mat) { this.matricula = mat; }
        public void SetEspecializacion(string espe) {this.especializacion = espe;}
        public void SetJefe(bool valor) { this.esJefe = valor;}
        public void SetTitular(bool valor) {  this.esTitular = true;}
        public void SetAsociado(bool valor) { this.esAsociado = true;}
        public void SetResidente(bool valor) { this.esResidente = true;}
        public void SetEmpleado(bool valor) { this.esEmpleado = true;}
        // Getters
        public ulong GetMatricula() { return this.matricula ; }
        public string GetEspecializacion() {return this.especializacion ;}
        public bool GetJefe() { return this.esJefe; }
        public bool GetTitular() {  return this.esTitular; }
        public bool GetAsociado() {  return this.esAsociado; }
        public bool GetResidente() {  return this.esResidente; }
        public bool GetEmpleado() {  return this.esEmpleado; }

        public override string ToString()
        {
            string datos ="";
            datos += "\nLegajo = " + base.GetLegajo().ToString() + " - Apellidos: " + base.GetApellidos() + " - Nombres: " + base.GetNombres() + " - Antigüedad: " + base.GetAnioIngreso().ToString() + "\nCategoria: " + base.GetCategoriaProfesional() + " - Matricula: " + this.matricula.ToString() + " - Especialización: " + this.especializacion + " - Sueldo: " + this.GetSueldo().ToString();
            return datos;
        }

        public void EstablecerSueldoProfesional()
        {
            double sueldoTotal = base.GetSueldo();

            if (base.GetCategoriaProfesional().ToLower() == "enfermero")
            {
                sueldoTotal += Empleado.GetBonoEnfermeros();
            }
            else if (base.GetCategoriaProfesional().ToLower() == "tecnico")
            {
                sueldoTotal += Empleado.GetBonoTecnicos();
            }
            else if (base.GetCategoriaProfesional().ToLower() == "medico")
            {
                if (this.esJefe)
                {
                    sueldoTotal += (Empleado.GetBonoMedicos() * 1.5);
                }
                else if (this.esTitular)
                {
                    sueldoTotal += Empleado.GetBonoMedicos() ;
                }
                else if (this.esAsociado)
                {
                    sueldoTotal += (Empleado.GetBonoMedicos() * 0.8);
                }
                else if (this.esResidente)
                {
                    sueldoTotal += (Empleado.GetBonoMedicos() * 0.5);
                }
                
            }

            base.SetSueldo(sueldoTotal);
        }

    }


}