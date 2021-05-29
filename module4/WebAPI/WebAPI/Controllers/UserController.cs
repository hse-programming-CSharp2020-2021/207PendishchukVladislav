using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class UserController : Controller
    {
        private static List<Models.UserInfo> _users = new List<Models.UserInfo>
        {
            new Models.UserInfo("Josh22", "email@site.com", 1),
            new Models.UserInfo("Sam_e", "el@site.com", 2)
        };

        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost("create-user")] 
        public IActionResult CreateUser([FromBody] Models.CreateUserRequest req) 
        {
            var user = new Models.UserInfo(req.UserName, req.EMail, _users.Count != 0 ? _users.Count + 1 : 1);
            _users.Add(user); 
            return Ok(user); 
        }

        [HttpGet("get-user-by-id")]
        public IActionResult GetUserById([FromQuery] int id)
        {
            var result = _users.Where(x => x.ID == id).ToList();

            if (result.Count() == 0)
            {
                return NotFound(new { Message = $"Пользователь с Id = {id} не найден" });
            }

            return Ok(result.First());
        }

        [HttpGet("get-all-users")] 
        public IActionResult GetAllUsers() 
        { 
            return Ok(_users); 
        }
    }
}
