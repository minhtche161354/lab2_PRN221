using Lab2.Binding;
using Lab2.Validation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models
{
    public class Customer
    {
        [Required(ErrorMessage = "Customer name is required !!")]
        [StringLength(20,MinimumLength = 3, ErrorMessage = "Name must be shorter than 20 and longer than 3 characters!!")]
        [Display(Name = "Customer Name")]
        [ModelBinder(BinderType = typeof(CheckNameBinding))]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Email is required!!")]
        [EmailAddress]
        [Display(Name = "User Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "YOB is required!!")]
        [Display(Name = "Year of birth")]
        [Range(1960,2023,ErrorMessage = "invalid")]
        [CustomerValidation]
        public int? YearOfBirth { get; set; }
    }
}
