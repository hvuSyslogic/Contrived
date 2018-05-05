using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contrived.Data.Domain;
using Contrived.Data.Persistence;
using Microsoft.AspNetCore.Mvc;

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
            _contrivedContext.Database.EnsureDeleted();
            _contrivedContext.Database.EnsureCreated();
            
            return RedirectToAction("Index", "Home");
        }
    }
}