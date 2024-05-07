using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using movieappauth.Data;
using Microsoft.EntityFrameworkCore;
using movieappauth.Models;
using Microsoft.AspNetCore.Identity;
using movieappauth.Models;
using Microsoft.AspNetCore.Identity; 

namespace movieappauth.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly ILogger<CatalogoController> _logger;
        private readonly ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;

        public CatalogoController(ILogger<CatalogoController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(string? searchString)
        {
            var productos = from o in _context.DataProducto select o;
            if(!String.IsNullOrEmpty(searchString)){
                productos = productos.Where(x => x.Name.Contains(searchString));
            }
            return View(productos.ToList());
        }
        
        public async Task<IActionResult> Details(int? id){
            Producto objProduct = await _context.DataProducto.FindAsync(id);
            if(objProduct == null){
                return NotFound();
            }
            return View(objProduct);
        }

        public async Task<IActionResult> Add (int? id){
             var userID= _userManager.GetUserName(User);
             if(userID == null){
                ViewData["Message"]="Por favor debe loguearse antes de agregar un producto";
                List<Producto> productos = new List<Producto>();
                return View("Index", productos);
             }else{
                var producto = await _context.DataProducto.FindAsync(id);
                return RedirectToAction(nameof(Index));
             }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}