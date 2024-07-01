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
        var person= DbContext.Persons.Include(x => x.Orders)
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
        DbContext.Entry(person).Reference(x=>x.Address).CurrentValue 
            = new Address(entity.Address.City, entity.Address.Street);
        foreach (var order in entity.Orders)
        {
            if (person.Orders.All(x => x.Id != order.Id))
            {
                DbContext.Entry(order).State = EntityState.Added;
            }
        }

        foreach (var eOrder in person.Orders)
        {
            if (entity.Orders.All(x => x.Id != eOrder.Id))
            {
                DbContext.Entry(eOrder).State = EntityState.Deleted;
            }
        }
        foreach (var his in entity.Histories)
        {
            if (person.Histories.All(x => x.Id != his.Id))
                DbContext.Entry(his).State = EntityState.Added;
        }
        await DbContext.SaveChangesAsync();
            
        }
    }
    /*public override async Task UpdateAsync(Person entity)
    {
        var existing = await DbContext.Persons.Include("Orders").FirstOrDefaultAsync(x=>x.Id == entity.Id);
        if (existing != null)
        {
            DbContext.Entry(existing).CurrentValues.SetValues(entity);
            //DbContext.Histories.AttachRange(entity.Histories);
            await DbContext.SaveChangesAsync();
        }
    }*/
    