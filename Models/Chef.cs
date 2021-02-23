
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace chefndish.Models
{
    public class RestrictedDate : ValidationAttribute
    {
        public override bool IsValid(object date) 
        {
            return (DateTime)date < DateTime.Now;
        }
    }
public class Chef
{
    [Key]
    public int ChefId { get; set; }// entry id 

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<Dish> Dishes {get; set;}


    [Required]
    [MinLength(3, ErrorMessage = "first name must have at least five characters")]
    public string FirstName { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "Last name must have at least 2 characters")]
    public string LastName { get; set; }

    [Required]
    [Display(Name = "Date of Birth")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [RestrictedDate]
    public DateTime Birthday {get;set;}

    public int Age
        {
            get { return DateTime.Now.Year - Birthday.Year; }
        }


    }
}






