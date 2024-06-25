// Copyright (c) 2022 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using Microsoft.AspNetCore.Mvc;
using ShopBotNET.Core.Services;
using Telegram.BotAPI.GettingUpdates;

namespace ShopBotNET.Webhook.Controllers;

[ApiController]
[Route("[controller]")]
public class BotController : ControllerBase
{
	private readonly IConfiguration _configuration;
	private readonly ILogger<BotController> _logger;
	private readonly ShopBot _bot;

	public BotController(ILogger<BotController> logger, IConfiguration configuration, ShopBot bot)
	{
		this._logger = logger;
		this._configuration = configuration;
		this._bot = bot;
	}

	[HttpGet]
	public IActionResult Get([FromHeader(Name = "X-Telegram-Bot-Api-Secret-Token")] string secretToken)
	{
		if (this._configuration["Telegram:SecretToken"] != secretToken)
		{
			this._logger.LogWarning("Failed access!");
			return this.Unauthorized();
		}
		return this.Ok();
	}

	[HttpPost]
	public async Task<IActionResult> PostAsync(
		[FromHeader(Name = "X-Telegram-Bot-Api-Secret-Token")] string secretToken,
		[FromBody] Update update, CancellationToken cancellationToken)
	{
		if (this._configuration["Telegram:SecretToken"] != secretToken)
		{
#if DEBUG
			this._logger.LogWarning("Failed access");
#endif
			return this.Unauthorized();
		}
		if (update == default)
		{
#if DEBUG
			this._logger.LogWarning("Invalid update detected");
#endif
			return this.BadRequest();
		}
		this._bot.OnUpdate(update);

		return await Task.FromResult(this.Ok());
	}
}
