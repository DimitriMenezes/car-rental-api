using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Car.Rental.Domain.Entities
{   
    [Table("User")]
    public class User : Base
    {        
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
