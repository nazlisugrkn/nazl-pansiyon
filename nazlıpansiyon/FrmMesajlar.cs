﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;



namespace nazlıpansiyon
{
    public partial class FrmMesajlar : Form
    {
        public FrmMesajlar()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=NAZLI PANSİYON;Integrated Security=True");
        private void verilergoster()
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Mesajlar", baglanti);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {

                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Mesajid"].ToString();
                ekle.SubItems.Add(oku["AdSoyad"].ToString());
                ekle.SubItems.Add(oku["Mesaj"].ToString());

                listView1.Items.Add(ekle);
            }

            baglanti.Close();
        }
            private void btnKaydet_Click(object sender, EventArgs e)
            {
            baglanti.Open();
            SqlCommand komut = new SqlCommand ("insert into Mesajlar (AdSoyad ,Mesaj) values ('" +textBox1.Text+"' , '" + richTextBox1.Text+ "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            verilergoster();

            }

        private void FrmMesajlar_Load(object sender, EventArgs e)
        {
            verilergoster();
        }
        int id = 0;

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            for (int i = 0; i < listView1.SelectedItems.Count; i++)
            {
                id = int.Parse(listView1.SelectedItems[i].SubItems[0].Text);
                textBox1.Text = listView1.SelectedItems[i].SubItems[1].Text;
                richTextBox1.Text = listView1.SelectedItems[i].SubItems[2].Text;
            }

            //id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            //textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            //richTextBox1.Text= listView1.SelectedItems[0].SubItems[2].Text;

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }

