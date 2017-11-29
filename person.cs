using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greencode.DatabaseConnection.KorosiZsombor
{
    public class Person
    {    
            private int id = 0; 
            private string firstName = null; 
            private string lastName = null;

        public int Id 
        {
            get { return id; }
            set { id = value; }
        }

        public string FirstName 
            {
                get { return firstName; }
                set { firstName = value; }
            }

        public string LastName 
            {
                get { return lastName; }
                set { lastName = value; }
            }

        public string toString()
        {
            //visszaterit egy szoveget
            return "Person: id: " + id + "First Name: " + firstName + "Last Name: " + lastName; 
        }
    }
}
