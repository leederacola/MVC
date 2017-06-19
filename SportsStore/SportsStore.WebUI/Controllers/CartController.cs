using System.Linq;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{

    public class CartController : Controller
    {
        private IProductRepository repository;

        public CartController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                ReturnUrl = returnUrl,
                Cart = cart
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int productId,
                string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId,
                string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
    }
}
/*
 * I have removed the GetCart method and added a Cart parameter to each of the action methods. When the MVC Framework receives a request that 
 * requires, say, the AddToCart method to be invoked, it begins by looking at the parameters for the action method. It looks at the list of binders
 *  available and tries to find one that can create instances of each parameter type. The custom binder is asked to create a Cart object, and it
 *   does so by working with the session state feature. Between the custom binder and the default binder, the MVC Framework is able to create the set
 *    of parameters required to call the action method, allowing me to refactor the controller so that it has no knowledge of how Cart objects are 
 *    created when requests are received. There are several benefits to using a custom model binder like this. The first is that I have separated the
 *     logic used to create a Cart from that of the controller, which allows me to change the way I store Cart objects without needing to change the controller. 
 *     The second benefit is that any controller class that works with Cart objects can simply declare them as action method parameters and take advantage 
 *     of the custom model binder. The third benefit, and the one I think is most important, is that I can now unit test the Cart controller without needing
 *      to mock a lot of ASP.NET plumbing.
 */
