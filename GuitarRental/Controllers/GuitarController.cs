using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuitarRental.Models;
using GuitarRental.Data;
using Microsoft.AspNetCore.Authorization;
using GuitarRental.Filters;

namespace ASPNETtestprojectControllers
{
    [DisableBasicAuthentication]
    public class GuitarController : Controller
    {
        private ICRUDGuitarRepository guitars;
        private readonly AppDbContext _db;

        public GuitarController(ICRUDGuitarRepository guitars, AppDbContext db)
        {
            this.guitars = guitars;
            _db = db;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Authorize]
        public IActionResult AddForm()
        {
            return View();
        }
        [Authorize]
        public IActionResult List()
        {
            return View(guitars.FindAll());
        }
        [Authorize]
        public IActionResult Details(int id)
        {
            return View(guitars.FindById(id));
        }
        [HttpPost]
        [Authorize]
        public IActionResult Add(Guitar guitar)
        {
            if (ModelState.IsValid)
            {
                guitar = guitars.Add(guitar);
                return View("Confirm", guitar);
            }
            return View("AddForm");
        }
        [Authorize]
        public IActionResult Edit(int id)
        {
            return View(guitars.FindById(id));
        }
        [HttpPost]
        [Authorize]
        public IActionResult Edit(Guitar guitar)
        {
            if (ModelState.IsValid)
            {
                guitar = guitars.Update(guitar);
                return View("List", guitars.FindAll());
            }
            return View();
        }
        [Authorize]
        public IActionResult Delete(int id)
        {
            guitars.Delete(id);
            return View("List", guitars.FindAll());
        }
        public IActionResult FindById(int id)
        {
            return View("List", guitars.FindById(id));
        }
        [Authorize]
        public IActionResult Update(Guitar guitar)
        {
            if (ModelState.IsValid)
            {
                guitar = guitars.Update(guitar);
                return View("List", guitars.FindAll());
            }
            return View();
        }
    }
}
