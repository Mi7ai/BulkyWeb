using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Bulky.Models
{
    public class Product
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title name is required")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Description name is required")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "ISBN name is required")]
        public string? ISBN { get; set; }

        [Required(ErrorMessage = "Author name is required")]
        public string? Author { get; set; }

        [Required(ErrorMessage = "Price name is required")]
        [Display(Name ="Price")]
        [Range(1, 1000, ErrorMessage = "Value must be between 1 - 1000")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Price 1-50 name is required")]
        [Display(Name ="Price 1-50")]
        [Range(1, 1000, ErrorMessage = "Value must be between 1 - 1000")]
        public double Price1to50 { get; set; }

        [Required(ErrorMessage = "Price 50+ name is required")]
        [Display(Name ="Price 50+")]
        [Range(1, 1000, ErrorMessage = "Value must be between 1 - 1000")]
        public double Price50 { get; set; }

        [Required(ErrorMessage = "Price 100+ name is required")]
        [Display(Name ="Price 100+")]
        [Range(1, 1000, ErrorMessage = "Value must be between 1 - 1000")]
        public double Price100 { get; set; }

        //this is the FK to the Category Table
        public int CategoryId { get; set; }

        //define the link to the Category Table
        [ValidateNever]
        //[ValidateNever] bypasses validation for ModelState on the controller if field does not meet requierements after posting form i.e create  
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        [ValidateNever]
        //[ValidateNever] bypasses validation for ModelState on the controller if field does not meet requierements after posting form i.e create
        public string? ImageUrl { get; set; }


    }
}

