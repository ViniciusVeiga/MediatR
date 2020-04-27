using Microsoft.AspNetCore.Mvc;

namespace MeuPortfolio.PortfolioManagement.Api.Controllers
{
	[ApiController]
	public class HomeController : ControllerBase
	{
		[HttpGet]
		[Route("")]
		public object Get()
		{
			return new { version = "Version 0.0.1" };
		}
	}
}