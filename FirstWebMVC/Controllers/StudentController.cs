using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FirstWebMVC.Models;

namespace FirstWebMVC.Controllers;

public class StudentController : Controller
{


    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(Student std)
    {
        string StrOutput = "Xin Chào " + std.name + " đến từ " + std.Address;
        ViewBag.Message = StrOutput;
        return View();
    }

}