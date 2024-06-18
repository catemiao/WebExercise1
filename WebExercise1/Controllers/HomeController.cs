using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebExercise1.Models;

namespace WebExercise1.Controllers
{
    public class HomeController : Controller
    {
        public readonly ISingleton _singleton;
        public readonly IScoped _scoped;
        public readonly ITransient _transient;

        public HomeController(ILogger<HomeController> logger, ISingleton singleton, IScoped scoped, ITransient transient)
        {
            _singleton = singleton;
            _scoped = scoped;
            _transient = transient;
        }

        public IActionResult Index(string param)
        {
            var message = $"<tr><td>Singleton</td><td>{_singleton.Id}</td></tr>"
                        + $"<tr><td>Scoped</td><td>{_scoped.Id}</td></tr>"
                        + $"<tr><td>Transient</td><td>{_transient.Id}</td></tr>";
            return View(model: message);
        }
    }
}
