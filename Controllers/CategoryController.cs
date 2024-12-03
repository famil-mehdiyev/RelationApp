using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneToManyRelation.Context;
using OneToManyRelation.Dto_s;
using OneToManyRelation.Model;

namespace OneToManyRelation.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CategoryController : ControllerBase
    {

        private readonly RelationContext _context;
        private readonly IMapper _mapper;

        public CategoryController(RelationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("All")]
        public IActionResult GetAll()
        {

            List<Category> categories = _context.Categories.Include(c => c.Products).ToList();
            //List<Category> categories = _context.Categories
            //                         .Include(c => c.Products)
            //                         .Where(c => c.Products.Any(p => p.Name == "Mercedes"))
            //                         .Select(c => new Category
            //                         {
            //                             Id = c.Id,
            //                             Name = c.Name,
            //                             Products = c.Products.Where(p => p.Name == "Mercedes").ToList()
            //                         })
            //                         .ToList();


            return Ok(categories);
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {

            var gettingData = _context.Categories.FirstOrDefault(x=>x.Id==id);

            if (gettingData == null)
            {
                return BadRequest("bu Id-ye uygun hec bir melumat tapilmadi!!!");
            }
            return StatusCode(201, gettingData);
        }

        [HttpPost("Add")]
        public IActionResult Create(CategoryDto dto)
        {
            Category category = _mapper.Map<Category>(dto);
            _context.Add(category);
            _context.SaveChanges();

            return StatusCode(201, category);
        }

        //[HttpPut("update")]

    }
}
