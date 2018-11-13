using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DbConnection;
using QuotingDojo.Models;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(Quotes newQuote)
        {
            if(ModelState.IsValid)
            {
                string insertQuery = 
                    $@"INSERT INTO quotes (Name, Quote, CreatedAt, UpdatedAt) 
                        VALUES ('{newQuote.Name}', '{newQuote.Quote}', NOW(), NOW())";
                DbConnector.Execute(insertQuery);

                return RedirectToAction("quotes");
            }
            return View("Index");
        }

        [HttpGet("quotes")]
        public IActionResult Quotes()
        {
            
            ViewBag.Quotes = DbConnector.Query("SELECT * FROM quotes ORDER BY CreatedAt DESC");

            return View("quotes");
        }
    }
}
