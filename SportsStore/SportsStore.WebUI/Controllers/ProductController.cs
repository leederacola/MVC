using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
/*
 * In addition to removing the Index action method, I added a constructor that declares a dependency on the IProductRepository interface, 
 * which will lead Ninject to inject the dependency for the product repository when it instantiates the controller class. I also imported the 
 * SportsStore.Domain namespaces so that I can refer to the repository and model classes without having to qualify their names.  Next, I have
 * added an action method, called List, which will render a view showing the complete list of products, as shown in Listing 7-7.
 */
namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;

        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }
        public ViewResult List()
        {
            return View(repository.Products);
        }
    }
}