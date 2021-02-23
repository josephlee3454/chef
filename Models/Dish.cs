
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace chefndish.Models
{
      public class Dish
    {
        [Key]
        public int DishId {get;set;}
        // [Required]
        // [MinLength(2, ErrorMessage="Dish Name must be at least two characters!")]
        public string DishName {get;set;}
        [Required]
        [Range(0,1000, ErrorMessage="Calories cannot exceed 5000 or negative.")]
        public int calories {get;set;}
        [Required]
        [Range(0,10)]
        public int Tastyness {get;set;}
        // [Required]
        // [MinLength(5)]

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        [Required]
        public int ChefId {get;set;}
        public Chef Creator {get;set;}
    }

}

