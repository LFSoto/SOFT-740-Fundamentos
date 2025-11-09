using System.Text.RegularExpressions;

namespace Calculator.Lib
{
    /// <summary>
    /// Contiene los métodos para calcular el precio total de los productos en el carrito
    /// </summary>
    public class OrderCalculator
    {
        private IDiscountService _discountService;
        private IPaymentService _paymentService;
        private INotificationService _notificationService;

        private const string _validPaymentMethod1 = "MASTERCARD";
        private const string _validPaymentMethod2 = "VISA";

        public OrderCalculator(IDiscountService discountService, IPaymentService paymentService, INotificationService notificationService)
        {
            _discountService = discountService;
            _paymentService = paymentService;
            _notificationService = notificationService;
        }

        /// <summary>
        /// Calcula el precio total de los productos
        /// </summary>
        /// <returns>Precio total</returns>
        public double CalculateTotalPrice(double[] productsPrices)
        {
            ValidatePaymentMethod();
            ValidateEmail();
            double totalPrice = 0;
            try
            {
                foreach (double product in productsPrices)
                {
                    totalPrice += product;
                }

                if (productsPrices.Length > 5)
                {
                    double discount = totalPrice * (_discountService.Discount / 100);
                    totalPrice -= discount;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return totalPrice;
        }

        /// <summary>
        /// Valida si el método de pago es válido o no
        /// </summary>
        private void ValidatePaymentMethod()
        {
            if (!_paymentService.PaymentMehod.Equals(_validPaymentMethod1) && !_paymentService.PaymentMehod.Equals(_validPaymentMethod2))
            {
                throw new InvalidOperationException("Invalid Payment Method");
            }
        }

        /// <summary>
        /// Valida que el formato del correo sea correcto
        /// </summary>
        private void ValidateEmail()
        {
            string pattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";

            if (string.IsNullOrWhiteSpace(_notificationService.Email) || !Regex.IsMatch(_notificationService.Email, pattern))
            {
                throw new InvalidOperationException("Invalid Email format");
            }
        }
    }
}
