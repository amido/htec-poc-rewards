using System;
using Amido.Stacks.Domain;

namespace Htec.Poc.Domain.Entities;

public class RewardItem : IEntity<Guid>
{
    public RewardItem(Guid id, string name, string description, double price, bool available)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        Available = available;
    }

    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public double Price { get; set; }

    public bool Available { get; set; }
}