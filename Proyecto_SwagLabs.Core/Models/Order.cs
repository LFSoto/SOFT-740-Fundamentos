using System.Collections.Generic;
using System.Linq;

namespace Proyecto_SwagLabs.Core.Models
{
    /// <summary>
    /// Representa un pedido completo (carrito de compra) con una colección de productos.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Identificador del pedido (opcional, útil si luego se integra con otros sistemas).
        /// </summary>
        public string? OrderId { get; }

        /// <summary>
        /// Colección de líneas de pedido asociadas a esta orden.
        /// </summary>
        public IReadOnlyCollection<OrderItem> Items { get; }

        /// <summary>
        /// Suma de los subtotales de todas las líneas del pedido.
        /// </summary>
        public decimal Subtotal => Items.Sum(i => i.Subtotal);

        /// <summary>
        /// Crea un nuevo pedido a partir de una colección de líneas.
        /// </summary>
        /// <param name="items">Líneas de pedido que componen la orden.</param>
        /// <param name="orderId">Identificador opcional del pedido.</param>
        public Order(IEnumerable<OrderItem> items, string? orderId = null)
        {
            Items = items?.ToList() ?? new List<OrderItem>();
            OrderId = orderId;
        }
    }
}
