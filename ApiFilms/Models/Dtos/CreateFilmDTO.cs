namespace ApiFilms.Models.Dtos;

public class CreateFilmDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }
    public string ImageRoute { get; set; }
    public enum ClassificationAgeType { AGE_12, AGE_16, AGE_18 }
    public ClassificationAgeType ClassificationAge { get; set; }
    public int CategoryId { get; set; }
}