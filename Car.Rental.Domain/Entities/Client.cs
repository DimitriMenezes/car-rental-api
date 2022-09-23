using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Car.Rental.Domain.Entities
{   
    
    public class Client : User
    {
        public string Cpf { get; set; }
        public DateTime Birthday { get; set; }

        public virtual Address Address { get; set; }
        public int AddressId { get; set; }
    }
}
