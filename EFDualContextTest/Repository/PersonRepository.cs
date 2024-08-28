using System.Data;
using EFDualContextTest.DataAccess;
using EFDualContextTest.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDualContextTest.Repository;

public class PersonRepository : GenericRepository<OrderDbContext, Person>, IPersonRepository
{
    public PersonRepository(OrderDbContext dbContext, ILogger<GenericRepository<OrderDbContext, Person>> logger) : base(
        dbContext, logger)
    {
    }

    public override async Task<Person> GetByIdAsync(Guid id, bool asNoTracking = true)
    {
        var query = DbContext.Persons.Include("Orders").Include("Histories");
        if (asNoTracking)
        {
            query = query.AsNoTracking();
        }

        return await query.FirstOrDefaultAsync(x=>x.Id == id);
    }

    public override async Task UpdateAsync(Person entity)
    {

        //var person = await _personRepository.GetByIdAsync(personId);
        var person = DbContext.Persons.Include(x => x.Orders)
            .Include(x => x.Histories).First(x => x.Id == entity.Id);

        var e = new
        {
            entity.Name,
            entity.Family,
            Address = new
            {
                entity.Address.City,
                entity.Address.Street
            }
        };
        DbContext.Entry(person).CurrentValues.SetValues(e);
        DbContext.Entry(person).Reference(x => x.Address).CurrentValue
            = new Address(entity.Address.City, entity.Address.Street);

        var order = new Order(1234567);
        ((List<Order>)DbContext.Entry(person).Collection(x => x.Orders).CurrentValue).Add(order);
        Logger.LogInformation(person.Orders.Count.ToString());
        DbContext.Entry(order).State = EntityState.Added;

        var ro = person.Orders.First(x => x.Id == Guid.Parse("6f4f7e0f-cac0-4c3f-9e17-a5916293bbe6"));

        ((List<Order>)DbContext.Entry(person).Collection(x => x.Orders).CurrentValue).Remove(ro); 
        DbContext.Entry(ro).State = EntityState.Deleted;

        foreach (var his in entity.Histories)
        {
            if (person.Histories.All(x => x.Id != his.Id))
                DbContext.Entry(his).State = EntityState.Added;
        }

        try
        {
            await DbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException exception)
        {
            Console.WriteLine(exception);
            throw;
        }
        

    }
}
 