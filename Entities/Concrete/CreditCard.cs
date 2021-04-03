using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class CreditCard:IEntity
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public string CardNumber { get; set; }
        public string SecurityNumber { get; set; }
        public string MounthOfExpirationDate { get; set; }
        public string YearOfExpirationDate { get; set; }
        public int Balance { get; set; }
    }
}
