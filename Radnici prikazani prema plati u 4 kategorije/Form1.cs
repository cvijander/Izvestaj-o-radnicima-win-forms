using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Radnici_prikazani_prema_plati_u_4_kategorije
{
    public partial class Form1 : Form
    {
        private OleDbConnection konekcija = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source =C:\Users\Cvijander\source\repos\Relja napredni kurs\Radnici prikazani prema plati u 4 kategorije\Radnici prikazani prema plati u 4 kategorije\bin\Debug\baza.mdb");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                konekcija.Open();
                string tekstKomande = "select COUNT(sfRadnik) from Radnik";
                OleDbCommand komanda = new OleDbCommand(tekstKomande, konekcija);
                txtUkupanBrojRadnika.Text = komanda.ExecuteScalar().ToString();
            }
            catch (Exception x)
            {
                MessageBox.Show("Greska prilikom brojanja radnika " + x.Message);
            }
            finally
            {
                if (konekcija.State == ConnectionState.Open)
                    konekcija.Close();
            }

            try
            {
                konekcija.Open();
                string tekstKomande = "select Plata + Premija from Radnik";
                int k1 = 0, k2 = 0, k3 = 0, k4 = 0;
                OleDbCommand komanda = new OleDbCommand(tekstKomande, konekcija);
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read() == true)
                {
                    int primanje = int.Parse(citac[0].ToString());
                    if (primanje <= 50000) k1++;
                    else if (primanje <= 75000) k2++;
                    else if (primanje <= 120000) k3++;
                    else if (primanje > 120000) k4++;
                }
                textBox1.Text = k1.ToString();
                textBox2.Text = k2.ToString();
                textBox3.Text = k3.ToString();
                textBox4.Text = k4.ToString();
            }
            catch (Exception x)
            {
                MessageBox.Show("Greska prilikom " + x.Message);
            }
            finally
            {
                if (konekcija.State == ConnectionState.Open)
                    konekcija.Close();
            }
        }

        private void textBox4_DoubleClick(object sender, EventArgs e)
        {
            //radnici sa platom + premijom vecom od 120 000
            dataGridView1.Visible = true;

            try
            {
                konekcija.Open();
                string tekstKomande = "select * from Radnik where plata + premija >= 120000";
                OleDbCommand komanda = new OleDbCommand(tekstKomande, konekcija);
                DataTable tabela = new DataTable();
                OleDbDataAdapter adapter = new OleDbDataAdapter(komanda);
                adapter.Fill(tabela);
                dataGridView1.DataSource = tabela;
            }
            catch (Exception x)
            {
                MessageBox.Show("Greska prilikom prikaza " + x.Message);
            }
            finally
            {
                if (konekcija.State == ConnectionState.Open)
                    konekcija.Close();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_DoubleClick(object sender, EventArgs e)
        {
            // radnici sa platom i premijom od 75000 do 120000
            dataGridView1.Visible = true;
            try
            {
                konekcija.Open();
                string tekstKomande = "select * from Radnik where plata + premija >= 75000 and plata +premija < 120000";
                OleDbCommand komanda = new OleDbCommand(tekstKomande, konekcija);
                DataTable tabela = new DataTable();
                OleDbDataAdapter adapter = new OleDbDataAdapter(komanda);
                adapter.Fill(tabela);
                dataGridView1.DataSource = tabela;
            }
            catch (Exception x)
            {
                MessageBox.Show("Greska prilikom ispisivanja radnika sa platom izmedju 75 000 i 120 000");
            }
            finally
            {
                if (konekcija.State == ConnectionState.Open)
                    konekcija.Close();
            }
        }

        private void textBox2_DoubleClick(object sender, EventArgs e)
        {
            // radnici sa platom izmedju 50 000 i 75000
            dataGridView1.Visible = true;

            try
            {
                konekcija.Open();
                string tekstKomande = "select * from Radnik where plata + premija >= 50000 and plata + premija < 75000 ";
                OleDbCommand komanda = new OleDbCommand(tekstKomande, konekcija);
                OleDbDataAdapter adapter = new OleDbDataAdapter(komanda);
                DataTable tabela = new DataTable();
                adapter.Fill(tabela);
                dataGridView1.DataSource = tabela;
            }
            catch (Exception x)
            {
                MessageBox.Show("Greska prilikom ispisivanja radnika sa platom i premijom izmedju 50000 i 75000");
            }
            finally
            {
                if (konekcija.State == ConnectionState.Open)
                    konekcija.Close();
            }
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            // radnici sa platom i premijom ispod 50000
            dataGridView1.Visible = true;

            try
            {
                konekcija.Open();
                string tekstKomande = "select * from Radnik where plata + premija <50000 ";
                OleDbCommand komanda = new OleDbCommand(tekstKomande, konekcija);
                OleDbDataAdapter adapter = new OleDbDataAdapter(komanda);
                DataTable tabela = new DataTable();
                adapter.Fill(tabela);
                dataGridView1.DataSource = tabela;
            }
            catch (Exception x)
            {
                MessageBox.Show("Greska prilikom ispisivanja radnika sa platom + premijom manjom od 50000");
            }
            finally
            {
                if (konekcija.State == ConnectionState.Open)
                    konekcija.Close();
            }
        }

        private void txtUkupanBrojRadnika_DoubleClick(object sender, EventArgs e)
        {
            //svi podaci o radnicima
            dataGridView1.Visible = true;

            try
            {
                konekcija.Open();
                string tekstKomande = "select * from Radnik";
                OleDbCommand komanda = new OleDbCommand(tekstKomande, konekcija);
                OleDbDataAdapter adapter = new OleDbDataAdapter(komanda);
                DataTable tabela = new DataTable();
                adapter.Fill(tabela);
                dataGridView1.DataSource = tabela;
            }
            catch (Exception x)
            {
                MessageBox.Show("Greska prilikom ispisivanja svih radnika " + x.Message);
            }
            finally
            {
                if (konekcija.State == ConnectionState.Open)
                    konekcija.Close();
            }
        }
    }
}