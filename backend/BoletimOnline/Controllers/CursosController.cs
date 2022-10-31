using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BoletimOnline;
using BoletimOnline.Models;

namespace BoletimOnline.Controllers
{
    public class CursosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CursosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cursoes
        public async Task<IActionResult> Listarcursos()
        {
              return View(await _context.Curso.ToListAsync());
        }
             
        
    }
}
