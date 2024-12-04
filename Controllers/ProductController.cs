using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OneToManyRelation.Context;
using OneToManyRelation.Dto_s;
using OneToManyRelation.Model;

namespace OneToManyRelation.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly RelationContext _context;
        private readonly IMapper _mapper;


        public ProductController(RelationContext relationContext/*, IMapper mapper*/)
        {
            _context = relationContext;
            //_mapper = mapper;
        }

        [HttpGet("all")]
        public IActionResult GetAll() 
        {
            IEnumerable<Product> product = _context.Products.ToList();
            return StatusCode(201, product);
        }

        [HttpGet("id")]
        public IActionResult GetId(int id) {
            var gettingData = _context.Products.FirstOrDefault(x => x.Id == id);
            return StatusCode(201, gettingData);

        }

        //[HttpPost("Add")]
        //public IActionResult Create(ProductDto productDto)
        //{
        //    Product product = _mapper.Map<Product>(productDto);
        //    //Product product1 = new Product()
        //    //{
        //    //    Name = productDto.Name,
        //    //    ManufactureYear = productDto.ManufactureYear,
        //    //    ManufacturingCountry = productDto.ManufacturingCountry,

        //    //};

        //    //var data = _context.Products.Add(product);
        //    _context.Add(product);
            
        //    _context.SaveChanges();

        //    return StatusCode(201,product);
        //}



    }
}
