using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital;

namespace Hospital
{
    public class Empleado
    {
        private uint legajo;
        private string apellidos;
        private string nombres;
        private string categoriaProfesional;
        private uint anioIngreso;
        private double sueldo;
        private static double bonoMedicos;
        private static double bonoEnfermeros;
        private static double bonoTecnicos;
        private static double montoReferencia;
        public Empleado(uint legajo, string apellidos, string nombres, uint anioIngreso, string categoria) 
        {
            this.legajo = legajo;
            this.apellidos = apellidos;
            this.nombres = nombres;
            this.anioIngreso = anioIngreso;
            this.categoriaProfesional = categoria;
        }

        //setters
        public void SetLegajo(uint leg) { this.legajo = leg; }
        public void SetApellidos(string apellidos) { this.apellidos = apellidos; }
        public void SetNombres(string nombres) {  this.nombres = nombres;}
        public void SetCategoriaProfesional(string categoria) { this.categoriaProfesional = categoria;}
        public void SetAnioIngreso(uint anioIngreso) { this.anioIngreso = anioIngreso; }
        public void SetSueldo(double sueldo) { this.sueldo = sueldo; }

        public static void SetMontoReferencia(double monto) { montoReferencia = monto; }
        public static void SetBonoEnfermeros(double bono) { bonoEnfermeros = bono; }
        public static void SetBonoTecnicos(double bono) { bonoTecnicos = bono; }
        public static void SetBonoMedicos(double bono) { bonoMedicos = bono; }


        //getters
        public uint GetLegajo() { return legajo; }
        public string GetApellidos() { return apellidos; }
        public string GetNombres() { return nombres; }
        public string GetCategoriaProfesional() { return categoriaProfesional; }
        public uint GetAnioIngreso() { return anioIngreso; }
        public double GetSueldo() { return sueldo; }

        public static double GetMontoReferencia() { return montoReferencia; }
        public static double GetBonoMedicos() { return bonoMedicos; }
        public static double GetBonoEnfermeros() { return bonoEnfermeros; }
        public static double GetBonoTecnicos() { return bonoTecnicos; }

        public void EstablecerSueldo()
        {
            double sueldoTotal = 0;

            if (anioIngreso < 2)
            {
                sueldoTotal = Empleado.GetMontoReferencia() * 0.5;
            }
            else if (anioIngreso < 4)
            {
                sueldoTotal = Empleado.GetMontoReferencia() * 0.7;
            }
            else if (anioIngreso < 6)
            {
                sueldoTotal = Empleado.GetMontoReferencia() * 0.9;
            }
            else if (anioIngreso < 8)
            {
                sueldoTotal = Empleado.GetMontoReferencia() * 1.1;
            }
            else if (anioIngreso < 10)
            {
                sueldoTotal = Empleado.GetMontoReferencia() * 1.3;
            }
            else if (anioIngreso < 12)
            {
                sueldoTotal = Empleado.GetMontoReferencia() * 1.5;
            }
            else if (anioIngreso < 14)
            {
                sueldoTotal = Empleado.GetMontoReferencia() * 1.7;
            }
            else if (anioIngreso < 16)
            {
                sueldoTotal = Empleado.GetMontoReferencia() * 1.9;
            }
            else if (anioIngreso < 18)
            {
                sueldoTotal = Empleado.GetMontoReferencia() * 2.1;
            }
            else if (anioIngreso < 20)
            {
                sueldoTotal = Empleado.GetMontoReferencia() * 2.3;
            }
            else if (anioIngreso >= 20)
            {
                sueldoTotal = Empleado.GetMontoReferencia() * 2.5;
            }

            sueldo = sueldoTotal;
        }
    }
}
