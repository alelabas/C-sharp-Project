using System;
using System.Collections;
using System.Collections.Generic;
using Hospital;

namespace Hospital
{

    public class CEjecutora
    {
        private static ListaEmpleados listaPersonal= new ListaEmpleados();
        private static ListaServicios listaServicios = new ListaServicios();
        private static CListaPacientes listaPacientes = new CListaPacientes();

        public static void Main()
        {
            UInt32 opcion = 0;
            while(opcion != 17)
            {
                Console.WriteLine("----- Menú Principal -----");
                Console.WriteLine("1. Establecer monto de referencia y bonos profesionales");
                Console.WriteLine("2. Registrar empleado");
                Console.WriteLine("3. Listado de empleados");
                Console.WriteLine("4. Registrar un servicio");
                Console.WriteLine("5. Asignar empleado a un servicio");
                Console.WriteLine("6. Reemplazar un Jefe de servicio");
                Console.WriteLine("7. Mostrar datos de un servicio");
                Console.WriteLine("8. Mostrar datos de un empleado");
                Console.WriteLine("9. Eliminar un empleado");
                Console.WriteLine("10. Mostrar cantidad de empleados y haberes de cada servicio");
                Console.WriteLine("11. Asignar un consultorio a un servicio");
                Console.WriteLine("12. Mostrar los consultorios de un servicio");
                Console.WriteLine("13. Registrar un paciente");
                Console.WriteLine("14. Mostrar los datos de todos los pacientes del hospital");
                Console.WriteLine("15. Dar de alta un paciente en un servicio");
                Console.WriteLine("16. Mostrar los servicios que tratan a un paciente");
                Console.WriteLine("17. Salir");
                Console.WriteLine("---------------------------\n");

                Console.WriteLine("Ingrese la opcion deseada: ");
                while (!(UInt32.TryParse(Console.ReadLine(), out opcion) && opcion <= 17 && opcion >= 1))
                {
                    Console.WriteLine("Opcion invalida. Por favor, ingrese un numero deseado.");
                }

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Ingrese el monto de referencia: ");
                        double remuneracion = double.Parse(Console.ReadLine());
                        Empleado.SetMontoReferencia(remuneracion);

                        Console.WriteLine("Ingrese el monto del bono de medicos: ");
                        double bonoMedicos = double.Parse(Console.ReadLine());
                        PersonalSanidad.SetBonoMedicos(bonoMedicos);

                        Console.WriteLine("Ingrese el monto del bono de enfermeros: ");
                        double bonoEnfermeros = double.Parse(Console.ReadLine());
                        PersonalSanidad.SetBonoEnfermeros(bonoEnfermeros);

                        Console.WriteLine("Ingrese el monto del bono de tecnicos: ");
                        double bonoTecnicos = double.Parse(Console.ReadLine());
                        PersonalSanidad.SetBonoTecnicos(bonoTecnicos);

                        break;

                    case 2:
                        Console.WriteLine("Ingrese legajo del profesional: ");
                        UInt32 legajo = UInt32.Parse(Console.ReadLine());

                        while (listaPersonal.BuscarLegajo(legajo) == 0)
                        {
                            Console.WriteLine("El legajo ingresado ya existe en el sistema. ");
                            Console.WriteLine("Ingrese legajo del profesional: ");
                            legajo = UInt32.Parse(Console.ReadLine());
                        }

                        Console.WriteLine("Ingrese el/los apellidos del profesional: ");
                        string apellido = Console.ReadLine();

                        Console.WriteLine("Ingrese el/los nombres del profesional: ");
                        string nombre = Console.ReadLine();

                        Console.WriteLine("Ingrese la antigüedad del profesional: ");
                        UInt32 anio = UInt32.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese la categoria del profesional [Medico/Enfermero/Tecnico/Camillero/Administrativo/Limpieza/Seguridad]: ");
                        string categoria = Console.ReadLine();

                        if (categoria.ToLower() == "medico" || categoria.ToLower() == "enfermero" || categoria.ToLower() == "tecnico")
                        {
                            Console.WriteLine("Ingrese la matricula del profesional: ");
                            ulong matricula = ulong.Parse(Console.ReadLine());

                            while (listaPersonal.BuscarMatricula(matricula) == 0)
                            {
                                Console.WriteLine("La matricula ingresada ya existe en el sistema.");
                                Console.WriteLine("Ingrese la matricula del profesional: ");
                                matricula = ulong.Parse(Console.ReadLine());
                            }

                            Console.WriteLine("Ingrese la especializacion del profesional: ");
                            string espe = Console.ReadLine();

                            PersonalSanidad aux = new PersonalSanidad(legajo, apellido, nombre, anio, categoria, matricula, espe);
                            listaPersonal.AgregarSanidad(aux);
                            aux.EstablecerSueldoProfesional();
                            Console.WriteLine("Personal de Sanidad agregado correctamente");
                        }
                        else
                        {
                            PersonalApoyo aux2 = new PersonalApoyo(legajo, apellido, nombre, anio, categoria);
                            listaPersonal.AgregarApoyo(aux2);
                            aux2.EstablecerSueldo();
                            Console.WriteLine("Personal de Apoyo agregado correctamente");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Personal del hospital: \n");
                        Console.WriteLine(listaPersonal.ToString());
                        break;

                    case 4:
                        Console.WriteLine("Ingrese el codigo del servicio: ");
                        UInt32 codigo = UInt32.Parse(Console.ReadLine());

                        while (listaServicios.BuscarCodigo(codigo) == 0)
                        {
                            Console.WriteLine("El codigo ingresado ya existe en el sistema. ");
                            Console.WriteLine("Ingrese el codigo del servicio: ");
                            codigo = UInt32.Parse(Console.ReadLine());
                        }

                        Console.WriteLine("Ingrese el nombre del servicio: ");
                        string nombreServicio = Console.ReadLine();

                        Console.WriteLine("Ingrese el legajo del medico a asignar como Jefe de servicio: ");
                        UInt32 legajoMedico = UInt32.Parse(Console.ReadLine());

                        PersonalSanidad auxSanidad = listaPersonal.BuscarMedico(legajoMedico);

                        //chequear que el medico no sea de jefe de otro servicio
                        while (auxSanidad.GetLegajo() == 0)
                        {
                            Console.WriteLine("El legajo ingresado no pertenece al sistema o no pertenece a un medico. Intente de nuevo: ");
                            legajoMedico = UInt32.Parse(Console.ReadLine());
                            auxSanidad = listaPersonal.BuscarMedico(legajoMedico);
                        }

                        if (!auxSanidad.GetJefe() && !auxSanidad.GetTitular() && !auxSanidad.GetAsociado() && !auxSanidad.GetResidente())
                        {
                            ServiciosMedicos servicio = new ServiciosMedicos(codigo, nombreServicio, auxSanidad);
                            auxSanidad.SetJefe(true);
                            auxSanidad.EstablecerSueldoProfesional();
                            listaServicios.AgregarServicio(servicio);
                        }
                        else Console.WriteLine("El medico ingresado ya pertenece a un servicio");
                        break;

                    case 5:
                        Console.WriteLine("Ingrese el codigo del servicio: ");
                        UInt32 codigoServicio = UInt32.Parse(Console.ReadLine());

                        while (listaServicios.BuscarCodigo(codigoServicio) == 1)
                        {
                            Console.WriteLine("El codigo ingresado no existe en el sistema. ");
                            Console.WriteLine("Ingrese el codigo del servicio: ");
                            codigoServicio = UInt32.Parse(Console.ReadLine());
                        }

                        ServiciosMedicos auxiliarServicios = listaServicios.ObtenerServicio(codigoServicio);

                        Console.WriteLine("Ingrese el legajo del profesional a asignar a un servicio: ");
                        UInt32 legAsignar = UInt32.Parse(Console.ReadLine());

                        while (listaPersonal.BuscarLegajo(legAsignar) == 1)
                        {
                            Console.WriteLine("El legajo ingresado no pertenece a ningun empleado.");
                            Console.WriteLine("Ingrese el legajo del profesional a asignar a un servicio: ");
                            legAsignar = UInt32.Parse(Console.ReadLine());
                        }

                        PersonalSanidad auxiliar = listaPersonal.BuscarPersonalSanidad(legAsignar);
                        PersonalApoyo auxiliar2 = listaPersonal.BuscarPersonalApoyo(legAsignar);

                        if (auxiliar.GetLegajo() != 0)
                        {
                            if (auxiliar.GetCategoriaProfesional().ToLower() == "medico")
                            {
                                if (!auxiliar.GetJefe() && !auxiliar.GetTitular() && !auxiliar.GetAsociado() && !auxiliar.GetResidente())
                                {
                                    Console.WriteLine("El legajo ingresado corresponde a un medico. Los medicos solo pueden ser asociados como Jefes de servicio, medico titular, medico asociado o residente");
                                    if (auxiliarServicios.GetJefeDeServicio().GetLegajo() != 0 && auxiliarServicios.GetMedicoTitular().GetLegajo() != 0 && auxiliarServicios.GetMedicoAsociado().GetLegajo() != 0 && auxiliarServicios.GetResidente().GetLegajo() != 0)
                                    {
                                        Console.WriteLine("Los puestos de medicos ya estan ocupados");
                                    }
                                    UInt32 opc = 0;
                                    //separar del main. metodo static de la lista
                                    while (opc != 5)
                                    {
                                        Console.WriteLine("Ingrese la opcion deseada: ");
                                        Console.WriteLine("Asociar al medico como Jefe de servicio[1]");
                                        Console.WriteLine("Asociar al medico como Medico titular[2]");
                                        Console.WriteLine("Asociar al medico como Medico asociado[3]");
                                        Console.WriteLine("Asociar al medico como residente[4]");
                                        Console.WriteLine("Salir[5]");
                                        opc = UInt32.Parse(Console.ReadLine());

                                        switch (opc)
                                        {
                                            case 1:
                                                if (auxiliarServicios.GetJefeDeServicio().GetLegajo() != 0)
                                                {
                                                    Console.WriteLine("El servicio ya posee Jefe de servicio");
                                                }
                                                else
                                                {
                                                    auxiliarServicios.SetJefeDeServicio(auxiliar);
                                                    auxiliar.SetJefe(true);
                                                    auxiliar.EstablecerSueldoProfesional();
                                                    Console.WriteLine("Jefe de servicio asignado correctamente");
                                                }
                                                break;
                                            case 2:
                                                if (auxiliarServicios.GetMedicoTitular().GetLegajo() != 0)
                                                {
                                                    Console.WriteLine("El servicio ya posee Medico titular");
                                                }
                                                else
                                                {
                                                    auxiliarServicios.SetMedicoTitular(auxiliar);
                                                    auxiliar.SetTitular(true);
                                                    auxiliar.EstablecerSueldoProfesional();
                                                    Console.WriteLine("Medico titular asignado correctamente");
                                                }
                                                break;
                                            case 3:
                                                if (auxiliarServicios.GetMedicoAsociado().GetLegajo() != 0)
                                                {
                                                    Console.WriteLine("El servicio ya posee Medico asociado");
                                                }
                                                else
                                                {
                                                    auxiliarServicios.SetMedicoAsociado(auxiliar);
                                                    auxiliar.SetAsociado(true);
                                                    auxiliar.EstablecerSueldoProfesional();
                                                    Console.WriteLine("Medico asociado asignado correctamente");
                                                }
                                                break;
                                            case 4:
                                                if (auxiliarServicios.GetResidente().GetLegajo() != 0)
                                                {
                                                    Console.WriteLine("El servicio ya posee residente");
                                                }
                                                else
                                                {
                                                    auxiliarServicios.SetResidente(auxiliar);
                                                    auxiliar.SetResidente(true);
                                                    auxiliar.EstablecerSueldoProfesional();
                                                    Console.WriteLine("Residente asignado correctamente");
                                                }
                                                break;
                                            case 5:
                                                Console.WriteLine("Saliendo....");
                                                break;
                                            default:
                                                break;
                                        }

                                    }
                                }
                                else Console.WriteLine("El medico ingresado ya es empleado por un servicio.");
                            }
                            else if (auxiliar.GetCategoriaProfesional().ToLower() == "enfermero")
                            {
                                if (!auxiliar.GetEmpleado())
                                {
                                    auxiliarServicios.AgregarEmpleados(auxiliar);
                                    auxiliar.SetEmpleado(true);
                                    auxiliar.EstablecerSueldoProfesional();
                                }
                                else Console.WriteLine("El enfermero ingresado ya es empleado por un servicio");
                            }
                            else auxiliarServicios.AgregarEmpleados(auxiliar);
                        }
                        else
                            if (auxiliar2.GetLegajo() != 0)
                        {
                            auxiliarServicios.AgregarEmpleados(auxiliar2);
                        }

                        break;

                    case 6:
                        Console.WriteLine("Ingrese el legajo del medico a asignar: ");
                        UInt32 legajoMed = UInt32.Parse(Console.ReadLine());

                        PersonalSanidad auxMed = listaPersonal.BuscarMedico(legajoMed);

                        while (auxMed.GetLegajo() == 0)
                        {
                            Console.WriteLine("El legajo ingresado no pertenece al sistema o no pertenece a un medico. Intente de nuevo: ");
                            legajoMed = UInt32.Parse(Console.ReadLine());
                            auxMed = listaPersonal.BuscarMedico(legajoMed);
                        }

                        if (auxMed.GetJefe() || auxMed.GetTitular() || auxMed.GetAsociado() || auxMed.GetResidente())
                            Console.WriteLine("El medico ingresado ya pertenece a un sistema");
                        else
                        {
                            Console.WriteLine("Ingrese el codigo del servicio: ");
                            codigoServicio = UInt32.Parse(Console.ReadLine());

                            while (listaServicios.BuscarCodigo(codigoServicio) == 1)
                            {
                                Console.WriteLine("El codigo ingresado no existe en el sistema. ");
                                Console.WriteLine("Ingrese el codigo del servicio: ");
                                codigoServicio = UInt32.Parse(Console.ReadLine());
                            }

                            auxiliarServicios = listaServicios.ObtenerServicio(codigoServicio);

                            if (auxiliarServicios.GetJefeDeServicio().GetLegajo() != 0)
                                Console.WriteLine("El servicio ya posee Jefe de servicio.");
                            else
                            {
                                auxiliarServicios.SetJefeDeServicio(auxMed);
                                Console.WriteLine("Medico asociado correctamente");
                                auxMed.SetJefe(true);
                                auxMed.EstablecerSueldoProfesional();
                            }
                        }
                        break;

                    case 7:
                        Console.WriteLine("Ingrese el codigo del servicio: ");
                        codigoServicio = UInt32.Parse(Console.ReadLine());

                        while (listaServicios.BuscarCodigo(codigoServicio) == 1)
                        {
                            Console.WriteLine("El codigo ingresado no existe en el sistema. ");
                            Console.WriteLine("Ingrese el codigo del servicio: ");
                            codigoServicio = UInt32.Parse(Console.ReadLine());
                        }

                        auxiliarServicios = listaServicios.ObtenerServicio(codigoServicio);
                        Console.WriteLine(auxiliarServicios.ToString());
                        break;

                    case 8:
                        Console.WriteLine("Ingrese legajo del profesional: ");
                        legajo = UInt32.Parse(Console.ReadLine());

                        listaPersonal.CargarSueldos();
                        while (listaPersonal.BuscarLegajo(legajo) == 1)
                        {
                            Console.WriteLine("El legajo ingresado no existe en el sistema. ");
                            Console.WriteLine("Ingrese legajo del profesional: ");
                            legajo = UInt32.Parse(Console.ReadLine());
                        }

                        if (listaPersonal.BuscarPersonalApoyo(legajo).GetLegajo() != 0)
                        {
                            PersonalApoyo auxapoyo = listaPersonal.BuscarPersonalApoyo(legajo);
                            Console.WriteLine(auxapoyo.ToString());
                            Console.WriteLine(listaServicios.MostrarTrabajos(auxapoyo));
                        }
                        else
                        {
                            PersonalSanidad auxsanidad = listaPersonal.BuscarPersonalSanidad(legajo);
                            Console.WriteLine(auxsanidad.ToString());
                            Console.WriteLine(listaServicios.MostrarTrabajos(auxsanidad));
                        }
                        break;

                    case 9:
                        Console.WriteLine("Ingrese el legajo del empleado a eliminar: ");
                        legajo = UInt32.Parse(Console.ReadLine());

                        while (listaPersonal.BuscarLegajo(legajo) == 1)
                        {
                            Console.WriteLine("El legajo ingresado no existe en el sistema. ");
                            Console.WriteLine("Ingrese legajo del profesional: ");
                            legajo = UInt32.Parse(Console.ReadLine());
                        }

                        PersonalApoyo empleadoApoyo = listaPersonal.BuscarPersonalApoyo(legajo);
                        PersonalSanidad empleadoSanidad = listaPersonal.BuscarPersonalSanidad(legajo);

                        if (empleadoApoyo.GetLegajo() != 0)
                        {
                            string datos = "";
                            if (datos == listaServicios.MostrarTrabajos(empleadoApoyo))
                            {
                                listaPersonal.EliminarEmpleadoApoyo(empleadoApoyo);
                                Console.WriteLine("Empleado eliminado correctamente");
                            }
                            else Console.WriteLine("Eliminacion no realizada. El empleado esta asignado a un servicio");
                        }
                        else if (empleadoSanidad.GetLegajo() != 0 && empleadoSanidad.GetCategoriaProfesional().ToLower() != "medico")
                        {
                            string datos = "";
                            if (!empleadoSanidad.GetEmpleado())
                                if (datos == listaServicios.MostrarTrabajos(empleadoSanidad))
                                {
                                    listaPersonal.EliminarEmpleadoSanidad(empleadoSanidad);
                                    Console.WriteLine("Empleado eliminado correctamente");
                                }
                                else Console.WriteLine("Eliminacion no realizada. El empleado esta asignado a un servicio");
                            else Console.WriteLine("Eliminacion no realizada. El empleado esta asignado a un servicio");
                        }
                        else if (empleadoSanidad.GetJefe() || empleadoSanidad.GetTitular() || empleadoSanidad.GetAsociado() || empleadoSanidad.GetResidente())
                        { Console.WriteLine("El empleado no pudo ser eliminado dado que tiene un cargo asociado"); }
                        else
                        { Console.WriteLine("Eliminacion no realizada. El empleado esta asignado a un servicio"); }
                        break;

                    case 10:
                        listaPersonal.CargarSueldos();
                        listaServicios.EmpleadosServicios();
                        break;

                    case 11:
                        Console.WriteLine("Ingrese el codigo del servicio: ");
                        codigoServicio = UInt32.Parse(Console.ReadLine());

                        while (listaServicios.BuscarCodigo(codigoServicio) == 1)
                        {
                            Console.WriteLine("El codigo ingresado no existe en el sistema. ");
                            Console.WriteLine("Ingrese el codigo del servicio: ");
                            codigoServicio = UInt32.Parse(Console.ReadLine());
                        }

                        auxiliarServicios = listaServicios.ObtenerServicio(codigoServicio);

                        Console.WriteLine("Ingrese el codigo del consultorio: ");
                        uint codigoConsultorio = uint.Parse(Console.ReadLine());

                        while (auxiliarServicios.BuscarConsultorio(codigoConsultorio) == 1)
                        {
                            Console.WriteLine("El codigo ingresado ya pertenece a un consultorio asignado a este servicio.");
                            Console.WriteLine("Ingrese el codigo del consultorio: ");
                            codigoConsultorio = uint.Parse(Console.ReadLine());
                        }

                        Console.WriteLine("Ingrese el numero del consultorio: ");
                        uint numeroConsultorio = uint.Parse(Console.ReadLine());
                        Console.WriteLine("Ingrese el piso del consultorio: ");
                        uint numeroPiso = uint.Parse(Console.ReadLine());
                        Console.WriteLine("Ingrese el sector del consultorio: ");
                        string sector = Console.ReadLine();

                        auxiliarServicios.AgregarConsultorio(new Consultorio(codigoConsultorio, numeroConsultorio, numeroPiso, sector));
                        Console.WriteLine("\nConsultorio agregado correctamente.\n");
                        break;

                    case 12:

                        Console.WriteLine("Ingrese el codigo del servicio: ");
                        codigoServicio = UInt32.Parse(Console.ReadLine());

                        while (listaServicios.BuscarCodigo(codigoServicio) == 1)
                        {
                            Console.WriteLine("El codigo ingresado no existe en el sistema. ");
                            Console.WriteLine("Ingrese el codigo del servicio: ");
                            codigoServicio = UInt32.Parse(Console.ReadLine());
                        }

                        auxiliarServicios = listaServicios.ObtenerServicio(codigoServicio);
                        Console.WriteLine("Consultorios: \n" + auxiliarServicios.MostrarConsultorios());

                        break;

                    case 13:
                        Console.WriteLine("Ingrese la historia clinica del paciente: ");
                        uint historia = uint.Parse(Console.ReadLine());

                        while (listaPacientes.BuscarPaciente(historia) == 0)
                        {
                            Console.WriteLine("La historia clinica ingresada ya existe en el sistema. ");
                            Console.WriteLine("Ingrese la historia clinica del paciente: ");
                            historia = UInt32.Parse(Console.ReadLine());
                        }

                        Console.WriteLine("Ingrese el numero de documento del paciente: ");
                        uint documento = uint.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese el/los apellidos del paciente: ");
                        string apellidos = Console.ReadLine();

                        Console.WriteLine("Ingrese el/los nombres de paciente: ");
                        string nombres = Console.ReadLine();

                        Console.WriteLine("Ingrese la fecha de nacimiento del paciente[dd/mm/aaaa]: ");
                        string fechaDeNacimiento = Console.ReadLine();

                        Console.WriteLine("Ingrese el sexo del paciente[masculino/femenino]:");
                        string sexo = Console.ReadLine();

                        Paciente pacienteNuevo = new Paciente(historia, documento, apellidos, nombres, fechaDeNacimiento, sexo);
                        listaPacientes.AgregarPaciente(pacienteNuevo);

                        Console.WriteLine("\nPaciente agregado.\n");
                        break;

                    case 14:
                        Console.WriteLine("Pacientes: ");
                        listaPacientes.MostrarPacientes();

                        break;

                    case 15:
                        Console.WriteLine("Ingrese la historia clinica del paciente: ");
                        historia = uint.Parse(Console.ReadLine());

                        while (listaPacientes.BuscarPaciente(historia) == 1)
                        {
                            Console.WriteLine("La historia clinica ingresada no existe en el sistema. ");
                            Console.WriteLine("Ingrese la historia clinica del paciente: ");
                            historia = UInt32.Parse(Console.ReadLine());
                        }

                        Console.WriteLine("Ingrese el codigo del servicio: ");
                        codigo = UInt32.Parse(Console.ReadLine());

                        while (listaServicios.BuscarCodigo(codigo) == 1)
                        {
                            Console.WriteLine("El codigo ingresado no existe en el sistema. ");
                            Console.WriteLine("Ingrese el codigo del servicio: ");
                            codigo = UInt32.Parse(Console.ReadLine());
                        }

                        ServiciosMedicos auxServicio = listaServicios.ObtenerServicio(codigo);
                        Paciente auxPaciente = listaPacientes.DarPaciente(historia);

                        Console.WriteLine("Ingrese la fecha de alta[dd/mm/aaaa]:");
                        string alta = Console.ReadLine();

                        auxServicio.AgregarPacientes(auxPaciente);
                        Console.WriteLine("Paciente dado de alta en el servicio");

                        break;

                    case 16:
                        Console.WriteLine("Ingrese la historia clinica del paciente: ");
                        uint historiaClinica = uint.Parse(Console.ReadLine());

                        while (listaPacientes.BuscarPaciente(historiaClinica) == 1)
                        {
                            Console.WriteLine("La historia clinica ingresada no existe en el sistema. ");
                            Console.WriteLine("Ingrese la historia clinica del paciente: ");
                            historiaClinica = UInt32.Parse(Console.ReadLine());
                        }

                        Console.WriteLine(listaServicios.MostrarPacientes(historiaClinica));

                        break;
                }
            }
        }
    }
}