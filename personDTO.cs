using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

//nevter
namespace interview 
{
    //osztaly
    public class PersonDTO : Form1
    {

        //private method
        public MySqlConnection connect;

        //konstruktor parameterrel
        public PersonDTO(MySqlConnection DBconnect)   
        {

            this.connect = DBconnect;
            
            try
            {
                this.connect.Open();

               // btn_delete.Visible = false;

                //MessageBox.Show("You are connected");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
       

        //public method aminek id a parametere 
        public Person findOne(int id)
        {
            //command peldany letrehozasa parameterekkel
            MySqlCommand command = new MySqlCommand("SELECT * FROM people WHERE id= "+id, this.connect);

            //peldany
            Person person = new Person();

            //a myreader mint valtozo megkapja azt az erteket amit a commandbol kiolvasott
            MySqlDataReader myReader = command.ExecuteReader();

            //hivjuk a Read parancsot
            myReader.Read();

            //a person.Id megkapja azt az erteket amit a myreaderben talal id neven
            person.Id = myReader.GetInt32("id");
            
            //a person.Id megkapja azt az erteket amit a myreaderben talal first_name neven
            person.Firstname = myReader.GetString("first_name");

            //a person.Id megkapja azt az erteket amit a myreaderben talal last_name neven
            person.Lastname = myReader.GetString("last_name");

            //bezarja a myreader valtozot
            myReader.Close();

            //visszateriti a person erteket
            return person;

            //dataGridView1.DataSource = person;  
        }

        //findAll fuggveny aminek nincs parametere lista tipusu
        public List<Person> findAll()
         {
            //people peldany valtozo
            List<Person> people = new List<Person>();
            
            //command peldany letrehozasa parameterekkel
            MySqlCommand command = new MySqlCommand("SELECT * FROM people", this.connect);

            //a myreader mint valtozo megkapja azt az erteket amit a commandbol kiolvasott
            MySqlDataReader myReader = command.ExecuteReader();
            
            //feltolti a person peldanyt azokkal az adatokkal amiket kiolvasott a myreader
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
            //dataGridView1.DataSource = people;


        }
        //insert method person parameterrel
        public int insert(Person person)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO people(first_name, last_name) values('"+ person.Firstname +"', '"+ person.Lastname +"');", this.connect);

            //ez egy method ami vissza teriti a sorok szamat
            command.ExecuteNonQuery();

            MySqlCommand command2 = new MySqlCommand("SELECT LAST_INSERT_ID() AS id");

            //a myreader mint valtozo megkapja azt az erteket amit a commandbol kiolvasott
            MySqlDataReader myReader = command.ExecuteReader();

            //hivjuk a Read parancsot
            myReader.Read();

            //az id egesz szam megkapja azt az erteket amit a myreaderben talal vagyis az utolso id erteket
            int id = myReader.GetInt32("id");

            person.Id = id;

            myReader.Close();

            return id;
        }
        //letrehozza az update fuggvenyt a person parameterrel aminek nincs visszateritesi erteke
        public void update(Person person)
        {
            MySqlCommand command = new MySqlCommand("UPDATE people SET (first_name = @fn, last_name = @ln) WHERE id=@id;", this.connect);

            command.Parameters.AddWithValue("@fn", person.Firstname);

            command.Parameters.AddWithValue("@ln", person.Lastname);

            command.Parameters.AddWithValue("@id", person.Id);

            command.ExecuteNonQuery();     
         }
        //letrehozza a delete fuggvenyt a person parameterrel aminek nincs visszateritesi erteke
        public void delete(Person person)
        {    
            MySqlCommand command = new MySqlCommand("DELETE FROM people WHERE id= @del", this.connect);

            command.Parameters.AddWithValue("@del", person.Id);

            command.ExecuteNonQuery();     
        }
    }
}
