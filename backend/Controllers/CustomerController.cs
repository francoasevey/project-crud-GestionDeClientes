﻿using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]//se usa para enlazar este controlador con el controlador CustomersController
    //[Authorize] se usa para darle autorizacion a cada archuvi con login
    [Route("api/[controller]")]//responde y se traduce a CustomersController
    public class CustomerController : Controller
    {
        // GET: CustomersController
        //[Authorize]
        //api/customer
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
        public async Task<ActionResult> GetCustomers()
        {
            throw new NotImplementedException();
        }
        //api/customer/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCustomer(long id)

        {
            var vacio = new CustomerDto();
            return new OkObjectResult(vacio);
        }
        //api/customer
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]

        public async Task<ActionResult> DeleteCustomer(long id)
        {
            throw new NotImplementedException();
        }
        //api/customer
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CustomerDto))]
        public async Task<IActionResult> CreateCustomer(CreateCustomerDto customer)
        {
            var vacio = new CustomerDto();
            return new CreatedResult($"http://localhost:7030/api/customer/{vacio.Id}", null);
        }

        //api/customer
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateCustomer(CustomerDto customer)
        {
            throw new NotImplementedException();
        }
    }
}