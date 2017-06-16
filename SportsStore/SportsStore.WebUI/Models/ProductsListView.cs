using System.Collections.Generic;
using SportsStore.Domain.Entities;


/*
 * I added a property called CurrentCategory. The next step is to update the Product controller so that the
 *  List action method will filter Product objects by category and use the new property I added to the view model
 *  to indicate which category has been selected. The changes are shown in Listing 8-2.
 */
namespace SportsStore.WebUI.Models
{
    public class ProductsListViewModel
    {

        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}