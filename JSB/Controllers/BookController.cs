
namespace JSB.Controllers;

public class BookController : BaseApiController
{
    private readonly StoreContext _context;
    private readonly IMapper _mapper;

    public BookController(StoreContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IReadOnlyList<BookToReturnDto>> GetAllBooks()
    {
        var Books = _context.Books.Include(b => b.Category).ToList();
        

        var bookToReturnDto = _mapper.Map<IEnumerable<BookToReturnDto>>(Books);

        return Ok(bookToReturnDto);
    }


    [HttpGet("{id}")]
    public ActionResult<BookToReturnDto> GetBook(int id)
    {
        var book = _context.Books.Include(b => b.Category).SingleOrDefault(b => b.BookId == id);
        if (book == null) { return NotFound(); }
        
        var bookToReturnDto = _mapper.Map<BookToReturnDto>(book);

        return Ok(bookToReturnDto);
    }


    [HttpPost]
    public ActionResult<BookToReturnDto> AddBook(BookDTO bookDTO)
    {
        if (bookDTO == null) { return BadRequest(); }

        var IsValidCategoryId = _context.Categories.Any(c => c.CategoryId == bookDTO.CategoryId);
        if (!IsValidCategoryId)
            return BadRequest("InValid CategoryId");

        var book = _mapper.Map<Book>(bookDTO);

        _context.Books.Add(book);
        _context.SaveChanges();

        var bookToReturnDto = _mapper.Map<BookToReturnDto>(book);

        return Ok(bookToReturnDto);
    }


    [HttpPut("{id}")]
    public ActionResult<BookToReturnDto> PutBook(int id, [FromBody] BookDTO bookDTO)
    {
        if (bookDTO == null) { return BadRequest(); }

        var book = _context.Books.SingleOrDefault(b => b.BookId == id);
        if (book == null) { return NotFound(); }

        var IsValidCategoryId = _context.Categories.Any(c => c.CategoryId == bookDTO.CategoryId);
        if (!IsValidCategoryId)
            return BadRequest("InValid CategoryId");

        book = _mapper.Map<Book>(bookDTO);

        _context.Books.Update(book);
        _context.SaveChanges();

        var bookToReturnDto = _mapper.Map<BookToReturnDto>(book);

        //return RedirectToAction(nameof(GetBook), id);
        return Ok(bookToReturnDto);

    }


    [HttpDelete("{id}")]
    public ActionResult<bool> DeleteBook(int id)
    {
        if (id < 0) return BadRequest("Not exists negative Id's ");
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
