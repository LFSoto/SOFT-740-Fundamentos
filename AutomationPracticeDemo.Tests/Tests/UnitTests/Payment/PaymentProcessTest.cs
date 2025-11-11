using AutomationSauceDemo.CalculatorLib;
using Moq;

namespace AutomationSauceDemo.Tests.UnitTests.Payment;

[TestFixture]
public class PaymentProcessTest
{
    private Mock<IPaymentService> mockPaymentService;
    private Mock<INotificationService> mockNotificationService;
    private OrderCalculator orderCalculator;

    [SetUp]
    public void Setup()
    {
        mockPaymentService = new Mock<IPaymentService>();
        mockNotificationService = new Mock<INotificationService>();
        orderCalculator = new OrderCalculator(mockPaymentService.Object, mockNotificationService.Object);
    }//Setup

    /********************************************************
    Scenario: Process payment with discount applied
    ********************************************************/
    [Test]
    public void ProcessPaymentWithDiscount()
    {
        // Arrange
        var products = new Products[]
        {
            new Products("Product1",100),
            new Products("Product2",200),
            new Products("Product3",300),
            new Products("Product4",400),
            new Products("Product5",500),
            new Products("Product6",600)
        };
        // Calculate expected final price before invoking ApplyDiscount so we can configure the mock
        decimal totalPrice = orderCalculator.GetTotalPrice(products);
        decimal discountPercentage = 10; //10% discount
        decimal discountAmount = orderCalculator.CalculateDiscountAmount(products, totalPrice, discountPercentage);
        decimal expectedFinalPrice = totalPrice - discountAmount;

        // Configure mock to return true when ProcessPayment is called with the expected final price
        mockPaymentService.Setup(ps => ps.ProcessPayment(expectedFinalPrice)).Returns(true);

        // Act
        decimal finalPrice = orderCalculator.ApplyDiscount(products, discountAmount);
        // Assert
        Assert.That(finalPrice, Is.EqualTo(expectedFinalPrice));
        // Verify that ProcessPayment was called with the correct final price
        mockPaymentService.Verify(ps => ps.ProcessPayment(expectedFinalPrice), Times.Once);
        mockNotificationService.Verify(ns => ns.SendNotification("Payment processed successfully."), Times.Once);
    }//ProcessPaymentWithApplyDiscount

    /********************************************************
    Scenario: Process payment without discount applied
    ********************************************************/
    [Test]
    public void ProcessPaymentWithoutDiscount()
    {
        var products = new Products[] {
            new Products("Product1",150),
            new Products("Product2",250)
        };
        // Calculate expected final price before invoking ApplyDiscount so we can configure the mock
        decimal totalPrice = orderCalculator.GetTotalPrice(products);
        decimal discountPercentage = 10; //10% discount
        decimal discountAmount = orderCalculator.CalculateDiscountAmount(products, totalPrice, discountPercentage);
        decimal expectedFinalPrice = totalPrice - discountAmount; // should be equal to totalPrice when no discount applies

        // Configure mock to return true when ProcessPayment is called with the expected final price
        mockPaymentService.Setup(ps => ps.ProcessPayment(expectedFinalPrice)).Returns(true);

        // Act
        decimal finalPrice = orderCalculator.ApplyDiscount(products, discountAmount);
        // Assert
        Assert.That(finalPrice, Is.EqualTo(expectedFinalPrice));
        // Verify that ProcessPayment was called with the correct final price
        mockPaymentService.Verify(ps => ps.ProcessPayment(expectedFinalPrice), Times.Once);
        mockNotificationService.Verify(ns => ns.SendNotification("Payment processed successfully."), Times.Once);
    }//ProcessPaymentWithoutApplyDiscount

    /********************************************************
    Scenario: Process payment failure
    ********************************************************/
    [Test]
    public void ProcessPaymentFailure()
    {
        // Arrange
        var products = new Products[]
        {
            new Products("Product1",1000),
            new Products("Product2",2000)
        };
        // Calculate expected final price before invoking ApplyDiscount so we can configure the mock
        decimal totalPrice = orderCalculator.GetTotalPrice(products);
        decimal discountPercentage = 5; //5% discount
        decimal discountAmount = orderCalculator.CalculateDiscountAmount(products, totalPrice, discountPercentage);
        decimal expectedFinalPrice = totalPrice - discountAmount;
        // Configure mock to return false to simulate payment failure
        mockPaymentService.Setup(ps => ps.ProcessPayment(expectedFinalPrice)).Returns(false);
        // Act
        decimal finalPrice = orderCalculator.ApplyDiscount(products, discountAmount);
        // Assert
        Assert.That(finalPrice, Is.EqualTo(expectedFinalPrice));
        // Verify that ProcessPayment was called with the correct final price
        mockPaymentService.Verify(ps => ps.ProcessPayment(expectedFinalPrice), Times.Once);
        mockNotificationService.Verify(ns => ns.SendNotification("Payment failed. Please try again."), Times.Once);
    }//ProcessPaymentFailure

    /********************************************************
    Scenario: Process payment failure by empty cart products
    ********************************************************/
    [Test]
    public void ProcessPaymentFailureByEmptyCart()
    {
        // Arrange
        // Empty products array to simulate empty cart
        var products = new Products[] { };
        // Calculate expected final price before configuring the mock
        decimal totalPrice = orderCalculator.GetTotalPrice(products);
        // Assert
        Assert.Throws<InvalidOperationException>(() => orderCalculator.ApplyPayment(totalPrice));
        // Verify that ProcessPayment was NOT called because the method should throw before attempting payment
        mockPaymentService.Verify(ps => ps.ProcessPayment(totalPrice), Times.Never);
        // Verify that notification was NOT sent when operation throws
        mockNotificationService.Verify(ns => ns.SendNotification("Payment failed. Please try again."), Times.Never);
    }//ProcessPaymentFailure
}//class
