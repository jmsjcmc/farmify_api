namespace Api.Models.Address
{
    public class Barangay
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Citymunicipalityid { get; set; }
        public CityMunicipality CityMunicipality { get; set; }
    }
}
