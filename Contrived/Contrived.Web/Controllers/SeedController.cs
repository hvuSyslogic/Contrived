using Contrived.Data.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackExchange.Profiling;
using StackExchange.Profiling.Storage;

namespace Contrived.Web.Controllers
{
    public class SeedController : Controller
    {
        private readonly ContrivedContext _contrivedContext;

        public SeedController(ContrivedContext contrivedContext)
        {
            _contrivedContext = contrivedContext;
        }
        
        public IActionResult Index()
        {
            using (MiniProfiler.Current.Step("Delete Database"))
            {
                _contrivedContext.Database.EnsureDeleted();
            }

            using (MiniProfiler.Current.Step("Created and Seed Database"))
            {
                _contrivedContext.Database.EnsureCreated();
            }
            
            var storage = new SqlServerStorage("");
            var scripts = storage.TableCreationScripts;

            foreach (var script in scripts)
            {
                _contrivedContext.Database.ExecuteSqlCommand(script);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}