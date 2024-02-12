//ejercicio 24
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    class Transaccion
    {
        public string Descripcion { get; set; }
        public double Monto { get; set; }
    }

    static List<Transaccion> ingresos = new List<Transaccion>();
    static List<Transaccion> egresos = new List<Transaccion>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Bienvenido al administrador de ingresos y egresos del hogar");
            Console.WriteLine("1. Agregar ingreso");
            Console.WriteLine("2. Agregar egreso");
            Console.WriteLine("3. Mostrar todos los registros");
            Console.WriteLine("4. Mostrar ingresos");
            Console.WriteLine("5. Mostrar egresos");
            Console.WriteLine("6. Editar registro");
            Console.WriteLine("7. Eliminar registro");
            Console.WriteLine("8. Salir");

            Console.Write("Seleccione una opción: ");
            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    AgregarTransaccion(ingresos);
                    break;
                case 2:
                    AgregarTransaccion(egresos);
                    break;
                case 3:
                    MostrarRegistros(ingresos.Concat(egresos).ToList());
                    break;
                case 4:
                    MostrarRegistros(ingresos);
                    break;
                case 5:
                    MostrarRegistros(egresos);
                    break;
                case 6:
                    EditarRegistro();
                    break;
                case 7:
                    EliminarRegistro();
                    break;
                case 8:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }
    }

    static void AgregarTransaccion(List<Transaccion> lista)
    {
        Console.Write("Ingrese la descripción: ");
        string descripcion = Console.ReadLine();
        Console.Write("Ingrese el monto: ");
        double monto = Convert.ToDouble(Console.ReadLine());

        lista.Add(new Transaccion { Descripcion = descripcion, Monto = monto });
        Console.WriteLine("Transacción agregada correctamente.");
    }

    static void MostrarRegistros(List<Transaccion> lista)
    {
        if (lista.Count == 0)
        {
            Console.WriteLine("No hay registros para mostrar.");
            return;
        }

        foreach (var transaccion in lista)
        {
            Console.WriteLine($"Descripción: {transaccion.Descripcion}, Monto: {transaccion.Monto}");
        }
    }

    static void EditarRegistro()
    {
        Console.WriteLine("Seleccione el tipo de registro a editar:");
        Console.WriteLine("1. Ingreso");
        Console.WriteLine("2. Egreso");
        Console.Write("Opción: ");
        int tipo = Convert.ToInt32(Console.ReadLine());

        List<Transaccion> lista;
        if (tipo == 1)
            lista = ingresos;
        else if (tipo == 2)
            lista = egresos;
        else
        {
            Console.WriteLine("Opción no válida.");
            return;
        }

        Console.Write("Ingrese el índice del registro a editar: ");
        int indice = Convert.ToInt32(Console.ReadLine());

        if (indice < 0 || indice >= lista.Count)
        {
            Console.WriteLine("Índice fuera de rango.");
            return;
        }

        Console.Write("Ingrese la nueva descripción: ");
        string nuevaDescripcion = Console.ReadLine();
        Console.Write("Ingrese el nuevo monto: ");
        double nuevoMonto = Convert.ToDouble(Console.ReadLine());

        lista[indice].Descripcion = nuevaDescripcion;
        lista[indice].Monto = nuevoMonto;

        Console.WriteLine("Registro editado correctamente.");
    }

    static void EliminarRegistro()
    {
        Console.WriteLine("Seleccione el tipo de registro a eliminar:");
        Console.WriteLine("1. Ingreso");
        Console.WriteLine("2. Egreso");
        Console.Write("Opción: ");
        int tipo = Convert.ToInt32(Console.ReadLine());

        List<Transaccion> lista;
        if (tipo == 1)
            lista = ingresos;
        else if (tipo == 2)
            lista = egresos;
        else
        {
            Console.WriteLine("Opción no válida.");
            return;
        }

        Console.Write("Ingrese el índice del registro a eliminar: ");
        int indice = Convert.ToInt32(Console.ReadLine());

        if (indice < 0 || indice >= lista.Count)
        {
            Console.WriteLine("Índice fuera de rango.");
            return;
        }

        lista.RemoveAt(indice);
        Console.WriteLine("Registro eliminado correctamente.");
    }
}
