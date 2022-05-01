// Copyright (c) 2022 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using ShopBotNET.Core.Data;
using ShopBotNET.Core.Entities;
using Telegram.BotAPI.InlineMode;
using Telegram.BotAPI.Payments;

namespace ShopBotNET.Infrastructure.Data
{
    public sealed class ProductRepository : IProducts
    {
        private static IEnumerable<ProductInfo> products = new ProductInfo[]
        {
            new ProductInfo(
                "Gelatin Hair Treatment",
                "Wind messing up your hair? Book a gelatin treatment today to freeze your locks into a block of delicious kiwi-flavored jello – no more loose strands. Special offer valid for 12PM on Tuesday at 123 Main St.",
                "https://telegra.ph/file/a01b1047f0367a8e0dc58.png",
                "EUR",
                new LabeledPrice[]
                {
                    new LabeledPrice("Subtotal", 2000),
                    new LabeledPrice("Early-Bird Discount", -22),
                    new LabeledPrice("Free Gloop", 0)
                })
            {
                MaxTipAmount = 20000,
                SuggestedTipAmounts = new uint[] { 200, 400 }
            },
            new ProductInfo(
                "Anti-Gravity Shoes",
                "WTread lightly on a whole new level. Guaranteed to work at participating locations outside of Earth’s orbit.",
                "https://telegra.ph/file/97c7ffe13287e629a2518.png",
                "EUR",
                new LabeledPrice[]
                {
                    new LabeledPrice("Subtotal", 4000),
                    new LabeledPrice("Launch Sale", -1031),
                    new LabeledPrice("Free Gloop", -1000)
                })
            {
                MaxTipAmount = 1100,
                SuggestedTipAmounts = new uint[] { 660, 740, 800, 1000 },
                NeedShippingAddress = true,
                IsFlexible = true
            },
            new ProductInfo(
                "Fountain of Youth",
                "Staying hydrated does wonders for your skin. Known side effects include a tendency to stockpile objects under your bed and a deep appreciation for grunge music.",
                "https://telegra.ph/file/710819789c7f7f38aa270.png",
                "MXN",
                new LabeledPrice[]
                {
                    new LabeledPrice("Subtotal", 100000),
                    new LabeledPrice("Ponce de Leon Fee", 50000),
                    new LabeledPrice("Nirvana Royalties", 1300)
                })
            {
                MaxTipAmount = 500,
                SuggestedTipAmounts = new uint[] { 100, 300 },
                NeedShippingAddress = true,
                IsFlexible = true
            },
            new ProductInfo(
                "Inflatable Flowerbed",
                "Perfect for curing homesickness, adding that extra bit of thrill to a somewhat stale relationship, or Bring-Your-Petunias-to-Work day.",
                "https://telegra.ph/file/a23d0dbeac2227c1d9f49.png",
                "EUR",
                new LabeledPrice[]
                {
                    new LabeledPrice("Subtotal", 1600),
                    new LabeledPrice("Hands Pump", 399)
                })
            {
                MaxTipAmount = 500,
                SuggestedTipAmounts = new uint[] { 100 },
                NeedShippingAddress = true,
                IsFlexible = true
            },
            new ProductInfo(
                "DIY Hunter-Gatherer Kit",
                "Includes a spear, fish trap, 3 kilos of berries, 12 assorted wild mushrooms, and a wicker basket. Order now to get a Fishing Manual and Mushroom Guide for free!",
                "https://telegra.ph/file/af58e212329329b974794.png",
                "JPY",
                new LabeledPrice[]
                {
                    new LabeledPrice("Subtotal", 12000),
                    new LabeledPrice("Fishing Manual", 0),
                    new LabeledPrice("Mushroom Guide", 0)
                })
            {
                MaxTipAmount = 20000,
                SuggestedTipAmounts = new uint[] { 200, 400 },
                NeedShippingAddress = true,
                IsFlexible = true
            },
            new ProductInfo(
                "Prepper Spray",
                "Guaranteed to repel bearded strangers wearing survival gear. 100% effective. Also works on sous chefs.",
                "https://telegra.ph/file/cb7c5db3fc193e665a51e.png",
                "EUR",
                new LabeledPrice[]
                {
                    new LabeledPrice("Subtotal", 101)
                })
            {
                MaxTipAmount = 10000,
                SuggestedTipAmounts = new uint[] { 100, 500, 700, 1000 },
                NeedShippingAddress = true,
                IsFlexible = true
            },
            new ProductInfo(
                "Koomsday Device",
                "One-button interface for selling your app to the Evil Empire, conveniently presented in the form of an aluminium briefcase.",
                "https://telegra.ph/file/f8ec8f297d1a633ba77b4.png",
                "USD",
                new LabeledPrice[]
                {
                    new LabeledPrice("Subtotal", 1000),
                    new LabeledPrice("Per User Surcharge", 3203),
                    new LabeledPrice("Used Once", -2303)
                })
            {
                MaxTipAmount = 20000,
                SuggestedTipAmounts = new uint[] { 200, 400 },
                NeedShippingAddress = true,
                IsFlexible = true
            },
            new ProductInfo(
                "Keyboard of the Ancients",
                "Polished sandstone, cave-painted keys, integrated bash pad.",
                "https://telegra.ph/file/b9b400ef51b021176806d.png",
                "DZD",
                new LabeledPrice[]
                {
                    new LabeledPrice("Subtotal", 19000000),
                    new LabeledPrice("Lifetime Warranty", 2000000),
                    new LabeledPrice("Lighty Used", -1000000)
                })
            {
                MaxTipAmount = 10000,
                SuggestedTipAmounts = new uint[] { 100, 500, 700, 1000 },
                NeedShippingAddress = true,
                IsFlexible = true
            },
            new ProductInfo(
                "Excalibür",
                "Included: 1 hilt, 1 blade, 3 screws, 1 Royal Certificate, 1 sense of divine purpose. Some assembly required.",
                "https://telegra.ph/file/8352aa4af5f588810d95d.png",
                "GBP",
                new LabeledPrice[]
                {
                    new LabeledPrice("Subtotal", 80000),
                    new LabeledPrice("Laxe Tax", 20000),
                    new LabeledPrice("Royal Discount", -17100),
                    new LabeledPrice("Pre-Shined", 0)
                })
            {
                MaxTipAmount = 1200,
                SuggestedTipAmounts = new uint[] { 100, 300 },
                NeedShippingAddress = true,
                IsFlexible = true
            },
            new ProductInfo(
                "“Genuine” Dragon",
                "Genuine 100% real dragon. Eats dog food. Does not breathe fire. Wags tail at maidens. Complimentary blanket with every purchase.",
                "https://telegra.ph/file/97a3806f835642ada8050.png",
                "EUR",
                new LabeledPrice[]
                {
                    new LabeledPrice("Subtotal", 9999),
                    new LabeledPrice("Fireproof Blanket", 0)
                })
            {
                MaxTipAmount = 10000,
                SuggestedTipAmounts = new uint[] { 100, 500, 700, 1000 },
                NeedShippingAddress = true,
                IsFlexible = true
            }
        };

