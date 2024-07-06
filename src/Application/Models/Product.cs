// Copyright (c) 2024 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

namespace ShopBotNET.Application.Models;

/// <summary>
/// Represents a product
/// </summary>
/// <param name="name">Product name</param>
/// <param name="description">Product description</param>
/// <param name="price">Product price</param>
public class Product(string name, string description, int price)
{
    /// <summary>
    /// The name of the product
    /// </summary>
    public string Name { get; set; } = name;

    /// <summary>
    /// A short description of the product
    /// </summary>
    public string Description { get; set; } = description;

    /// <summary>
    /// The price of the product
    /// </summary>
    public int Price { get; set; } = price;

    /// <summary>
    /// The image of the product
    /// </summary>
    public Image Photo { get; set; }
}
