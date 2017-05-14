using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductApplication.Models.Product
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }

        [Display(Name="Product Name")]
        [Required(ErrorMessage="Please enter Product Name")]
        public string Name { get; set; }

        [Display(Name="Product Category")]
        [Required(ErrorMessage="Please select Category")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Please select Category")]
        public int Category { get; set; }
        public string CategoryName { get; set; }
        public List<SelectListItem> Categories { get; set; }

        [Range(1,Int32.MaxValue,ErrorMessage="Please enter valid Quantity")]
        [Display(Name="Quantity")]
        [Required(ErrorMessage="Please enter Quantity")]
        public int? Quantity { get; set; }

        [Range(1, Int32.MaxValue, ErrorMessage = "Please enter valid Price")]
        [Display(Name="Price")]
        [Required(ErrorMessage="Please enter Price")]
        public decimal? Price { get; set; }

        [Display(Name="Product Description")]
        [Required(ErrorMessage="Please enter Product Description")]
        public string Description { get; set; }
    }
}