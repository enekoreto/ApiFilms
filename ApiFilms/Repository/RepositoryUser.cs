using System.Security.Cryptography;
using System.Text;
using ApiFilms.Data;
using ApiFilms.Models;
using ApiFilms.Models.Dtos;
using ApiFilms.Repository.IRepository;

namespace ApiFilms.Repository;

public class RepositoryUser : IRespositoryUser
{
    private readonly ApplicationDBContext _db;

    public RepositoryUser(ApplicationDBContext db)
    {
        _db = db;
    }

    public ICollection<User> GetUsers()
    {
        return _db.User.OrderBy(c => c.Name).ToList();
    }

    public User GetUser(int userId)
    {
        return _db.User.Find(userId);
    }

    public bool IsUniqueUser(string user)
    {
        var userDb = _db.User.FirstOrDefault(u => u.Username == user);
        return userDb != null;
    }

    public Task<UserLogInAnswerDTO> LogIn(LogInUserDTO logInUserDTO)
    {
        throw new NotImplementedException();
    }

    public async Task<User> Register(CreateUserDTO createUserDTO)
    {
        var encryptedPassword = GetMD5(createUserDTO.Password); //an encrypted password is saved

        User user = new User()
        {
            Username = createUserDTO.Username,
            Password = encryptedPassword,
            Name = createUserDTO.Name,
            Role = createUserDTO.Role,
        };
        
        _db.User.Add(user);
        await _db.SaveChangesAsync(); //waits until the changes are saved
        user.Password = encryptedPassword;
        return user;
    }
    
    /// <summary>
    /// Generates an MD5 hash of the given input string.
    /// WARNING: MD5 is not secure for password hashing and should not be used for sensitive data.
    /// Consider using a more secure hashing algorithm like BCrypt or PBKDF2 for password storage.
    /// </summary>
    /// <param name="input">The string to hash.</param>
    /// <returns>A hexadecimal representation of the MD5 hash.</returns>
    public static string GetMD5(string input)
    {
        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert hash bytes to hexadecimal string
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}