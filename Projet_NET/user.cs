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
    public partial class user : Form
    {
        public user()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection cnx = new SqlConnection("Data Source=DESKTOP-FJ4UE8I\\SQLEXPRESS01;Initial Catalog=GESTION;Integrated Security=True");
            cnx.Open();


            SqlCommand Cmd = new SqlCommand("insert into Utilisateur (Nom_Uti,Email_Uti,Pwd_Uti) values (@n,@e,@p)", cnx);
            Cmd.Parameters.AddWithValue("@n", NomTab.Text);
            Cmd.Parameters.AddWithValue("@e", textBox2.Text);
            Cmd.Parameters.AddWithValue("@p", textBox1.Text);
            Cmd.ExecuteNonQuery();
            cnx.Close();
            MessageBox.Show("User Ajoutée ");
            NomTab.Text = "";
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection cnx = new SqlConnection("Data Source=.;Initial Catalog=GESTION;Integrated Security=True");
            cnx.Open();
            SqlCommand Cmd = new SqlCommand("UPDATE Utilisateur SET (Nom_Uti=@l,Email_Uti=@p,Pwd_Uti=@pw) WHERE Nom_Uti=@l ", cnx);
            Cmd.Parameters.AddWithValue("@l", NomTab.Text);
            Cmd.Parameters.AddWithValue("@p", textBox2.Text);
            Cmd.Parameters.AddWithValue("@pw", textBox1.Text);
            Cmd.ExecuteNonQuery();
            cnx.Close();
            MessageBox.Show(" User updated ");
            NomTab.Text = "";
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cnx = new SqlConnection("Data Source=.;Initial Catalog=GESTION;Integrated Security=True");
            cnx.Open();

            SqlCommand Cmd = new SqlCommand("DELETE Utilisateur  WHERE Nom_Uti=@L ", cnx);
            Cmd.Parameters.AddWithValue("@L", NomTab.Text);
            Cmd.ExecuteNonQuery();
            cnx.Close();
            MessageBox.Show(" User deleted ");
        }

        private void CategoriesListe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection cnx = new SqlConnection("Data Source=.;Initial Catalog=GESTION;Integrated Security=True");
            cnx.Open();
            SqlCommand Cmd = new SqlCommand(" SELECT * fromUtilisateur ", cnx);
            SqlDataAdapter adapter = new SqlDataAdapter(Cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            CategoriesListe.DataSource = dt;
        }
    }
}
