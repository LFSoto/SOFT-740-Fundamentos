using Moq;
using Calculator.Lib;

namespace DixonProyectoFinal.Tests.UnitTests
{
    [TestFixture]
    public class OrderCalculatorUnitTests
    {
        private Mock<IDiscountService> _discount = new Mock<IDiscountService>();
        private Mock<IPaymentService> _validPayment = new Mock<IPaymentService>();
        private Mock<IPaymentService> _invalidPayment = new Mock<IPaymentService>();
        private Mock<INotificationService> _validEmail = new Mock<INotificationService>();
        private Mock<INotificationService> _invalidEmail = new Mock<INotificationService>();

        private OrderCalculator? _orderCalculator;

        [SetUp]
        public void SetUp()
        {
            _discount.Setup(d => d.Discount).Returns(10.00);
            _validPayment.Setup(vp => vp.PaymentMehod).Returns("VISA");
            _invalidPayment.Setup(ip => ip.PaymentMehod).Returns("AMEX");
            _validEmail.Setup(ve => ve.Email).Returns("dixonc@test.com");
            _invalidEmail.Setup(ie => ie.Email).Returns("dixonc.com");
        }

        [Test]
        public void ShouldReturnTotalPriceOf_FourProducts_WithoutDiscount()
        {
            _orderCalculator = new OrderCalculator(_discount.Object, _validPayment.Object, _validEmail.Object);

            double[] productsPrices = [100.25, 125, 500.75, 400.60];
            double result = _orderCalculator.CalculateTotalPrice(productsPrices);

            Assert.That(result, Is.EqualTo(1126.60));
        }

        [Test]
        public void ShouldReturnTotalPriceOf_FiveProducts_WithoutDiscount()
        {
            _orderCalculator = new OrderCalculator(_discount.Object, _validPayment.Object, _validEmail.Object);

            double[] productsPrices = [100.25, 125, 500.75, 400.60, 500];
            double result = _orderCalculator.CalculateTotalPrice(productsPrices);

            Assert.That(result, Is.EqualTo(1626.60));
        }

        [Test]
        public void ShouldReturnTotalPriceOf_SixProducts_WithDiscount()
        {
            _orderCalculator = new OrderCalculator(_discount.Object, _validPayment.Object, _validEmail.Object);

            double[] productsPrices = [100.25, 125, 500.75, 400.60, 500.67, 745.38];
            double result = _orderCalculator.CalculateTotalPrice(productsPrices);

            Assert.That(result, Is.EqualTo(2135.385));
        }

        [Test]
        public void ShouldReturnInvalidPaymentMethod()
        {
            _orderCalculator = new OrderCalculator(_discount.Object, _invalidPayment.Object, _validEmail.Object);

            double[] productsPrices = [100.25, 125, 500.75, 400.60];

            Assert.Throws<InvalidOperationException>(() => _orderCalculator.CalculateTotalPrice(productsPrices));
        }

        [Test]
        public void ShouldReturnInvalidEmailFormat()
        {
            _orderCalculator = new OrderCalculator(_discount.Object, _validPayment.Object, _invalidEmail.Object);

            double[] productsPrices = [100.25, 125, 500.75, 400.60];

            Assert.Throws<InvalidOperationException>(() => _orderCalculator.CalculateTotalPrice(productsPrices));
        }
    }
}
