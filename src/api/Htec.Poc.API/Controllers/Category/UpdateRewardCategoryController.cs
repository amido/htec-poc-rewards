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
/// Category related operations
/// </summary>
[Consumes("application/json")]
[Produces("application/json")]
[ApiExplorerSettings(GroupName = "Category")]
public class UpdateRewardCategoryController : ApiControllerBase
{
    readonly ICommandHandler<UpdateCategory, bool> commandHandler;

    public UpdateRewardCategoryController(ICommandHandler<UpdateCategory, bool> commandHandler)
    {
        this.commandHandler = commandHandler ?? throw new ArgumentNullException(nameof(commandHandler));
    }

    /// <summary>
    /// Update a category in the reward
    /// </summary>
    /// <remarks>Update a category to reward</remarks>
    /// <param name="id">reward id</param>
    /// <param name="categoryId">Id for Category being removed</param>
    /// <param name="body">Category being added</param>
    /// <response code="204">No Content</response>
    /// <response code="400">Bad Request</response>
    /// <response code="404">Resource not found</response>
    /// <response code="409">Conflict, an item already exists</response>
    [HttpPut("/v1/reward/{id}/category/{categoryId}")]
    [Authorize]
    public async Task<IActionResult> UpdateRewardCategory([FromRoute][Required]Guid id, [FromRoute][Required]Guid categoryId, [FromBody]UpdateCategoryRequest body)
    {
        // NOTE: Please ensure the API returns the response codes annotated above

        await commandHandler.HandleAsync(
            new UpdateCategory(
                correlationId: GetCorrelationId(),
                rewardId: id,
                categoryId: categoryId,
                name: body.Name,
                description: body.Description
            )
        );

        return StatusCode(204);
    }
}
