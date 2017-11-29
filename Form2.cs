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
        private PersonDTO personDTO;
        private MySqlConnection connect;
        private Form1 form1;
        
        public Form2(Form1 form1)
        {
            InitializeComponent();
            string ConnectString = "Server=localhost;Database=people;Uid=root;Pwd=12345678;";
            MySqlConnection connect = new MySqlConnection(ConnectString);

            personDTO = new PersonDTO(connect);

            Person person = new Person();

            this.form1 = form1;
            

        }
        public void setId(int ertek)
        {
            textBox1.Text = ertek.ToString();
        }

        private void btn_cancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btn_save_Click_1(object sender, EventArgs e)
        {

            Person person = new Person();
            person.Id =Int32.Parse(textBox1.Text.ToString());
            person.Firstname = first_name_txt.Text;
            person.Lastname = last_name_txt.Text;
            personDTO.save(person);
            this.Close();
            form1.refresh(); //itt hibat ad!
            
        }
            
        

      
    }
}
