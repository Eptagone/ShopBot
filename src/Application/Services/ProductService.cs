using ShopBotNET.Application.Models;
using Telegram.BotAPI.Payments;

namespace ShopBotNET.Application.Services;

class ProductService : IProductService
{
    /// <inheritdoc />
    public IEnumerable<CheckoutOrder> GetAvailableOrders()
    {
        yield return new CheckoutOrder(
            new Product(
                "Gelatin Hair Treatment",
                "Wind messing up your hair? Book a gelatin treatment today to freeze your locks into a block of delicious kiwi-flavored jello - no more loose strands. Special offer valid for 12PM on Tuesday at 123 Main St.",
                2000
            )
            {
                Photo = new Image(
                    "https://telegra.ph/file/a01b1047f0367a8e0dc58.png",
                    31638,
                    512,
                    480
                )
            },
            "EUR",
            [new LabeledPrice("Early-Bird Discount", -22), new LabeledPrice("Free Gloop", 0)]
        )
        {
            MaxTipAmount = 20000,
            SuggestedTipAmounts = [200, 400]
        };

        yield return new CheckoutOrder(
            new Product(
                "Anti-Gravity Shoes",
                "WTread lightly on a whole new level. Guaranteed to work at participating locations outside of Earth’s orbit.",
                4000
            )
            {
                Photo = new Image(
                    "https://telegra.ph/file/97c7ffe13287e629a2518.png",
                    26512,
                    513,
                    380
                )
            },
            "EUR",
            [new LabeledPrice("Launch Sale", -1031), new LabeledPrice("Free Gloop", -1000)]
        )
        {
            MaxTipAmount = 1100,
            SuggestedTipAmounts = [660, 740, 800, 1000],
            NeedShippingAddress = true,
            IsFlexible = true
        };

        yield return new CheckoutOrder(
            new Product(
                "Fountain of Youth",
                "Staying hydrated does wonders for your skin. Known side effects include a tendency to stockpile objects under your bed and a deep appreciation for grunge music.",
                100000
            )
            {
                Photo = new Image(
                    "https://telegra.ph/file/710819789c7f7f38aa270.png",
                    45365,
                    512,
                    498
                )
            },
            "MXN",
            [
                new LabeledPrice("Ponce de Leon Fee", 50000),
                new LabeledPrice("Nirvana Royalties", 1300)
            ]
        )
        {
            MaxTipAmount = 500,
            SuggestedTipAmounts = [100, 300],
            NeedShippingAddress = true,
            IsFlexible = true
        };

        yield return new CheckoutOrder(
            new Product(
                "Inflatable Flowerbed",
                "Perfect for curing homesickness, adding that extra bit of thrill to a somewhat stale relationship, or Bring-Your-Petunias-to-Work day.",
                1600
            )
            {
                Photo = new Image(
                    "https://telegra.ph/file/a23d0dbeac2227c1d9f49.png",
                    38913,
                    512,
                    490
                )
            },
            "EUR",
            [new LabeledPrice("Hands Pump", 399)]
        )
        {
            MaxTipAmount = 500,
            SuggestedTipAmounts = [100],
            NeedShippingAddress = true,
            IsFlexible = true
        };

        yield return new CheckoutOrder(
            new Product(
                "DIY Hunter-Gatherer Kit",
                "Includes a spear, fish trap, 3 kilos of berries, 12 assorted wild mushrooms, and a wicker basket. Order now to get a Fishing Manual and Mushroom Guide for free!",
                12000
            )
            {
                Photo = new Image(
                    "https://telegra.ph/file/af58e212329329b974794.png",
                    45756,
                    512,
                    485
                )
            },
            "JPY",
            [new LabeledPrice("Fishing Manual", 0), new LabeledPrice("Mushroom Guide", 0)]
        )
        {
            MaxTipAmount = 20000,
            SuggestedTipAmounts = [200, 400],
            NeedShippingAddress = true,
            IsFlexible = true
        };
        yield return new CheckoutOrder(
            new Product(
                "Prepper Spray",
                "Guaranteed to repel bearded strangers wearing survival gear. 100% effective. Also works on sous chefs.",
                101
            )
            {
                Photo = new Image(
                    "https://telegra.ph/file/cb7c5db3fc193e665a51e.png",
                    34700,
                    512,
                    421
                )
            },
            "EUR",
            []
        )
        {
            MaxTipAmount = 10000,
            SuggestedTipAmounts = [100, 500, 700, 1000],
            NeedShippingAddress = true,
            IsFlexible = true
        };
        yield return new CheckoutOrder(
            new Product(
                "Koomsday Device",
                "One-button interface for selling your app to the Evil Empire, conveniently presented in the form of an aluminium briefcase.",
                1000
            )
            {
                Photo = new Image(
                    "https://telegra.ph/file/f8ec8f297d1a633ba77b4.png",
                    39918,
                    512,
                    460
                )
            },
            "USD",
            [new LabeledPrice("Per User Surcharge", 3203), new LabeledPrice("Used Once", -2303)]
        )
        {
            MaxTipAmount = 20000,
            SuggestedTipAmounts = [200, 400],
            NeedShippingAddress = true,
            IsFlexible = true
        };
        yield return new CheckoutOrder(
            new Product(
                "Keyboard of the Ancients",
                "Polished sandstone, cave-painted keys, integrated bash pad.",
                19000000
            )
            {
                Photo = new Image(
                    "https://telegra.ph/file/b9b400ef51b021176806d.png",
                    26121,
                    512,
                    280
                )
            },
            "DZD",
            [
                new LabeledPrice("Lifetime Warranty", 2000000),
                new LabeledPrice("Lighty Used", -1000000)
            ]
        )
        {
            MaxTipAmount = 10000,
            SuggestedTipAmounts = [100, 500, 700, 1000],
            NeedShippingAddress = true,
            IsFlexible = true
        };

        yield return new CheckoutOrder(
            new Product(
                "Excalibür",
                "Included: 1 hilt, 1 blade, 3 screws, 1 Royal Certificate, 1 sense of divine purpose. Some assembly required.",
                80000
            )
            {
                Photo = new Image(
                    "https://telegra.ph/file/8352aa4af5f588810d95d.png",
                    41949,
                    512,
                    491
                )
            },
            "GBP",
            [
                new LabeledPrice("Laxe Tax", 20000),
                new LabeledPrice("Royal Discount", -17100),
                new LabeledPrice("Pre-Shined", 0)
            ]
        )
        {
            MaxTipAmount = 1200,
            SuggestedTipAmounts = [100, 300],
            NeedShippingAddress = true,
            IsFlexible = true
        };

        yield return new CheckoutOrder(
            new Product(
                "“Genuine” Dragon",
                "Genuine 100% real dragon. Eats dog food. Does not breathe fire. Wags tail at maidens. Complimentary blanket with every purchase.",
                9999
            )
            {
                Photo = new Image(
                    "https://telegra.ph/file/97a3806f835642ada8050.png",
                    30885,
                    512,
                    420
                )
            },
            "EUR",
            [new LabeledPrice("Fireproof Blanket", 0)]
        )
        {
            MaxTipAmount = 10000,
            SuggestedTipAmounts = [100, 500, 700, 1000],
            NeedShippingAddress = true,
            IsFlexible = true
        };
    }
}
