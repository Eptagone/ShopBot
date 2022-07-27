// Copyright (c) 2022 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using Microsoft.AspNetCore.Mvc;
using ShopBotNET.Core.Services;
using Telegram.BotAPI.GettingUpdates;

namespace ShopBotNET.Webhook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BotController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<BotController> _logger;
        private readonly ShopBot _bot;

        public BotController(ILogger<BotController> logger, IConfiguration configuration, ShopBot bot)
        {
            _logger = logger;
            _configuration = configuration;
            _bot = bot;
        }

        [HttpGet]
        public IActionResult Get([FromHeader(Name = "X-Telegram-Bot-Api-Secret-Token")] string secretToken)
        {
            if (_configuration["Telegram:SecretToken"] != secretToken)
            {
                _logger.LogWarning("Failed access!");
                return Unauthorized();
            }
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(
            [FromHeader(Name = "X-Telegram-Bot-Api-Secret-Token")] string secretToken,
            [FromBody] Update update, CancellationToken cancellationToken)
        {
            if (_configuration["Telegram:SecretToken"] != secretToken)
            {
#if DEBUG
                _logger.LogWarning("Failed access");
#endif
                return Unauthorized();
            }
            if (update == default)
            {
#if DEBUG
                _logger.LogWarning("Invalid update detected");
#endif
                return BadRequest();
            }
            _bot.OnUpdate(update);

            return await Task.FromResult(Ok());
        }
    }
}
