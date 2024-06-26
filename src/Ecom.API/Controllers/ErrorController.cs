﻿using Ecom.API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.API.Controllers
{
	[Route("errors/{statusCode}/[action]")]
	[ApiController]
	[ApiExplorerSettings(IgnoreApi = true)]
	public class ErrorController : ControllerBase
	{
		[HttpGet]
		public ActionResult Error(int statusCode)
		{
			return new ObjectResult(new BaseCommonResponse(statusCode));
		}
	}
}
