using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;

/*
Building a Category Navigation Menu
I need to provide customers with a way to select a category that does not involve typing in URLs. This means presenting them with a list of the categories 
available and indicating which, if any, is currently selected. As I build out the application, I will use this list of categories in more than one controller, 
so I need something that is self-contained and reusable. The ASP.NET MVC Framework has the concept of child actions, which are perfect for creating items
such as a reusable navigation control. A child action relies on the HTML helper method called Html.Action, which lets you include the output from an 
arbitrary action method in the current view. In this case, I can create a new controller (I will call it NavController) with an action method
(which I will call Menu) that renders a navigation menu. I will then use the Html.Action helper method to inject the output from that method into the layout.
This approach gives me a real controller that can contain whatever application logic I need and that can be unit tested like any other controller. 
It is a nice way of creating smaller segments of an application while preserving the overall MVC Framework approach.
 */
namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        /* add a constructor that accepts an IProductRepository implementation as its argument. 
         This has the effect of declaring a dependency that Ninject will resolve when it creates instances of the NavController class. 
         */
        private IProductRepository repository;

        public NavController(IProductRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
 
            IEnumerable<string> cartgories = repository.Products
                                        .Select(x => x.Category)
                                        .Distinct()
                                        .OrderBy(x => x);

            return PartialView(cartgories);
        }
    }
}