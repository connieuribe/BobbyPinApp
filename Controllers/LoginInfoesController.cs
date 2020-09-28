using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BobbyPinApp.Models;

namespace BobbyPinApp.Controllers
{
    public class LoginInfoesController : Controller
    {
        private readonly CloudApplicationContext _context;

        public LoginInfoesController(CloudApplicationContext context)
        {
            _context = context;
        }

        // GET: LoginInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LoginInfo.ToListAsync());
        }

        // GET: LoginInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginInfo = await _context.LoginInfo
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (loginInfo == null)
            {
                return NotFound();
            }

            return View(loginInfo);
        }

        // GET: LoginInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LoginInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Username,UserPassword,FirstName,LastName")] LoginInfo loginInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loginInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loginInfo);
        }

        // GET: LoginInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginInfo = await _context.LoginInfo.FindAsync(id);
            if (loginInfo == null)
            {
                return NotFound();
            }
            return View(loginInfo);
        }

        // POST: LoginInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Username,UserPassword,FirstName,LastName")] LoginInfo loginInfo)
        {
            if (id != loginInfo.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loginInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoginInfoExists(loginInfo.UserId))
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
            return View(loginInfo);
        }

        // GET: LoginInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginInfo = await _context.LoginInfo
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (loginInfo == null)
            {
                return NotFound();
            }

            return View(loginInfo);
        }

        // POST: LoginInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loginInfo = await _context.LoginInfo.FindAsync(id);
            _context.LoginInfo.Remove(loginInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoginInfoExists(int id)
        {
            return _context.LoginInfo.Any(e => e.UserId == id);
        }
    }
}
