using System;

namespace Htec.Poc.CQRS.Queries.SearchReward;

public class SearchRewardResultItem
{
    public Guid? Id { get; set; }

    public Guid RestaurantId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public bool? Enabled { get; set; }
}
