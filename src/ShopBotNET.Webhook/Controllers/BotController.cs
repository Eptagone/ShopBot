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

        [HttpGet("{webhookToken}")]
        public IActionResult Get(string webhookToken)
        {
            if (_configuration["Telegram:WebhookToken"] != webhookToken)
            {
                _logger.LogWarning("Failed access!");
                Unauthorized();
            }
            return Ok();
        }

        [HttpPost("{webhookToken}")]
        public async Task<IActionResult> PostAsync(string webhookToken, [FromBody] Update update, CancellationToken cancellationToken)
        {
            if (_configuration["Telegram:WebhookToken"] != webhookToken)
            {
#if DEBUG
                _logger.LogWarning("Failed access");
#endif
                Unauthorized();
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
