using System;

namespace Htec.Poc.CQRS.Commands;

/// <summary>
/// Define required parameters for commands executed against a category
/// </summary>
public interface ICategoryCommand : IRewardCommand
{
    Guid CategoryId { get; }
}
