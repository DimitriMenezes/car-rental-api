using System;
using System.Collections.Generic;
using System.Text;

namespace Car.Rental.Services.Model
{
    public class AddressModel
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string ReferenceNumber { get; set; }
        public string Complement { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
