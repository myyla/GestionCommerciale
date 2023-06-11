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
    public partial class Connexion : Form
    {

        public Connexion()
        {
            InitializeComponent();
        }

        string test_obligatoire()
        {
            if (NomTab.Text == "") return "Enter votre nom";
            if (textBox1.Text == "") return "Enter votre email";
            if (textBox2.Text == "") return "Enter votre password";
            else return null; 

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (test_obligatoire() == null)
            { 
                MessageBox.Show(" wait ... Connection to data base");
                SqlConnection cnx = new SqlConnection("Data Source=DESKTOP-FJ4UE8I\\SQLEXPRESS01;Initial Catalog=GESTION;Integrated Security=True");
                cnx.Open();


                SqlCommand Cmd = new SqlCommand("insert into Utilisateur (Nom_Uti,Email_Uti,Pwd_Uti) values (@n,@e,@p)", cnx);
                SqlCommand Cmd2 = new SqlCommand("insert into Role (Nom_Role) values (@r)", cnx);
                Cmd.Parameters.AddWithValue("@n", NomTab.Text);
                Cmd.Parameters.AddWithValue("@e", textBox2.Text);
                Cmd.Parameters.AddWithValue("@p", textBox1.Text);

                Cmd2.Parameters.AddWithValue("@r", comboBox1.Text);
                Cmd.ExecuteNonQuery();
                Cmd2.ExecuteNonQuery();
                cnx.Close();
                MessageBox.Show("User Ajoutée ");
                NomTab.Text = "";
                textBox2.Text = "";
                Article articleForm = new Article();  // Crée une instance du formulaire "Article"
                articleForm.Show();  // Affiche le formulaire "Article"
                
                
            }
            else
            { MessageBox.Show(test_obligatoire(), "obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Error);  }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void NomTab_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
