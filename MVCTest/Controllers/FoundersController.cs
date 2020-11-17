﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCTest.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MVCTest.Controllers
{
    public class FoundersController : Controller
    {
        IGenericRepository<Founder> founderRepository;
        public FoundersController(IGenericRepository<Founder> rep) => founderRepository = rep;
        public IActionResult Index()
        {
            return View(founderRepository.Get());
        }
        [HttpPost]
        public ViewResult addFounder(Founder f) {
            f.DateAdd = DateTime.Now;
            f.DateUpdate = DateTime.Now;
            if (ModelState.IsValid) {
                return View(founderRepository.Get());
            }
            else
                return View(founderRepository.Get());

        }
    }
}