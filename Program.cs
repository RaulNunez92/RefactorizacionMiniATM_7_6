namespace RefactorizacionATM;

internal class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("========================================================");
        Console.WriteLine("       INICIALIZACIÓN DEL SISTEMA BANCARIO              ");
        Console.WriteLine("========================================================");

        // Captura interactiva del cliente para evitar valores fijos (Zero Hardcoding)
        Console.Write("Ingrese el nombre completo del Titular: ");
        string titular = Console.ReadLine() ?? "Cliente General";

        Console.Write("Ingrese el Número de Cuenta: ");
        int.TryParse(Console.ReadLine(), out int noCuenta);
        if (noCuenta <= 0) noCuenta = 1001;

        Console.Write("Ingrese el Saldo Inicial de apertura: RD$ ");
        decimal.TryParse(Console.ReadLine(), out decimal saldoInicial);
        if (saldoInicial < 0) saldoInicial = 5000m;

        // Inyección de dependencias modular
        CuentaBancaria cuenta = new CuentaBancaria(noCuenta, titular, saldoInicial);
        ServicioATM servicio = new ServicioATM(cuenta);
        ConsolaATM consola = new ConsolaATM(servicio);

        // Arranque de la interfaz
        consola.Ejecutar();
    }
}
