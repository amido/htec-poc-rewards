﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Amido.Stacks.Application.CQRS.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Htec.Poc.API.Models.Requests;
using Htec.Poc.CQRS.Commands;

namespace Htec.Poc.API.Controllers;

/// <summary>
/// Item related operations
/// </summary>
[Consumes("application/json")]
[Produces("application/json")]
[ApiExplorerSettings(GroupName = "Item")]
public class UpdateRewardItemController : ApiControllerBase
{
    readonly ICommandHandler<UpdateRewardItem, bool> commandHandler;

    public UpdateRewardItemController(ICommandHandler<UpdateRewardItem, bool> commandHandler)
    {
        this.commandHandler = commandHandler ?? throw new ArgumentNullException(nameof(commandHandler));
    }

    /// <summary>
    /// Update an item in the reward
    /// </summary>
    /// <remarks>Update an  item in the reward</remarks>
    /// <param name="id">Id for reward</param>
    /// <param name="categoryId">Id for Category</param>
    /// <param name="itemId">Id for item being updated</param>
    /// <param name="body">Category being added</param>
    /// <response code="204">No Content</response>
    /// <response code="400">Bad Request</response>
    /// <response code="404">Resource not found</response>
    [HttpPut("/v1/reward/{id}/category/{categoryId}/items/{itemId}")]
    [Authorize]
    public async Task<IActionResult> UpdateRewardItem([FromRoute][Required]Guid id, [FromRoute][Required]Guid categoryId, [FromRoute][Required]Guid itemId, [FromBody]UpdateItemRequest body)
    {
        // NOTE: Please ensure the API returns the response codes annotated above

        await commandHandler.HandleAsync(
            new UpdateRewardItem(
                correlationId: GetCorrelationId(),
                rewardId: id,
                categoryId: categoryId,
                rewardItemId: itemId,
                name: body.Name,
                description: body.Description,
                price: body.Price,
                available: body.Available
            )
        );

        return StatusCode(204);
    }
}
