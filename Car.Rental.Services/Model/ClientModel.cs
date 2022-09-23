using System;
using System.Collections.Generic;
using System.Text;

namespace Car.Rental.Services.Model
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Cpf { get; set; }
        public DateTime Birthday { get; set; }
        public AddressModel Address { get; set; }
    }
}
