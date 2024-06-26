﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoneyZoneMvc.Infrastructure.Data.Models
{
    public class OrderProduct
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;

        [Required]
        public int Quantity { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;
    }
}
