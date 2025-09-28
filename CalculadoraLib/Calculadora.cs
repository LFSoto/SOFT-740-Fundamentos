namespace CalculadoraLib;

public class Calculadora
{
    ITimeProvider _timeProvider;
    public Calculadora(ITimeProvider timeProvider)
    {
        _timeProvider = timeProvider;
    }

    public int Sumar(int a, int b)
    {
        var now = _timeProvider.Now;
        if (now.Hour < 8 || now.Hour >= 18)
        {
            throw new InvalidOperationException("Operación realiza fuera de horario.");
        }
        return a + b;


    }

    public int Restar(int a, int b)
    {
        var now = _timeProvider.Now;
        if (now.Hour < 8 || now.Hour >= 18)
        {
            throw new InvalidOperationException("Operación realiza fuera de horario.");
        }
        return a - b;
    }

    public int Multiplicar(int a, int b)
    {
        var now = _timeProvider.Now;
        if (now.Hour < 8 || now.Hour >= 18)
        {
            throw new InvalidOperationException("Operación realiza fuera de horario.");
        }
        return a * b;

    }
   

    public double Dividir(int a, int b)
    {
        var now = _timeProvider.Now;
        if (b == 0) throw new DivideByZeroException("No se puede dividir entre cero.");
        else if (now.Hour < 8 || now.Hour >= 18)
        {
            throw new InvalidOperationException("Operación realiza fuera de horario.");
        }
        return (double)a / b;
    }
}