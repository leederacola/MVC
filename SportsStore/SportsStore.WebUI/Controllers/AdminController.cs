using System.Web.Mvc;
using SportsStore.Domain.Abstract;

namespace SportsStore.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IProductRepository repository;

        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Products);
        }
    }
}
/*
 * The controller constructor declares a dependency on the IProductRepository interface, 
 * which Ninject will resolve when instances are created. The controller defines a single action method, 
 * Index, that calls the View method to select the default view for the action, passing the set of
 *  products in the database as the view model.
 */
