#nullable disable

namespace WebEndpoint.DTO.Models
{
    public class PropertyDTO
    {
        public int Id { get; set; }
        public string YearBuilt { get; set; }
        public decimal ListPrice { get; set; }
        public decimal MonthlyRent { get; set; }
        public AddressDTO Address { get; set; }

        public PropertyDTO() { }

        public PropertyDTO(Property.EntityFramework.Models.Property p)
        {
            this.Id = p.Id;
            this.YearBuilt = p.YearBuilt;
            this.ListPrice = p.ListPrice;
            this.MonthlyRent = p.MonthlyRent;
            this.Address = new AddressDTO(p.Address);
        }

        public Property.EntityFramework.Models.Property toProperty(Property.EntityFramework.Models.Address address)
        {
            return new Property.EntityFramework.Models.Property()
            {
                Id = this.Id,
                YearBuilt = this.YearBuilt,
                ListPrice = this.ListPrice,
                MonthlyRent = this.MonthlyRent,
                Address = address
            };
        }

        public Property.EntityFramework.Models.Property toProperty()
        {
            return new Property.EntityFramework.Models.Property()
            {
                Id = this.Id,
                YearBuilt = this.YearBuilt,
                ListPrice = this.ListPrice,
                MonthlyRent = this.MonthlyRent,
                Address = this.Address.toAddress()
            };
        }
    }
}
