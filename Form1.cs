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


namespace Greencode.DatabaseConnection.KorosiZsombor
{
    
    public partial class Form1 : Form
    {
        public DataGridView dataGridView1 = new DataGridView();

        private MySqlConnection connect;

        private PersonDTO personDTO;

        private Person person;

        public Form1() 
        {     
            InitializeComponent();

            string ConnectString = "Server=localhost;Database=people;Uid=root;Pwd=12345678;";

            MySqlConnection connect = new MySqlConnection(ConnectString);
            
            personDTO = new PersonDTO(connect);

            Init();

            LoadData();
        }

        void LoadData()
        {
            List<Person> people = personDTO.FindAll();
                    
            foreach (Person person in people)
            {
                object[] row = new object[] { person.Id.ToString(), person.FirstName, person.LastName };
                
                dataGridView1.Rows.Add(row);
            }
        }
             
        public void Init()
        {
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();

            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();

            dataGridView1.ColumnCount = 3;

            dataGridView1.Columns[0].Name = "ID";

            dataGridView1.Columns[1].Name = "First Name";

            dataGridView1.Columns[2].Name = "Last Name";

            deleteButtonColumn.HeaderText = "Delete";

            deleteButtonColumn.Name = "Delete";

            deleteButtonColumn.Text = "Delete";

            deleteButtonColumn.UseColumnTextForButtonValue = true;

            dataGridView1.Columns.Add(deleteButtonColumn);

            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellDeleteClick);

            editButtonColumn.HeaderText = "Edit";

            editButtonColumn.Name = "Edit";

            editButtonColumn.Text = "Edit";

            editButtonColumn.UseColumnTextForButtonValue = true;

            dataGridView1.Columns.Add(editButtonColumn);

            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellEditClick);
        }
        public void RefreshTable()
        {
            dataGridView1.Rows.Clear();

            LoadData();
        }
       
      
        private void dataGridView1_CellDeleteClick(object sender, DataGridViewCellEventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete person to the table?","Confirm Delete!!",MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {           
                var SenderGrid = (DataGridView)sender;

                if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index && e.RowIndex >= 0 )
                {
                    personDTO.Delete(Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()));

                    //MessageBox.Show("ID= "+dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()+" deleted!");

                    RefreshTable();
                }
            }
            else
            {
                // If 'No', do something here.
            }
        }
        
        private void dataGridView1_CellEditClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
            {
                Form2 form2 = new Form2(this);

                person = personDTO.FindOne(Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()));

                ((TextBox)form2.Controls["txtID"]).Text = person.Id.ToString();

                ((TextBox)form2.Controls["txtFirstName"]).Text = person.FirstName;

                ((TextBox)form2.Controls["txtLastName"]).Text = person.LastName;
                
                form2.Show();
            }
        }

        private void btnAddPerson_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);

            form2.SetId(0);

            form2.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

