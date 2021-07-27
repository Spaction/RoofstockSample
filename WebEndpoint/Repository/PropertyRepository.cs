using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebEndpoint.Repository
{
    using Property.EntityFramework.Context;
    using Property.EntityFramework.Models;

    public class PropertyRepository : Repository<Property, RoofstockDbContext>, IPropertyRepository
    {
        public PropertyRepository(RoofstockDbContext dbContext) : base(dbContext)
        {
        }

        public new Task<Property> GetById(int id) {
            return context.Properties.Include(y => y.Address).Where(y => y.Id == id).FirstOrDefaultAsync();
        }
        public Task<List<Property>> GetByIds(ICollection<int> id)
        {
            return context.Set<Property>().Where(y => id.Contains(y.Id)).ToListAsync();
        }
    }
}
