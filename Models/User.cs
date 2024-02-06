namespace authentication_api.Models;

public class User
{
  public int Id { get; set; }
  public string? Name { get; set; }
  public required string Email { get; set; }
  public required string HashedPassword { get; set; }
  public List<string>? Roles { get; set; }
}