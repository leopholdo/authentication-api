using authentication_api.Data;
using authentication_api.Models;

namespace authentication_api.Services.BoardsService
{
  public interface IAuthService 
  {
    User? GetUser(int? id, string? email);
    List<UserDTO>? GetUsers(int? id, string? email);
    Task<User> Register(UserDTO userDTO);
    Task<User> Update(UserDTO userDTO);
    Task<User> UpdatePassword(UserDTO userDTO);
  }
  
  public class AuthService : IAuthService
  {
    private readonly DataContext _context;

    public AuthService(DataContext context)
    {
        _context = context;
    }

    public User? GetUser(int? id, string? email)
    {
      var user = _context.Users
        .Where(u => 
          u.Id == id ||
          u.Email == email
        )
        .FirstOrDefault();

      return user;
    }

    public List<UserDTO>? GetUsers(int? id, string? email)
    {
      var user = _context.Users
        .Select(user => new UserDTO {
          Id = user.Id,
          Email = user.Email,
          Name = user.Name ?? string.Empty
        })
        .Where(u => 
          u.Id == id ||
          u.Email == email
        )
        .ToList();

      return user;
    }

    public async Task<User> Register(UserDTO userDTO)
    {
      string hashedPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(userDTO.Password, 12);

      User user = new User
      {
        Name = userDTO.Name,
        Email = userDTO.Email,
        HashedPassword = hashedPassword
      };

      _context.Users.Add(user);
      await _context.SaveChangesAsync();

      return user;
    }

    public async Task<User> Update(UserDTO userDTO)
    {
      var user = await _context.Users.FindAsync(userDTO.Id);

      if(user == null) 
      {
        throw new Exception("except_user_not_found");
      }

      user.Email = userDTO.Email;
      user.Name = userDTO.Name;

      await _context.SaveChangesAsync();

      return user;
    }

    public async Task<User> UpdatePassword(UserDTO userDTO)
    {
      var user = await _context.Users.FindAsync(userDTO.Id);

      if(user == null) 
      {
        throw new Exception("except_user_not_found");
      }

      user.HashedPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(userDTO.Password);

      _context.Users.Update(user);
      await _context.SaveChangesAsync();

      return user;
    }
  }
}