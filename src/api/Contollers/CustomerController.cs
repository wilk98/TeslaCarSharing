using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeslaCarSharing.Application.Contracts.Application;
using TeslaCarSharing.Application.DTOs.Customer;
using TeslaCarSharing.Core;
using AutoMapper;

namespace TeslaCarSharing.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;

    public CustomerController(ICustomerService customerService, IMapper mapper)
    {
        _customerService = customerService;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDto>> GetCustomer(int id)
    {
        var customer = await _customerService.Get(id);
        if (customer == null)
        {
            return NotFound();
        }
        var customerDto = _mapper.Map<CustomerDto>(customer);
        return Ok(customerDto);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
    {
        var customers = await _customerService.GetAll();
        var customersDto = _mapper.Map<IEnumerable<CustomerDto>>(customers);
        return Ok(customersDto);
    }

    [HttpPost]
    public async Task<ActionResult<CustomerDto>> AddCustomer(Customer customer)
    {
        var addedCustomer = await _customerService.Add(customer);
        var customerDto = _mapper.Map<CustomerDto>(addedCustomer);
        return CreatedAtAction(nameof(GetCustomer), new { id = customerDto.Id }, customerDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
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
        var customer = await _customerService.Get(id);
        if (customer == null)
        {
            return NotFound();
        }

        await _customerService.Delete(customer);

        return NoContent();
    }
}
