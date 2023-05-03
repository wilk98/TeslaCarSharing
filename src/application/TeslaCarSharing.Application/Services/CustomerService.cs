using AutoMapper;
using TeslaCarSharing.Application.Contracts.Application;
using TeslaCarSharing.Application.Contracts.Infrastructure;
using TeslaCarSharing.Application.DTOs.Customer;
using TeslaCarSharing.Core;
using FluentValidation;

namespace TeslaCarSharing.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;
    private readonly IValidator<CustomerDto> _validator;

    public CustomerService(ICustomerRepository repository, IMapper mapper, IValidator<CustomerDto> validator)
    {
        _repository = repository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<CustomerDto> Add(CustomerDto customerDto)
    {
        var validationResult = await _validator.ValidateAsync(customerDto);
        if (!validationResult.IsValid)
        {
            throw new FluentValidation.ValidationException(validationResult.Errors);
        }
        var customer = _mapper.Map<Customer>(customerDto);
        var addedCustomer = await _repository.Add(customer);
        return _mapper.Map<CustomerDto>(addedCustomer);
    }

    public async Task Delete(int customerId)
    {
        var customer = await _repository.Get(customerId);
        if (customer != null)
        {
            await _repository.Delete(customer);
        }
    }

    public async Task<IReadOnlyList<CustomerDto>> GetAllCustomersAsync()
    {
        var customers = await _repository.GetAll();
        return _mapper.Map<IReadOnlyList<CustomerDto>>(customers);
    }

    public async Task<CustomerDto> GetCustomerAsync(int customerId)
    {
        var customer = await _repository.Get(customerId);
        return _mapper.Map<CustomerDto>(customer);
    }

    public async Task Update(CustomerDto customerDto)
    {
        var validationResult = await _validator.ValidateAsync(customerDto);
        if (!validationResult.IsValid)
        {
            throw new FluentValidation.ValidationException(validationResult.Errors);
        }
        var customer = _mapper.Map<Customer>(customerDto);
        await _repository.Update(customer);
    }
}
