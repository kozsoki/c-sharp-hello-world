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
        private Form1 form;

        public Form2()
        {
            InitializeComponent();
            string ConnectString = "Server=localhost;Database=people;Uid=root;Pwd=12345678;";
            MySqlConnection connect = new MySqlConnection(ConnectString);

            personDTO = new PersonDTO(connect);




        }
       

        private void btn_cancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click_1(object sender, EventArgs e)
        {

            
         
            personDTO.insert(first_name_txt.Text, last_name_txt.Text);
            
            this.Close();
           // form.refresh(); itt hibat ad!

        }

      
    }
}
