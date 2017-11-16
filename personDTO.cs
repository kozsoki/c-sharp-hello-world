using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace interview
{
    public class personDTO
    {
        public personDTO(MySqlConnection connect)
        {
            this.connect = connect;
        }
        private MySqlConnection connect;
        public Person findOne(int id)
        {
            MySqlCommand command = new MySqlCommand("select * from people WHERE id= "+id, this.connect);
            Person person = new Person();
            MySqlDataReader myReader;
            myReader = command.ExecuteReader();
            myReader.Read();
            person.Id = myReader.GetInt32("id");
            person.Firstname = myReader.GetString("first_name");
            person.Lastname = myReader.GetString("last_name");
            myReader.Close();
            return person;
            

        }
        public List<Person> findAll() 
         {
            List<Person> people = new List<Person>();
            
            MySqlCommand command = new MySqlCommand("SELECT * FROM people", this.connect);
            MySqlDataReader myReader;
            
            myReader = command.ExecuteReader();
            while (myReader.Read())
            {
                Person person = new Person();
                person.Id = myReader.GetInt32("id");
                person.Firstname = myReader.GetString("first_name");
                person.Lastname = myReader.GetString("last_name");
                people.Add(person);
            }
            myReader.Close();
            return people;
         }

        public int insert(Person person)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO people(first_name, last_name) values('"+ person.Firstname +"', '"+ person.Lastname +"');", this.connect);
            
            command.ExecuteNonQuery();
            MySqlCommand command2 = new MySqlCommand("SELECT LAST_INSERT_ID() AS id");
            MySqlDataReader myReader;
            myReader = command.ExecuteReader();
            myReader.Read();
            
            int id = myReader.GetInt32("id");
            person.Id = id;
            myReader.Close();
            return id;
            

        }

        public void update(Person person)
        {
            MySqlCommand command = new MySqlCommand("UPDATE people SET (first_name = @fn, last_name = @ln) WHERE id=@id;", this.connect);
            command.Parameters.AddWithValue("@fn", person.Firstname);
            command.Parameters.AddWithValue("@ln", person.Lastname);
            command.Parameters.AddWithValue("@id", person.Id);
            command.ExecuteNonQuery();
            
            
         }
        /*public void delete(Person person)
        {
            
            MySqlCommand command = new MySqlCommand("DELETE FROM people WHERE id= " + del[0], this.connect);
          
            command.ExecuteNonQuery();
            
        }*/
    }
}
