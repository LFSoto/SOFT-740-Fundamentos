using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Proyecto_SwagLabs.Tests.Pages
{
    /// <summary>
    /// Página de listado de productos (inventario) de SwagLabs.
    /// Permite consultar, agregar y eliminar productos del carrito de compras.
    /// </summary>
    public class ProductsPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public ProductsPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        #region Elementos de la página

        /// <summary>
        /// Colección de productos visibles en el inventario
        /// (cada uno es un <div class="inventory_item">).
        /// </summary>
        private IReadOnlyCollection<IWebElement> InventoryItems =>
            _driver.FindElements(By.CssSelector("div.inventory_item"));

        /// <summary>
        /// Icono del carrito en el header.
        /// </summary>
        private IWebElement CartIcon =>
            _driver.FindElement(By.CssSelector("a.shopping_cart_link"));

        /// <summary>
        /// Badge del carrito que muestra la cantidad de productos.
        /// Si el carrito está vacío, este elemento no existe.
        /// </summary>
        private IWebElement? CartBadge =>
            _driver.FindElements(By.CssSelector(".shopping_cart_link .shopping_cart_badge"))
                   .FirstOrDefault();

        /// <summary>
        /// Ítems listados en la página de carrito.
        /// </summary>
        private IReadOnlyCollection<IWebElement> CartItems =>
            _driver.FindElements(By.CssSelector("div.cart_item"));

        /// <summary>
        /// Botón "Continue Shopping" en la página de carrito.
        /// </summary>
        private IWebElement ContinueShoppingButton =>
            _driver.FindElement(By.CssSelector("button[data-test='continue-shopping']"));

        #endregion

        #region Navegación

        /// <summary>
        /// Navega a la página del carrito haciendo clic en el ícono correspondiente.
        /// </summary>
        public void GoToCart()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(CartIcon)).Click();
            _wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div.cart_list")));
        }

        #endregion

        #region Utilidades de carrito

        /// <summary>
        /// Devuelve la cantidad de productos actualmente en el carrito.
        /// </summary>
        public int GetCartItemCount()
        {
            var badge = CartBadge;
            if (badge == null)
                return 0;

            return int.TryParse(badge.Text.Trim(), out var count)
                ? count
                : 0;
        }

        /// <summary>
        /// Limpia el carrito si contiene productos.
        /// Si ya está vacío, no hace nada.
        /// </summary>
        public void ClearCartIfNotEmpty()
        {
            if (GetCartItemCount() == 0)
                return;

            GoToCart();

            while (true)
            {
                var items = CartItems;
                if (items.Count == 0)
                    break;

                var firstItem = items.First();
                var removeButton = firstItem.FindElement(By.CssSelector("button[data-test^='remove-']"));
                _wait.Until(ExpectedConditions.ElementToBeClickable(removeButton)).Click();
            }

            _wait.Until(ExpectedConditions.ElementToBeClickable(ContinueShoppingButton)).Click();
            _wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div.inventory_list")));
        }

        #endregion

        #region Alta de productos al carrito

        /// <summary>
        /// Agrega uno o varios productos al carrito según su nombre visible.
        /// Antes de agregar, valida si el carrito tiene productos y los elimina.
        /// </summary>
        /// <param name="productNames">Lista de nombres de productos visibles en pantalla.</param>
        /// <exception cref="ArgumentException">Si no se pasa ningún producto.</exception>
        /// <exception cref="InvalidOperationException">Si un producto no existe en el listado.</exception>
        public void AddProductsToCartByName(params string[] productNames)
        {
            if (productNames is null || productNames.Length == 0)
                throw new ArgumentException("Debe especificar al menos un nombre de producto.", nameof(productNames));

            ClearCartIfNotEmpty();

            var remaining = new HashSet<string>(
                productNames.Select(p => p.Trim()),
                StringComparer.OrdinalIgnoreCase
            );

            _wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div.inventory_list")));

            foreach (var item in InventoryItems)
            {
                var nameElement = item.FindElement(By.CssSelector("div.inventory_item_name"));
                var nameText = nameElement.Text.Trim();

                if (!remaining.Contains(nameText))
                    continue;

                var addToCartButton = item.FindElement(By.CssSelector("button.btn_inventory"));
                _wait.Until(ExpectedConditions.ElementToBeClickable(addToCartButton)).Click();

                remaining.Remove(nameText);

                if (!remaining.Any())
                    break;
            }

            if (remaining.Any())
            {
                var notFound = string.Join(", ", remaining);
                throw new InvalidOperationException(
                    $"No se encontraron en la página los siguientes productos: {notFound}");
            }
        }

        #endregion
    }
}

