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
    public class UserController : Controller
    {
        private readonly ApplicationDBContext context;

        public UserController(ApplicationDBContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var listadoSelect = GetUserTypes();
            var model = new UserViewModel(listadoSelect);
            return View(model);
        }

        [HttpGet]
        [Route("[controller]/{username}")]
        public ActionResult Index(string username)
        {
            var usuario = context.User.Include(x=>x.UserType).FirstOrDefault(x=>x.Username == username);
            var listadoSelect = GetUserTypes();
            var model = new UserViewModel(listadoSelect)
            {
                Username = usuario.Username,
                Address = usuario.Address,
                Email = usuario.Email,
                UserTypeId = usuario.UserTypeId
            };
            return View(model);
        }

        [HttpGet]
        public SelectList GetUserTypes()
        {
            var listado = context.UserType.ToList();
            var listadoList = new SelectList(listado, "Id", "Name");
            return listadoList;
        }

        [HttpPost]
        //[Route("[controller]")]
        public ActionResult Save(UserSaveViewModel viewModel)
        {
            var user = new User()
            {
                Username = viewModel.Username,
                Address = viewModel.Address,
                Email = viewModel.Email,
                UserTypeId = viewModel.UserTypeId
            };
            context.Add(user);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
