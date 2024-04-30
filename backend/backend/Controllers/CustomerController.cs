using backend.Dtos;
using Microsoft.AspNetCore.Mvc;
using backend.Repositories;
using backend.CasosDeUso;


namespace backend.Controllers
{
    [ApiController]//se usa para enlazar este controlador con el controlador CustomersController
    //[Authorize] se usa para darle autorizacion a cada archuvi con login
    [Route("api/[controller]")]//responde y se traduce a CustomersController
    public class CustomerController : Controller
    {

        private readonly CustomerDatabaseContext _customerDatabaseContext;
        private readonly IUpdateCustomerUseCase _UpdateCustomerUseCase;

        public CustomerController(CustomerDatabaseContext customerDatabaseContext, IUpdateCustomerUseCase updateCustomerUseCase)
        {
            _customerDatabaseContext = customerDatabaseContext;
            _UpdateCustomerUseCase = updateCustomerUseCase;
        }
        // GET: CustomersController
        //[Authorize]
        //api/customer
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CustomerDto>))]
        public async Task<IActionResult> GetCustomers()
        {
            var result = _customerDatabaseContext.Customer.Select(c => c.ToDto()).ToList();
            return new OkObjectResult(result);
        }
        //api/customer/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCustomer(long id)

        {
            CustomerEntity result = await _customerDatabaseContext.Get(id);

            return new OkObjectResult(result.ToDto());
        }
        //api/customer
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]

        public async Task<IActionResult> DeleteCustomer(long id)
        {
            var result = await _customerDatabaseContext.Delete(id);
            return new OkObjectResult(result);
        }
        //api/customer
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CustomerDto))]
        public async Task<IActionResult> CreateCustomer(CreateCustomerDto customer)
        {
            CustomerEntity result = await _customerDatabaseContext.Add(customer);
            return new CreatedResult($"https://localhost:7030/api/customer/{result.Id}", null);
        }

        //api/customer
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCustomer(CustomerDto customer)
        {
            CustomerDto? result = await _UpdateCustomerUseCase.Execute(customer);
            if (result == null)
                return new NotFoundResult();
            return new OkObjectResult(result);
        }
    }
}
