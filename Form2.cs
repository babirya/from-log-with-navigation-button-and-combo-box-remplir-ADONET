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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        } 
        // calling ado class here
        ado d = new ado(); 
         // this for button of navigation 
        public int fox; 
        // methode for navigation button  
        public void navigation()
        {
            textBox1.Text = d.dt.Rows[fox][0].ToString();
            textBox2.Text = d.dt.Rows[fox][1].ToString();
            textBox3.Text = d.dt.Rows[fox][2].ToString();
            textBox4.Text = d.dt.Rows[fox][3].ToString();



        }

        // 1  remplir  datgrid view 
        public void remplir ()
        { 
            if(d.dt.Rows.Count!=null)
            {
                d.dt.Rows.Clear();
            }
            d.connecter();
            d.cmd.CommandText = "select *from country";
            d.cmd.Connection = d.con;
            d.rd = d.cmd.ExecuteReader();
            d.dt.Load(d.rd);
            dataGridView1.DataSource = d.dt;
            d.rd.Close(); 
        }  

        // remplir combobox 

        public void remplircombo()
        { 
            // this for clear for eviter repitions trouble 
            d.connecter(); 
            d.cmd.CommandText = "select id from country ";
            d.cmd.Connection = d.con;
            d.rd = d.cmd.ExecuteReader(); 
            while(d.rd.Read())
            {
                comboBox1.Items.Add(d.rd[0]);
            }

        }


        private void Form2_Load(object sender, EventArgs e)
        {
            remplir();
            remplircombo();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fox = 0;
            navigation();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fox = d.dt.Rows.Count - 1;
            navigation();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                fox++;
                navigation();
            }catch
            {
                MessageBox.Show("you are the in the last row  now");
                fox--; 
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                fox--;
                navigation();
            }
            catch
            {
                MessageBox.Show("you are at the first row now");
                fox++;
            }
        }
    }
}
