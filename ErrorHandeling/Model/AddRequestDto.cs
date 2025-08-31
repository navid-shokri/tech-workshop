using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using ClassLibrary1;
using Microsoft.AspNetCore.Authentication;

namespace ErrorHandeling.Model;

public class AddRequestDto :Class1
{
    [Required]
    [Range(0,9)]
    public int First { get; set; }
    [Required]
    [Range(0,9)]
    public int Second { get; set; }
    
}