using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebEndpoint.Service
{
    using Property.EntityFramework.Models;
    using Property.EntityFramework.Context;
    using WebEndpoint.DTO.Models;
    using WebEndpoint.Repository;

    public class PropertyService : IPropertyService
    {
        private readonly RoofstockDbContext context;
        private readonly IPropertyRepository propertyRepository;
        private readonly IAddressRepository addressRepository;

        public PropertyService(RoofstockDbContext dbContext, IAddressRepository addressRepository, IPropertyRepository propertyRepository)
        {
            context = dbContext;
            this.propertyRepository = propertyRepository;
            this.addressRepository = addressRepository;
        }

        public Task<List<PropertyDTO>> GetAllPropertiesAndAddresses()
        {
            return context.Properties.Include(y => y.Address).Select(y => new PropertyDTO(y)).ToListAsync();
        }

        public async Task SaveProperty(PropertyDTO newProperty)
        {
            var existingProperties = (await propertyRepository.GetById(newProperty.Id));

            //Because we provide the primary key, EF Core cannot determine if the row exists already or not.
            if (existingProperties == null)
            {
                var tracking = propertyRepository.Add(newProperty.toProperty());
                tracking.State = EntityState.Added;
            }
            else
            {
                existingProperties.Update(newProperty.toProperty());
            }
            await context.SaveChangesAsync();
        }
    }
}
