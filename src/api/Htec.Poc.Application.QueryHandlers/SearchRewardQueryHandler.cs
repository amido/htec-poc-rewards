using System;
using System.Linq;
using System.Threading.Tasks;
using Amido.Stacks.Application.CQRS.Queries;
using Amido.Stacks.Data.Documents.Abstractions;
using Htec.Poc.CQRS.Queries.SearchReward;
using Htec.Poc.Domain;

namespace Htec.Poc.Application.QueryHandlers;

public class SearchRewardQueryHandler : IQueryHandler<SearchReward, SearchRewardResult>
{
    readonly IDocumentSearch<Reward> storage;

    public SearchRewardQueryHandler(IDocumentSearch<Reward> storage)
    {
        this.storage = storage;
    }

    public async Task<SearchRewardResult> ExecuteAsync(SearchReward criteria)
    {
        if (criteria == null)
            throw new ArgumentException("A valid SearchRewardQueryCriteria os required!");

        int pageSize = 10;
        int pageNumber = 1;
        var searchTerm = string.Empty;
        Guid tenantId = criteria.TenantId.HasValue ? criteria.TenantId.Value : Guid.Empty;

        if (criteria.PageSize.HasValue && criteria.PageSize > 0)
            pageSize = criteria.PageSize.Value;

        if (criteria.PageNumber.HasValue && criteria.PageNumber > 0)
            pageNumber = criteria.PageNumber.Value;

        if (!string.IsNullOrEmpty(criteria.SearchText))
            searchTerm = criteria.SearchText.Trim();

        bool restaurantIdProvided = criteria.TenantId.HasValue;

        var results = await storage.Search(
            itemFilter =>
                (string.IsNullOrEmpty(searchTerm) || itemFilter.Name.Contains(searchTerm)) &&
                //Nullable types must have a value when passed to a seach, this is why we convert it to non nullable and pass a boolean check
                (!restaurantIdProvided || itemFilter.TenantId == tenantId),
            null,
            pageSize,
            pageNumber);

        var result = new SearchRewardResult();
        result.PageSize = pageSize;
        result.PageNumber = pageNumber;

        if (!results.IsSuccessful)
            return result;

        result.Results = results.Content.Select(i => new SearchRewardResultItem()
        {
            Id = i.Id,
            RestaurantId = i.TenantId,
            Name = i.Name,
            Description = i.Description,
            Enabled = i.Enabled
        });


        return result;
    }
}
