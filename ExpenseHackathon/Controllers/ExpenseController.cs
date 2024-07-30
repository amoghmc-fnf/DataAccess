using ExpenseHackathon.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseHackathon.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ExpenseDbContext expenseDbContext;

        public ExpenseController(ExpenseDbContext expenseDbContext)
        {
            this.expenseDbContext = expenseDbContext;
        }

        public JsonResult AllExpenses() => Json(expenseDbContext.Expenses.ToList());

        [HttpGet]
        public JsonResult FindByDescription(string description)
        {
            var expenses = expenseDbContext.Expenses.Where((e) => e.Description.Contains(description)).ToList();
            return Json(expenses);
        }

        [HttpGet]
        public JsonResult FindByDate(DateTime date)
        {
            var formattedDate = date.GetDateTimeFormats();
            var expenses = expenseDbContext.Expenses.Where((e) => e.Date.Equals(date)).ToList();
            return Json(expenses);
        }

        [HttpGet]
        public JsonResult FindByMonth(DateTime month)
        {
            var expenses = expenseDbContext.Expenses.Where((e) =>
                (e.Date.Month.Equals(month.Month) && e.Date.Year.Equals(month.Year))).ToList();

            return Json(expenses);
        }

        [HttpPost]
        public string AddExpense(Expense expense)
        {
            expenseDbContext.Expenses.Add(expense);
            expenseDbContext.SaveChanges();
            return "Expense added successfully!";
        }
    }

}
