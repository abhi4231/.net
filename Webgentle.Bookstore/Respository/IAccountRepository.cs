using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Webgentle.Bookstore.Models;
using Webgentle.BookStore.Models;

namespace Webgentle.Bookstore.Respository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);
        Task<SignInResult> PasswordSignInAsync(SignInModel signInModel);
        Task SignOutAsync();

    }
}