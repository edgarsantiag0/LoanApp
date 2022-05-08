using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApp.Controllers
{
    public class CustomerLoansController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerLoansController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CustomerLoans
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CustomerLoans.Include(c => c.LoanProduct);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CustomerLoans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerLoan = await _context.CustomerLoans
                .Include(c => c.Customer)
                .Include(c => c.LoanProduct)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerLoan == null)
            {
                return NotFound();
            }

            return View(customerLoan);
        }

        // GET: CustomerLoans/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id");
            ViewData["LoanProductId"] = new SelectList(_context.LoanProducts, "Id", "Id");
            return View();
        }

        // POST: CustomerLoans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Amount,Balance,MonthsToPayback,LoanPurpose,LoanRepresentative,Date,CustomerId,LoanProductId")] CustomerLoan customerLoan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerLoan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", customerLoan.CustomerId);
            ViewData["LoanProductId"] = new SelectList(_context.LoanProducts, "Id", "Id", customerLoan.LoanProductId);
            return View(customerLoan);
        }

        // GET: CustomerLoans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerLoan = await _context.CustomerLoans.FindAsync(id);
            if (customerLoan == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", customerLoan.CustomerId);
            ViewData["LoanProductId"] = new SelectList(_context.LoanProducts, "Id", "Id", customerLoan.LoanProductId);
            return View(customerLoan);
        }

        // POST: CustomerLoans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Amount,Balance,MonthsToPayback,LoanPurpose,LoanRepresentative,Date,CustomerId,LoanProductId")] CustomerLoan customerLoan)
        {
            if (id != customerLoan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerLoan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerLoanExists(customerLoan.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", customerLoan.CustomerId);
            ViewData["LoanProductId"] = new SelectList(_context.LoanProducts, "Id", "Id", customerLoan.LoanProductId);
            return View(customerLoan);
        }

        // GET: CustomerLoans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerLoan = await _context.CustomerLoans
                .Include(c => c.Customer)
                .Include(c => c.LoanProduct)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerLoan == null)
            {
                return NotFound();
            }

            return View(customerLoan);
        }

        // POST: CustomerLoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerLoan = await _context.CustomerLoans.FindAsync(id);
            _context.CustomerLoans.Remove(customerLoan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerLoanExists(int id)
        {
            return _context.CustomerLoans.Any(e => e.Id == id);
        }
    }
}
