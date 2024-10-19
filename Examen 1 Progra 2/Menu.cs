using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Examen_1_Progra_2
{
    public class Menu
    {
        private Empleado[] empleados;
        private int contadorEmpleados;

        public Menu()
        {
            empleados = new Empleado[10];
            contadorEmpleados = 0;
        }

        public void mostrarMenu()
        {
            int opcion;
            do
            {
                Console.WriteLine("\n--- Menú Principal ---");
                Console.WriteLine("1. Inicializar Arreglos");
                Console.WriteLine("2. Agregar Empleados");
                Console.WriteLine("3. Consultar Empleados");
                Console.WriteLine("4. Modificar Empleados");
                Console.WriteLine("5. Borrar empleados");
                Console.WriteLine("6. Reportes");
                Console.WriteLine("7. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Entrada inválida. Por favor, ingrese un número.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        inicializarArreglos();
                        break;
                    case 2:
                        agregarEmpleado();
                        break;
                    case 3:
                        consultarEmpleado();
                        break;
                    case 4:
                        modificarEmpleado();
                        break;
                    case 5:
                        borrarEmpleado();
                        break;
                    case 6:
                        MostrarReportes();
                        break;
                    case 7:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            } while (opcion != 7);
        }

        public void inicializarArreglos()
        {
            empleados = new Empleado[10];
            contadorEmpleados = 0;
            Console.WriteLine("Arreglo Inicializado");
        }

        public void agregarEmpleado()
        {
            if (contadorEmpleados < 10)
            {
                Empleado empleado = new Empleado();

                Console.Write("Ingrese la cédula: ");
                empleado.Cedula = Console.ReadLine();
                Console.Write("Ingrese el nombre: ");
                empleado.Nombre = Console.ReadLine();
                Console.Write("Ingrese la dirección: ");
                empleado.Direccion = Console.ReadLine();
                Console.Write("Ingrese el teléfono: ");
                empleado.Telefono = Console.ReadLine();
                Console.Write("Ingrese el salario: ");

                if (!double.TryParse(Console.ReadLine(), out double salario))
                {
                    Console.WriteLine("Salario inválido. Debe ingresar un número.");
                    return;
                }
                empleado.Salario = salario;

                empleados[contadorEmpleados] = empleado;
                contadorEmpleados++;
                Console.WriteLine("Empleado agregado exitosamente.");
            }
            else
            {
                Console.WriteLine("No se pueden agregar más empleados");
            }
        }

        public void consultarEmpleado()
        {
            Console.WriteLine("Ingrese la cédula del empleado que quiere consultar: ");
            string cedula = Console.ReadLine();

            for (int i = 0; i < contadorEmpleados; i++)
            {
                if (empleados[i].Cedula == cedula)
                {
                    Console.WriteLine($"Cédula: {empleados[i].Cedula}, Nombre: {empleados[i].Nombre}, Dirección: {empleados[i].Direccion}, Teléfono: {empleados[i].Telefono}, Salario: {empleados[i].Salario}");
                    return;
                }
            }
            Console.WriteLine("Empleado no encontrado");
        }

        public void modificarEmpleado()
        {
            Console.WriteLine("Ingresa la cédula del empleado a modificar: ");
            string cedula = Console.ReadLine();

            for (int i = 0; i < contadorEmpleados; i++)
            {
                if (empleados[i].Cedula == cedula)
                {
                    Console.Write("Ingrese el nuevo nombre: ");
                    empleados[i].Nombre = Console.ReadLine();
                    Console.Write("Ingrese la nueva dirección: ");
                    empleados[i].Direccion = Console.ReadLine();
                    Console.Write("Ingrese el nuevo teléfono: ");
                    empleados[i].Telefono = Console.ReadLine();
                    Console.Write("Ingrese el nuevo salario: ");

                    if (!double.TryParse(Console.ReadLine(), out double salario))
                    {
                        Console.WriteLine("Salario inválido. Debe ingresar un número.");
                        return;
                    }
                    empleados[i].Salario = salario;

                    Console.WriteLine("Empleado modificado exitosamente.");
                    return;
                }
            }
            Console.WriteLine("Empleado no encontrado");
        }

        public void borrarEmpleado()
        {
            Console.WriteLine("Ingrese la cédula del empleado que desea eliminar: ");
            string cedula = Console.ReadLine();

            for (int i = 0; i < contadorEmpleados; i++)
            {
                if (empleados[i].Cedula == cedula)
                {
                    for (int j = i; j < contadorEmpleados - 1; j++)
                    {
                        empleados[j] = empleados[j + 1];
                    }
                    empleados[contadorEmpleados - 1] = null;
                    contadorEmpleados--;

                    Console.WriteLine("Empleado eliminado exitosamente.");
                    return;
                }
            }
            Console.WriteLine("Empleado no encontrado");
        }

        public void MostrarReportes()
        {
            Console.WriteLine("\n--- Menú de Reportes ---");
            Console.WriteLine("1. Listar empleados ordenados por nombre");
            Console.WriteLine("2. Calcular promedio de salarios");

            Console.Write("Seleccione una opción: ");
            if (!int.TryParse(Console.ReadLine(), out int opcion))
            {
                Console.WriteLine("Entrada inválida. Ingrese un número.");
                return;
            }

            switch (opcion)
            {
                case 1:
                    listarEmpleadosOrdenados();
                    break;
                case 2:
                    calcularPromedioSalarios();
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }

        public void listarEmpleadosOrdenados()
        {
            Empleado[] empleadosOrdenados = new Empleado[contadorEmpleados];
            Array.Copy(empleados, empleadosOrdenados, contadorEmpleados);
            Array.Sort(empleadosOrdenados, (e1, e2) => e1.Nombre.CompareTo(e2.Nombre));

            foreach (var empleado in empleadosOrdenados)
            {
                if (empleado != null)
                {
                    Console.WriteLine($"Nombre: {empleado.Nombre}, Cédula: {empleado.Cedula}, Dirección: {empleado.Direccion}, Teléfono: {empleado.Telefono}, Salario: {empleado.Salario}");
                }
            }
        }

        public void calcularPromedioSalarios()
        {
            double totalSalarios = 0;

            for (int i = 0; i < contadorEmpleados; i++)
            {
                totalSalarios += empleados[i].Salario;
            }

            if (contadorEmpleados > 0)
            {
                double promedio = totalSalarios / contadorEmpleados;
                Console.WriteLine($"El promedio de los salarios es: {promedio}");
            }
            else
            {
                Console.WriteLine("No hay empleados para calcular el promedio.");
            }
        }
    }
}
