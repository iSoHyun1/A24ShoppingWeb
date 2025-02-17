using A24Shopping.Models;
using Microsoft.EntityFrameworkCore;

namespace A24Shopping.Repository
{
    public class SeedData
    {
        public static void SeedingData(DataContext _context)
        {
            _context.Database.Migrate();
            if (!_context.Products.Any())
            {

                CategoryModel men = new CategoryModel { Name = "Men", Slug = "men", Description = "Test Test 1", Status = 1 };
                CategoryModel women = new CategoryModel { Name = "Women", Slug = "women", Description = "Test Test 2", Status = 1 };
                CategoryModel kid = new CategoryModel { Name = "Kid", Slug = "kid", Description = "Test Test 3", Status = 1 };


                _context.Products.AddRange(
                    new ProductModel { Name = "Levents", Slug = "men", Description = "Levents is the best", Image = "1.jpg", Category = men, Price = 390 },
                    new ProductModel { Name = "Gucci", Slug = "women", Description = "gucci is the best", Image = "1.jpg", Category = women, Price = 1190 },
                    new ProductModel { Name = "Channel", Slug = "kid", Description = "channel is the best", Image = "1.jpg", Category = kid, Price = 3990 }
                );

                _context.SaveChanges();
            }
        }
    }
}
