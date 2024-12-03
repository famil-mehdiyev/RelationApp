using OneToManyRelation.Model;

namespace OneToManyRelation.Dto_s
{
    public class ProductDto
    {
        public string Name { get; set; }
        public int ManufactureYear { get; set; }
        public string ManufacturingCountry { get; set; }

        public int CategoryId { get; set; }

    }
}
