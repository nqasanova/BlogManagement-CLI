using System;
namespace BlogManagement_CLI.Database.Models.Common;

public abstract class Entity<TId>
{
    public TId Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}