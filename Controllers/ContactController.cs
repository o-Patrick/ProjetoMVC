using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.Context;
using ProjetoMVC.Models;

namespace ProjetoMVC.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactBookContext _context;

        public ContactController(ContactBookContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var contacts = _context.Contacts.ToList();
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public IActionResult Create(Contact entity)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Add(entity);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(entity);
        }

        public IActionResult Edit(int id)
        {
            var contact = _context.Contacts.Find(id);
            
            if (contact == null)
                return RedirectToAction(nameof(Index));

            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(Contact entity)
        {
            var dbEntity = _context.Contacts.Find(entity.Id);

            if (dbEntity != null)
            {
                dbEntity.Name = entity.Name;
                dbEntity.Telephone = entity.Telephone;
                dbEntity.Active = entity.Active;

                _context.Contacts.Update(entity);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var contact = _context.Contacts.Find(id);

            if (contact == null)
                return RedirectToAction(nameof(Index));

            return View(contact);
        }

        public IActionResult Delete(int id)
        {
            var contact = _context.Contacts.Find(id);

            if (contact == null)
                return RedirectToAction(nameof(Index));

            return View(contact);
        }

        public IActionResult Delete(Contact contact)
        {
            var dbEntity = _context.Contacts.Find(contact.Id);

            if (dbEntity != null)
            {
                _context.Remove(contact);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Delete));
        }
    }
}