using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Lib
{
    /// <summary>
    /// Contiene los métodos para calcular el precio total de los productos en el carrito
    /// </summary>
    public class OrderCalculator
    {
        IDiscountService _discountService;

        public OrderCalculator(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        /// <summary>
        /// Calcula el precio total de los productos
        /// </summary>
        /// <returns>Precio total</returns>
        public double CalculateTotalPrice(double[] productsPrices)
        {
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
    }
}
