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
        public Form1()
        {
            InitializeComponent();
            DBconnection();
            fill_listbox();
        }
        void fill_listbox()
        {
            string ConnectString = "Server=localhost;Database=felveteli;Uid=root;Pwd=;";
            string Query = "select * from people";
            MySqlConnection DBconnect = new MySqlConnection(ConnectString);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, DBconnect);
            MySqlDataReader myReader;
            try
            {
                DBconnect.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    string nr = myReader.GetString("nr");
                    string firstname = myReader.GetString("first_name");
                    string lastname = myReader.GetString("last_name");
                    listBox1.Items.Add(nr + " " + firstname + " " + lastname);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void DBconnection()
        {
            string ConnectString = "Server=localhost;Database=felveteli;Uid=root;Pwd=;";
            MySqlConnection DBconnect = new MySqlConnection(ConnectString);
            try
            {
                DBconnect.Open();
                btn_delete.Visible = false;
                btn_delete.Visible = false;
                //MessageBox.Show("You are connected");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DBconnection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ConnectString = "Server=localhost;Database=felveteli;Uid=root;Pwd=;";
            string Query = "insert into people(first_name,last_name) values('"+this.first_name_txt.Text+"','"+this.last_name_txt.Text+"');"; 
            MySqlConnection DBconnect = new MySqlConnection(ConnectString);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, DBconnect);
            MySqlDataReader myReader;
            try
            {
                DBconnect.Open();
                myReader = cmdDataBase.ExecuteReader();
               // MessageBox.Show("Added");
                while (myReader.Read())
                {

                }
                refresh();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void refresh()
        {
            listBox1.Items.Clear();
            fill_listbox();
            btn_delete.Visible = false;
            btn_delete.Visible = false;
            first_name_txt.Text = "";
            last_name_txt.Text = "";

        }
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                btn_delete.Visible = true;
                btn_delete.Visible = true;
            }
        }
       

        private void btn_delete_Click(object sender, EventArgs e)
        {
            
            string[] del = listBox1.SelectedItem.ToString().Split(' ');
           
            string ConnectString = "Server=localhost;Database=felveteli;Uid=root;Pwd=;";
            string Query = "delete from people where nr= "+del[0];
            MySqlConnection DBconnect = new MySqlConnection(ConnectString);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, DBconnect);
            MySqlDataReader myReader;
            try
            {
                DBconnect.Open();
                myReader = cmdDataBase.ExecuteReader();
               // MessageBox.Show("Deleted");
                while (myReader.Read())
                {

                }
                refresh();
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

