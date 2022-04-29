﻿using System;
using Amido.Stacks.Application.CQRS.ApplicationEvents;
using Amido.Stacks.Core.Operations;
using Newtonsoft.Json;

namespace Htec.Poc.Application.CQRS.Events;

public class CategoryUpdatedEvent : IApplicationEvent
{
    [JsonConstructor]
    public CategoryUpdatedEvent(int operationCode, Guid correlationId, Guid rewardId, Guid categoryId)
    {
        OperationCode = operationCode;
        CorrelationId = correlationId;
        RewardId = rewardId;
        CategoryId = categoryId;
    }

    public CategoryUpdatedEvent(IOperationContext context, Guid rewardId, Guid categoryId)
    {
        OperationCode = context.OperationCode;
        CorrelationId = context.CorrelationId;
        RewardId = rewardId;
        CategoryId = categoryId;
    }

    public int EventCode => (int)Enums.EventCode.CategoryUpdated;

    public int OperationCode { get; }

    public Guid CorrelationId { get; }

    public Guid RewardId { get; }

    public Guid CategoryId { get; }
}
