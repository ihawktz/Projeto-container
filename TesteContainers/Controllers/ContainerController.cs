using Microsoft.AspNetCore.Mvc;
using TesteContainers.Data;
using TesteContainers.Models;
using System.Collections.Generic;
using System.Linq;

namespace TesteContainers.Controllers
{
    public class ContainerController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ContainerController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
                IEnumerable<ContainerModel> containers = _db.Containers.ToList();
            return View(containers);
        }

        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? ID)
        {
            if (ID == null || ID == 0)
            {
                return NotFound();
            }

            ContainerModel container = _db.Containers.FirstOrDefault(x => x.ID == ID);

            if (container == null)
            {
                return NotFound();
            }

            return View(container);
        }

        [HttpPost]
        public IActionResult Editar(ContainerModel container)
        {
            if (ModelState.IsValid)
            {
                _db.Containers.Update(container);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(container);
        }

        [HttpPost]
        public IActionResult Adicionar(ContainerModel container)
        {
            if (ModelState.IsValid)
            {
                _db.Containers.Add(container);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(container);
        }

        [HttpGet]

        public IActionResult Excluir(int? ID)
        {
            if(ID == null || ID == 0)
            {
                return NotFound();
            }

            ContainerModel container = _db.Containers.FirstOrDefault(x => x.ID == ID);

            if (container == null)
            {
                return NotFound();
            }

            return View(container);
        }

        [HttpPost]
        public IActionResult Excluir(ContainerModel container)
        {
            if (container == null)
            {
                return NotFound();
            }

            _db.Containers.Remove(container); 
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
