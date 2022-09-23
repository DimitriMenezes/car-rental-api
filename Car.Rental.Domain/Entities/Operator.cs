using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Car.Rental.Domain.Entities
{    
    public class Operator : User
    {        
        public string EnrollmentCode { get; set; }
    }
}
