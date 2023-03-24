using System.ComponentModel.DataAnnotations;

namespace GraphQLSample.Models;

public class Platform
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    public string? Publisher { get; set; }

    public ICollection<Command> Commands { get; set; } = Enumerable.Empty<Command>().ToList();
}