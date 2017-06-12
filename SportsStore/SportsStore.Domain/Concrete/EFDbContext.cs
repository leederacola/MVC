using SportsStore.Domain.Entities;
using System.Data.Entity;


/*
 * To take advantage of the code-first feature, I need to create a class that is derived from System.Data.Entity.DbContext. 
 * This class then automatically defines a property for each table in the database that I want to work with.
 * The name of the property specifies the table, and the type parameter of the DbSet result specifies the model type that the 
 * Entity Framework should use to represent rows in that table. In this case, the property name is Products and the type parameter is Product, 
 * meaning that the Entity Framework should use the Product model type to represent rows in the Products table.
 * Next, I need to tell the Entity Framework how to connect to the database, which I do by adding a database connection string to the Web.config 
 * file in the SportsStore.WebUI project with the same name as the context class, as shown in Listing 7-13.
*/
namespace SportsStore.Domain.Concrete
{
    class EFDbContext : DbContext
    {
        public DbSet<Product>   Products { get; set; }
    }
}
