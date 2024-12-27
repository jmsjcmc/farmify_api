namespace Api.Models.Address
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Province> Provinces { get; set; }
    }
}
