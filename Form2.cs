using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace interview
{
    public partial class Form2 : Form
    {
        private MySqlConnection connection;
        public Form2()
        {
            InitializeComponent();

            listView1.Items.Add("ID   NAME");

            string ConnectString = "Server=localhost;Database=people;Uid=root;Pwd=12345678;";

            string Query = "select * from people";

            MySqlConnection DBconnect = new MySqlConnection(ConnectString);

            MySqlCommand cmdDataBase = new MySqlCommand(Query, DBconnect);

            MySqlDataReader myReader;
            Person person = new Person();
            try
            {
                DBconnect.Open();

                myReader = cmdDataBase.ExecuteReader();

                while (myReader.Read())
                {
                    person.Id = myReader.GetInt32("id");

                    person.Firstname = myReader.GetString("first_name");

                    person.Lastname = myReader.GetString("last_name");

                    listView1.View = View.List;

                    listView1.Items.Add(person.Id + "     " + person.Firstname + " " + person.Lastname);

                }
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
