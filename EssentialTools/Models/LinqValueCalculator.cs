using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq;

namespace EssentialTools.Models
{
    public class LinqValueCalculator
    {
        public decimal ValueProducts(IEnumerable<Product> products)
        {
            //Ling Sum method for enumerable
            return products.Sum(p => p.Price);
        }

    }
}