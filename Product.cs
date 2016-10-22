// Model file for specification of all input types for View

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ExceptionContextCode.Models
{
    public class Product:IValidatableObject
    {
    
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "*")]
        public string ProductName { get; set; }
        [Required(ErrorMessage="*")]
        public Decimal? UnitPrice { get; set; }
        public Int16? UnitsInStock { get; set; }
        public Int16? UnitsOnOrder { get; set; }
        public bool Discontinued { get; set; }

// ValidationContext is used for setting validation criteria for properties
// same like we do in .js file
        public IEnumerable<ValidationResult> Validate(ValidationContext validationcontext)
        {

// 1st condition hits when someone try to order a product unit that's production is stoped now
// 2nd condition hits when we try to order a product, thats already haveing >100 units in stock
// 3rd condition hits when price are negitive or zero

             if ((UnitsOnOrder > 0) && (Discontinued))
                yield return new ValidationResult("Can't order new product", new[] { "UnitsOnOrder" });
            if ((UnitsInStock > 100) && (UnitsOnOrder > 0))
                yield return new ValidationResult("We already have a lots of this", new[] { "UnitsOnOrder" });
            if ((UnitPrice <= 0))
                yield return new ValidationResult("Price must be Positive integer more than 0", new[] { "UnitPrice" });
           

        }

        public string Exception { get; set; }
    }
}
