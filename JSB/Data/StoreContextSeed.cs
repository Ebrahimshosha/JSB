
namespace JSB.Data;

public static class StoreContextSeed
{
    public static async Task seedAsync(StoreContext context)
    {
        if (!context.Categories.Any())
        {

            var CategoriesData = File.ReadAllText("../JSB/Data/Dataseed/Categories.json");
            var Categories = JsonSerializer.Deserialize<List<Category>>(CategoriesData);


            if (Categories?.Count() > 0)
            {
                foreach (var Category in Categories)
                {
                    await context.Set<Category>().AddAsync(Category);
                }
                context.SaveChanges();
            }
        }

        if (!context.Books.Any())
        {
            var BooksData = File.ReadAllText("../JSB/Data/Dataseed/Book.json");
            // ../TalabatRebosatiory/Data/Dataseed/brands.json"
            var Books = JsonSerializer.Deserialize<List<Book>>(BooksData);


            if (Books?.Count() > 0)
            {
                foreach (var Book in Books)
                {
                    await context.Set<Book>().AddAsync(Book);
                }
                context.SaveChanges();
            }
        }

        
    }
}
