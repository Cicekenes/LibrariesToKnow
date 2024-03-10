using System;
using System.Collections.Generic;

namespace UdemySwagger.Models;

/// <summary>
/// Ürün nesnesi
/// </summary>
public partial class Product
{
    /// <summary>
    /// Ürün Id'si
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Ürün fiyatı
    /// </summary>
    public string Name { get; set; } = null!;
    /// <summary>
    /// Ürün fiyatı
    /// </summary>
    public decimal Price { get; set; }
    /// <summary>
    /// Ürün eklenme tarihi
    /// </summary>
    public DateTime? Date { get; set; }
    /// <summary>
    /// Ürün kategorisi
    /// </summary>
    public string? Category { get; set; }
}
