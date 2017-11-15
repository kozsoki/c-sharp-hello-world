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
            public int Id
            {
                get { return id; }
                set { id = value; }
            }

            private string firstName;
            public string Firstname
            {
                get { return firstName; }
                set { firstName = value; }
            }

            private string lastName;
            public string Lastname
            {
                get { return lastName; }
                set { lastName = value; }
            } 
    }
}
