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
      //Get All Quests Here
      var model = _context.Quests.ToList();
      return View(model);
    }
    public IActionResult Details(string name)
    {
      //Get matching Quest here
      var model = _context.Quests.FirstOrDefault(e => e.Name == name);
      return View(model);
    }
    public IActionResult Update(Quest quest)
    {
      // add quest update logic here
      _context.Entry(quest).State = EntityState.Modified;
      _context.SaveChanges();
      return RedirectToAction("Index");
    }
    public IActionResult Delete(string name)
    {
      // delete record from database here
      var original = _context.Quests.FirstOrDefault(e => e.Name == name);
      _context.Quests.Remove(original);
      _context.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}