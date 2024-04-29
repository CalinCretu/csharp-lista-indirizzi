using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_lista_indirizzi
{
    public class Address
    {
        public string Name { get; set; }                // definisco le proprieta' di Address
        public string Surname { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string ZIP { get; set; }

        public Address(string name, string surname, string street, string city, string province, string zip)            // costruttore per inizializzare un nuovo oggetto Address
        {
            this.Name = name;
            this.Surname = surname;
            this.Street = street;
            this.City = city;
            this.Province = province;
            this.ZIP = zip;
        }
        public override string ToString()                           // sovrascrivo il metodo ToString per ottenere una rappresentazione testuale dell'indirizzo
        {
            return $"{Name},{Surname},{Street},{City},{Province},{ZIP},";
        }
    }
}
