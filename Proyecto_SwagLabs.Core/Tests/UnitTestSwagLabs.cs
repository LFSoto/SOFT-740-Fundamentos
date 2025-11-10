using Moq;
using NUnit.Framework;
using Proyecto_SwagLabs.Core.Models;
using Proyecto_SwagLabs.Core.Services;

namespace Proyecto_SwagLabs.Core.Tests
{
    /// <summary>
    /// Pruebas unitarias para la clase <see cref="OrderCalculator"/>.
    /// </summary>
    [TestFixture]
    public class OrderCalculatorTests
    {
        private Mock<IPaymentService> _paymentServiceMock = null!;
        private Mock<INotificationService> _notificationServiceMock = null!;
        private OrderCalculator _calculator = null!;

        /// <summary>
        /// Se ejecuta antes de cada prueba.
        /// Inicializa los mocks y la instancia de <see cref="OrderCalculator"/>.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            _paymentServiceMock = new Mock<IPaymentService>(MockBehavior.Strict);
            _notificationServiceMock = new Mock<INotificationService>(MockBehavior.Strict);

            _calculator = new OrderCalculator(
                _paymentServiceMock.Object,
                _notificationServiceMock.Object,
                discountQuantityThreshold: 5,
                discountPercentage: 0.10m); // 10% de descuento
        }

        /// <summary>
        /// Verifica que se lance una excepción si se intenta calcular el total
        /// de un carrito vacío.
        /// </summary>
        [Test]
        public void CalculateTotal_WhenCartIsEmpty_ThrowsInvalidOperationException()
        {
            // Arrange
            var emptyItems = Array.Empty<OrderItem>();

            // Act + Assert
            Assert.Throws<InvalidOperationException>(
                () => _calculator.CalculateTotal(emptyItems));
        }

        /// <summary>
        /// Verifica que si la cantidad total de productos supera el umbral definido,
        /// se aplique el descuento correspondiente.
        /// </summary>
        [Test]
        public void CalculateTotal_WhenQuantityGreaterThanThreshold_AppliesDiscount()
        {
            // Arrange
            var items = new[]
            {
                new OrderItem("P1", "Producto 1", 10m, 3), // subtotal 30
                new OrderItem("P2", "Producto 2", 20m, 3)  // subtotal 60
            };
            // Subtotal = 90, cantidad total = 6 (>5) -> aplica 10% => total esperado = 81

            // Act
            var total = _calculator.CalculateTotal(items);

            // Assert
            Assert.That(total, Is.EqualTo(81m));
        }

        /// <summary>
        /// Verifica que si la cantidad total de productos no supera el umbral,
        /// no se aplique ningún descuento.
        /// </summary>
        [Test]
        public void CalculateTotal_WhenQuantityNotGreaterThanThreshold_NoDiscountApplied()
        {
            // Arrange
            var items = new[]
            {
                new OrderItem("P1", "Producto 1", 10m, 2), // 20
                new OrderItem("P2", "Producto 2", 15m, 3)  // 45
            };
            // Subtotal = 65, cantidad total = 5 (no >5) -> sin descuento

            // Act
            var total = _calculator.CalculateTotal(items);

            // Assert
            Assert.That(total, Is.EqualTo(65m));
        }

        /// <summary>
        /// Verifica que al procesar una orden válida, el servicio de pago
        /// reciba el monto correcto calculado por <see cref="OrderCalculator"/>.
        /// </summary>
        [Test]
        public void ProcessOrder_WhenCalled_ChargesCalculatedTotal()
        {
            // Arrange
            var items = new[]
            {
                new OrderItem("P1", "Producto 1", 10m, 3), // 30
                new OrderItem("P2", "Producto 2", 20m, 3)  // 60
            };
            var order = new Order(items);

            // Subtotal = 90, cantidad total = 6 -> aplica 10% descuento -> total = 81
            decimal? chargedAmount = null;

            _paymentServiceMock
                .Setup(p => p.Charge(It.IsAny<decimal>()))
                .Callback<decimal>(amount => chargedAmount = amount)
                .Returns(true);

            _notificationServiceMock
                .Setup(n => n.NotifyOrderConfirmed(order));

            // Act
            var result = _calculator.ProcessOrder(order);

            // Assert
            Assert.That(result, Is.True, "Se esperaba que el pago fuera exitoso.");
            Assert.That(chargedAmount, Is.EqualTo(81m), "El monto cobrado no coincide con el total esperado.");

            _paymentServiceMock.Verify(p => p.Charge(It.IsAny<decimal>()), Times.Once);
            _notificationServiceMock.Verify(n => n.NotifyOrderConfirmed(order), Times.Once);
        }

        /// <summary>
        /// Verifica que si el pago falla, no se envía ninguna notificación de pedido confirmado.
        /// </summary>
        [Test]
        public void ProcessOrder_WhenPaymentFails_DoesNotSendNotification()
        {
            // Arrange
            var items = new[]
            {
                new OrderItem("P1", "Producto 1", 50m, 1)
            };
            var order = new Order(items);

            _paymentServiceMock
                .Setup(p => p.Charge(It.IsAny<decimal>()))
                .Returns(false);

            // No se espera ninguna llamada a NotifyOrderConfirmed,
            // por lo que no configuramos Setup en el mock.

            // Act
            var result = _calculator.ProcessOrder(order);

            // Assert
            Assert.That(result, Is.False, "Se esperaba que el proceso de pago fuera rechazado.");

            _paymentServiceMock.Verify(p => p.Charge(It.IsAny<decimal>()), Times.Once);
            _notificationServiceMock.Verify(
                n => n.NotifyOrderConfirmed(It.IsAny<Order>()),
                Times.Never);
        }
    }
}
