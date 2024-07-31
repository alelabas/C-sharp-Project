using System;
using System.Collections.Generic;
using Hospital;

namespace Hospital
{

    public class PersonalApoyo:Empleado
    {
        public PersonalApoyo(uint legajo, string apellidos, string nombres, uint anioIngreso, string categoria) : base(legajo, apellidos, nombres, anioIngreso, categoria) { }

        public PersonalApoyo() : base(0, "", "", 0, ""){ }

        public override string ToString()
        {
            string datos = "";
            datos += "\nLegajo = " + base.GetLegajo().ToString() + " - Apellidos: " + base.GetApellidos() + " - Nombres: " + base.GetNombres() + " - Antigüedad: " + base.GetAnioIngreso().ToString() + " - Categoria Profesional: " + base.GetCategoriaProfesional() + " - Sueldo: " + this.GetSueldo().ToString();
            return datos;
        }
    }

}
