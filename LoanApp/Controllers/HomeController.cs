using AutoMapper;
using Contracts;
using LoanApp.Models;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LoanApp.Controllers
{
    public class HomeController : Controller
    {
        private ILoggerManager _logger;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public HomeController(ILoggerManager logger, IRepositoryManager repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            _logger.LogInfo("Here is info message.");
            _logger.LogDebug("Here is debug message.");
            _logger.LogWarn("Here is warn message.");
            _logger.LogError("Here is an error message.");

            //  _repository.Country.AnyMethodFromCompanyRepository();


            return View();
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
