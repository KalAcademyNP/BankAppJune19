using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankApp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace BankUI.Controllers
{
    [Authorize]
    public class AccountsController : Controller
    {

        // GET: Accounts
        public async Task<IActionResult> Index()
        {
            return View(Bank.GetAccountsByEmailAddress(HttpContext.User.Identity.Name)); ;
        }

        // GET: Accounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = Bank.FindAccountByAccountNumber(id.Value);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        public IActionResult Deposit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = Bank.FindAccountByAccountNumber(id.Value);
            return View(account);
        }

        [HttpPost]
        public IActionResult Deposit(IFormCollection data)
        {
            var accountNumber = Convert.ToInt32(data["AccountNumber"]);
            var amount = Convert.ToDecimal(data["Amount"]);
            Bank.Deposit(accountNumber, amount);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Transactions(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactions = Bank.GetTransactionsByAccountNumber(id.Value);
            return View(transactions);
        }

        public IActionResult Withdraw(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = Bank.FindAccountByAccountNumber(id.Value);
            return View(account);
        }

        [HttpPost]
        public IActionResult Withdraw(IFormCollection data)
        {
            var accountNumber = Convert.ToInt32(data["AccountNumber"]);
            var amount = Convert.ToDecimal(data["Amount"]);
            Bank.Withdraw(accountNumber, amount);
            return RedirectToAction(nameof(Index));
        }


        // GET: Accounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("EmailAddress,AccountType")]
            Account account)
        {
            if (ModelState.IsValid)
            {
                Bank.CreateAccount(account.EmailAddress, account.AccountType);
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // GET: Accounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = Bank.FindAccountByAccountNumber(id.Value);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, 
            [Bind("AccountNumber,EmailAddress,AccountType")]
            Account account)
        {
            if (id != account.AccountNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Bank.EditAccount(account);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.AccountNumber))
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
            return View(account);
        }

        // GET: Accounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = Bank.FindAccountByAccountNumber(id.Value);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Bank.DeleteAccount(id);
            return RedirectToAction(nameof(Index));
        }

        private bool AccountExists(int id)
        {
            return (Bank.FindAccountByAccountNumber(id) != null) ? true : false;
        }
    }
}
