using FizzAndBuzz.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using FizzAndBuzz.Collections;

namespace FizzAndBuzz.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFizzBuzzBL _fizzBuzzBL;
        /// <summary>
        /// Constructor Injection
        /// </summary>
        /// <param name="fizzBuzzBL"></param>
        public HomeController( IFizzBuzzBL fizzBuzzBL)
        {
            _fizzBuzzBL = fizzBuzzBL;
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
                    foreach (string value in valuesArray)
                        outputList.Add(value + " - " + _fizzBuzzBL.ArryValues(value));

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