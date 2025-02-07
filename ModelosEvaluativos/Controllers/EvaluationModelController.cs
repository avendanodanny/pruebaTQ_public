using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelosEvaluativos.Models;
using ModelosEvaluativos.Data;

namespace ModelosEvaluativos.Controllers;

public class EvaluationModelController : Controller
{
    private readonly AppDbContext _context;

    public EvaluationModelController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Models.ToListAsync());
    }
}