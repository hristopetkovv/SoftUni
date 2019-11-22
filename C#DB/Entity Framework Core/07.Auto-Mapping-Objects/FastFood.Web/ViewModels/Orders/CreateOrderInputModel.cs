﻿using System.ComponentModel.DataAnnotations;

namespace FastFood.Web.ViewModels.Orders
{
    public class CreateOrderInputModel
    {
        [Required]
        public string Customer { get; set; }

        public string ItemName { get; set; }

        public string EmployeeName { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        public string Type { get; set; }
    }
}
