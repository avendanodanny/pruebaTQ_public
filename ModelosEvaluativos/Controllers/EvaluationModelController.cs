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

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateModel([Bind("nombre,descripcion,estado")] EvaluationModel model)
    {
        
        try
        {
            if (ModelState.IsValid)
            {
                _context.Add(model);
                _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }
        catch (DbUpdateException /* ex */)
        {
            //Log the error (uncomment ex variable name and write a log.
            ModelState.AddModelError("", "Unable to save changes. " +
                "Try again, and if the problem persists " +
                "see your system administrator.");
        }
        return View(model);
    }

    public IActionResult EditModel(int id)
    {
        var model = _context.Models.First(acct => acct.id == id);

        return View(model);
    }

    [HttpPost]
    public IActionResult EditModel(EvaluationModel model)
    {
        if (ModelState.IsValid)
        {
            _context.Models.Update(model);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }

}