using TeslaCarSharing.Application.Contracts.Infrastructure;
using TeslaCarSharing.Core;

namespace TeslaCarSharing.Infrastructure.Repositories;

public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(TeslaCarSharingDbContext context) : base(context)
    {
    }

}
