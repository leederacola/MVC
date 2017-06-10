using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moq;
using Ninject;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
/*
 *  In Chapter 6, I showed you how to use Ninject to create a custom dependency resolver that the MVC Framework
 *  will use to instantiate objects across the application. I am going to repeat that process, starting with 
 *  adding an Infrastructure folder to the SportsStore.WebUI project and adding a class file called 
 *  NinjectDependencyResolver.cs to it. You can see the contents of the new file in Listing 7-1.
*/
/*
 * Making a Mock Repository
 *  I had to add a number of namespaces to the file for this addition, but the process I used to create the mock repository
 *  implementation uses the same Moq techniques I introduced in Chapter 6. I want Ninject to return the same mock object whenever
 *  it gets a request for an implementation of the IProductRepository interface, which is why I used the ToConstant method to set 
 *  the Ninject scope, like this:
        ...
        kernel.Bind<IProductRepository>().ToConstant(mock.Object) ;
        ...
 *  Rather than create a new instance of the implementation object each time, Ninject will always satisfy requests for the
 *  IProductRepository interface with the same mock object.
*/
namespace SportsStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }


        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product> {
                new Product { Name = "Football", Price = 25 },
                new Product { Name = "Surf board", Price = 179 },
                new Product { Name = "Running shoes", Price = 95 }
            });

            kernel.Bind<IProductRepository>().ToConstant(mock.Object);
        }
    }
}
