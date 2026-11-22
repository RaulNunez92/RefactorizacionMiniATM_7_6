namespace RefactorizacionATM;

public class CuentaBancaria
{
    public int NumeroCuenta { get; }
    public string Titular { get; }
    public decimal Saldo { get; private set; }

    public CuentaBancaria(int numeroCuenta, string titular, decimal saldoInicial)
    {
        if (numeroCuenta <= 0)
            throw new ArgumentException("El número de cuenta debe ser positivo.");

        if (string.IsNullOrWhiteSpace(titular))
            throw new ArgumentException("El titular no puede estar vacío.");

        if (saldoInicial < 0)
            throw new ArgumentException("El saldo inicial no puede ser negativo.");

        NumeroCuenta = numeroCuenta;
        Titular = titular;
        Saldo = saldoInicial;
    }

    public bool Depositar(decimal monto, out string mensajeError)
    {
        if (monto <= 0)
        {
            mensajeError = "El monto a depositar debe ser mayor que cero.";
            return false;
        }

        Saldo += monto;
        mensajeError = string.Empty;
        return true;
    }

    public bool Retirar(decimal monto, out string mensajeError)
    {
        if (monto <= 0)
        {
            mensajeError = "El monto a retirar debe ser mayor que cero.";
            return false;
        }

        if (monto > Saldo)
        {
            mensajeError = $"Fondos insuficientes. Su saldo disponible es: RD$ {Saldo:N2}";
            return false;
        }

        Saldo -= monto;
        mensajeError = string.Empty;
        return true;
    }
}