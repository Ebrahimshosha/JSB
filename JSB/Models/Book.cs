namespace JSB.Models;

public class Book
{
    public int BookId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double price { get; set; }
    public string Author { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }

}
