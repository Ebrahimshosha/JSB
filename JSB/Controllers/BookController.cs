using JSB.Data;
using JSB.DTO;
using JSB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JSB.Controllers;

public class BookController : BaseApiController
{
    private readonly StoreContext _context;

    public BookController(StoreContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IReadOnlyList<BookToReturnDto>> GetAllBooks()
    {
        var Books = _context.Books.Include(b => b.Category).ToList();
        var BooksToReturnDto = new List<BookToReturnDto>();
        foreach (var book in Books)
        {
            var bookToReturnDto = new BookToReturnDto()
            {
                Id = book.BookId,
                Name = book.Name,
                Author = book.Author,
                CategoryId = book.CategoryId,
                Description = book.Description,
                price = book.price,
                Stock = book.Stock,
                CategoryDescription = book.Category.Description,
                CategoryName = book.Category.Name

            };
            BooksToReturnDto.Add(bookToReturnDto);
        };
        return Ok(BooksToReturnDto);
    }


    [HttpGet("{id}")]
    public ActionResult<BookToReturnDto> GetBook(int id)
    {
        var book = _context.Books.Include(b => b.Category).SingleOrDefault(b => b.BookId == id);
        if (book == null) { return NotFound(); }
        var bookToReturnDto = new BookToReturnDto()
        {
            Id = book.BookId,
            Name = book.Name,
            Author = book.Author,
            CategoryId = book.CategoryId,
            Description = book.Description,
            price = book.price,
            Stock = book.Stock,
            CategoryDescription = book.Category.Description,
            CategoryName = book.Category.Name
            
        };
        return Ok(bookToReturnDto);
    }


    [HttpPost]
    public ActionResult<Book> AddBook(BookDTO bookDTO)
    {
        if (bookDTO == null) { return BadRequest(); }
        var book = new Book()
        {
            Name = bookDTO.Name,
            Author = bookDTO.Author,
            CategoryId = bookDTO.CategoryId,
            price = bookDTO.price,
            Stock = bookDTO.Stock,
            Description = bookDTO.Description
        };
        _context.Books.Add(book);
        _context.SaveChanges();
        return Ok(book);
    }


    [HttpPut("{id}")]
    public ActionResult<Book> PutBook(int id, [FromBody] BookDTO bookDTO)
    {
        if (bookDTO == null) { return BadRequest(); }

        var book = _context.Books.SingleOrDefault(b => b.BookId == id);
        if (book == null) { return NotFound(); }

        book.Author = bookDTO.Author;
        book.Name = bookDTO.Name;
        book.CategoryId = bookDTO.CategoryId;
        book.Description = bookDTO.Description;
        book.Stock = bookDTO.Stock;
        book.price = bookDTO.price;

        _context.Books.Update(book);
        _context.SaveChanges();

        return Ok(book);

    }


    [HttpDelete("{id}")]
    public ActionResult<bool> DeleteBook(int id)
    {
        if (id < 0) return BadRequest();
        var book = _context.Books.SingleOrDefault(b => b.BookId == id);
        if (book == null)
        {
            return NotFound();
        };
        _context.Books.Remove(book);
        _context.SaveChanges();
        return Ok(true);
    }
}
