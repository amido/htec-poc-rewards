using System.ComponentModel.DataAnnotations;

namespace Htec.Poc.API.Models.Requests;

/// <summary>
/// Request model used by UpdateCategory api endpoint
/// </summary>
public class UpdateCategoryRequest
{
    /// <example>Burgers</example>
    [Required]
    public string Name { get; set; }

    /// <example>A delicious selection of burgers</example>
    public string Description { get; set; }
}