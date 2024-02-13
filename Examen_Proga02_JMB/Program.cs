using System;

class Program
{
    static int[] numeroFactura = new int[15];
    static string[] numeroPlaca = new string[15];
    static string[] hora = new string[15];
    static DateTime[] fecha = new DateTime[15];
    static int[] tipoVehiculo = new int[15];
    static int[] numeroCaseta = new int[15];
    static double[] montoPagar = new double[15];
    static double[] pagaCon = new double[15];
    static double[] vuelto = new double[15];

    static void Main(string[] args)
    {
        ConfigurarConsola();

        int opcion;
        do
        {
            MostrarEncabezado("Sistema de Control de Peaje");

            Console.WriteLine("Menú Principal");
            Console.WriteLine("1. Inicializar Vectores");
            Console.WriteLine("2. Ingresar Paso Vehicular");
            Console.WriteLine("3. Consulta de vehículos por Número de Placa");
            Console.WriteLine("4. Modificar Datos de Vehículos por Número de Placa");
            Console.WriteLine("5. Reporte Todos los Datos de los vectores");
            Console.WriteLine("6. Salir");

            Console.Write("Seleccione una opción: ");
            opcion = LeerEntero();

            switch (opcion)
            {
                case 1:
                    InicializarVectores();
                    break;
                case 2:
                    IngresoPasoVehicular();
                    break;
                case 3:
                    ConsultaVehiculosNumeroPlaca();
                    break;
                case 4:
                    ModificarDatosVehiculosNumeroPlaca();
                    break;
                case 5:
                    ReporteTodosLosDatos();
                    break;
                case 6:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default: //valida si no cumple
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                    break;
            }

        } while (opcion != 6);
    }

    static void InicializarVectores()
    {
        for (int i = 0; i < 15; i++)
        {
            numeroFactura[i] = 0;
            numeroPlaca[i] = "";
            hora[i] = "";
            fecha[i] = DateTime.MinValue;
            tipoVehiculo[i] = 0;
            numeroCaseta[i] = 0;
            montoPagar[i] = 0;
            pagaCon[i] = 0;
            vuelto[i] = 0;
        }
        Console.WriteLine("Vectores inicializados correctamente\n");
    }

    static void IngresoPasoVehicular()
    {
        for (int i = 0; i < 15; i++)
        {
            Console.WriteLine($"Registrar Paso Vehicular #{i + 1}");

            Console.Write("Número de Factura: ");
            numeroFactura[i] = LeerEntero();

            Console.Write("Número de Placa: ");
            numeroPlaca[i] = Console.ReadLine();

            Console.Write("Fecha (dd/MM/yyyy): ");
            fecha[i] = LeerFecha();

            Console.Write("Hora (HH:mm): ");
            hora[i] = Console.ReadLine();

            Console.WriteLine("Tipo de Vehículo (1=Moto, 2=Vehículo Liviano, 3=Camión o Pesado, 4=Autobús): ");
            tipoVehiculo[i] = LeerEntero();

            Console.WriteLine("Número de Caseta (1, 2, 3): ");
            numeroCaseta[i] = LeerEntero();

            montoPagar[i] = CalcularMontoAPagar(tipoVehiculo[i]);

            Console.WriteLine($"Monto a Pagar: ¢{montoPagar[i]}");

            Console.Write("Paga con: ¢");
            pagaCon[i] = LeerDouble();

            vuelto[i] = pagaCon[i] - montoPagar[i];

            Console.WriteLine($"Vuelto: ¢{vuelto[i]}");

            Console.Write("¿Desea ingresar otro paso vehicular? (S/N): ");
            string continuar = Console.ReadLine().ToUpper();
            if (continuar != "S")
                break;
        }
    }

    static void ConsultaVehiculosNumeroPlaca()
    {
        Console.Write("Ingrese el número de placa a buscar: ");
        string placaBuscada = Console.ReadLine();

        for (int i = 0; i < 15; i++)
        {
            if (numeroPlaca[i].Equals(placaBuscada, StringComparison.OrdinalIgnoreCase))
            {
                MostrarResultadoVehiculo(i);
                break;
            }
        }
    }

