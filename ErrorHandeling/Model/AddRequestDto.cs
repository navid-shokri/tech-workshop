using System.ComponentModel.DataAnnotations;

namespace ErrorHandeling.Model;

public class AddRequestDto
{
    [Required]
    [Range(0,9)]
    public int First { get; set; }
    [Required]
    [Range(0,9)]
    public int Second { get; set; }
}