namespace OpenBazaar.Model.Users.Dtos;

public sealed record UpdateUserRequest(string Id,string FirstName,string LastName, string UserName,string Email);