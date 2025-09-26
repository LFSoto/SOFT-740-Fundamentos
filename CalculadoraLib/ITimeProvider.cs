namespace CalculadoraLib
{
    ///
    /// Practica- Parte 3
    /// Crar una interfaz ITimeProvider con una propiedad Now de tipo DateTime.
    public interface ITimeProvider
    {
        DateTime Now { get; }
    }
}
