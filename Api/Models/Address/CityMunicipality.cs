namespace Api.Models.Address
{
    public class CityMunicipality
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Provinceid { get; set; }
        public Province Province { get; set; }
        public ICollection<Barangay> Barangays { get; set; }
    }
}
