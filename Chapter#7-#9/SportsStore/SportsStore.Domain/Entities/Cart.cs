﻿using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Domain.Entities
{
    public class Cart
    {
        private readonly List<CartLine> _lineCollection = new List<CartLine>();

        public void AddItem(Product product, int quantity)
        {
            var line = _lineCollection.FirstOrDefault(p => p.Product.ProductId == product.ProductId);

            if (line == null)
            {
                _lineCollection.Add(new CartLine {Product = product, Quantity = quantity});
            }
            else line.Quantity += quantity;
        }

        public void RemoveLine(Product product)
        {
            _lineCollection.RemoveAll(p => p.Product.ProductId == product.ProductId);
        }

        public decimal ComputeTotalValue()
        {
            return _lineCollection.Sum(l => l.Product.Price*l.Quantity);
        }

        public void Clear()
        {
            _lineCollection.Clear();
        }

        public List<CartLine> Lines
        {
            get { return _lineCollection.ToList(); }
        }
    }
}
