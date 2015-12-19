using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace APM.WebAPI.Models
{
    public class Product
    {
        public string Description { get; set; }

        public decimal Price { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        [MinLength(6, ErrorMessage = "Min length is 6 characters")]
        public string ProductCode { get; set; }

        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        [MinLength(5, ErrorMessage = "Min length is 5 characters")]
        [MaxLength(11, ErrorMessage = "Max length is 11 characters")]
        public string ProductName { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}