using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.EntityFramework.Models
{
    public partial class Address: IEquatable<Address>
    {
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

        public bool Equals(Address other)
        {
            return this.Address1 == other.Address1 &&
                this.Address2 == other.Address2 &&
                this.City == other.City &&
                this.Country == other.Country &&
                this.County == other.County &&
                this.District == other.District &&
                this.State == other.State &&
                this.Zip == other.Zip &&
                this.ZipPlus4 ==other.ZipPlus4;
        }
        
        public void Update(Address other)
        {
            if(this.Address1 != other.Address1)
            {
                this.Address1 = other.Address1;
            }
            if(this.Address2 != other.Address2)
            {
                this.Address2 = other.Address2.Trim();
            }
            if(this.City != other.City)
            {
                this.City = other.City;
            }
            if(this.Country != other.Country)
            {
                this.Country = other.Country;
            }
            if(this.County != other.County)
            {
                this.County = other.County;
            }
            if(this.District != other.District)
            {
                this.District = other.District;
            }
            if(this.State != other.State)
            {
                this.State = other.State;
            }
            if(this.Zip != other.Zip)
            {
                this.Zip = other.Zip;
            }
            if(this.ZipPlus4 != other.ZipPlus4)
            {
                this.ZipPlus4 = other.ZipPlus4;
            }
        }
    }
}
