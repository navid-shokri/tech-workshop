using System;

namespace EFDualContextTest.Models;
public abstract class BaseEntity
{
    public BaseEntity()
    {
        //Validate();
    }
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; protected set; } = DateTime.Now;
    public bool IsDeleted { get; protected set; }
    public DateTime? DeletedAt { get; protected set; }
    public DateTime? ModifiedAt { get; set; }

    public void SetAsDeleted( )
    {
        DeletedAt = DateTime.Now;
        IsDeleted = true;
    }

    protected abstract void Validate();

}