using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interview
{
    public class Person
    {
    
            private int id;
            private string firstName;
            private string lastName;
            public int Id
        {
            get { return id; }
            set { id = value; }
        }
           public string Firstname
            {
                get { return firstName; }
                set { firstName = value; }
            }  
            public string Lastname
            {
                get { return lastName; }
                set { lastName = value; }
            }

        public string toString() {
            return "Person: id: " + id + "First Name: " + firstName + "Last Name: " + lastName;
        }
    }
}
