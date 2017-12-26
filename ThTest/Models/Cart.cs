using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Th.Models;

namespace ThTest.Models
{
    public class Cart
    {
        private IList<CartLine> CartLines { get; set; } = new List<CartLine>();

        public virtual IEnumerable<CartLine> Lines => this.CartLines;

        public virtual void AddItem(Product mdProduct, int quantity = 1)
        {
            CartLine vmLine = this.CartLines.Where(p => p.Product.Id == mdProduct.Id).FirstOrDefault();

            if (vmLine == null)
            {
                this.CartLines.Add(new CartLine
                {
                    Product = mdProduct,
                    Quantity = quantity,
                });
            }
            else
            {
                vmLine.Quantity++;
            }
        }

        public virtual void RemoveLine(Product mdProduct)
        {
            this.CartLines.Remove(this.CartLines.FirstOrDefault(c => c.Product.Id == mdProduct.Id));
        }

        public virtual decimal ComputeTotal()
        {
            return this.CartLines.Sum(cl => cl.Product.UnitPrice * cl.Quantity);
        }

        public virtual decimal ComputeQuantity()
        {
            return this.CartLines.Sum(cl => cl.Quantity);
        }

        public virtual bool IsEmpty
        {
            get
            {
                return this.Lines.Count() == 0;
            }
        }

        public virtual void Clear()
        {
            this.CartLines.Clear();
        }
    }
}
