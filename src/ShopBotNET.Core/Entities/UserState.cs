// Copyright (c) 2022 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

namespace ShopBotNET.Core.Entities
{
    public class UserState
    {
        public UserState()
        {
        }

        public UserState(long chatId, string name)
        {
            ChatId = chatId;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public int Id { get; set; }
        /// <summary>
        /// Unique identifier for chat where bot is waiting a response.
        /// </summary>
        public long ChatId { get; set; }
        /// <summary>
        /// State name
        /// </summary>
        public string Name { get; set; }
    }
}
