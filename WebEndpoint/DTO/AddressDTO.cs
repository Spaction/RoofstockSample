#nullable disable

namespace WebEndpoint.DTO.Models
{
    using System.Text.Json.Serialization;
    public class AddressDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string County { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string ZipPlus4 { get; set; }

        public AddressDTO() { }

        public AddressDTO(Property.EntityFramework.Models.Address a)
        {
            this.Id = a.Id;
            this.Address1 = a.Address1;
            this.Address2 = a.Address2;
            this.City = a.City;
            this.Country = a.Country;
            this.County = a.County;
            this.District = a.District;
            this.State = a.State;
            this.Zip = a.Zip;
            this.ZipPlus4 = a.ZipPlus4;
        }

        public Property.EntityFramework.Models.Address toAddress()
        {
            return new Property.EntityFramework.Models.Address()
            {
                Address1 = this.Address1,
                Address2 = this.Address2,
                City = this.City,
                Country = this.Country,
                County = this.County,
                District = this.District,
                State = this.State,
                Zip = this.Zip,
                ZipPlus4 = this.ZipPlus4,
        };
        }
    }
}
