﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Detyra1
{
    public partial class Form8 : Form
    {
        string connectionString = "server=localhost;database=sephorasistem;uid=root;pwd=;";

        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        public void loadMaskara()
        {

            string connectionString = "server=localhost;database=sephorasistem;uid=root;pwd=;";
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = "SELECT id, emriFurnitorit as 'Emri Furnitorit',emriKategorise as 'Emri Kategorise',emriMaskares as 'Emri Maskares',sasia as'Sasia',cmimiBlerjes as 'Cmimi Blerjes',cmimiShitjes as 'Cmimi Shitjes',aktiv as  'Aktiv' FROM maskara";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                }

            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.ShowDialog();
        }
    }
}
