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
            

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Delete";
            buttonColumn.Name = "Delete";
            buttonColumn.Text = "Delete";
            buttonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(buttonColumn);

            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellDeleteClick);

            foreach (Person person in people)
            {
                
               
                object[] row = new object[] { person.Id.ToString(), person.Firstname, person.Lastname };
                
                dataGridView1.Rows.Add(row);
                
                
            }
            
           
        }
               
        public void refresh()
        {
            
            dataGridView1.Rows.Clear();

            load_data();
            
        }
        
       
      
        public void dataGridView1_CellDeleteClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                if (e.RowIndex !=0 )
                {
                   
                    personDTO.delete(Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()));
                    MessageBox.Show("A "+dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()+"-as/es idval rendelkezo torolve lett");
                    refresh();
                    

                }
                else
                {
                    MessageBox.Show("nem mukodik");
                }
            }
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            
           
            

        }
      

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(); //itt hibat ad ha az utolsot vagy az utolso elottit torli

        }

        private void btn_addpperson_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            load_data();
        }
    }
}

