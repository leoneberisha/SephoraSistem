﻿using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Detyra1
{
    public partial class Form5 : Form
    {
        string connectionString = "server=localhost;database=sephorasistem;uid=root;pwd=;";
       private void LoadFondatine()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "Select id, emri_kategoris as 'Emri Kategorise',emri_furnitorit as 'Emri Furnitorit',emri_fondatines as 'Emri Fondatines',nuanca as 'Nuanca', stoku as 'Stoku', sasia as 'Sasia', cmimiBlerjes as 'Cmimi Blerjes', cmimiShitjes as 'Cmimi Shitjes',totali as 'Totali', aktiv as 'Aktiv' FROM fondatine";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                Form6 form6 = new Form6();
                form6.ShowDialog();
            }

        }
        public Form5()
        {
            InitializeComponent();
        }
        private Form6 form6Reference;

        public Form5(Form6 form6)
        {
            InitializeComponent();
            form6Reference = form6;
        }


       
        private void button2_Click(object sender, EventArgs e)//== RUAJ
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO fondatine(emri_kategoris,emri_furnitorit,emri_fondatines,nuanca,stoku,sasia,cmimiBlerjes,cmimiShitjes,totali,aktiv) VALUES (@emri_kategoris,@emri_furnitorit,@emri_fondatines,@nuanca,@stoku,@sasia,@cmimiBlerjes,@cmimiShitjes,@totali,@aktiv)";
                MySqlCommand cmd = new MySqlCommand( query, conn);
                cmd.Parameters.AddWithValue("@emri_kategoris", textBox1.Text);
                cmd.Parameters.AddWithValue("@emri_furnitorit", textBox2.Text);
                cmd.Parameters.AddWithValue("@emri_fondatines", textBox3.Text);
                cmd.Parameters.AddWithValue("@nuanca", textBox4.Text);
                cmd.Parameters.AddWithValue("@stoku", textBox5.Text);
                cmd.Parameters.AddWithValue("@sasia", textBox6.Text);
                cmd.Parameters.AddWithValue("@cmimiBlerjes",textBox7.Text);
                cmd.Parameters.AddWithValue("@cmimiShitjes", textBox8.Text);
                cmd.Parameters.AddWithValue("@totali", textBox9.Text);
                cmd.Parameters.AddWithValue("@aktiv", textBox10.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            form6Reference.LoadFondatine();
            this.Close();

        }

        // Mbyll formën
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool isEditMode = false;
        private int editingId;

        public Form5(Form6 form6,int id,string emri_kategoris, string emri_furnitorit, string emri_fondatines, string nuanca, string stoku, string sasia, string cmimiBlerjes, string cmimiShtijes,string totali, string aktiv, bool isEdit)
        {
            InitializeComponent();
            form6Reference = new Form6();
            isEditMode = true;
            editingId = id; 

            textBox1.Text= emri_kategoris;
            textBox2.Text= emri_furnitorit;
            textBox3.Text= emri_fondatines;
            textBox4.Text= nuanca;
            textBox5.Text= stoku;
            textBox6.Text= sasia;
            textBox7.Text= cmimiBlerjes;
            textBox8.Text= cmimiShtijes;
            textBox9.Text = totali;
            textBox10.Text= aktiv;

        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        // Pastro fushat
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd;

                if (isEditMode)
                {
                    string updateQuery = "UPDATE fondatine SET emri_kategoris=@emri_kategoris,emri_furnitorit=@emri_furnitorit, emri_fondatines=@emri_fondatines, nuanca=@nuanca, stoku=@stoku, sasia=@sasia, cmimiBlerjes=@cmimiBlerjes, cmimiShitjes=@cmimiShitjes, totali=@totali, aktiv=@aktiv WHERE id=@id ";
                    cmd = new MySqlCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@id", editingId);
                }
                else
                {
                    string insertQuery = "INSERT INTO fondatine(emri_kategoris,emri_furnitorit,emri_fondatines,nuanca,stoku,sasia,cmimiBlerjes,cmimiShitjes,totali,aktiv) VALUES (@emri_kategoris,@emri_furnitorit,@emri_fondatines,@nuanca,@stoku,@sasia,@cmimiBlerjes,@cmimiShitjes,@totali,@aktiv)";
                    cmd = new MySqlCommand(@insertQuery, conn);
                }
                cmd.Parameters.AddWithValue("@emri_kategoris", textBox1.Text);
                cmd.Parameters.AddWithValue("@emri_furnitorit", textBox2.Text);
                cmd.Parameters.AddWithValue("@emri_fondatines", textBox3.Text);
                cmd.Parameters.AddWithValue("@nuanca", textBox4.Text);
                cmd.Parameters.AddWithValue("@stoku", textBox5.Text);
                cmd.Parameters.AddWithValue("@sasia", textBox6.Text);
                cmd.Parameters.AddWithValue("@cmimiBlerjes", textBox7.Text);
                cmd.Parameters.AddWithValue("@cmimiShitjes", textBox8.Text);
                cmd.Parameters.AddWithValue("@totali", textBox9.Text);
                cmd.Parameters.AddWithValue("@aktiv", textBox10.Text);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            form6Reference.LoadFondatine();
            this.Close();

        }
    }
}
