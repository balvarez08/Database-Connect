using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DatabaseConnection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Visible = false;
            label1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            

            string cmd = "select name from sys.databases";
            string servername = textBox2.Text;
            string UserID = textBox1.Text;
            string Password = textBox3.Text;
            try
            {

                SqlConnection myConnection = new SqlConnection("server=" + servername + ";User ID=" + UserID + ";Password=" + Password + "");
                myConnection.Open();
                SqlCommand sqlcmd = new SqlCommand(cmd, myConnection);
                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd, myConnection);
                if (myConnection.State.ToString() == "Open")
                {
                    comboBox1.Visible = true;
                    label1.Visible = true;
                    label1.Text = "Connected";
                    DataSet ds = new DataSet();
                    sqlDA.Fill(ds);
                    myConnection.Close();

                    ds.Tables[0].Rows.Add("Please Select Item");
                    comboBox1.DataSource = ds.Tables[0];
                    comboBox1.DisplayMember = "name";
                    comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
                }
                else
                {

                    label1.Visible = true;
                    label1.Text = "Can't Connect";
                }
            }
            catch
            {
                 label1.Visible = true;
                 label1.Text = "Can't Connect";
            }



        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }    

       
    }
}
