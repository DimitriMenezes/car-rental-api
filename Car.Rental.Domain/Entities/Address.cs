using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Car.Rental.Domain.Entities
{
    [Table("Address")]
    public class Address : Base
    {
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string ReferenceNumber { get; set; }
        public string Complement { get; set; }
        public string City { get; set; }
        public string State { get; set; }       
    }
}
