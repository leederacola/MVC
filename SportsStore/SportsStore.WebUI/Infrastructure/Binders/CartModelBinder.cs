using System.Web.Mvc;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Infrastructure.Binders
{

    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {

            // get the Cart from the session

            Cart cart = null;
            if (controllerContext.HttpContext.Session != null)
            {
                cart = (Cart)controllerContext.HttpContext.Session[sessionKey];
            }
            // create the Cart if there wasn't one in the session data
            if (cart == null)
            {
                cart = new Cart();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = cart;
                }
            }
            // return the cart
            return cart;
        }
    }
}
/*
 * I create a custom model binder by implementing the System.Web.Mvc.IModelBinder interface. To create this implementation, 
 * I added a new folder in the SportsStore.WebUI project called Infrastructure/Binders and created a CartModelBinder.cs class
 * file inside it. Listing 9-1 shows the contents of the new file.
 * 
 * The IModelBinder interface defines one method: BindModel. The two parameters are provided to make creating the domain model object possible. 
 * The ControllerContext provides access to all the information that the controller class has, which includes details of the request from the client.
 *  The ModelBindingContext gives you information about the model object you are being asked to build and some tools for making the binding process easier.
 *  For my purposes, the ControllerContext class is the one I am interested in. It has an HttpContext property, which in turn has a Session property that
 *   lets me get and set session data. I can obtain the Cart object associated with the user's session by reading a value from the session data, 
 *   and create a Cart if there is not one there already.I need to tell the MVC Framework that it can use the CartModelBinder class to create instances of Cart.
 *    I do this in the Application_Start method of Global.asax, as shown in Listing 9-2.
 */
