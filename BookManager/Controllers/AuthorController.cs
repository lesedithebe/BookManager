﻿using Microsoft.AspNetCore.Mvc;

namespace BookManager.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
