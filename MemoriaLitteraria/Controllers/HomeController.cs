using MemoriaLitteraria.Models;
using MemoriaLitteraria.Services;
using MemoriaLitteraria.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MemoriaLitteraria.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FileService _fileService;
        private readonly AuthorService _authorService;
        private readonly SectionService _sectionService;

        public HomeController(ILogger<HomeController> logger, FileService fileService, AuthorService authorService, SectionService sectionService)
        {
            _logger = logger;
            _fileService = fileService;
            _authorService = authorService;
            _sectionService = sectionService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Section()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new Error { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<IActionResult> GetSnippets(string search)
        {
            var results = await _sectionService.GetSectionsAsync(search);
            var snippets = new List<Snippet>();

            foreach (var item in results)   
            {
                Models.File file = await _fileService.GetFileAsync(item.FileId);
                Author author = await _authorService.GetAuthorAsync(file.AuthorId);
                snippets.Add(new Snippet(file, item, author, search));
            }

            return Json(snippets); ;
        }
    }
}
