using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class Consultorio
    {
        private uint codigo;
        private uint numero;
        private uint piso;
        private string sector;

        public Consultorio(uint codigo, uint numero, uint piso, string sector)
        {
            this.codigo = codigo;
            this.numero = numero;
            this.piso = piso;
            this.sector = sector;
        }

        public Consultorio()
        {
            this.codigo = 0;
            this.numero = 0;
            this.piso = 0;
            this.sector = "";
        }

        //setters 
        public void SetCodigo(uint codigo) { this.codigo = codigo; } 
        public void SetNumero(uint numero) { this.numero = numero; }
        public void SetPiso(uint piso) { this.piso = piso; }
        public void SetSector(string sector) { this.sector = sector; }

        //getters
        public uint GetCodigo() { return this.codigo; }
        public uint GetNumero() { return this.numero; }
        public uint GetPiso() {  return this.piso; }
        public string GetSector() { return this.sector; }

        public override string ToString()
        {
            string datos = "";
            datos = "\nCodigo: " + this.codigo + " - Numero: " + this.numero + " - Piso: " + this.piso + " - Sector: " + this.sector;
            return datos;
        }

        }
}
