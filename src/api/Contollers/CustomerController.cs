using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeslaCarSharing.Application.Contracts.Application;
using TeslaCarSharing.Core;
using AutoMapper;
using TeslaCarSharing.Application.DTOs.Customer;

namespace TeslaCarSharing.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDto>> GetCustomer(int id)
    {
        var customer = await _customerService.GetCustomerAsync(id);
        if (customer == null)
        {
            return NotFound();
        }
        return Ok(customer);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
    {
        var customers = await _customerService.GetAllCustomersAsync();
        return Ok(customers);
    }

    [HttpPost]
    public async Task<ActionResult<CustomerDto>> AddCustomer(CustomerDto customer)
    {
        var addedCustomer = await _customerService.Add(customer);
        return CreatedAtAction(nameof(GetCustomer), new { id = addedCustomer.Id }, addedCustomer);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer(int id, CustomerDto customer)
    {
        if (id != customer.Id)
        {
            return BadRequest();
        }

        await _customerService.Update(customer);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        var customer = await _customerService.GetCustomerAsync(id);
        if (customer == null)
        {
            return NotFound();
        }

        await _customerService.Delete(customer.Id);

        return NoContent();
    }
}
