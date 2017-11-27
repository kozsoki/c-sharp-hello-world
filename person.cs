using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interview
{
    public class Person
    {
    
            private int id; //egy private valtozo amit csak itt hasznalhatsz a Person osztalyban
            private string firstName; //egy private valtozo amit csak itt hasznalhatsz a Person osztalyban
            private string lastName; //egy private valtozo amit csak itt hasznalhatsz a Person osztalyban

        //method
        public int Id 
        {
            get { return id; }
            set { id = value; }
        }
        //method
        public string Firstname 
            {
                get { return firstName; }
                set { firstName = value; }
            }

        //method
        public string Lastname 
            {
                get { return lastName; }
                set { lastName = value; }
            }
        //method
        public string toString()
        {
            //visszaterit egy szoveget
            return "Person: id: " + id + "First Name: " + firstName + "Last Name: " + lastName; 
        }
    }
}
