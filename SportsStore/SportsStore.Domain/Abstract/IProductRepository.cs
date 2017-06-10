using System.Collections.Generic;
using SportsStore.Domain.Entities;


/*
 * This interface uses IEnumerable<T> to allow a caller to obtain a sequence of Product objects, without saying how or 
 * where the data is stored or retrieved. A class that depends on the IProductRepository interface can obtain Product 
 * objects without needing to know anything about where they are coming from or how the implementation class will deliver them. 
 * This is the essence of the repository pattern. I will revisit the IProductRepository interface throughout the development process to add features.
 */

namespace SportsStore.Domain.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }
}
