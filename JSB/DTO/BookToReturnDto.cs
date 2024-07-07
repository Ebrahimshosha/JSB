namespace JSB.DTO;

public class BookToReturnDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public double price { get; set; }
    public string Author { get; set; } = null!;
    public int Stock { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = null!;
    public string CategoryDescription { get; set; } = null!;
}
