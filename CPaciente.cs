using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class Paciente
    {
        private uint historiaClinica;
        private uint documento;
        private string apellidos;
        private string nombres;
        private string nacimiento;
        private string sexo;
        private string fechaDeAlta;

        public Paciente(uint historiaClinica, uint documento, string apellidos, string nombres, string nacimiento, string sexo)
        {
            this.historiaClinica = historiaClinica;
            this.documento = documento;
            this.apellidos = apellidos;
            this.nombres = nombres;
            this.nacimiento = nacimiento;
            this.sexo = sexo;
            this.fechaDeAlta = "";
        }

        //setters
        public void SetHistoriaClinica(uint historia) { this.historiaClinica = historia; }
        public void SetDocumento(uint documento) { this.documento = documento; }
        public void SetApellidos(string apellidos) { this.apellidos=apellidos; }
        public void SetNombres(string nombres) { this.nombres=nombres; }
        public void SetNacimiento(string nacimiento) { this.nacimiento = nacimiento; }
        public void SetSexo(string sexo) {  this.sexo = sexo; }
        public void SetFechaDeAlta(string fecha) { this.fechaDeAlta=fecha; }

        //getters
        public uint GetHistoriaClinica() { return this.historiaClinica; }
        public uint GetDocumento() {  return this.documento; }
        public string GetApellidos() { return this.apellidos; }
        public string GetNombres() { return this.nombres; }
        public string GetNacimiento() {  return this.nacimiento; }
        public string GetSexo() {  return this.sexo; }
        public string GetFechaDeAlta() {  return this.fechaDeAlta; }

        public override string ToString()
        {
            string datos = "\nHistoria clinica: " + this.historiaClinica.ToString() + " - DNI: " + this.documento.ToString() + " - Apellidos: " + this.apellidos + " - Nombres: " + this.nombres + " - Fecha de nacimiento: " + this.nacimiento + " - Sexo: " + this.sexo + " - Fecha de alta: " + this.fechaDeAlta;
            return datos;
        }
    }
}
