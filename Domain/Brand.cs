
namespace Domain
{
    public class Brand
    {
        public int BrandID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Beer> Beers { get; set; }
    }
}
