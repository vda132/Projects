using ASP.Net.MediatR.Contacts.Helpers;
using System.Security.Cryptography;
using System.Text;

namespace ASP.Net.MediatR.Services.Helpers;

public class PasswordHasher : IPasswordHasher
{
    public async Task<string> HashPassword(string password)
    {
        var md5 = MD5.Create();
        var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));

        return await Task.FromResult(Convert.ToBase64String(hash));
    }
}
