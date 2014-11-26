using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTool.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly ILinqValueCalculator _valueCalculator;

        public IEnumerable<Product> Products { get; set; }
        public ShoppingCart(ILinqValueCalculator valueCalculator )
        {
            _valueCalculator = valueCalculator;
        }
        public decimal CalculateProductTotal()
        {
            return _valueCalculator.ValueProduct(Products);
        }
    }
}