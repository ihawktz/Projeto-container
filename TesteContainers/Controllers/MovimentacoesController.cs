using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Globalization;
using TesteContainers.Data;
using TesteContainers.Models;

namespace TesteContainers.Controllers
{
    public class MovimentacoesController : Controller
    {

        private readonly ApplicationDbContext _db;

        public MovimentacoesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<MovimentacoesModel> movimentacoes = _db.Movimentacoes.ToList();
            return View(movimentacoes);
        }

        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adicionar(MovimentacoesModel movs)
        {
            if (ModelState.IsValid) 
            {

                _db.Movimentacoes.Add(movs);
                _db.SaveChanges();

                return RedirectToAction("Index");

            }

            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? Id)
        {
            if(Id == null || Id == 0)
            {
                return NotFound();
            }

            MovimentacoesModel movimentacoes = _db.Movimentacoes.FirstOrDefault(x => x.Id == Id);

            if(movimentacoes == null)
            {
                return NotFound();
            }

            return View(movimentacoes);
        }

        [HttpPost]
        public IActionResult Editar(MovimentacoesModel movimentacoes)
        {
            if(ModelState.IsValid)
            {
                _db.Movimentacoes.Update(movimentacoes);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(movimentacoes);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            MovimentacoesModel movimentacoes = _db.Movimentacoes.FirstOrDefault(x => x.Id == id);

            if(movimentacoes == null)
            {
                return NotFound();
            }

            return View(movimentacoes);
        }

        [HttpPost]
        public IActionResult Excluir(MovimentacoesModel movimentacoes)
        {
            if (movimentacoes == null)
            {
                return NotFound();
            }

            _db.Movimentacoes.Remove(movimentacoes);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
