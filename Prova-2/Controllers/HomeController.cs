using Microsoft.AspNetCore.Mvc;
using Prova_2.Models;
using Prova_2.Services;
using System.Diagnostics;

namespace Prova_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticoloService _articoloService;
        private readonly IWebHostEnvironment _env;



        public HomeController(ILogger<HomeController> logger, IArticoloService articoloService, IWebHostEnvironment env)
        {
            _logger = logger;
            _articoloService = articoloService;
            _env = env;
        
        
        
        }

        public IActionResult Index()
        {
            var articoli = _articoloService.GetAll().OrderByDescending(a => a.Id);
           return View(articoli);
        }


        public IActionResult Dettagli(int id) 
        { 
        var articolo=_articoloService.GetById(id);
            if (articolo == null) 
            { return NotFound(); }
        
        return View(articolo);
        
        
        }
        public IActionResult Crea() { return View(new ArticoloInputModel()); }
        
        [HttpPost]

        public IActionResult Crea(ArticoloInputModel input)
        {
          
                var articolo = new Articolo
                {
                    Nome = input.Nome,
                    Prezzo = input.Prezzo,
                    Descrizione = input.Descrizione
                };
                _articoloService.Create(articolo);
                string uploads = Path.Combine(_env.WebRootPath, "foto");

                if (input.ImmagineCopertina?.Length > 0)
                {
                    string filePath = Path.Combine(uploads, $"{articolo.Id}_copertina.jpg");
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        input.ImmagineCopertina.CopyTo(fileStream);
                    }
                    articolo.ImmagineCopertina = $"/foto/{articolo.Id}_copertina.jpg";

                }

                if (input.ImmagineAggiuntiva1?.Length > 0)
                {
                    string filePath = Path.Combine(uploads, $"{articolo.Id}_aggiuntiva1.jpg");
                    using (var fileStream = new FileStream(filePath, FileMode.Create)) 
                    {

                        input.ImmagineAggiuntiva1.CopyTo(fileStream);
                    }
                    articolo.ImmagineAggiuntiva1 = $"/foto/{articolo.Id}_aggiuntiva1.jpg";

                }


                if (input.ImmagineAggiuntiva2?.Length > 0)
                {
                    string filePath = Path.Combine(uploads, $"{articolo.Id}_aggiuntiva2.jpg");
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        input.ImmagineAggiuntiva2.CopyTo(fileStream);
                    }
                    articolo.ImmagineAggiuntiva2 = $"/foto/{articolo.Id}_aggiuntiva2.jpg";
                }


                _articoloService.Update(articolo);


                return RedirectToAction ( nameof (Index));


        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
