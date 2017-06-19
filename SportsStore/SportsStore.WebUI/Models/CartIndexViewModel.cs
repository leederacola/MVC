using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}
/*
 * The final point to note about the Cart controller is that both the AddToCart and RemoveFromCart methods call the RedirectToAction method. 
    This has the effect of sending an HTTP redirect instruction to the client browser, asking the browser to request a new URL. In this case,
    I have asked the browser to request a URL that will call the Index action method of the Cart controller.
    I am going to implement the Index method and use it to display the contents of the Cart. If you refer back to Figure 8-7, you will see that
    this is the workflow when the user clicks the Add to cart button.
 * I need to pass two pieces of information to the view that will display the contents of the cart: the Cart object and the URL to display if the
    user clicks the Continue shopping button. I created a new class file called CartIndexViewModel.cs in the Models folder of the SportsStore.WebUI project.
    The contents of this file are shown in Listing 8-15.
 */
