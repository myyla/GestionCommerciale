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
    public partial class Article : Form
    {
        public Article()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection cnx = new SqlConnection("Data Source=DESKTOP-FJ4UE8I\\SQLEXPRESS01;Initial Catalog=GESTION;Integrated Security=True");
            cnx.Open();


            SqlCommand Cmd = new SqlCommand("insert into Article(Libelle,Prix_Unitaire) values (@libel,@prix)", cnx);
            Cmd.Parameters.AddWithValue("@libel", NomTab.Text);
            Cmd.Parameters.AddWithValue("@prix", textBox2.Text);
            Cmd.ExecuteNonQuery();
            cnx.Close();
            MessageBox.Show(" Article Ajoutée ");
            NomTab.Text = "";
            textBox2.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection cnx = new SqlConnection("Data Source=.;Initial Catalog=GESTION;Integrated Security=True");
            cnx.Open();
            SqlCommand Cmd = new SqlCommand("UPDATE  Article SET Libelle=@l,Prix_Unitaire=@p WHERE Libelle=@l ", cnx);
            Cmd.Parameters.AddWithValue("@l", NomTab.Text);
            Cmd.Parameters.AddWithValue("@p", textBox2.Text);
            Cmd.ExecuteNonQuery();
            cnx.Close();
            MessageBox.Show("Article updated ");
            NomTab.Text = "";
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cnx = new SqlConnection("Data Source=.;Initial Catalog=GESTION;Integrated Security=True");
            cnx.Open();

            SqlCommand Cmd = new SqlCommand("DELETE  Article  WHERE Libelle=@L ", cnx);
            Cmd.Parameters.AddWithValue("@L", NomTab.Text);
            Cmd.ExecuteNonQuery();
            cnx.Close();
            MessageBox.Show(" Product deleted ");
        }

        private void CategoriesListe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection cnx = new SqlConnection("Data Source=.;Initial Catalog=GESTION;Integrated Security=True");
            cnx.Open();
            SqlCommand Cmd = new SqlCommand(" SELECT * from Article ", cnx);
            SqlDataAdapter adapter = new SqlDataAdapter(Cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            CategoriesListe.DataSource = dt;
        }
    }
}
