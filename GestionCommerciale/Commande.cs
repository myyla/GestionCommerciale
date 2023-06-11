using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_NET
{
    public partial class Commande : Form
    {
        public Commande()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
           
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection cnx = new SqlConnection("Data Source=DESKTOP-FJ4UE8I\\SQLEXPRESS01;Initial Catalog=GESTION;Integrated Security=True");
            cnx.Open();


            SqlCommand Cmd = new SqlCommand("insert into Commande(Date_Cmd) values (@Date_Cmd)", cnx);
            Cmd.Parameters.AddWithValue("Date_Cmd", NomTab.Text);
           
            Cmd.ExecuteNonQuery();
            cnx.Close();
            MessageBox.Show(" Commande Ajoutée ");
            NomTab.Text = "";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cnx = new SqlConnection("Data Source=.;Initial Catalog=GESTION;Integrated Security=True");
            cnx.Open();

            SqlCommand Cmd = new SqlCommand("DELETE  Commande  WHERE Date_Cmd=@d ", cnx);
            Cmd.Parameters.AddWithValue("@d", NomTab.Text);
            Cmd.ExecuteNonQuery();
            cnx.Close();
            MessageBox.Show(" Command deleted ");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection cnx = new SqlConnection("Data Source=.;Initial Catalog=GESTION;Integrated Security=True");
            cnx.Open();
            SqlCommand Cmd = new SqlCommand("UPDATE  Commande SET Date_Cmd=@d WHERE Date_Cmd=@d ", cnx);
            Cmd.Parameters.AddWithValue("@d", NomTab.Text);

            Cmd.ExecuteNonQuery();
            cnx.Close();
            MessageBox.Show("command updated ");
            NomTab.Text = "";
        }
    }
}
