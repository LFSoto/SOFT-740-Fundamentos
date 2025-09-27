namespace CalculadoraLib;

public class Calculadora
{
    ITimeProvider _timerProvider;
    public Calculadora(ITimeProvider timeProvider) {

        _timerProvider = timeProvider;

    }

    private void ValidarHoras() {
        var now = _timerProvider.Now;
        if (now.Hour < 8 || now.Hour >= 18)
        {

            throw new InvalidOperationException("Operación no permitida fuera del horario hábil (08:00 - 18:00).");

        }
    }

    public int Sumar(int a, int b) {
        ValidarHoras();
        return a + b;
    }

    public int Restar(int a, int b) {
        ValidarHoras();
        return a - b;
    }

    public int Multiplicar(int a, int b) => a * b;

    public double Dividir(int a, int b)
    {
        if (b == 0) throw new DivideByZeroException("No se puede dividir entre cero.");
        return (double)a / b;
    }
}