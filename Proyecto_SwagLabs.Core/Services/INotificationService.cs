using Proyecto_SwagLabs.Core.Models;

namespace Proyecto_SwagLabs.Core.Services
{
    /// <summary>
    /// Servicio responsable de enviar notificaciones relacionadas con pedidos.
    /// </summary>
    public interface INotificationService
    {
        /// <summary>
        /// Envía una notificación indicando que el pedido fue confirmado.
        /// </summary>
        /// <param name="order">Pedido confirmado.</param>
        void NotifyOrderConfirmed(Order order);
    }
}
