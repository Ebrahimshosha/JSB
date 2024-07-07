using JSB.Data;
using JSB.DTO;
using JSB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JSB.Controllers;

public class CategoryController : BaseApiController
{
    private readonly StoreContext _context;

    public CategoryController(StoreContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IReadOnlyList<Category>> GetAllCategories()
    {
        var Categories = _context.Categories.ToList();
        return Ok(Categories);
    }


    [HttpGet("{id}")]
    public ActionResult<Category> Getcategory(int id)
    {
        var category = _context.Categories.SingleOrDefault(b => b.CategoryId == id);
        
        return Ok(category);
    }


    [HttpPost]
    public ActionResult<Category> AddCategory(CategoryDTO categoryDTO)
    {
        if (categoryDTO == null) { return BadRequest(); }

        var category = new Category()
        {
            Name = categoryDTO.Name,
            Description = categoryDTO.Description
        };

        _context.Categories.Add(category);
        _context.SaveChanges();
        return Ok(category);
    }


    [HttpPut("{id}")]
    public ActionResult<Category> PutCategory(int id, [FromBody] CategoryDTO categoryDTO)
    {
        if (categoryDTO == null) { return BadRequest(); }

        var category = _context.Categories.SingleOrDefault(b => b.CategoryId == id);
        if (category == null) { return NotFound(); }

        category.Name = categoryDTO.Name;
        category.Description = categoryDTO.Description;

        _context.Categories.Update(category);
        _context.SaveChanges();

        return Ok(category);

    }


    [HttpDelete("{id}")]
    public ActionResult<bool> Deletecategory(int id)
    {
        if (id < 0) return BadRequest();
        var Category = _context.Categories.SingleOrDefault(b => b.CategoryId == id);
        if (Category == null)
        {
            return NotFound();
        };
        _context.Categories.Remove(Category);
        _context.SaveChanges();
        return Ok(true);
    }
}
