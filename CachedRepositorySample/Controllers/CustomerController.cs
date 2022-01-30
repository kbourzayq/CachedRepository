using CachedRepositorySample.Data.Contracts;
using CachedRepositorySample.DTO;
using CachedRepositorySample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CachedRepositorySample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IReadOnlyRepository<Customer> _repository;

        public CustomerController(IReadOnlyRepository<Customer> repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public ActionResult<CustomerListDto> GetAll()
        {
            var timer = Stopwatch.StartNew();
            var customers = _repository.List();
            timer.Stop();
            CustomerListDto customerList = new CustomerListDto { 
                Customers = customers, 
                ElapsedTimeMilliseconds = timer.ElapsedMilliseconds
            };
            return Ok(customerList);
        }
    }
}
