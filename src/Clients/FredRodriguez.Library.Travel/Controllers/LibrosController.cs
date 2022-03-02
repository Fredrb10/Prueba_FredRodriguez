using FredRodriguez.Library.Travel.Data;
using FredRodriguez.Library.Travel.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace FredRodriguez.Library.Travel.Controllers
{
   // [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class LibrosController : Controller
    {
        private readonly PersistenceContext _context;

        public LibrosController(PersistenceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return Redirect("https://localhost:44331/" + $"?ReturnBaseUrl={this.Request.Scheme}://{this.Request.Host}/");
        }

        public IActionResult Index()
        {
            IEnumerable<Libro> listLibros = _context.Libros;
            return View(listLibros);
        }

        [HttpGet]
        public async Task<IActionResult> Connect(string access_token)
        {
            var token = access_token.Split('.');
            var base64Content = Convert.FromBase64String(token[1] + "=");

            var user = JsonSerializer.Deserialize<AccessTokenUserInformation>(base64Content);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.nameid),
                new Claim(ClaimTypes.Name, user.unique_name),
                new Claim(ClaimTypes.Email, user.email),
                new Claim("access_token", access_token)
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IssuedUtc = DateTime.UtcNow.AddHours(10)
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return Redirect("~/Libros");
        }

        public IActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Libro libro)
        {
           
          libro.id = System.Guid.NewGuid();
          _context.Libros.Add(libro);
          _context.SaveChanges();

          TempData["mensaje"] = "Libro guardado exitosamente";
          return RedirectToAction("Index");
           
        }

        public IActionResult Edit(Guid? id)
        {
            if(id == null ) return NotFound();
           
            var libro = _context.Libros.Find(id);

            if(libro == null) return NotFound();

            return View(libro);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Libro libro)
        {  
             _context.Libros.Update(libro);
             _context.SaveChanges();
             TempData["mensaje"] = "Libro actualizado exitosamente";
             return RedirectToAction("Index");
           
        }
        public IActionResult Delete(Guid? id)
        {
            if (id == null) return NotFound();

            var libro = _context.Libros.Find(id);

            if (libro == null) return NotFound();

            return View(libro);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteLibro(Guid? id)
        {
            var libro = _context.Libros.Find(id);

            if(libro == null) return NotFound();

            _context.Libros.Remove(libro);
            _context.SaveChanges();

           TempData["mensaje"] = "Libro eliminado exitosamente";
           return RedirectToAction("Index");
           
        }
    }
}
