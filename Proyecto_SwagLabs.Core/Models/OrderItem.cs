namespace Proyecto_SwagLabs.Core.Models
{
    /// <summary>
    /// Representa una línea de pedido (un producto dentro del carrito).
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// Código único del producto (SKU o identificador interno).
        /// </summary>
        public string ProductCode { get; }

        /// <summary>
        /// Nombre descriptivo del producto.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Precio unitario del producto.
        /// </summary>
        public decimal UnitPrice { get; }

        /// <summary>
        /// Cantidad de unidades del producto incluidas en el pedido.
        /// </summary>
        public int Quantity { get; }

        /// <summary>
        /// Subtotal de la línea (UnitPrice × Quantity).
        /// </summary>
        public decimal Subtotal => UnitPrice * Quantity;

        /// <summary>
        /// Crea una nueva línea de pedido.
        /// </summary>
        /// <param name="productCode">Código único del producto.</param>
        /// <param name="name">Nombre descriptivo del producto.</param>
        /// <param name="unitPrice">Precio unitario del producto.</param>
        /// <param name="quantity">Cantidad de unidades.</param>
        /// <exception cref="ArgumentException">
        /// Se lanza si <paramref name="productCode"/> o <paramref name="name"/> están vacíos,
        /// o si <paramref name="quantity"/> es menor o igual a cero,
        /// o si <paramref name="unitPrice"/> es menor que cero.
        /// </exception>
        public OrderItem(string productCode, string name, decimal unitPrice, int quantity)
        {
            if (string.IsNullOrWhiteSpace(productCode))
                throw new ArgumentException("El código de producto es obligatorio.", nameof(productCode));

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("El nombre del producto es obligatorio.", nameof(name));

            if (unitPrice < 0)
                throw new ArgumentException("El precio unitario no puede ser negativo.", nameof(unitPrice));

            if (quantity <= 0)
                throw new ArgumentException("La cantidad debe ser mayor que cero.", nameof(quantity));

            ProductCode = productCode;
            Name = name;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }
    }
}
