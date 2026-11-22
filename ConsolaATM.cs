namespace RefactorizacionATM;

public class ConsolaATM
{
    private readonly ServicioATM _servicio;

    public ConsolaATM(ServicioATM servicio)
    {
        _servicio = servicio ?? throw new ArgumentNullException(nameof(servicio));
    }

    public void Ejecutar()
    {
        bool sesionActiva = true;

        do
        {
            MostrarMenu();
            byte opcion = LeerOpcionMenu(); // Optimización de tipo: byte (1 byte)

            switch (opcion)
            {
                case 1:
                    MostrarSaldo();
                    break;

                case 2:
                    ProcesarDeposito();
                    break;

                case 3:
                    ProcesarRetiro();
                    break;

                case 4:
                    Console.WriteLine("\n>> Sesión finalizada con éxito. Gracias por usar nuestro cajero.");
                    sesionActiva = false;
                    break;

                default:
                    Console.WriteLine("\n>> Error: Opción no válida. Por favor, seleccione un número del 1 al 4.");
                    Pausar();
                    break;
            }

        } while (sesionActiva);
    }

    private void MostrarMenu()
    {
        Console.WriteLine("\n========================================================");
        Console.WriteLine("           BANCO NACIONAL - SISTEMA ATM REFACTORIZADO   ");
        Console.WriteLine($" Titular: {_servicio.ObtenerTitular()} | Cuenta: #{_servicio.ObtenerNumeroCuenta()}");
        Console.WriteLine("========================================================");
        Console.WriteLine("1. Consultar Saldo");
        Console.WriteLine("2. Depositar Dinero");
        Console.WriteLine("3. Retirar Dinero");
        Console.WriteLine("4. Salir");
        Console.WriteLine("--------------------------------------------------------");
        Console.Write("Seleccione una opción: ");
    }

    private static byte LeerOpcionMenu()
    {
        byte.TryParse(Console.ReadLine() ?? "", out byte opcion);
        return opcion;
    }

    private void MostrarSaldo()
    {
        Console.WriteLine($"\n>> Su saldo contable disponible es: RD$ {_servicio.ObtenerSaldo():N2}");
        Pausar();
    }

    private void ProcesarDeposito()
    {
        decimal monto = CapturarMontoValido("\nIngrese el monto a depositar: RD$ ");
        var resultado = _servicio.RealizarDeposito(monto);

        Console.WriteLine(resultado.Exito ? $">> {resultado.Mensaje}" : $">> [RECHAZADO] {resultado.Mensaje}");
        Pausar();
    }

    private void ProcesarRetiro()
    {
        decimal monto = CapturarMontoValido("\nIngrese el monto a retirar: RD$ ");
        var resultado = _servicio.RealizarRetiro(monto);

        Console.WriteLine(resultado.Exito ? $">> {resultado.Mensaje}" : $">> [RECHAZADO] {resultado.Mensaje}");
        Pausar();
    }

    private static decimal CapturarMontoValido(string mensaje)
    {
        decimal monto;
        Console.Write(mensaje);

        while (!decimal.TryParse(Console.ReadLine(), out monto) || monto <= 0)
        {
            Console.WriteLine(">> Error: Ingrese un valor numérico positivo.");
            Console.Write(mensaje);
        }

        return monto;
    }

    private static void Pausar()
    {
        Console.WriteLine("\nPresione Enter para continuar...");
        Console.ReadLine();
    }
}

