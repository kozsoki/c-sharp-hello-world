using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Greencode.DatabaseConnection.KorosiZsombor
{
    public class PersonDTO 
    {
        private MySqlConnection connect;

        public PersonDTO(MySqlConnection DBconnect)   
        {
            this.connect = DBconnect;
            
            try
            {
                this.connect.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        public Person FindOne(int id)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM people WHERE id= "+id, this.connect);

            Person person = new Person();

            MySqlDataReader myReader = command.ExecuteReader();

            myReader.Read();

            person.Id = myReader.GetInt32("id");
            
            person.Firstname = myReader.GetString("first_name");

            person.Lastname = myReader.GetString("last_name");

            myReader.Close();

            return person;
        }

        public List<Person> FindAll()
         {
            List<Person> people = new List<Person>();
            
            MySqlCommand command = new MySqlCommand("SELECT * FROM people", this.connect);

            MySqlDataReader myReader = command.ExecuteReader();
            
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

        public void Insert(Person person)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO people(first_name, last_name) values('"+ person.Firstname +"', '"+ person.Lastname +"');", this.connect);

            command.ExecuteNonQuery();
        }

        public void Update(Person person)
        {
            MySqlCommand command = new MySqlCommand("UPDATE people SET first_name = @fn, last_name = @ln WHERE id=@id;", this.connect);

            command.Parameters.AddWithValue("@fn", person.Firstname);

            command.Parameters.AddWithValue("@ln", person.Lastname);

            command.Parameters.AddWithValue("@id", person.Id);

            command.ExecuteNonQuery();     
        }

        public void Delete(Person person)
        {    
            MySqlCommand command = new MySqlCommand("DELETE FROM people WHERE id= @del", this.connect);

            command.Parameters.AddWithValue("@del", person.Id);

            command.ExecuteNonQuery();     
        }

        public void Delete(int id)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM people WHERE id= @del", this.connect);

            command.Parameters.AddWithValue("@del", id);

            command.ExecuteNonQuery();
        }

        public void Save(Person person)
        {
            if (person.Id == 0)
            {
                Insert(person);
            }
            else
            {
                Update(person);
            }
        }
    }
}
