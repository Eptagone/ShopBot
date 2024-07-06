// Copyright (c) 2024 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

namespace ShopBotNET.Application.Models;

/// <summary>
/// Represents an image
/// </summary>
public class Image(string url, int size, int width, int height)
{
    /// <summary>
    /// Image url
    /// </summary>
    public string Url { get; set; } = url;

    /// <summary>
    /// Image size
    /// </summary>
    public int Size { get; set; } = size;

    /// <summary>
    /// Image width
    /// </summary>
    public int Width { get; set; } = width;

    /// <summary>
    /// Image height
    /// </summary>
    public int Height { get; set; } = height;
}
