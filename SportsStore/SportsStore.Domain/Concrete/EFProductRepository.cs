using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System.Collections.Generic;


/*
 * This is the repository class. It implements the IProductRepository interface and uses
 * an instance of EFDbContext to retrieve data from the database using the Entity Framework. 
 * You will see how I work with the Entity Framework (and how simple it is) as I add features to the repository.
 * To use the new repository class, I need to edit the Ninject bindings and replace the mock repository with a binding for the real one.
 * Edit the NinjectDependencyResolver.cs class file in the SportsStore.WebUI project so that the AddBindings method looks like Listing 7-15.
 */
namespace SportsStore.Domain.Concrete
{

    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }
    }
}