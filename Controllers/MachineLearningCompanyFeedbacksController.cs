using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MachineLearningCompany.Data;
using MachineLearningCompany.Models;
using Microsoft.AspNetCore.Authorization;

namespace MachineLearningCompany.Controllers
{
    public class MachineLearningCompanyFeedbacksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MachineLearningCompanyFeedbacksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MachineLearningCompanyFeedbacks
        public async Task<IActionResult> Index()
        {
            return View(await _context.MachineLearningCompanyFeedback.ToListAsync());
        }

        // GET: MachineLearningCompanyFeedbacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machineLearningCompanyFeedback = await _context.MachineLearningCompanyFeedback
                .FirstOrDefaultAsync(m => m.Id == id);
            if (machineLearningCompanyFeedback == null)
            {
                return NotFound();
            }

            return View(machineLearningCompanyFeedback);
        }

        // GET: MachineLearningCompanyFeedbacks/Create
        [Authorize(Roles = "Manager,User")]
        public IActionResult Create()
        {
            MachineLearningCompanyFeedback feedback = new MachineLearningCompanyFeedback();

            feedback.Date = DateTime.Now;
            feedback.Name = User.Identity.Name;


            return View(feedback);
            
        }

        // POST: MachineLearningCompanyFeedbacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager,User")]
        public async Task<IActionResult> Create([Bind("Id,Date,Name,Heading,Company,Feedback,Rating,Agree,Disagree")] MachineLearningCompanyFeedback machineLearningCompanyFeedback)
        {
            if (ModelState.IsValid)
            {
                _context.Add(machineLearningCompanyFeedback);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(machineLearningCompanyFeedback);
        }

        // GET: MachineLearningCompanyFeedbacks/Edit/5
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machineLearningCompanyFeedback = await _context.MachineLearningCompanyFeedback.FindAsync(id);
            machineLearningCompanyFeedback.Date = DateTime.Now;
            if (machineLearningCompanyFeedback == null)
            {
                return NotFound();
            }
            return View(machineLearningCompanyFeedback);
        }

        // POST: MachineLearningCompanyFeedbacks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Name,Heading,Company,Feedback,Rating,Agree,Disagree")] MachineLearningCompanyFeedback machineLearningCompanyFeedback)
        {
            if (id != machineLearningCompanyFeedback.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(machineLearningCompanyFeedback);
                    machineLearningCompanyFeedback.Date = DateTime.Now;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MachineLearningCompanyFeedbackExists(machineLearningCompanyFeedback.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(machineLearningCompanyFeedback);
        }


        [Authorize(Roles = "Manager,User")]
        public async Task<IActionResult> IncreaseFeedBackAgree(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedback =
                await _context.MachineLearningCompanyFeedback.SingleOrDefaultAsync(m => m.Id == id);

            if (feedback == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int totalAgree = feedback.Agree + 1;
                    feedback.Agree = totalAgree;


                    _context.Update(feedback);
                    await _context.SaveChangesAsync();

                }
                catch
                {
                    if (!MachineLearningCompanyFeedbackExists(feedback.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            else
            {
                //DO NOTHING
            }

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Manager,User")]
        public async Task<IActionResult> IncreaseFeedBackDisagree(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedback =
                await _context.MachineLearningCompanyFeedback.SingleOrDefaultAsync(m => m.Id == id);

            if (feedback == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int totalDisagree = feedback.Disagree + 1;
                    feedback.Disagree = totalDisagree;


                    _context.Update(feedback);
                    await _context.SaveChangesAsync();

                }
                catch
                {
                    if (!MachineLearningCompanyFeedbackExists(feedback.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            else
            {
                //DO NOTHING
            }

            return RedirectToAction("Index");
        }


        // GET: MachineLearningCompanyFeedbacks/Delete/5
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machineLearningCompanyFeedback = await _context.MachineLearningCompanyFeedback
                .FirstOrDefaultAsync(m => m.Id == id);
            if (machineLearningCompanyFeedback == null)
            {
                return NotFound();
            }

            return View(machineLearningCompanyFeedback);
        }

        // POST: MachineLearningCompanyFeedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var machineLearningCompanyFeedback = await _context.MachineLearningCompanyFeedback.FindAsync(id);
            _context.MachineLearningCompanyFeedback.Remove(machineLearningCompanyFeedback);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MachineLearningCompanyFeedbackExists(int id)
        {
            return _context.MachineLearningCompanyFeedback.Any(e => e.Id == id);
        }
    }
}
