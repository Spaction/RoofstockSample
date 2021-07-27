using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebEndpoint.Repository
{
    using Property.EntityFramework.Models;
    using Property.EntityFramework.Context;

    public class AddressRepository : Repository<Address, RoofstockDbContext>, IAddressRepository
    {
        public AddressRepository(RoofstockDbContext dbContext) : base(dbContext)
        {
        }
    }
}
