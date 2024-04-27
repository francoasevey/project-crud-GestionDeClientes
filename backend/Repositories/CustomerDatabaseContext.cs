using backend.Dtos;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class CustomerDatabaseContext : DbContext
    {
        public CustomerDatabaseContext(DbContextOptions<CustomerDatabaseContext> options)
            : base(options)
            {

            }
        public DbSet<CustomerEntity> Customer { get; set; }

        public async Task<CustomerEntity> Get(long id)
        {
            return await Customer.FirstAsync(x => x.Id == id);
        }

        public async Task<CustomerEntity> Add(CreateCustomerDto customerDto)
        {
            CustomerEntity entity = new CustomerEntity()
            {
                Id = null,
                Address = customerDto.Address,
                Email = customerDto.Email,
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
            };

            EntityEntry<CustomerEntity> response = await Customer.AddAsync(entity);
            await SaveChangesAsync();
            return await Get(response.Entity.Id ?? throw new Exception("no se ha podido guardar"));
        }
    }
    public class CustomerEntity
    {
        public long? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }


    }
}
