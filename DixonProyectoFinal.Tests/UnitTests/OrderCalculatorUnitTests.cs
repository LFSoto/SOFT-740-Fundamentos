using Moq;
using Calculator.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DixonProyectoFinal.Tests.UnitTests
{
    [TestFixture]
    public class OrderCalculatorUnitTests
    {
        Mock<IDiscountService> _discount = new Mock<IDiscountService>();
        OrderCalculator orderCalculator;

        [SetUp]
        public void SetUp()
        {
            _discount.Setup(d => d.Discount).Returns(10.00);
            orderCalculator = new OrderCalculator(_discount.Object);
        }

        [Test]
        public void ShouldReturnTotalPriceOf_FourProducts_WithoutDiscount()
        {
            double[] productsPrices = [100.25, 125, 500.75, 400.60];

            double result = orderCalculator.CalculateTotalPrice(productsPrices);

            Assert.That(result, Is.EqualTo(1126.60));
        }
    }

   //TODO tests de 5 productos, 6 productos y 0 productos, además
   // implementar IPaymentService: Si es VISA o Mastercard procesar la compra si es AMEX no
   // implementar INotificacionService: si el correo el validos mostrar en el assert que la notificación fue enviada, de lo contrario mostrar un error de que no se envio por correo no valido.
}
