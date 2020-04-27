using Domain.Commands.Abstracts;
using Domain.Commands.Interfaces;
using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace MeuPortfolio.PortfolioManagement.Api.Controllers
{
    public class BaseController : Controller
    {
        protected BaseController() { }

        protected IActionResult Response(CommandResult commandResult, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            if (commandResult.Notifications.Any()) return BadRequest(commandResult.Notifications);
            return StatusCode((int)httpStatusCode, commandResult.Data);
        }

        protected IActionResult Ok<T>(IEnumerable<T> list)
        {
            if (list == null || !list.Any()) return NoContent();
            return Ok(list as object);
        }
    }
}
