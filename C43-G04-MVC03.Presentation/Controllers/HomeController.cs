using System.Diagnostics;
using C43_G04_MVC03.Presentation.Models;

namespace C43_G04_MVC03.Presentation.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    // private readonly ISingletonSerivce _singleTonService1;
    // private readonly ISingletonSerivce _singleTonService2;
    // private readonly IScopedService _scopedService1;
    // private readonly IScopedService _scopedService2;
    // private readonly ITransientService _transientService1;
    // private readonly ITransientService _transientService2;
    //
    // public HomeController(ISingletonSerivce singletonSerivce1, ISingletonSerivce singletonSerivce2,
    //     ITransientService transientService1, ITransientService transientService2,
    //     IScopedService scopedService1, IScopedService scopedService2)
    // {
    //     this._singleTonService1 = singletonSerivce1;
    //     this._singleTonService2 = singletonSerivce2;
    //     
    //     this._transientService1 = transientService1;
    //     this._transientService2 = transientService2;
    //     
    //     this._scopedService1 = scopedService1;
    //     this._scopedService2 = scopedService2;
    // }

    // public string Index()
    // {
    //     StringBuilder sb = new StringBuilder();
    //     sb.AppendLine($"SingleTon1 :: {_singleTonService1.GetGuid()}");
    //     sb.AppendLine($"SingleTon2 :: {_singleTonService2.GetGuid()}");
    //     
    //     sb.AppendLine($"Scoped1 :: {_scopedService1.GetGuid()}");
    //     sb.AppendLine($"Scoped2 :: {_scopedService2.GetGuid()}");
    //     
    //     sb.AppendLine($"Transient1 :: {_transientService1.GetGuid()}");
    //     sb.AppendLine($"Scoped2 :: {_transientService2.GetGuid()}");
    //     
    //     return sb.ToString();
    // }
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }


    public IActionResult Our()
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
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}