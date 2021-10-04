using Microsoft.AspNetCore.Mvc;
using SmallExample.Entities;
using SmallExample.Models;
using SmallExample.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallExample.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDBContext context;

        public LoginController(ApplicationDBContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel viewModel)
        {
            var login = new Login()
            {
                Username = viewModel.Username,
                Password = viewModel.Password
            };
            var user = new User()
            {
                Username=viewModel.Username,
                Address=viewModel.Address,
                Email=viewModel.Email
            };
            context.Login.Add(login);
            context.User.Add(user);
            context.SaveChanges();
            return View();
        }

        [HttpGet]
        public async Task<List<UserType>> GetUserTypes()
        {
            return null;// await context.use
        }

    }
}
