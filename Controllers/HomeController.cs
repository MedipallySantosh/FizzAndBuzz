using FizzAndBuzz.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using FizzAndBuzz.Collections;
using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace FizzAndBuzz.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IFizzBuzzBL _fizzBuzzBL;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _fizzBuzzBL = new FizzBuzzBL();
        }

        public IActionResult Index()
        {
            return View(new FizzBuzzModel_Calculate());
        }

        [HttpPost]
        public ActionResult Index(FizzBuzzModel_Calculate model)
        {
                try
                {
                    List<string> outputList = new List<string>();
                    if (!string.IsNullOrWhiteSpace(model.InputNumbers) && model.InputNumbers.Length > 50)
                    {
                        outputList.Add(FBConstants.NumberOfChars);
                        model.OutputValues = outputList.ToArray();
                        return View(model);
                    }
                    string[] valuesArray = model.InputNumbers?.Split(',');

                    if (valuesArray == null || valuesArray.Length == 0)
                    {
                        outputList.Add(FBConstants.InvalidValue);
                        model.OutputValues = outputList.ToArray();
                        return View(model);
                    }
                   // FizzBuzzBL fizzBuzz = new FizzBuzzBL();
                    foreach (string value in valuesArray)
                        outputList.Add(value + " - " + _fizzBuzzBL.ArryValues(value));

                    // Store the divisions performed 
                    model.OutputValues = outputList.ToArray();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred: " + ex.Message);
                }

            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}