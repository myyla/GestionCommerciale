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
    public partial class Categorie : Form
    {
        //Class1 Con;
       
        public Categorie()
        {
            InitializeComponent();
            
        }

        private void liste_categories()
        {
           
        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_g_ut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {

             
            try
            {
                if (NomTab.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("completer le formulaire");
                }
                else
                {
                    SqlConnection cnx = new SqlConnection("Data Source=DESKTOP-FJ4UE8I\\SQLEXPRESS01;Initial Catalog=GESTION;Integrated Security=True");
                    cnx.Open();


                    SqlCommand Cmd = new SqlCommand("insert into TableCateg(CatNom,CatRem) values (@CatNom,@CatRem)",cnx);
                    Cmd.Parameters.AddWithValue("@CatNom", NomTab.Text);
                    Cmd.Parameters.AddWithValue("@CatRem", textBox2.Text);
                    Cmd.ExecuteNonQuery();
                    cnx.Close();
                    MessageBox.Show("Categorie Ajoutée ");
                    NomTab.Text = "";
                    textBox2.Text = "";

                
                }
            }
            catch(Exception  ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int Key = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection cnx = new SqlConnection("Data Source=.;Initial Catalog=GESTION;Integrated Security=True");
            cnx.Open();
            SqlCommand Cmd = new SqlCommand(" SELECT * from TableCateg ", cnx);
            SqlDataAdapter adapter = new SqlDataAdapter(Cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            CategoriesListe.DataSource = dt;
        }
        private void Categorie_Load(object sender, EventArgs e)
        {
            SqlConnection cnx = new SqlConnection("Data Source=.;Initial Catalog=GESTION;Integrated Security=True");
            cnx.Open();
            SqlCommand Cmd = new SqlCommand(" SELECT * from TableCateg ", cnx);
            SqlDataAdapter adapter = new SqlDataAdapter(Cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            CategoriesListe.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection cnx = new SqlConnection("Data Source=.;Initial Catalog=GESTION;Integrated Security=True");
            cnx.Open();
            SqlCommand Cmd = new SqlCommand("UPDATE  TableCateg SET CatNom=@CatNom,CatRem=@CatRem WHERE CatNom=@CatNom ", cnx);
            Cmd.Parameters.AddWithValue("@CatNom", NomTab.Text);
            Cmd.Parameters.AddWithValue("@CatRem", textBox2.Text);
            Cmd.ExecuteNonQuery();
            cnx.Close();
            MessageBox.Show("Categorie updated ");
            NomTab.Text = "";
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cnx = new SqlConnection("Data Source=.;Initial Catalog=GESTION;Integrated Security=True");
            cnx.Open();

            SqlCommand Cmd = new SqlCommand("DELETE  TableCateg  WHERE CatCde=@CatNom ", cnx);
            Cmd.Parameters.AddWithValue("@CatNom", NomTab.Text);
            Cmd.ExecuteNonQuery();
            cnx.Close();
            MessageBox.Show("Categorie deleted ");
        }
    }
}
