using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class CListaPacientes
    {
        private ArrayList listaPacientes;

        public CListaPacientes()
        {
            listaPacientes = new ArrayList();
        }

        public void AgregarPaciente(Paciente aux) { listaPacientes.Add(aux); }

        public uint BuscarPaciente(uint historia)
        {
            foreach (Paciente aux in listaPacientes)
            {
                if (aux != null)
                    if (aux.GetHistoriaClinica() == historia) return 0;
            }
            return 1;
        }

        public void MostrarPacientes()
        {
            foreach (Paciente aux in listaPacientes)
            {
                if (aux != null)
                    Console.WriteLine("\n" + aux.ToString());
            }
        }

        public Paciente DarPaciente(uint historia)
        {
            foreach (Paciente aux in listaPacientes)
            {
                if (aux != null)
                    if (historia == aux.GetHistoriaClinica())
                        return aux;
            }
            return new Paciente(0, 0, "", "", "", "");
        }

    }
}
