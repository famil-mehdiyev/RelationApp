using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OneToManyRelation.Context;
using OneToManyRelation.Dto_s;
using OneToManyRelation.Model;

namespace OneToManyRelation.Controllers
{
   
    [Route("/api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly PostgreSqlDbContext _dbContext;    
        private readonly RelationContext _context;
        private readonly IMapper _mapper;


        public ProductController(PostgreSqlDbContext dbContext,RelationContext relationContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _context = relationContext;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public IActionResult GetAll() 
        {
            IEnumerable<Product> product = _dbContext.Products.ToList();
            return StatusCode(201, product);
        }

        [HttpGet("id")]
        public IActionResult GetId(int id) {
            var gettingData = _dbContext.Products.FirstOrDefault(x => x.Id == id);
            return StatusCode(201, gettingData);

        }

        [HttpPost("Add")]
        public IActionResult Create(ProductDto productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
            //Product product1 = new Product()
            //{
            //    Name = productDto.Name,
            //    ManufactureYear = productDto.ManufactureYear,
            //    ManufacturingCountry = productDto.ManufacturingCountry,

            //};

            //var data = _context.Products.Add(product);
            _dbContext.Add(product);

            _dbContext.SaveChanges();

            return StatusCode(201, product);
        }



    }
}
