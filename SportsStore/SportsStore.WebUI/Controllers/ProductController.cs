using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;


/*
 * I added a property called CurrentCategory (productListView model). The next step is to update the Product controller so that the List action method
 *  will filter Product objects by category and use the new property I added to the view model to indicate which category
 *  has been selected. The changes are shown in Listing 8-2.
 */
namespace SportsStore.WebUI.Controllers
{

    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;

        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        public ViewResult List(string category, int page = 1)   //added string category to pram for filtering
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products
                .Where(p => category == null || p.Category == category) //added new LINQ expression Where for filtering
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Products.Count()
                },
                CurrentCategory = category  //this updates current category
            };
            return View(model);
        }
    }
}