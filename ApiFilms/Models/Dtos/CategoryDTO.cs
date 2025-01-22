using System.ComponentModel.DataAnnotations;

namespace ApiFilms.Models.Dtos;

public class CategoryDTO
{
    public int Id { get; set; }
    [Required(ErrorMessage = "The field {0} is required")] //{0} refers to name
    [MaxLength(100, ErrorMessage = "The field {0} must be less than {1} characters")] //{1} is the maximum amount of characters
    public string Name { get; set; }
    [Required]
    public DateTime CreatedDate { get; set; }
}