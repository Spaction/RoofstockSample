using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebEndpoint.Repository
{
    using Property.EntityFramework.Models;
    using Property.EntityFramework.Context;

    public interface IAddressRepository : IRepository<Address>
    {
    }
}
