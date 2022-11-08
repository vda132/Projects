namespace ASP.Net.MediatR.Contacts.Helpers;

public interface IPasswordHasher
{
    Task<string> HashPassword(string password);
}