    static void ModificarDatosVehiculosNumeroPlaca()
    {
        Console.Write("Ingrese el número de placa a modificar: ");
        string placaModificar = Console.ReadLine();

        int indiceModificar = -1;

        for (int i = 0; i < 15; i++)
        {
            if (numeroPlaca[i].Equals(placaModificar, StringComparison.OrdinalIgnoreCase))
            {
                indiceModificar = i;
                break;
            }
        }

        if (indiceModificar != -1)
        {
            Console.WriteLine("Datos del Vehículo:");
            MostrarResultadoVehiculo(indiceModificar);

            Console.WriteLine("Seleccione el campo a modificar:");
            Console.WriteLine("1. Número de Factura");
            Console.WriteLine("2. Número de Placa");


            Console.Write("Ingrese la opción: ");
            int opcionModificar = LeerEntero();

            switch (opcionModificar)
            {
                case 1:
                    Console.Write("Nuevo Número de Factura: ");
                    numeroFactura[indiceModificar] = LeerEntero();
                    break;
                case 2:
                    Console.Write("Nuevo Número de Placa: ");
                    numeroPlaca[indiceModificar] = Console.ReadLine();
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            Console.WriteLine("Modificación realizada con éxito.");
        }
        else
        {
            Console.WriteLine("No se encontró ningún vehículo con la placa proporcionada.");
        }
    }

    static void ReporteTodosLosDatos()
    {
        Console.WriteLine("=== Reporte de Todos los Datos ===");
        Console.WriteLine("N factura\tPlaca\tTipo de vehículo\tCaseta\tMonto Pagar\tPaga con\tVuelto");
        Console.WriteLine("=============================================================================");

        for (int i = 0; i < 15; i++)
        {
            Console.WriteLine($"{numeroFactura[i]}\t\t{numeroPlaca[i]}\t\t{tipoVehiculo[i]}\t\t{numeroCaseta[i]}\t\t{montoPagar[i]}\t\t{pagaCon[i]}\t\t{vuelto[i]}");
        }

        Console.WriteLine("=============================================================================");
    }

    static void MostrarResultadoVehiculo(int indice)
    {
        Console.WriteLine($"Número de Factura: {numeroFactura[indice]}");
        Console.WriteLine($"Número de Placa: {numeroPlaca[indice]}");
        Console.WriteLine($"Fecha: {fecha[indice].ToString("dd/MM/yyyy")}");
        Console.WriteLine($"Hora: {hora[indice]}");
        Console.WriteLine($"Tipo de Vehículo: {tipoVehiculo[indice]}");
        Console.WriteLine($"Número de Caseta: {numeroCaseta[indice]}");
        Console.WriteLine($"Monto a Pagar: ¢{montoPagar[indice]}");
        Console.WriteLine($"Paga con: ¢{pagaCon[indice]}");
        Console.WriteLine($"Vuelto: ¢{vuelto[indice]}");
    }

    static double CalcularMontoAPagar(int tipoVehiculo)
    {
        switch (tipoVehiculo)
        {
            case 1: // Si es Motocicleta
                return 500;
            case 2: // Si es Vehículo Liviano
                return 700;
            case 3: // Si esCamión o Pesado
                return 2700;
            case 4: // Si es Autobús
                return 3700;
            default:
                return 0;
        }
    }

    static void MostrarEncabezado(string titulo)
    {
        Console.SetCursorPosition((Console.WindowWidth - titulo.Length) / 2, Console.CursorTop);
        Console.WriteLine(titulo + "\n");
    }

    static void ConfigurarConsola()
    {
        Console.Title = "Sistema de Control de Peaje";

        Console.WindowWidth = 120;
        Console.WindowHeight = 30;
        Console.BufferWidth = 120;
        Console.BufferHeight = 300;
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Clear();
    }

    static int LeerEntero()
    {
        int numero;
        while (!int.TryParse(Console.ReadLine(), out numero))
        {
            Console.Write("Entrada no válida. Por favor, ingrese un número entero: ");
        }
        return numero;
    }

    static double LeerDouble()
    {
        double numero;
        while (!double.TryParse(Console.ReadLine(), out numero))
        {
            Console.Write("Entrada no válida. Por favor, ingrese un número: ");
        }
        return numero;
    }

    static DateTime LeerFecha()
    {
        DateTime fecha;
        while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fecha))
        {
            Console.Write("Formato de fecha incorrecto. Ingrese la fecha en formato dd/MM/yyyy: ");
        }
        return fecha;
    }
}
