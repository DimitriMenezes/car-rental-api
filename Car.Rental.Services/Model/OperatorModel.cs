using System;
using System.Collections.Generic;
using System.Text;

namespace Car.Rental.Services.Model
{
    public class OperatorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string EnrollmentCode { get; set; }       
    }
}
