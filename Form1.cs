using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;


namespace interview
{
    
    public partial class Form1 : Form
    {
        public DataGridView dataGridView1 = new DataGridView();

        private MySqlConnection connect;

        private PersonDTO personDTO;

        //konstruktor
        public Form1() 
        {
            
            InitializeComponent();
            //egy szoveg tipusu valtozot hoz letre es erteket ad neki
            string ConnectString = "Server=localhost;Database=people;Uid=root;Pwd=12345678;";

            MySqlConnection connect = new MySqlConnection(ConnectString);

            personDTO = new PersonDTO(connect);
            //meghivja a fuggvenyt
            load_data();
        }
        

        //letrehozza a fuggvenyt
        void load_data()
        {
           
            List<Person> people = personDTO.findAll();

            dataGridView1.Rows.Clear();

            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "First Name";
            dataGridView1.Columns[2].Name = "Last Name";

            foreach (Person person in people)
            {
                string[] row = new string[] { person.Id.ToString(), person.Firstname, person.Lastname };

                dataGridView1.Rows.Add(row);
            }
           
            


        }
        // letrehozza a DBconnection fuggvenyt
     /*  private void DBconnection()
        {
            string ConnectString = "Server=localhost;Database=people;Uid=root;Pwd=12345678;";

            MySqlConnection DBconnect = new MySqlConnection(ConnectString);

            try
            {
                DBconnect.Open();

                btn_delete.Visible = false;

                //MessageBox.Show("You are connected");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
       */ 
       

       
       /* private void refresh()
        {
            
            dataGridView1.Rows.Clear();

            load_data();

            btn_delete.Visible = false;

            first_name_txt.Text = "";

            last_name_txt.Text = "";

            
        }
        */

       

      

     
        
       

        public void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            
            if (dataGridView1.SelectedRows != null)
            {
                btn_delete.Visible = true;

            }
            

        }

        
    }
}

