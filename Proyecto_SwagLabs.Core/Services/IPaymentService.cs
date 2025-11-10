namespace Proyecto_SwagLabs.Core.Services
{
    /// <summary>
    /// Servicio responsable de procesar pagos de pedidos.
    /// En un entorno real, podría llamar a un gateway de pago externo.
    /// </summary>
    public interface IPaymentService
    {
        /// <summary>
        /// Intenta cobrar el importe indicado.
        /// </summary>
        /// <param name="amount">Importe a cobrar.</param>
        /// <returns>
        /// <c>true</c> si el cobro fue exitoso; <c>false</c> en caso contrario.
        /// </returns>
        bool Charge(decimal amount);
    }
}
