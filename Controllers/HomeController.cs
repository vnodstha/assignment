using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MachineLearningCompany.Models;
using MachineLearningCompany.Data;
using Microsoft.EntityFrameworkCore;

namespace MachineLearningCompany.Controllers
{
    public class HomeController : Controller
    {
        private readonly Data.ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context) { _context = context; }
        public async Task<IActionResult> Index()
        {
            ViewData["Message"] = "Your application description page.";
            return View(await _context.MachineLearningCompanyFeedback.ToListAsync());
        }

        public async Task<IActionResult> About()
        {
            ViewData["Message"] = "Your application description page.";
            return View(await _context.MachineLearningCompanyFeedback.ToListAsync());
            
        }

        

        public async Task<IActionResult> MachineLearningCompany()
        {
            ViewData["Message"] = "Your application description page.";
            return View(await _context.MachineLearningCompanyFeedback.ToListAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
