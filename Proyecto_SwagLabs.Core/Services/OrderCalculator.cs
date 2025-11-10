using Proyecto_SwagLabs.Core.Models;

namespace Proyecto_SwagLabs.Core.Services
{
    /// <summary>
    /// Clase responsable de aplicar las reglas de negocio para el cálculo
    /// de totales de una orden y del proceso básico de compra.
    /// </summary>
    public class OrderCalculator
    {
        private readonly IPaymentService _paymentService;
        private readonly INotificationService _notificationService;

        /// <summary>
        /// Cantidad mínima de productos a partir de la cual se aplica descuento.
        /// </summary>
        public int DiscountQuantityThreshold { get; }

        /// <summary>
        /// Porcentaje de descuento aplicado cuando se supera el umbral de cantidad.
        /// Por ejemplo, 0.10m = 10% de descuento.
        /// </summary>
        public decimal DiscountPercentage { get; }

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="OrderCalculator"/> con sus dependencias.
        /// </summary>
        /// <param name="paymentService">
        /// Servicio que realizará el cobro del pedido.
        /// </param>
        /// <param name="notificationService">
        /// Servicio que enviará la notificación tras una compra exitosa.
        /// </param>
        /// <param name="discountQuantityThreshold">
        /// Cantidad mínima de productos para aplicar descuentos (por defecto 5).
        /// </param>
        /// <param name="discountPercentage">
        /// Porcentaje de descuento a aplicar cuando se supera el umbral (por defecto 10%).
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Se lanza si <paramref name="paymentService"/> o <paramref name="notificationService"/> son nulos.
        /// </exception>
        public OrderCalculator(
            IPaymentService paymentService,
            INotificationService notificationService,
            int discountQuantityThreshold = 5,
            decimal discountPercentage = 0.10m)
        {
            _paymentService = paymentService ?? throw new ArgumentNullException(nameof(paymentService));
            _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));

            if (discountQuantityThreshold < 1)
                throw new ArgumentException("El umbral de descuento debe ser al menos 1.", nameof(discountQuantityThreshold));

            if (discountPercentage < 0 || discountPercentage > 1)
                throw new ArgumentException("El porcentaje de descuento debe estar entre 0 y 1.", nameof(discountPercentage));

            DiscountQuantityThreshold = discountQuantityThreshold;
            DiscountPercentage = discountPercentage;
        }

        /// <summary>
        /// Calcula el total a pagar para un conjunto de líneas de pedido,
        /// aplicando las reglas de negocio definidas.
        /// </summary>
        /// <param name="items">Colección de productos incluidos en el pedido.</param>
        /// <returns>Total final a pagar tras aplicar descuentos.</returns>
        /// <exception cref="InvalidOperationException">
        /// Se lanza si el carrito está vacío.
        /// </exception>
        public decimal CalculateTotal(IEnumerable<OrderItem> items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            var list = items.ToList();
            if (!list.Any())
                throw new InvalidOperationException("No se puede calcular el total de un carrito vacío.");

            var subtotal = list.Sum(i => i.Subtotal);
            var totalQuantity = list.Sum(i => i.Quantity);

            if (totalQuantity > DiscountQuantityThreshold)
            {
                var discountAmount = subtotal * DiscountPercentage;
                return subtotal - discountAmount;
            }

            return subtotal;
        }

        /// <summary>
        /// Procesa un pedido completo: calcula el total, intenta realizar el pago
        /// y, si tiene éxito, envía la notificación correspondiente.
        /// </summary>
        /// <param name="order">Pedido a procesar.</param>
        /// <returns>
        /// <c>true</c> si el pago fue exitoso y se envió la notificación;
        /// <c>false</c> si el pago fue rechazado.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Se lanza si <paramref name="order"/> es nulo.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Se lanza si la orden no contiene líneas (carrito vacío).
        /// </exception>
        public bool ProcessOrder(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));

            var total = CalculateTotal(order.Items);

            var paymentSucceeded = _paymentService.Charge(total);
            if (!paymentSucceeded)
                return false;

            _notificationService.NotifyOrderConfirmed(order);
            return true;
        }
    }
}
