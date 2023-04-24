using TeslaCarSharing.Application.Contracts.Application;
using TeslaCarSharing.Application.Contracts.Infrastructure;
using TeslaCarSharing.Core;

namespace TeslaCarSharing.Application.Services;
public class CustomerService : GenericService<Customer>, ICustomerService
{
    private readonly ICustomerRepository _repository;

    public CustomerService(ICustomerRepository repository) : base(repository)
    {
        _repository = repository;
    }
}
