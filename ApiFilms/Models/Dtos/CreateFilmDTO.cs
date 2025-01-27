namespace ApiFilms.Models.Dtos;

public class CreateFilmDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }
    public string ImageRoute { get; set; }
    public enum CreateClassificationAgeType { AGE_12, AGE_16, AGE_18 } //each one will be identified by the position
    public CreateClassificationAgeType ClassificationAge { get; set; }
    public int CategoryId { get; set; }
}