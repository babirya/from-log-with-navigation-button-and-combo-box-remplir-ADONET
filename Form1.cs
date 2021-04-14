using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace country2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ado d = new ado(); 
       

        private void button1_Click(object sender, EventArgs e)
        {
            // this is for login
            
            bool res = false;
        
            d.cmd.CommandText = "select id, name from country";
            d.cmd.Connection = d.con;
            d.rd = d.cmd.ExecuteReader(); 
            while(d.rd.Read())
            {
                 if(textBox1.Text.Equals(d.rd[1].ToString()) && textBox2.Text.Equals(d.rd[0].ToString())) 
                 {

                     res = true;
                     break;
                 }
                 
            }
            if (res == true)
            {
                this.Hide();
                Form2 f2 = new Form2();
                f2.Show();
            }
            else
            {
                MessageBox.Show("password or country name is wrong ");
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            d.connecter(); 
        }
    }
}
