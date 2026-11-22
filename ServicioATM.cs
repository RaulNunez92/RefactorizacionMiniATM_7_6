namespace RefactorizacionATM;

public class ServicioATM
{
    private readonly CuentaBancaria _cuenta;

    public ServicioATM(CuentaBancaria cuenta)
    {
        _cuenta = cuenta ?? throw new ArgumentNullException(nameof(cuenta));
    }

    public int ObtenerNumeroCuenta() => _cuenta.NumeroCuenta;
    public string ObtenerTitular() => _cuenta.Titular;
    public decimal ObtenerSaldo() => _cuenta.Saldo;

    public (bool Exito, string Mensaje) RealizarDeposito(decimal monto)
    {
        if (_cuenta.Depositar(monto, out string error))
        {
            return (true, $"Depósito exitoso de RD$ {monto:N2}. Saldo actual: RD$ {_cuenta.Saldo:N2}");
        }

        return (false, $"Error en depósito: {error}");
    }

    public (bool Exito, string Mensaje) RealizarRetiro(decimal monto)
    {
        if (_cuenta.Retirar(monto, out string error))
        {
            return (true, $"Retiro exitoso de RD$ {monto:N2}. Saldo restante: RD$ {_cuenta.Saldo:N2}");
        }

        return (false, $"Error en retiro: {error}");
    }
}