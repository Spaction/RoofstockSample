#nullable disable

namespace Property.EntityFramework.Models
{
    using System.Collections.Generic;
    public partial class Property
    {
        public int Id { get; set; }
        public string YearBuilt { get; set; }
        public decimal ListPrice { get; set; }
        public decimal MonthlyRent { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }

        public void Update(Property p)
        {
            if (YearBuilt != p.YearBuilt)
            {
                YearBuilt = p.YearBuilt;
            }
            if (ListPrice != p.ListPrice)
            {
                ListPrice = p.ListPrice;
            }
            if (MonthlyRent != p.MonthlyRent)
            {
                MonthlyRent = p.MonthlyRent;
            }
            if (!Address.Equals(p.Address))
            {
                Address.Update(p.Address);
            }
        }
    }
}
