using Microsoft.AspNetCore.Mvc;
using HealthTrack.Data;
using HealthTrack.Models;
using Microsoft.AspNetCore.Authorization;

namespace HealthTrack.Controllers
{
    [Authorize]
    public class MedicoController : Controller
    {
        private readonly HealthTrackContext _context;

        public MedicoController(HealthTrackContext context)
        {
            _context = context;
        }

        // Listar médicos
        public IActionResult Index()
        {
            var medicos = _context.Medicos.ToList();
            return View(medicos);
        }

        // Exibir formulário para criar um médico
        public IActionResult Create()
        {
            return View();
        }

        // Salvar novo médico
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Medico medico)
        {
            if (ModelState.IsValid)
            {
                _context.Medicos.Add(medico);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(medico);
        }

        // Exibir formulário para editar um médico
        public IActionResult Edit(int id)
        {
            var medico = _context.Medicos.Find(id);
            if (medico == null) return NotFound();

            return View(medico);
        }

        // Salvar alterações do médico
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Medico medico)
        {
            if (ModelState.IsValid)
            {
                _context.Medicos.Update(medico);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(medico);
        }

        // Confirmar exclusão de médico
        public IActionResult Delete(int id)
        {
            var medico = _context.Medicos.Find(id);
            if (medico == null) return NotFound();

            return View(medico);
        }

        // Excluir médico
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var medico = _context.Medicos.Find(id);
            if (medico != null)
            {
                _context.Medicos.Remove(medico);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}