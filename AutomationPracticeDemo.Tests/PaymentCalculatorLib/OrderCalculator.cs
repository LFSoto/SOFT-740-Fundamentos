namespace AutomationSauceDemo.CalculatorLib;
public class OrderCalculator
{
    IPaymentService paymentService;
    INotificationService notificationService;
    public OrderCalculator(IPaymentService payService, INotificationService notifyService)
    {
        paymentService = payService;
        notificationService = notifyService;
    }//ctor

    public decimal ApplyDiscount(Products[] products, decimal discountAmount)
    {
        decimal total = GetTotalPrice(products) - discountAmount;
        // Use ApplyPayment so the payment result triggers notifications
        ApplyPayment(total);
        Console.WriteLine($"Final price after applying discount: {total}");
        return total;
    }//CalculateTotalPrice

    public decimal GetTotalPrice(Products[] products)
    {
        decimal total = 0;
        foreach (var product in products)
        {
            total += product.GetProductPrice();
        }//foreach
        Console.WriteLine($"Total price of products in the cart: {total}");
        return total;
    }//GetTotalPrice

    public decimal ApplyPayment(decimal amount)
    {
        // Validate amount
        if (amount <= 0)
        {
            Console.WriteLine("Invalid payment amount. The shopping cart is empty!!");
            throw new InvalidOperationException("Invalid payment amount. The shopping cart is empty!!");
        }

        // Process payment
        bool paymentSuccess = paymentService.ProcessPayment(amount);

        // Send notification based on payment result
        if (paymentSuccess)
        {
            notificationService.SendNotification("Payment processed successfully.");
            Console.WriteLine("Payment processed successfully.");
        }
        else
        {
            notificationService.SendNotification("Payment failed. Please try again.");
            Console.WriteLine("Payment failed. Please try again.");
        }
        return amount;
    }//ApplyPayment
    public decimal CalculateDiscountAmount(Products[] products, decimal totalPrice, decimal discountPercentage)
    {
        decimal discountAmount = 0;
        if (IsDiscountApplicable(products))
        {
            discountAmount = (discountPercentage / 100) * totalPrice;
            Console.WriteLine($"Discount of {discountPercentage}% applicable. Discount Amount: {discountAmount}");
        }
        return discountAmount;
    }//ApplyDiscount

    public bool IsDiscountApplicable(Products[] products)
    {
        if (products == null || products.Length == 0)
            return false;
        else if (products.Length > 5)
        {
            Console.WriteLine("More than 5 products in the cart. Discount applicable.");
            return true;
        }
        else
            Console.WriteLine("5 or fewer products in the cart. No discount applicable.");
        return false;
    }//IsDiscountApplicable
}//class

