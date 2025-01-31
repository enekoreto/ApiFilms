namespace ApiFilms.Models.Dtos;

public class UserLogInAnswerDTO
{
    public UserDataDTO User { get; set; }
    public string Role { get; set; }
    public string Token { get; set; }
}