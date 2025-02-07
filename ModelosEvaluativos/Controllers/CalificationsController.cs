using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelosEvaluativos.Models;
using ModelosEvaluativos.Data;

namespace ModelosEvaluativos.Controllers;

public class CalificationsController : Controller
{
    private readonly AppDbContext _context;

    public CalificationsController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }
}