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
    public class PostsController : Controller
    {
        private readonly CloudApplicationContext _context;

        public PostsController(CloudApplicationContext context)
        {
            _context = context;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
            var cloudApplicationContext = _context.Post.Include(p => p.Cat).Include(p => p.Condition).Include(p => p.User);
            return View(await cloudApplicationContext.ToListAsync());
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .Include(p => p.Cat)
                .Include(p => p.Condition)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            ViewData["CatId"] = new SelectList(_context.Category, "CatId", "CatId");
            ViewData["ConditionId"] = new SelectList(_context.Condition, "ConditionId", "ConditionId");
            ViewData["UserId"] = new SelectList(_context.LoginInfo, "UserId", "Username");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,ConditionId,CatId")] Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CatId"] = new SelectList(_context.Category, "CatId", "CatId", post.CatId);
            ViewData["ConditionId"] = new SelectList(_context.Condition, "ConditionId", "ConditionId", post.ConditionId);
            ViewData["UserId"] = new SelectList(_context.LoginInfo, "UserId", "Username", post.UserId);
            return View(post);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["CatId"] = new SelectList(_context.Category, "CatId", "CatId", post.CatId);
            ViewData["ConditionId"] = new SelectList(_context.Condition, "ConditionId", "ConditionId", post.ConditionId);
            ViewData["UserId"] = new SelectList(_context.LoginInfo, "UserId", "Username", post.UserId);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ConditionId,CatId")] Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.Id))
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
            ViewData["CatId"] = new SelectList(_context.Category, "CatId", "CatId", post.CatId);
            ViewData["ConditionId"] = new SelectList(_context.Condition, "ConditionId", "ConditionId", post.ConditionId);
            ViewData["UserId"] = new SelectList(_context.LoginInfo, "UserId", "Username", post.UserId);
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .Include(p => p.Cat)
                .Include(p => p.Condition)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _context.Post.FindAsync(id);
            _context.Post.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return _context.Post.Any(e => e.Id == id);
        }
    }
}
