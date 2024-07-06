using ShopBotNET.Application.Models;

namespace ShopBotNET.Application.Services;

interface IProductService
{
    IEnumerable<CheckoutOrder> GetAvailableOrders();
}
