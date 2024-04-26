
namespace Domain
{
    public class Beer
    {
        public int BeerID { get; set; }
        public string Name { get; set; }
        public int BrandID { get; set; }
        public virtual Brand Brand { get; set; }
    }
}
