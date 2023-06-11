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
    public partial class Fournisseur : Form
    {
        public Fournisseur()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection cnx = new SqlConnection("Data Source=DESKTOP-FJ4UE8I\\SQLEXPRESS01;Initial Catalog=GESTION;Integrated Security=True");
            cnx.Open();


            SqlCommand Cmd = new SqlCommand("insert into Fournisseur(Nom_Fournisseur) values (@nm)", cnx);
            Cmd.Parameters.AddWithValue("@nm", NomTab.Text);

            Cmd.ExecuteNonQuery();
            cnx.Close();
            MessageBox.Show(" Fournisseur Ajoutée ");
            NomTab.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection cnx = new SqlConnection("Data Source=.;Initial Catalog=GESTION;Integrated Security=True");
            cnx.Open();
            SqlCommand Cmd = new SqlCommand("UPDATE  Commande SET Nom_Fournisseur=@d WHERE Nom_Fournisseur=@l ", cnx);
            Cmd.Parameters.AddWithValue("@d", NomTab.Text);

            Cmd.ExecuteNonQuery();
            cnx.Close();
            MessageBox.Show(" Fournisseur updated ");
            NomTab.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cnx = new SqlConnection("Data Source=.;Initial Catalog=GESTION;Integrated Security=True");
            cnx.Open();

            SqlCommand Cmd = new SqlCommand("DELETE  Fournisseur  WHERE Fournisseur=@f ", cnx);
            Cmd.Parameters.AddWithValue("@f", NomTab.Text);
            Cmd.ExecuteNonQuery();
            cnx.Close();
            MessageBox.Show(" Command deleted ");
        }
    }
}
