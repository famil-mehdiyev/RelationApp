using OneToManyRelation.Model.Base;

namespace OneToManyRelation.Model
{
    public class Category : BaseModel

    {
     
        public ICollection<Product> Products { get; set; }   
    }
}
