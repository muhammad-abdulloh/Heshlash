using Heshlash.Api.Models;
using Heshlash.Api.Service.Interface;
using Heshlash.Api.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Heshlash.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private Heshshess heshshess;
        private readonly IUserServices userServices;
        public UserController(IUserServices userService)
        {
            this.userServices = userService;
        }

        [HttpPost]
        public async Task<User> Create(User user)
        {
            return await userServices.CreateAsync(user);
        }

        [HttpPost]
        public Task<User> GetAsync([DataType(DataType.Password), FromForm] string password)
        {
            //string result = ComputeHash(password, new SHA256CryptoServiceProvider());

            heshshess = new Heshshess();
            string result = heshshess.ComputeHash(password, new SHA256CryptoServiceProvider());

            return userServices.GetAsync(p => p.Password.Equals(result));
        }
    }
}
