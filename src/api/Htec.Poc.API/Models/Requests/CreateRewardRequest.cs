using System;
using System.ComponentModel.DataAnnotations;

namespace Htec.Poc.API.Models.Requests;

/// <summary>
/// Request model used by CreateReward api endpoint
/// </summary>
public class CreateRewardRequest
{
    /// <example>Name of reward created</example>
    [Required]
    public string Name { get; set; }

    /// <example>Description of reward created</example>
    [Required]
    public string Description { get; set; }

    /// <example>d290f1ee-6c54-4b01-90e6-d701748f0851</example>
    [Required]
    public Guid TenantId { get; set; }

    /// <summary>
    /// Represents the status of the reward. False if disabled
    /// </summary>
    [Required]
    public bool Enabled { get; set; }
}