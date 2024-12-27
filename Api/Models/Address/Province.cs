namespace Api.Models.Address
{
    public class Province
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Regionid { get; set; }
        public Region Region { get; set; }
        public ICollection<CityMunicipality> CityMunicipalities { get; set; }
    }
}
