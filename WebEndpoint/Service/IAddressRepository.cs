using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebEndpoint.Service
{
    using Property.EntityFramework.Models;
    using Property.EntityFramework.Context;
    using WebEndpoint.DTO.Models;

    public interface IPropertyService
    {
        Task<List<PropertyDTO>> GetAllPropertiesAndAddresses();

        Task SaveProperty(PropertyDTO newProperty);
    }
}
