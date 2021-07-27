using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebEndpoint.Repository
{
    using Property.EntityFramework.Models;
    using Property.EntityFramework.Context;

    public interface IPropertyRepository : IRepository<Property>
    {
        Task<List<Property>> GetByIds(ICollection<int> id);
    }
}
