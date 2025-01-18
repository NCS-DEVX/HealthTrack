using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using HealthTrack.Data;
using HealthTrack.Models;

namespace HealthTrack.Controllers
{
    [Authorize]
    public class ConsultaController : Controller
    {
        private readonly HealthTrackContext _context;

        public ConsultaController(HealthTrackContext context)
        {
            _context = context;
        }

        // Listar todas as consultas
        public IActionResult Index()
        {
            var consultas = _context.Consultas
                .Include(c => c.Medico)
                .Include(c => c.Paciente)
                .ToList();
            return View(consultas);
        }

        // Exibir detalhes de uma consulta
        public IActionResult Details(int id)
        {
            var consulta = _context.Consultas
                .Include(c => c.Medico)
                .Include(c => c.Paciente)
                .FirstOrDefault(c => c.Id == id);

            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // Exibir formulário para criar uma consulta
        public IActionResult Create()
        {
            ViewBag.Medicos = _context.Medicos.ToList();
            ViewBag.Pacientes = _context.Pacientes.ToList();
            return View();
        }

        // Salvar a nova consulta
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                _context.Consultas.Add(consulta);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Medicos = _context.Medicos.ToList();
            ViewBag.Pacientes = _context.Pacientes.ToList();
            return View(consulta);
        }

        // Exibir formulário para editar uma consulta
        public IActionResult Edit(int id)
        {
            var consulta = _context.Consultas.Find(id);
            if (consulta == null)
            {
                return NotFound();
            }

            ViewBag.Medicos = _context.Medicos.ToList();
            ViewBag.Pacientes = _context.Pacientes.ToList();
            return View(consulta);
        }

        // Salvar as alterações na consulta
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                _context.Consultas.Update(consulta);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Medicos = _context.Medicos.ToList();
            ViewBag.Pacientes = _context.Pacientes.ToList();
            return View(consulta);
        }

        // Confirmar exclusão de uma consulta
        public IActionResult Delete(int id)
        {
            var consulta = _context.Consultas
                .Include(c => c.Medico)
                .Include(c => c.Paciente)
                .FirstOrDefault(c => c.Id == id);

            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // Excluir uma consulta
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var consulta = _context.Consultas.Find(id);
            if (consulta != null)
            {
                _context.Consultas.Remove(consulta);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}