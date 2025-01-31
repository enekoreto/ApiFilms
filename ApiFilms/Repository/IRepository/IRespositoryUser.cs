using ApiFilms.Models;
using ApiFilms.Models.Dtos;

namespace ApiFilms.Repository.IRepository
{
    public interface IRespositoryUser
    {
        ICollection<User> GetUsers(); //All users
        User GetUser(int userId); //One individual user
        bool IsUniqueUser(string user);
        Task<UserLogInAnswerDTO> LogIn(LogInUserDTO logInUserDTO); //asynchronous method that returns a task
        Task<UserDataDTO> Register(CreateUserDTO createUserDTO);
    }
}
