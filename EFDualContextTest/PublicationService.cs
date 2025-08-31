using EFDualContextTest.DataAccess;
using EFDualContextTest.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDualContextTest;

public class PublicationService
{
    private readonly OrderDbContext _dbContext;

    public PublicationService(OrderDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    private string book1 = "hichi";
    private string book2 = "bazam hichi";
    private string book3 = "va digar hich";

    private string arash = "Arash";
    private string ali = "Ali";
    private string bita = "Bita";
    public async Task AddBooks()
    {
       
        var books = new List<Book> { new() { Name = book1  } , new() { Name = book2 } , new () { Name = book3 }  };
        _dbContext.Books.AddRange(books);
        await _dbContext.SaveChangesAsync();
    }

    public async Task AddAuthors()
    {
        var authors = new List<Author> { new() { Name = arash  } , new() { Name = ali } , new () { Name = bita }  };
        _dbContext.Authors.AddRange(authors);
        await _dbContext.SaveChangesAsync();
    }

    public async Task AssignBooks()
    {
        await AssignBooks(ali, new List<string> { book1, book2 });
        await AssignBooks(bita, new List<string> { book3, book2 });
    }

    public async Task<List<Author>> GetAuthersAsyc()
    {
        return await _dbContext.Authors.Include(x=>x.Books).ToListAsync();
    }

    public async Task ReassignBooks()
    {
        var newbooks = new List<string> { book1, book2 };
        var author = await _dbContext.Authors.Include(x => x.Books).FirstOrDefaultAsync(x => x.Name == bita);
        var books =  _dbContext.Books.Where(x => newbooks.Contains(x.Name));
        author.SetBooks( await books.ToListAsync());
        _dbContext.Attach(author);
        _dbContext.Entry(author).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
    private async Task AssignBooks(string authorName, List<string> bookNames)
    {
        var author = await _dbContext.Authors.FirstOrDefaultAsync(x => x.Name == authorName);
        var books = await _dbContext.Books.Where(x => bookNames.Contains(x.Name)).ToListAsync();
        author.SetBooks(books);
        _dbContext.Attach(author);
        _dbContext.Entry(author).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
}