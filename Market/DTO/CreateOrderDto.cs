﻿using System.ComponentModel.DataAnnotations;
using Market.Models;

namespace Market.DTO;

public class OrderDto
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public Guid CustomerId { get; set; }
    public Guid SellerId { get; set; }
    public Guid ProductId { get; set; }

    internal static OrderDto FromModel(Order order) =>
        new()
        {
            Id = order.Id,
            CustomerId = order.CustomerId,
            SellerId = order.SellerId,
            ProductId = order.ProductId
        };
}