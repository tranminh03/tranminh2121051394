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

}
