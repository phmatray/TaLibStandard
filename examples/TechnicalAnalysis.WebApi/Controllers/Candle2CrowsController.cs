using Microsoft.AspNetCore.Mvc;
using TechnicalAnalysis.Business;
using TechnicalAnalysis.Candles.CandleDoji;

namespace TechnicalAnalysis.WebApi.Controllers;

[ApiController]
[Route("candles/[controller]")]
public class CandleDojiController : Controller
{
    private readonly ILogger<CandleDojiController> _logger;
    
    public CandleDojiController(ILogger<CandleDojiController> logger)
    {
        _logger = logger;
    }

    [HttpGet("sample", Name = "GetCandleDojiSample")]
    public ActionResult<CandleDojiResult> Index()
    {
        DataHistory data = DataHistoryRepository
            .GetDataHistoryFromFile("btc", "eur", "day");

        CandleDojiResult result = TAMath.CdlDoji(0, data.Count - 1, data.Open, data.High, data.Low, data.Close);
       
        return Ok(result);
    }
}
