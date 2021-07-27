using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEndpoint.Service;

namespace WebEndpoint.Controllers
{
    using Property.EntityFramework.Models;
    using Property.EntityFramework.Context;
    using WebEndpoint.DTO.Models;

    [ApiController]
    [Route("api/[controller]")]
    public class PropertiesController : ControllerBase
    {
        private readonly ILogger<PropertiesController> _logger;

        private readonly IPropertyService propertyService;

        public PropertiesController(ILogger<PropertiesController> logger, IPropertyService service)
        {
            _logger = logger;
            propertyService = service;
        }

        [HttpGet("GetSaved")]
        public async Task<IActionResult> GetSavedProperties()
        {
            return Ok(await propertyService.GetAllPropertiesAndAddresses());
        }

        [HttpPost("Save")]
        public async Task<IActionResult> SaveProperty([FromBody] PropertyDTO property)
        {
            await propertyService.SaveProperty(property);
            return Ok();
        }

        [HttpGet("TestError")]
        public async Task<IActionResult> TestError()
        {
            if(DateTime.Now.Year == 2020)
            {
                await propertyService.GetAllPropertiesAndAddresses();
            }
            throw new NotImplementedException();
        }
    }
}
