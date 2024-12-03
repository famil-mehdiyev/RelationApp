using OneToManyRelation.Model.Base;

namespace OneToManyRelation.Model
{
    public class Product :  BaseModel
    {
     
        public int ManufactureYear { get; set; }
        public string ManufacturingCountry { get; set; }
        public int CategoryId { get; set; }
        public Category Categories { get; set; }
    }
}
