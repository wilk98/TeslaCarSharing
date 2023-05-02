using TeslaCarSharing.Application.DTOs.Customer;

namespace TeslaCarSharing.Application.Contracts.Application;

public interface ICustomerService
{
    Task<CustomerDto> GetCustomerAsync(int customerId);
    Task<IReadOnlyList<CustomerDto>> GetAllCustomersAsync();
    Task<CustomerDto> Add(CustomerDto customerDto);
    Task Update(CustomerDto customerDto);
    Task Delete(int customerId);
}
