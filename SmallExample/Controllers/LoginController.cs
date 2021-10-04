using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet]
        public ActionResult Login()
        {
            ViewData["listado"] = GetUserTypes();
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel viewModel)
        {
            ViewData["listado"] = GetUserTypes();
            var login = new Login()
            {
                Username = viewModel.Username,
                Password = viewModel.Password
            };
            var user = new User()
            {
                Username=viewModel.Username,
                Address=viewModel.Address,
                Email=viewModel.Email,
                UserTypeId=viewModel.UserTypeId
            };
            context.Login.Add(login);
            context.User.Add(user);
            context.SaveChanges();
            return View();
        }

        [HttpGet]
        public SelectList GetUserTypes()
        {
            var listado = context.UserType.ToList();
            var listadoList = new SelectList(listado,"Id","Name");
            return listadoList;
        }

    }
}
