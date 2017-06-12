using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moq;
using Ninject;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;
using SportsStore.Domain.Entities;
/*
 *  In Chapter 6, I showed you how to use Ninject to create a custom dependency resolver that the MVC Framework
 *  will use to instantiate objects across the application. I am going to repeat that process, starting with 
 *  adding an Infrastructure folder to the SportsStore.WebUI project and adding a class file called 
 *  NinjectDependencyResolver.cs to it. You can see the contents of the new file in Listing 7-1.
 *
 * 
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
 *  
 *  
 *  
 * This is the repository class. It implements the IProductRepository interface and uses
 * an instance of EFDbContext to retrieve data from the database using the Entity Framework. 
 * You will see how I work with the Entity Framework (and how simple it is) as I add features to the repository.
 * To use the new repository class, I need to edit the Ninject bindings and replace the mock repository with a binding for the real one.
 * Edit the NinjectDependencyResolver.cs class file in the SportsStore.WebUI project so that the AddBindings method looks like Listing 7-15.
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
            kernel.Bind<IProductRepository>().To<EFProductRepository>();
        }
    }
}
