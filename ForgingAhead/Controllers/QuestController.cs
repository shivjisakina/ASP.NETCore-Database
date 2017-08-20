using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ForgingAhead.Models;

namespace ForgingAhead.Controllers
{
  public class QuestController : Controller
  {
    //Add Context Property Here
    private readonly ApplicationDbContext _context;

    public QuestController(ApplicationDbContext context)
    {
      //Inject ApplicationDbContext here
      _context = context;
    }

    [HttpGet]
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(Quest quest)
    {
      //Save Quest to Database Here
      _context.Quests.Add(quest);
      _context.SaveChanges();
      return RedirectToAction("Index");
    }

    public IActionResult Index()
    {
      return View();
    }
  }
}