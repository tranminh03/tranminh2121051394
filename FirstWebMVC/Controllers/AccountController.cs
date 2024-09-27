using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FirstWebMVC.Models;

namespace FirstWebMVC.Controllers;
public class AccountController : Controller
{
    public IActionResult Login()
    {
        return View();
    }
}