        public IEnumerable<InlineQueryResult> GetProducts(string providerToken)
        {
            const uint photoSize = 51488;
            const uint photoHeight = 490;
            const uint photoWidth = 640;

            foreach (var p in products)
            {
                var invoice = new InputInvoiceMessageContent(p.Name, p.Description, p.Payload, providerToken, p.Currency, p.Prices)
                {
                    PhotoUrl = p.PhotoUrl,
                    PhotoSize = photoSize,
                    PhotoHeight = photoHeight,
                    PhotoWidth = photoWidth,
                    IsFlexible = p.IsFlexible,
                    NeedShippingAddress = p.NeedShippingAddress
                };

                if (p.MaxTipAmount != null)
                {
                    invoice.MaxTipAmount = (uint)p.MaxTipAmount;
                }
                if (p.SuggestedTipAmounts != null)
                {
                    invoice.SuggestedTipAmounts = p.SuggestedTipAmounts;
                }

                yield return new InlineQueryResultArticle
                {
                    Id = p.Name,
                    Title = p.Name,
                    Description = p.Description,
                    ThumbUrl = p.PhotoUrl,
                    InputMessageContent = invoice
                };
            }
        }

        public IEnumerable<ShippingOption> GetShippingOptions(string payload, ShippingAddress address)
        {
            return new ShippingOption[]
            {
                new ShippingOption
                {
                    Id = "Free",
                    Title = "Free Shipping - Pigeons",
                    Prices = new LabeledPrice[]
                        {
                            new LabeledPrice("Shipping", 0)
                        }
                },
                new ShippingOption
                {
                    Id = "FedEx",
                    Title = "FedEx",
                    Prices = new LabeledPrice[]
                    {
                        new LabeledPrice("Shipping", 499),
                        new LabeledPrice("Handling", 299),
                        new LabeledPrice("Taxes", 100)
                    }
                },
                new ShippingOption
                {
                    Id = "DHL",
                    Title = "DHL",
                    Prices = new LabeledPrice[]
                    {
                        new LabeledPrice("Shipping", 599),
                        new LabeledPrice("Handling", 399),
                        new LabeledPrice("Taxes", 50)
                    }
                }
            };
        }
    }
}
